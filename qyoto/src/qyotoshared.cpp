#include <QtCore>
#include <QtGui>

#include <smoke.h>
#include <qt/qt_smoke.h>

#include "smokeqyoto.h"
#include "qyoto.h"
#include "invokeslot.h"
#include "delegateinvocation.h"

#ifdef DEBUG
int do_debug = qtdb_gc;
#else
int do_debug = qtdb_none;
#endif

// modules
QHash<Smoke*, QyotoModule> qyoto_modules;

extern "C" {
bool application_terminated = false;
};

FromIntPtr FreeGCHandle;
CreateInstanceFn CreateInstance;
GetInstanceFn GetInstance;
GetIntPtr GetSmokeObject;

SetIntPtr SetSmokeObject;

SetIntPtr AddGlobalRef;
SetIntPtr RemoveGlobalRef;

MapPointerFn MapPointer;
FromIntPtr UnmapPointer;

OverridenMethodFn OverridenMethod;
InvokeMethodFn InvokeMethod;
InvokeCustomSlotFn InvokeCustomSlot;

OverridenMethodFn GetProperty;
SetPropertyFn SetProperty;

SetIntPtr InvokeDelegate;

void
smokeStackToQtStack(Smoke::Stack stack, void ** o, int items, MocArgument* args)
{
	for (int i = 0; i < items; i++) {
		Smoke::StackItem *si = stack + i;
		//printf("si->s_int: %d, i: %d\n", si->s_int, i);
		switch(args[i].argType) {
		case xmoc_bool:
			o[i] = &si->s_bool;
			break;
		case xmoc_int:
			o[i] = &si->s_int;
			break;
		case xmoc_double:
			o[i] = &si->s_double;
			break;
		case xmoc_charstar:
			o[i] = &si->s_voidp;
			break;
		case xmoc_QString:
			o[i] = si->s_voidp;
			break;
		default:
		{
			const SmokeType &t = args[i].st;
			void *p;
			switch(t.elem()) {
			case Smoke::t_bool:
				p = &si->s_bool;
				break;
			case Smoke::t_char:
				p = &si->s_char;
				break;
			case Smoke::t_uchar:
				p = &si->s_uchar;
				break;
			case Smoke::t_short:
				p = &si->s_short;
				break;
			case Smoke::t_ushort:
				p = &si->s_ushort;
				break;
			case Smoke::t_int:
				p = &si->s_int;
				break;
			case Smoke::t_uint:
				p = &si->s_uint;
				break;
			case Smoke::t_long:
				p = &si->s_long;
				break;
			case Smoke::t_ulong:
				p = &si->s_ulong;
				break;
			case Smoke::t_float:
				p = &si->s_float;
				break;
			case Smoke::t_double:
				p = &si->s_double;
				break;
			case Smoke::t_enum:
			{
				// allocate a new enum value
				Smoke::EnumFn fn = SmokeClass(t).enumFn();
				if (!fn) {
					printf("Unknown enumeration %s\n", t.name());
					p = new int((int)si->s_enum);
					break;
				}
				Smoke::Index id = t.typeId();
				(*fn)(Smoke::EnumNew, id, p, si->s_enum);
				(*fn)(Smoke::EnumFromLong, id, p, si->s_enum);
				// FIXME: MEMORY LEAK
				break;
			}
			case Smoke::t_class:
			case Smoke::t_voidp:
				if (strchr(t.name(), '*') != 0) {
					p = &si->s_voidp;
				} else {
					p = si->s_voidp;
				}
				break;
			default:
				p = 0;
				break;
			}
			o[i] = p;
		}
		}
	}
}

void
smokeStackFromQtStack(Smoke::Stack stack, void ** _o, int items, MocArgument* args)
{
	for (int i = 0; i < items; i++) {
		void *o = _o[i];
		switch(args[i].argType) {
		case xmoc_bool:
		stack[i].s_bool = *(bool*)o;
		break;
		case xmoc_int:
		stack[i].s_int = *(int*)o;
		break;
		case xmoc_double:
		stack[i].s_double = *(double*)o;
		break;
		case xmoc_charstar:
		stack[i].s_voidp = o;
		break;
		case xmoc_QString:
		stack[i].s_voidp = o;
		break;
		default:	// case xmoc_ptr:
		{
			const SmokeType &t = args[i].st;
			void *p = o;
			switch(t.elem()) {
			case Smoke::t_bool:
			stack[i].s_bool = **(bool**)o;
			break;
			case Smoke::t_char:
			stack[i].s_char = **(char**)o;
			break;
			case Smoke::t_uchar:
			stack[i].s_uchar = **(unsigned char**)o;
			break;
			case Smoke::t_short:
			stack[i].s_short = **(short**)p;
			break;
			case Smoke::t_ushort:
			stack[i].s_ushort = **(unsigned short**)p;
			break;
			case Smoke::t_int:
			stack[i].s_int = **(int**)p;
			break;
			case Smoke::t_uint:
			stack[i].s_uint = **(unsigned int**)p;
			break;
			case Smoke::t_long:
			stack[i].s_long = **(long**)p;
			break;
			case Smoke::t_ulong:
			stack[i].s_ulong = **(unsigned long**)p;
			break;
			case Smoke::t_float:
			stack[i].s_float = **(float**)p;
			break;
			case Smoke::t_double:
			stack[i].s_double = **(double**)p;
			break;
			case Smoke::t_enum:
			{
				Smoke::EnumFn fn = SmokeClass(t).enumFn();
				if (!fn) {
					printf("Unknown enumeration %s\n", t.name());
					stack[i].s_enum = **(int**)p;
					break;
				}
				Smoke::Index id = t.typeId();
				(*fn)(Smoke::EnumToLong, id, p, stack[i].s_enum);
			}
			break;
			case Smoke::t_class:
			case Smoke::t_voidp:
				if (strchr(t.name(), '*') != 0) {
					stack[i].s_voidp = *(void **)p;
				} else {
					stack[i].s_voidp = p;
				}
			break;
			}
		}
		}
	}
}

smokeqyoto_object * 
alloc_smokeqyoto_object(bool allocated, Smoke * smoke, int classId, void * ptr)
{
	smokeqyoto_object  * o = (smokeqyoto_object *) malloc(sizeof(smokeqyoto_object));
	o->classId = classId;
	o->smoke = smoke;
	o->ptr = ptr;
	o->allocated = allocated;
	return o;
}

void
free_smokeqyoto_object(smokeqyoto_object * o)
{
	free(o);
	return;
}

// Store pointer in a Hashtable : "pointer_to_Qt_object" => weak ref to associated C# object
// Recurse to store it also as casted to its parent classes.

void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr) {
    void *ptr = o->smoke->cast(o->ptr, o->classId, classId);
	
    if (ptr != lastptr) {
		lastptr = ptr;
		if (do_debug & qtdb_gc) {
			const char *className = o->smoke->classes[o->classId].className;
			printf(	"mapPointer (%s*)%p -> %p global ref: %s\n", 
						className, 
						ptr, 
						(void*)obj,
						IsContainedInstance(o) ? "true" : "false" );
			fflush(stdout);
		}
		(*MapPointer)(ptr, obj, IsContainedInstance(o));
    }
	
	for (Smoke::Index *i = o->smoke->inheritanceList + o->smoke->classes[classId].parents; *i; i++) {
		mapPointer(obj, o, *i, lastptr);
    }
	
	return;
}

void unmapPointer(smokeqyoto_object *o, Smoke::Index classId, void *lastptr) {
	void *ptr = o->smoke->cast(o->ptr, o->classId, classId);

	if (ptr != lastptr) {
		lastptr = ptr;
		(*UnmapPointer)(ptr);
	}

	for (Smoke::Index *i = o->smoke->inheritanceList + o->smoke->classes[classId].parents; *i; i++) {
		unmapPointer(o, *i, lastptr);
    }
}

const char *
resolve_classname(Smoke* smoke, int classId, void * ptr)
{
	if (smoke->classes[classId].external) {
		Smoke::ModuleIndex mi = smoke->findClass(smoke->className(classId));
		return qyoto_modules.value(mi.smoke).resolve_classname(mi.smoke, mi.index, ptr);
	}
	return qyoto_modules.value(smoke).resolve_classname(smoke, classId, ptr);
}

bool
IsContainedInstance(smokeqyoto_object *o)
{
	QHash<Smoke*, QyotoModule>::const_iterator i;
	for (i = qyoto_modules.constBegin(); i != qyoto_modules.constEnd(); ++i) {
		if (i.value().IsContainedInstance(o))
			return true;
	}
	return false;
}

extern "C"
{

Q_DECL_EXPORT void
InstallInvokeDelegate(SetIntPtr callback)
{
	InvokeDelegate = callback;
}

Q_DECL_EXPORT bool
ConnectDelegate(void* obj, const char* signal, void* delegate)
{
	smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
	QObject *qobject = (QObject*) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject").index);
	new DelegateInvocation(qobject, signal, delegate);
	(*FreeGCHandle)(obj);
	return true;
}

Q_DECL_EXPORT QMetaObject* parent_meta_object(void* obj) {
	smokeqyoto_object* o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
	Smoke::ModuleIndex nameId = o->smoke->findMethodName(o->smoke->className(o->classId), "metaObject");
	Smoke::ModuleIndex classId = { o->smoke, o->classId };
	Smoke::ModuleIndex meth = o->smoke->findMethod(classId, nameId);
	if (meth.index <= 0) {
		// Should never happen..
	}

	Smoke::Method &methodId = meth.smoke->methods[meth.smoke->methodMaps[meth.index].method];
	Smoke::ClassFn fn = meth.smoke->classes[methodId.classId].classFn;
	Smoke::StackItem i[1];
	(*fn)(methodId.method, o->ptr, i);
	return (QMetaObject*) i[0].s_voidp;
}

static bool
setMocType(MocArgument *arg, int idx, const char * name_value, const char * static_type)
{
	QByteArray name(name_value);
	Smoke::Index typeId = 0;

	if (strcmp(static_type, "ptr") == 0) {
		arg[idx].argType = xmoc_ptr;
		typeId = qt_Smoke->idType((const char *) name);
		if (typeId == 0 && !name.contains('*')) {
			name += "&";
			typeId = qt_Smoke->idType((const char *) name);
		}
	} else if (strcmp(static_type, "bool") == 0) {
		arg[idx].argType = xmoc_bool;
		typeId = qt_Smoke->idType((const char *) name);
	} else if (strcmp(static_type, "int") == 0) {
		arg[idx].argType = xmoc_int;
		typeId = qt_Smoke->idType((const char *) name);
	} else if (strcmp(static_type, "double") == 0) {
		arg[idx].argType = xmoc_double;
		typeId = qt_Smoke->idType((const char *) name);
	} else if (strcmp(static_type, "char*") == 0) {
		arg[idx].argType = xmoc_charstar;
		typeId = qt_Smoke->idType((const char *) name);
	} else if (strcmp(static_type, "QString") == 0) {
		arg[idx].argType = xmoc_QString;
		name += "*";
		typeId = qt_Smoke->idType((const char *) name);
	}
	
	if (typeId == 0) {
#ifdef DEBUG
		printf("In setMocType(): no typeId %s\n", name_value);
#endif
		return false;
	}

	arg[idx].st.set(qt_Smoke, typeId);
	return true;
}

Q_DECL_EXPORT MocArgument *
GetMocArgumentsNumber(QString replyType, QString member, int& number) 
{
	QRegExp rx1("^.*\\((.*)\\)$");
	QRegExp rx2("^(bool|int|double|char\\*|QString)&?$");
	int match = rx1.indexIn(member);
	if (match == -1) {
		return 0;
	}

	if (replyType.isEmpty()) {
		replyType = "void";
	}
	QStringList args(replyType);

	QString argStr = rx1.cap(1);

    if (!argStr.isEmpty()) {
		args << argStr.split(",");
	}

	number = args.size() - 1;

	MocArgument * mocargs = new MocArgument[args.size()];
	int i = 0;
	for (	QStringList::Iterator it = args.begin(); 
			it != args.end(); 
			++it, i++ ) 
	{
		QString a = (*it);

		if (a == "void" || a == "" || a == " ") {
			mocargs[i].argType = xmoc_void;
		} else {
			a.replace(QRegExp("^const\\s+"), "");
			a = (rx2.indexIn(a) == -1) ? "ptr" : rx2.cap(1);

			QByteArray name = (*it).toLatin1();
			QByteArray static_type = a.toLatin1();
			if (!setMocType(mocargs, i, name.constData(), static_type.constData())) {
				return 0;
			}
		}
    }

	return mocargs;
}

Q_DECL_EXPORT MocArgument *
GetMocArguments(QString type, QString member) {
	int tmp;
	return GetMocArgumentsNumber(type, member, tmp);
}

int qt_metacall(void* obj, int _c, int _id, void* _o) {
	smokeqyoto_object* o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
	
	Smoke::ModuleIndex nameId = o->smoke->findMethodName(o->smoke->className(o->classId), "qt_metacall$$?");
	Smoke::ModuleIndex classId = { o->smoke, o->classId };
	Smoke::ModuleIndex meth = nameId.smoke->findMethod(classId, nameId);
	if(meth.index > 0) {
		Smoke::Method &m = meth.smoke->methods[meth.smoke->methodMaps[meth.index].method];
		Smoke::ClassFn fn = meth.smoke->classes[m.classId].classFn;
		Smoke::StackItem i[4];
		i[1].s_enum = _c;
		i[2].s_int = _id;
		i[3].s_voidp = _o;
		(*fn)(m.method, o->ptr, i);
		
		int ret = i[0].s_int;
		if (ret < 0)
			return ret;
	} else {
		// Should never happen..
		qFatal("Cannot find %s::qt_metacall() method\n", 
			o->smoke->classes[o->classId].className );
	}

	QObject *qobj = (QObject*)o->ptr;
	// get obj metaobject with a virtual call
	const QMetaObject *metaobject = qobj->metaObject();
	
	// get method/property count
	int count = 0;
	if (_c == QMetaObject::InvokeMetaMethod) {
		count = metaobject->methodCount();
	} else {
		count = metaobject->propertyCount();
	}
	
	if (_c == QMetaObject::InvokeMetaMethod) {
		// retrieve method signature from id
		QMetaMethod method = metaobject->method(_id);
		QString name(method.signature());
		QString type(method.typeName());
		
		if (method.methodType() == QMetaMethod::Signal) {
			metaobject->activate(qobj, _id, (void**) _o);
			return _id - count;
		}
	
		int items;
		MocArgument* mocArgs = GetMocArgumentsNumber(type, name, items);
		
		// invoke slot
		InvokeSlot slot(obj, method.signature(), items, mocArgs, (void**)_o);
		slot.next();
	} else if (_c == QMetaObject::ReadProperty) {
		QMetaProperty property = metaobject->property(_id);
		void* variant = (*GetProperty)(obj, property.name());
		smokeqyoto_object* sqo = (smokeqyoto_object*) (*GetSmokeObject)(variant);
		((void**)_o)[0] = sqo->ptr;
	} else if (_c == QMetaObject::WriteProperty) {
		QMetaProperty property = metaobject->property(_id);
		smokeqyoto_object* sqo = alloc_smokeqyoto_object(false, qt_Smoke,
		                                                 qt_Smoke->idClass("QVariant").index,
		                                                 ((void**)_o)[0]);
		void* variant = (*CreateInstance)("Qyoto.QVariant", sqo);
		(*SetProperty)(obj, property.name(), variant);
	}
	return _id - count;
}

}
