#include <qstring.h>
#include <qregexp.h>
#include <qapplication.h>
#include <qcanvas.h>
#include <qlistview.h>
#include <qtable.h>
#include <qlayout.h>
#include <qmetaobject.h>

#include "smoke.h"

#undef DEBUG
#ifndef _GNU_SOURCE
#define _GNU_SOURCE
#endif
#ifndef __USE_POSIX
#define __USE_POSIX
#endif
#ifndef __USE_XOPEN
#define __USE_XOPEN
#endif

#include "marshall.h"
#include "qyoto.h"
#include "smokeqyoto.h"


extern "C" {
static GetIntPtr IntPtrToCharStarStar;
static GetCharStarFromIntPtr IntPtrToCharStar;
static GetIntPtrFromCharStar IntPtrFromCharStar;
static GetIntPtr IntPtrToQString;
static GetIntPtr IntPtrFromQString;

void AddIntPtrToCharStarStar(GetIntPtr callback)
{
	IntPtrToCharStarStar = callback;
}

void AddIntPtrToCharStar(GetCharStarFromIntPtr callback)
{
	IntPtrToCharStar = callback;
}

void AddIntPtrFromCharStar(GetIntPtrFromCharStar callback)
{
	IntPtrFromCharStar = callback;
}

void AddIntPtrToQString(GetIntPtr callback)
{
	IntPtrToQString = callback;
}

void AddIntPtrFromQString(GetIntPtr callback)
{
	IntPtrFromQString = callback;
}

extern void * set_obj_info(const char * className, smokeqyoto_object * o);
//extern void * IntPtrToCharStarStar(void * item);
};

extern bool isDerivedFromByName(Smoke *smoke, const char *className, const char *baseClassName);
extern void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr);

/*
 * Given an approximate classname and a qt instance, try to improve the resolution of the name
 * by using the various Qt rtti mechanisms for QObjects, QEvents and QCanvasItems
 */
static const char *
resolve_classname(Smoke* smoke, int classId, void * ptr)
{
	if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QEvent")) {
		QEvent * qevent = (QEvent *) smoke->cast(ptr, classId, smoke->idClass("QEvent"));
		switch (qevent->type()) {
		case QEvent::ChildInserted:
		case QEvent::ChildRemoved:
			return "Qt::ChildEvent";
		case QEvent::Close:
			return "Qt::CloseEvent";
		case QEvent::ContextMenu:
			return "Qt::ContextMenuEvent";
//		case QEvent::User:
//			return "Qt::CustomEvent";
		case QEvent::DragEnter:
			return "Qt::DragEnterEvent";
		case QEvent::DragLeave:
			return "Qt::DragLeaveEvent";
		case QEvent::DragMove:
			return "Qt::DragMoveEvent";
		case QEvent::DragResponse:
			return "Qt::DragResponseEvent";
		case QEvent::Drop:
			return "Qt::DropEvent";
		case QEvent::FocusIn:
		case QEvent::FocusOut:
			return "Qt::FocusEvent";
		case QEvent::Hide:
			return "Qt::HideEvent";
		case QEvent::KeyPress:
		case QEvent::KeyRelease:
			return "Qt::KeyEvent";
		case QEvent::IMStart:
		case QEvent::IMCompose:
		case QEvent::IMEnd:
			return "Qt::IMEvent";
		case QEvent::MouseButtonPress:
		case QEvent::MouseButtonRelease:
		case QEvent::MouseButtonDblClick:
		case QEvent::MouseMove:
			return "Qt::MouseEvent";
		case QEvent::Move:
			return "Qt::MoveEvent";
		case QEvent::Paint:
			return "Qt::PaintEvent";
		case QEvent::Resize:
			return "Qt::ResizeEvent";
		case QEvent::Show:
			return "Qt::ShowEvent";
	//	case QEvent::Tablet:
	//		 return "Qt::TabletEvent";
		case QEvent::Timer:
			return "Qt::TimerEvent";
		case QEvent::Wheel:
			return "Qt::WheelEvent";
		default:
			break;
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QObject")) {
		return smoke->binding->className(classId);

		QObject * qobject = (QObject *) smoke->cast(ptr, classId, smoke->idClass("QObject"));
		QMetaObject * meta = qobject->metaObject();

		while (meta != 0) {
			Smoke::Index classId = smoke->idClass(meta->className());
			if (classId != 0) {
				return smoke->binding->className(classId);
			}

			meta = meta->superClass();
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QCanvasItem")) {
		QCanvasItem * qcanvasitem = (QCanvasItem *) smoke->cast(ptr, classId, smoke->idClass("QCanvasItem"));
		switch (qcanvasitem->rtti()) {
		case QCanvasItem::Rtti_Sprite:
			return "Qt::CanvasSprite";
		case QCanvasItem::Rtti_PolygonalItem:
			return "Qt::CanvasPolygonalItem";
		case QCanvasItem::Rtti_Text:
			return "Qt::CanvasText";
		case QCanvasItem::Rtti_Polygon:
			return "Qt::CanvasPolygon";
		case QCanvasItem::Rtti_Rectangle:
			return "Qt::CanvasRectangle";
		case QCanvasItem::Rtti_Ellipse:
			return "Qt::CanvasEllipse";
		case QCanvasItem::Rtti_Line:
			return "Qt::CanvasLine";
		case QCanvasItem::Rtti_Spline:
			return "Qt::CanvasSpline";
		default:
			break;
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QListViewItem")) {
		QListViewItem * item = (QListViewItem *) smoke->cast(ptr, classId, smoke->idClass("QListViewItem"));
		switch (item->rtti()) {
		case 0:
			return "Qt::ListViewItem";
		case 1:
			return "Qt::CheckListItem";
		default:
			return "Qt::ListViewItem";
			break;
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QTableItem")) {
		QTableItem * item = (QTableItem *) smoke->cast(ptr, classId, smoke->idClass("QTableItem"));
		switch (item->rtti()) {
		case 0:
			return "Qt::TableItem";
		case 1:
			return "Qt::ComboTableItem";
		case 2:
			return "Qt::CheckTableItem";
		default:
			return "Qt::TableItem";
			break;
		}
	}
	
	return smoke->binding->className(classId);
}

bool
matches_arg(Smoke *smoke, Smoke::Index meth, Smoke::Index argidx, const char *argtype)
{
    Smoke::Index *arg = smoke->argumentList + smoke->methods[meth].args + argidx;
    SmokeType type = SmokeType(smoke, *arg);
    if(type.name() && !strcmp(type.name(), argtype))
	return true;
    return false;
}

void *
construct_copy(smokeqyoto_object *o)
{
    const char *className = o->smoke->className(o->classId);
    int classNameLen = strlen(className);
    char *ccSig = new char[classNameLen + 2];       // copy constructor signature
    strcpy(ccSig, className);
    strcat(ccSig, "#");
    Smoke::Index ccId = o->smoke->idMethodName(ccSig);
    delete[] ccSig;

    char *ccArg = new char[classNameLen + 8];
    sprintf(ccArg, "const %s&", className);

    Smoke::Index ccMeth = o->smoke->findMethod(o->classId, ccId);

    if(!ccMeth) {
	return 0;
    }
	Smoke::Index method = o->smoke->methodMaps[ccMeth].method;
    if(method > 0) {
	// Make sure it's a copy constructor
	if(!matches_arg(o->smoke, method, 0, ccArg)) {
            delete[] ccArg;
	    return 0;
        }
        delete[] ccArg;
        ccMeth = method;
    } else {
        // ambiguous method, pick the copy constructor
	Smoke::Index i = -method;
	while(o->smoke->ambiguousMethodList[i]) {
	    if(matches_arg(o->smoke, o->smoke->ambiguousMethodList[i], 0, ccArg))
		break;
            i++;
	}
        delete[] ccArg;
	ccMeth = o->smoke->ambiguousMethodList[i];
	if(!ccMeth)
	    return 0;
    }

    // Okay, ccMeth is the copy constructor. Time to call it.
    Smoke::StackItem args[2];
    args[0].s_voidp = 0;
    args[1].s_voidp = o->ptr;
    Smoke::ClassFn fn = o->smoke->classes[o->classId].classFn;
    (*fn)(o->smoke->methods[ccMeth].method, 0, args);
    return args[0].s_voidp;
}

extern "C" {

void *
StringArrayToCharStarStar(int length, char ** strArray)
{
	char ** result = (char **) calloc(length, sizeof(char *));
	int i;
	for (i = 0; i < length; i++) {
		result[i] = strdup(strArray[i]);
	}
	return (void *) result;
}

void *
StringToQString(char *str)
{
	QString * result = new QString((const char *) str);
	return (void *) result;
}

char *
StringFromQString(void *ptr)
{
	return strdup(((QString *) ptr)->latin1());
}

}

void
marshall_basetype(Marshall *m)
{
    switch(m->type().elem()) {
      case Smoke::t_bool:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_bool = m->var().s_bool;
	    break;
	  case Marshall::ToObject:
	    m->var().s_bool = m->item().s_bool;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_char:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_char = m->var().s_char;
	    break;
	  case Marshall::ToObject:
	    m->var().s_char = m->item().s_char;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_uchar:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_uchar = m->var().s_uchar;
	    break;
	  case Marshall::ToObject:
	    m->var().s_uchar = m->item().s_uchar;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_short:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_short = m->var().s_short;
	    break;
	  case Marshall::ToObject:
	    m->var().s_short = m->item().s_short;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_ushort:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_ushort = m->var().s_ushort;
	    break;
	  case Marshall::ToObject:
	    m->var().s_ushort = m->item().s_ushort;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_int:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_int = m->var().s_int;
	    break;
	  case Marshall::ToObject:
	    m->var().s_int = m->item().s_int;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_uint:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_uint = m->var().s_uint;
	    break;
	  case Marshall::ToObject:
	    m->var().s_uint = m->item().s_uint;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_long:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_long = m->var().s_long;
	    break;
	  case Marshall::ToObject:
	    m->var().s_long = m->item().s_long;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_ulong:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_ulong = m->var().s_ulong;
	    break;
	  case Marshall::ToObject:
	    m->var().s_ulong = m->item().s_ulong;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_float:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_float = m->var().s_float;
	    break;
	  case Marshall::ToObject:
	    m->var().s_float = m->item().s_float;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_double:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_double = m->var().s_double;
	    break;
	  case Marshall::ToObject:
	    m->var().s_double = m->item().s_double;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_enum:
	switch(m->action()) {
	  case Marshall::FromObject:
	    m->item().s_enum = m->var().s_enum;
	    break;
	  case Marshall::ToObject:
	    m->var().s_enum = m->item().s_enum;
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      case Smoke::t_class:
	switch(m->action()) {
	  case Marshall::FromObject:
	    {
		if (m->var().s_class == 0) {
			m->item().s_class = 0;
			return;
		}

		smokeqyoto_object *o = value_obj_info(m->var().s_class);
		if(!o || !o->ptr) {
                    if(m->type().isRef()) {
//                        rb_warning("References can't be nil\n");
                        m->unsupported();
                    }
		    m->item().s_class = 0;
		    break;
		}
		void *ptr = o->ptr;
		if(!m->cleanup() && m->type().isStack()) {
		    ptr = construct_copy(o);
		}
		const Smoke::Class &c = m->smoke()->classes[m->type().classId()];
		ptr = o->smoke->cast(
		    ptr,				// pointer
		    o->classId,				// from
		    o->smoke->idClass(c.className)	// to
		);
		m->item().s_class = ptr;
		break;
	    }
	    break;
	  case Marshall::ToObject:
	    {
		if(m->item().s_voidp == 0) {
			m->var().s_voidp = 0;
		    break;
		}

		void *p = m->item().s_voidp;
		void * obj = getPointerObject(p);
		if (obj != 0) {
			m->var().s_voidp = obj;
		    break;
		}
		smokeqyoto_object  * o = (smokeqyoto_object *) malloc(sizeof(smokeqyoto_object));
		o->smoke = m->smoke();
		o->classId = m->type().classId();
		o->ptr = p;
		o->allocated = false;

		const char * classname = resolve_classname(o->smoke, o->classId, o->ptr);
		
		if(m->type().isConst() && m->type().isRef()) {
		    p = construct_copy( o );
		    if(p) {
			o->ptr = p;
			o->allocated = true;
		    }
		}
		
		obj = set_obj_info(classname, o);
		if (do_debug & qtdb_calls) {
			printf("allocating %s %p -> %p\n", classname, o->ptr, (void*)obj);
		}

		if(m->type().isStack()) {
		    o->allocated = true;
			// Keep a mapping of the pointer so that it is only wrapped once
		    mapPointer(obj, o, o->classId, 0);
		}
		
		m->var().s_class = obj;
	    }
	    break;
	  default:
	    m->unsupported();
	    break;
	}
	break;
      default:
	m->unsupported();
	break;
    }
}

static void marshall_void(Marshall * /*m*/) {}
static void marshall_unknown(Marshall *m) {
    m->unsupported();
}

static void marshall_charP(Marshall *m) {
	switch(m->action()) {
	case Marshall::FromObject:
	{
		if (m->var().s_class == 0) {
			m->item().s_voidp = 0;
		} else {
			m->item().s_voidp = (*IntPtrToCharStar)(m->var().s_class);
		}
	}
	break;
	case Marshall::ToObject:
	{
		char *p = (char*) m->item().s_voidp;
	    if (p != 0) {
			m->var().s_class = (*IntPtrFromCharStar)(strdup(p));
	    } else {
			m->var().s_class = 0;
		}

	    if (m->cleanup()) {
			delete[] p;
		}
	}
	break;
		default:
		m->unsupported();
	break;
	}
}

static void marshall_QString(Marshall *m) {
    switch(m->action()) {
      case Marshall::FromObject:
	{
	    QString* s = 0;

	    if( m->var().s_voidp != 0) {
			s = (QString *) (*IntPtrToQString)(m->var().s_voidp);
#if 0
               if(SvUTF8(*(m->var())))
                    s = QString::fromUtf8(SvPV_nolen(*(m->var())));
               else if(PL_hints & HINT_LOCALE)
                    s = QString::fromLocal8Bit(SvPV_nolen(*(m->var())));
               else
                    s = QString::fromLatin1(SvPV_nolen(*(m->var())));
#else
            // Treat everything as UTF-8..for now
//            s = new QString(QString::fromUtf8(StringValuePtr(*(m->var())), RSTRING(*(m->var()))->len));
#endif
            } else {
                s = new QString(QString::null);
            }
		
	    m->item().s_voidp = s;
	    m->next();
		
		if (!m->type().isConst() && m->var().s_voidp != 0 && s != 0) {
//			rb_str_resize(*(m->var()), 0);
//			rb_str_cat2(*(m->var()), (const char *)*s);
		}
	    
		if(s && m->cleanup())
		delete s;
	}
	break;
      case Marshall::ToObject:
	{
	    QString *s = (QString*)m->item().s_voidp;
	    if (s) {
			if (s->isNull()) {
				m->var().s_voidp = 0;
			} else {
				m->var().s_class = (*IntPtrFromQString)(s);
			}
//                if(!(PL_hints & HINT_BYTES))
//                {
//		    sv_setpv_mg(m->var(), (const char *)s->utf8());
//                    SvUTF8_on(*(m->var()));
//                }
//                else if(PL_hints & HINT_LOCALE)
//                    sv_setpv_mg(m->var(), (const char *)s->local8Bit());
//                else
//                    sv_setpv_mg(m->var(), (const char *)s->latin1());
			if (m->cleanup())
				delete s;
			} else {
				m->var().s_voidp = 0;
			}
	}
	break;
		default:
		m->unsupported();
	break;
    }
}


static void marshall_intR(Marshall *m) {
	switch(m->action()) {
	case Marshall::FromObject:
	{
		int * i = new int;
		*i = m->var().s_int;
		m->item().s_voidp = i;
		m->next();
	    if(m->cleanup() && m->type().isConst()) {
			delete i;
	    } else {
//			m->item().s_voidp = new int((int)NUM2INT(rv));
	    }
	}
	break;
	case Marshall::ToObject:
	{
		int *ip = (int*)m->item().s_voidp;
		m->var().s_int = *ip;
	}
	break;
      default:
	m->unsupported();
	break;
    }
}


static void marshall_charP_array(Marshall *m) {

    switch(m->action()) {
      case Marshall::FromObject:
	{
		m->item().s_voidp = (*IntPtrToCharStarStar)(m->var().s_voidp);
		char ** temp = (char **) m->item().s_voidp;
	}
	break;
      default:
	m->unsupported();
	break;
    }

}


TypeHandler Qt_handlers[] = {
    { "QString", marshall_QString },
    { "QString&", marshall_QString },
    { "QString*", marshall_QString },
    { "int&", marshall_intR },
    { "int*", marshall_intR },
    { "char*", marshall_charP },
    { "char**", marshall_charP_array },

    { 0, 0 }
};

QAsciiDict<TypeHandler> type_handlers(199);

void install_handlers(TypeHandler *h) {
    while(h->name) {
	type_handlers.insert(h->name, h);
	h++;
    }
}

Marshall::HandlerFn getMarshallFn(const SmokeType &type) {
    if(type.elem())
	return marshall_basetype;
    if(!type.name())
	return marshall_void;
	TypeHandler *h = type_handlers[type.name()];
    if(h == 0 && type.isConst() && strlen(type.name()) > strlen("const ")) {
    	h = type_handlers[type.name() + strlen("const ")];
    }
	
    if(h != 0) {
	return h->fn;
    }

    return marshall_unknown;
}