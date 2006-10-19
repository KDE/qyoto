#include <QtCore/qstring.h>
#include <QtCore/qregexp.h>
#include <QtGui/qapplication.h>
#include <QtGui/qlistwidget.h>
#include <QtGui/qlayout.h>
#include <QtCore/qmetaobject.h>
#include <QtGui/qtablewidget.h>

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


                case QEvent::Timer:
                        return "Qyoto.QTimerEvent";
                case QEvent::MouseButtonPress:
                case QEvent::MouseButtonRelease:
                case QEvent::MouseButtonDblClick:
                case QEvent::MouseMove:
                        return "Qyoto.QMouseEvent";
                case QEvent::KeyPress:
                case QEvent::KeyRelease:
                case QEvent::ShortcutOverride:
                        return "Qyoto.QKeyEvent";
                case QEvent::FocusIn:
                case QEvent::FocusOut:
                        return "Qyoto.QFocusEvent";
                case QEvent::Enter:
                case QEvent::Leave:
                        return "Qyoto.QEvent";
                case QEvent::Paint:
                        return "Qyoto.QPaintEvent";
                case QEvent::Move:
                        return "Qyoto.QMoveEvent";
                case QEvent::Resize:
                        return "Qyoto.QResizeEvent";
                case QEvent::Create:
                case QEvent::Destroy:
                        return "Qyoto.QEvent";
                case QEvent::Show:
                        return "Qyoto.QShowEvent";
                case QEvent::Hide:
                        return "Qyoto.QHideEvent";
                case QEvent::Close:
                        return "Qyoto.QCloseEvent";
                case QEvent::Quit:
                case QEvent::ParentChange:
                case QEvent::ParentAboutToChange:
                case QEvent::ThreadChange:
                case QEvent::WindowActivate:
                case QEvent::WindowDeactivate:
                case QEvent::ShowToParent:
                case QEvent::HideToParent:
                        return "Qyoto.QEvent";
                case QEvent::Wheel:
                        return "Qyoto.QWheelEvent";
                case QEvent::WindowTitleChange:
                case QEvent::WindowIconChange:
                case QEvent::ApplicationWindowIconChange:
                case QEvent::ApplicationFontChange:
                case QEvent::ApplicationLayoutDirectionChange:
                case QEvent::ApplicationPaletteChange:
                case QEvent::PaletteChange:
                        return "Qyoto.QEvent";
                case QEvent::Clipboard:
                        return "Qyoto.QClipboardEvent";
                case QEvent::Speech:
                case QEvent::MetaCall:
                case QEvent::SockAct:
                case QEvent::WinEventAct:
                case QEvent::DeferredDelete:
                        return "Qyoto.QEvent";
                case QEvent::DragEnter:
                        return "Qyoto.QDragEnterEvent";
                case QEvent::DragLeave:
                        return "Qyoto.QDragLeaveEvent";
                case QEvent::DragMove:
                        return "Qyoto.QDragMoveEvent";
                case QEvent::Drop:
                        return "Qyoto.QDropEvent";
                case QEvent::DragResponse:
                        return "Qyoto.QDragResponseEvent";
                case QEvent::ChildAdded:
                case QEvent::ChildRemoved:
                case QEvent::ChildPolished:
                        return "Qyoto.QChildEvent";
                case QEvent::ShowWindowRequest:
                case QEvent::PolishRequest:
                case QEvent::Polish:
                case QEvent::LayoutRequest:
                case QEvent::UpdateRequest:
                case QEvent::EmbeddingControl:
                case QEvent::ActivateControl:
                case QEvent::DeactivateControl:
                        return "Qyoto.QEvent";
                case QEvent::ContextMenu:
                        return "Qyoto.QContextMenuEvent";
                case QEvent::InputMethod:
                        return "Qyoto.QInputMethodEvent";
                case QEvent::AccessibilityPrepare:
                        return "Qyoto.QEvent";
                case QEvent::TabletMove:
                case QEvent::TabletPress:
                case QEvent::TabletRelease:
                        return "Qyoto.QTabletEvent";
                case QEvent::LocaleChange:
                case QEvent::LanguageChange:
                case QEvent::LayoutDirectionChange:
                case QEvent::Style:
                case QEvent::OkRequest:
                case QEvent::HelpRequest:
                        return "Qyoto.QEvent";
                case QEvent::IconDrag:
                        return "Qyoto.QIconDragEvent";
                case QEvent::FontChange:
                case QEvent::EnabledChange:
                case QEvent::ActivationChange:
                case QEvent::StyleChange:
                case QEvent::IconTextChange:
                case QEvent::ModifiedChange:
                case QEvent::MouseTrackingChange:
                        return "Qyoto.QEvent";
                case QEvent::WindowBlocked:
                case QEvent::WindowUnblocked:
                case QEvent::WindowStateChange:
                        return "Qyoto.QWindowStateChangeEvent";
                case QEvent::ToolTip:
                case QEvent::WhatsThis:
                        return "Qyoto.QHelpEvent";
                case QEvent::StatusTip:
                        return "Qyoto.QEvent";
                case QEvent::ActionChanged:
                case QEvent::ActionAdded:
                case QEvent::ActionRemoved:
                        return "Qyoto.QActionEvent";
                case QEvent::FileOpen:
                        return "Qyoto.QFileOpenEvent";
                case QEvent::Shortcut:
                        return "Qyoto.QShortcutEvent";
                case QEvent::WhatsThisClicked:
                        return "Qyoto.QWhatsThisClickedEvent";
                case QEvent::ToolBarChange:
                        return "Qyoto.QToolBarChangeEvent";
                case QEvent::ApplicationActivated:
                case QEvent::ApplicationDeactivated:
                case QEvent::QueryWhatsThis:
                case QEvent::EnterWhatsThisMode:
                case QEvent::LeaveWhatsThisMode:
                case QEvent::ZOrderChange:
                        return "Qyoto.QEvent";
                case QEvent::HoverEnter:
                case QEvent::HoverLeave:
                case QEvent::HoverMove:
                        return "Qyoto.QHoverEvent";
                case QEvent::AccessibilityHelp:
                case QEvent::AccessibilityDescription:
                        return "Qyoto.QEvent";
		default:
			break;
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QObject")) {
		return smoke->binding->className(classId);

		QObject * qobject = (QObject *) smoke->cast(ptr, classId, smoke->idClass("QObject"));
		const QMetaObject * meta = qobject->metaObject();

		while (meta != 0) {
			Smoke::Index classId = smoke->idClass(meta->className());
			if (classId != 0) {
				return smoke->binding->className(classId);
			}

			meta = meta->superClass();
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QLayoutItem")) {
		QLayoutItem * item = (QLayoutItem *) smoke->cast(ptr, classId, smoke->idClass("QLayoutItem"));
		if (item->widget() != 0) {
			return "Qt::WidgetItem";
		} else if (item->spacerItem() != 0) {
			return "Qt::SpacerItem";
		} else {
			return "Qt::Layout";
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QListWidgetItem")) {
		QListWidgetItem * item = (QListWidgetItem *) smoke->cast(ptr, classId, smoke->idClass("QListWidgetItem"));
		switch (item->type()) {
		case 0:
			return "Qt::ListWidgetItem";
		default:
			return "Qt::ListWidgetItem";
			break;
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QTableWidgetItem")) {
		QTableWidgetItem * item = (QTableWidgetItem *) smoke->cast(ptr, classId, smoke->idClass("QTableWidgetItem"));
		switch (item->type()) {
		case 0:
			return "Qt::TableWidgetItem";
		default:
			return "Qt::TableWidgetItem";
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
    QByteArray ba = ((QString *) ptr)->toLatin1();
    return strdup(ba.constData());
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
		if(obj != 0) {
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
            if (m->var().s_class == 0) {
                    m->item().s_voidp = 0;
            } else {
                    m->item().s_voidp = (*IntPtrToCharStar)(m->var().s_class);
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
//                m->item().s_voidp = new int((int)NUM2INT(rv));
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

static void marshall_voidP_array(Marshall* m) {
	switch(m->action()) {
	case Marshall::FromObject:
		m->item().s_voidp = m->var().s_voidp;
		break;
	case Marshall::ToObject:
		m->var().s_voidp = m->item().s_voidp;
		break;
	default:
		m->unsupported();
		break;
	}
}

void marshall_QStringList(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject: 
		{
//			VALUE list = *(m->var());
//			if (TYPE(list) != T_ARRAY) {
//				m->item().s_voidp = 0;
//				break;
//			}

//			int count = RARRAY(list)->len;
			int count = 0;
			QStringList *stringlist = new QStringList;

			for (long i = 0; i < count; i++) {
//				VALUE item = rb_ary_entry(list, i);
//					if(TYPE(item) != T_STRING) {
						stringlist->append(QString());
//						continue;
//					}
//				stringlist->append(*(qstringFromRString(item)));
			}

			m->item().s_voidp = stringlist;
			m->next();

			if (stringlist != 0 && !m->type().isConst()) {
//				rb_ary_clear(list);
				for (QStringList::Iterator it = stringlist->begin(); it != stringlist->end(); ++it) {
//					rb_ary_push(list, rstringFromQString(&(*it)));
				}
			}
			
			if (m->cleanup()) {
				delete stringlist;
			}
	   
			break;
		}

      case Marshall::ToObject: 
	{
		QStringList *stringlist = static_cast<QStringList *>(m->item().s_voidp);
		if (!stringlist) {
//			*(m->var()) = Qnil;
			break;
		}

//		VALUE av = rb_ary_new();
		for (QStringList::Iterator it = stringlist->begin(); it != stringlist->end(); ++it) {
//			VALUE rv = rstringFromQString(&(*it));
//			rb_ary_push(av, rv);
		}

//		*(m->var()) = av;

		if (m->cleanup()) {
			delete stringlist;
		}

	}
	break;
      default:
	m->unsupported();
	break;
    }
}

template <class Item, class ItemList, const char *ItemSTR >
void marshall_ValueListItem(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject:
		{
//			VALUE list = *(m->var());
//			if (TYPE(list) != T_ARRAY) {
				m->item().s_voidp = 0;
//				break;
//			}
//			int count = RARRAY(list)->len;
			int count = 0;
			ItemList *cpplist = new ItemList;
			long i;
			for(i = 0; i < count; i++) {
//				VALUE item = rb_ary_entry(list, i);
				// TODO do type checking!
				smokeqyoto_object *o = value_obj_info(0);
				if(!o || !o->ptr)
					continue;
				
				void *ptr = o->ptr;
				ptr = o->smoke->cast(
					ptr,				// pointer
					o->classId,				// from
					o->smoke->idClass(ItemSTR)	        // to
				);
				cpplist->append(*(Item*)ptr);
			}

			m->item().s_voidp = cpplist;
			m->next();

			if (!m->type().isConst()) {
//				rb_ary_clear(list);
				for(int i=0; i < cpplist->size(); ++i) {
//					VALUE obj = getPointerObject((void*)&(cpplist->at(i)));
//					rb_ary_push(list, obj);
				}
			}

			if (m->cleanup()) {
				delete cpplist;
			}
		}
		break;
      
		case Marshall::ToObject:
		{
			ItemList *valuelist = (ItemList*)m->item().s_voidp;
			if (valuelist == 0) {
//				*(m->var()) = Qnil;
				break;
			}

//			VALUE av = rb_ary_new();

			int ix = m->smoke()->idClass(ItemSTR);
			const char * className = m->smoke()->binding->className(ix);

			for (int i=0; i < valuelist->size() ; ++i) {
				void *p = (void *) &(valuelist->at(i));

				if (m->item().s_voidp == 0) {
//					*(m->var()) = Qnil;
					break;
				}

//				VALUE obj = getPointerObject(p);
//				if(obj == Qnil) {
					smokeqyoto_object  * o = (smokeqyoto_object *) malloc(sizeof(smokeqyoto_object));
					o->smoke = m->smoke();
					o->classId = o->smoke->idClass(ItemSTR);
					o->ptr = p;
					o->allocated = false;
//					obj = set_obj_info(className, o);
//				}
		
//				rb_ary_push(av, obj);
			}

//			*(m->var()) = av;
			m->next();

			if (m->cleanup()) {
				delete valuelist;
			}

		}
		break;
      
		default:
			m->unsupported();
		break;
	}
}

#define DEF_VALUELIST_MARSHALLER(ListIdent,ItemList,Item) namespace { char ListIdent##STR[] = #Item; };  \
        Marshall::HandlerFn marshall_##ListIdent = marshall_ValueListItem<Item,ItemList,ListIdent##STR>;

DEF_VALUELIST_MARSHALLER( QVariantList, QList<QVariant>, QVariant )

TypeHandler Qt_handlers[] = {
    { "QString", marshall_QString },
    { "QString&", marshall_QString },
    { "QString*", marshall_QString },
    { "int&", marshall_intR },
    { "int*", marshall_intR },
    { "char*", marshall_charP },
    { "char**", marshall_charP_array },
    { "QStringList", marshall_QStringList },
    { "QStringList&", marshall_QStringList },
    { "QStringList*", marshall_QStringList },
//    { "void**", marshall_voidP_array },
    { "QList<QVariant>", marshall_QVariantList },
    { "QList<QVariant>&", marshall_QVariantList },
    { "QVariantList&", marshall_QVariantList },

    { 0, 0 }
};

QHash<QString,TypeHandler *> type_handlers;

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
