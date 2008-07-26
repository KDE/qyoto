#include <QtCore>
#include <QtGui>

#include <smoke/smoke.h>
#include <smoke/qt_smoke.h>

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
}

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
smokeStackToQtStack(Smoke::Stack stack, void ** o, int start, int end, QList<MocArgument*> args)
{
	for (int i = start, j = 0; i < end; i++, j++) {
		Smoke::StackItem *si = stack + j;
		switch(args[i]->argType) {
		case xmoc_bool:
			o[j] = &si->s_bool;
			break;
		case xmoc_int:
			o[j] = &si->s_int;
			break;
		case xmoc_uint:
			o[j] = &si->s_uint;
			break;
		case xmoc_long:
			o[j] = &si->s_long;
			break;
		case xmoc_ulong:
			o[j] = &si->s_ulong;
			break;
		case xmoc_double:
			o[j] = &si->s_double;
			break;
		case xmoc_charstar:
			o[j] = &si->s_voidp;
			break;
		case xmoc_QString:
			o[j] = si->s_voidp;
			break;
		default:
		{
			const SmokeType &t = args[i]->st;
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
					qWarning("Unknown enumeration %s\n", t.name());
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
			o[j] = p;
		}
		}
	}
}

void
smokeStackFromQtStack(Smoke::Stack stack, void ** _o, int start, int end, QList<MocArgument*> args)
{
	for (int i = start, j = 0; i < end; i++, j++) {
		void *o = _o[j];
		switch(args[i]->argType) {
		case xmoc_bool:
			stack[j].s_bool = *(bool*)o;
			break;
		case xmoc_int:
			stack[j].s_int = *(int*)o;
			break;
		case xmoc_uint:
			stack[j].s_uint = *(uint*)o;
			break;
		case xmoc_long:
			stack[j].s_long = *(long*)o;
			break;
		case xmoc_ulong:
			stack[j].s_ulong = *(ulong*)o;
			break;
		case xmoc_double:
			stack[j].s_double = *(double*)o;
			break;
		case xmoc_charstar:
			stack[j].s_voidp = o;
			break;
		case xmoc_QString:
			stack[j].s_voidp = o;
			break;
		default:	// case xmoc_ptr:
		{
			const SmokeType &t = args[i]->st;
			void *p = o;
			switch(t.elem()) {
			case Smoke::t_bool:
			stack[j].s_bool = **(bool**)o;
			break;
			case Smoke::t_char:
			stack[j].s_char = **(char**)o;
			break;
			case Smoke::t_uchar:
			stack[j].s_uchar = **(unsigned char**)o;
			break;
			case Smoke::t_short:
			stack[j].s_short = **(short**)p;
			break;
			case Smoke::t_ushort:
			stack[j].s_ushort = **(unsigned short**)p;
			break;
			case Smoke::t_int:
			stack[j].s_int = **(int**)p;
			break;
			case Smoke::t_uint:
			stack[j].s_uint = **(unsigned int**)p;
			break;
			case Smoke::t_long:
			stack[j].s_long = **(long**)p;
			break;
			case Smoke::t_ulong:
			stack[j].s_ulong = **(unsigned long**)p;
			break;
			case Smoke::t_float:
			stack[j].s_float = **(float**)p;
			break;
			case Smoke::t_double:
			stack[j].s_double = **(double**)p;
			break;
			case Smoke::t_enum:
			{
				Smoke::EnumFn fn = SmokeClass(t).enumFn();
				if (!fn) {
					qWarning("Unknown enumeration %s\n", t.name());
					stack[j].s_enum = **(int**)p;
					break;
				}
				Smoke::Index id = t.typeId();
				(*fn)(Smoke::EnumToLong, id, p, stack[j].s_enum);
			}
			break;
			case Smoke::t_class:
			case Smoke::t_voidp:
				if (strchr(t.name(), '*') != 0) {
					stack[j].s_voidp = *(void **)p;
				} else {
					stack[j].s_voidp = p;
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
qyoto_resolve_classname(smokeqyoto_object * o)
{
	if (o->smoke->classes[o->classId].external) {
		Smoke::ModuleIndex mi = o->smoke->findClass(o->smoke->className(o->classId));
        o->smoke = mi.smoke;
		o->classId = mi.index;
		return qyoto_modules.value(mi.smoke).resolve_classname(o);
	}
	return qyoto_modules.value(o->smoke).resolve_classname(o);
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
	new DelegateInvocation(qobject, signal, delegate, o);
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

QList<MocArgument*>
GetMocArguments(Smoke* smoke, const char * typeName, QList<QByteArray> methodTypes)
{
static QRegExp * rx = 0;
	if (rx == 0) {
		rx = new QRegExp("^(bool|int|uint|long|ulong|double|char\\*|QString)&?$");
	}

	methodTypes.prepend(QByteArray(typeName));
	QList<MocArgument*> result;

	foreach (QByteArray name, methodTypes) {
		MocArgument *arg = new MocArgument;
		Smoke::Index typeId = 0;
		if (name.isEmpty() || name == "void") {
			arg->argType = xmoc_void;
			result.append(arg);
		} else {
			name.replace("const ", "");
			QString staticType = (rx->indexIn(name) != -1 ? rx->cap(1) : "ptr");
			if (staticType == "ptr") {
				arg->argType = xmoc_ptr;
				QByteArray targetType = name;
				typeId = smoke->idType(targetType.constData());
				if (typeId == 0 && !name.contains('*')) {
					if (!name.contains("&")) {
						targetType += "&";
					}
					typeId = smoke->idType(targetType.constData());
				}

				// This shouldn't be necessary because the type of the slot arg should always be in the 
				// smoke module of the slot being invoked. However, that isn't true for a dataUpdated()
				// slot in a PlasmaScripting.Applet
				if (typeId == 0) {
					QHash<Smoke*, QyotoModule>::const_iterator it;
					for (it = qyoto_modules.constBegin(); it != qyoto_modules.constEnd(); ++it) {
						smoke = it.key();
						targetType = name;
						typeId = smoke->idType(targetType.constData());
						if (typeId != 0) {
							break;
						}
	
						if (typeId == 0 && !name.contains('*')) {
							if (!name.contains("&")) {
								targetType += "&";
							}

							typeId = smoke->idType(targetType.constData());
	
							if (typeId != 0) {
								break;
							}
						}
					}
				}
			} else if (staticType == "bool") {
				arg->argType = xmoc_bool;
				typeId = smoke->idType(name.constData());
			} else if (staticType == "int") {
				arg->argType = xmoc_int;
				typeId = smoke->idType(name.constData());
			} else if (staticType == "uint") {
				arg->argType = xmoc_uint;
				typeId = smoke->idType(name.constData());
			} else if (staticType == "long") {
				arg->argType = xmoc_long;
				typeId = smoke->idType(name.constData());
			} else if (staticType == "ulong") {
				arg->argType = xmoc_ulong;
				typeId = smoke->idType(name.constData());
			} else if (staticType == "double") {
				arg->argType = xmoc_double;
				typeId = smoke->idType(name.constData());
			} else if (staticType == "char*") {
				arg->argType = xmoc_charstar;
				typeId = smoke->idType(name.constData());
			} else if (staticType == "QString") {
				arg->argType = xmoc_QString;
				name += "*";
				typeId = smoke->idType(name.constData());
			}

			if (typeId == 0) {
				qFatal("Cannot handle '%s' as slot argument", name.constData());
				return result;
			}

			arg->st.set(smoke, typeId);
			result.append(arg);
		}
	}

	return result;
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

		QList<MocArgument*> mocArgs = GetMocArguments(o->smoke, method.typeName(), method.parameterTypes());
		
		// invoke slot
		Qyoto::InvokeSlot slot(obj, method.signature(), mocArgs, (void**)_o);
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
