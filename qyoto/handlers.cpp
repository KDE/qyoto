#include <QtCore/qstring.h>
#include <QtCore/qregexp.h>
#include <QtGui/qapplication.h>
#include <QtGui/qlistwidget.h>
#include <QtGui/qlayout.h>
#include <QtCore/qmetaobject.h>
#include <QtGui/qtablewidget.h>

#include <QtGui/qpainter.h>
#include <QtGui/qpalette.h>
#include <QtGui/qtablewidget.h>
#include <QtGui/qtoolbar.h>
#include <QtGui/qdockwidget.h>
#include <QtNetwork/qurlinfo.h>
#include <QtCore/qlinkedlist.h>
#include <QtCore/qobject.h>
#include <QtCore/qtextcodec.h>
#include <QtCore/qprocess.h>
#include <QtNetwork/qhostaddress.h>
#include <QtCore/qpair.h>
#include <QtGui/qevent.h>
#include <QtGui/qpixmap.h>
#include <QtGui/qaction.h>
#include <QtGui/qtreewidget.h>
#include <QtGui/qtextobject.h>
#include <QtGui/qtextlayout.h>
#include <QtGui/qabstractbutton.h>
#include <QtGui/qlistwidget.h>
#include <QtGui/qpolygon.h>
#include <QtCore/qurl.h>
#include <QtCore/qdir.h>
#include <QtCore/qobject.h>
#include <QtGui/qwidget.h>
#include <QtGui/qtabbar.h>
#include <QtCore/qhash.h>

#if QT_VERSION >= 0x40200
#include <QtGui/qgraphicsscene.h>
#include <QtGui/qgraphicsitem.h>
#include <QtGui/qstandarditemmodel.h>
#include <QtGui/qundostack.h>
#endif

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
static GetIntPtr StringBuilderToQString;
static SetIntPtrFromCharStar StringBuilderFromQString;
static GetIntPtr StringListToQStringList;
static GetIntPtr ListToPointerList;
static GetIntPtr ListIntToQListInt;
static CreateInstanceFn ConstructList;
static SetIntPtr AddIntPtrToList;
static AddInt AddIntToListInt;
static ConstructDict ConstructDictionary;
static InvokeMethodFn AddObjectObjectToDictionary;
static AddIntObject AddIntObjectToDictionary;
static DictToMap DictionaryToQMap;

void InstallIntPtrToCharStarStar(GetIntPtr callback)
{
	IntPtrToCharStarStar = callback;
}

void InstallIntPtrToCharStar(GetCharStarFromIntPtr callback)
{
	IntPtrToCharStar = callback;
}

void InstallIntPtrFromCharStar(GetIntPtrFromCharStar callback)
{
	IntPtrFromCharStar = callback;
}

void InstallIntPtrToQString(GetIntPtr callback)
{
	IntPtrToQString = callback;
}

void InstallIntPtrFromQString(GetIntPtr callback)
{
	IntPtrFromQString = callback;
}

void InstallStringBuilderToQString(GetIntPtr callback)
{
	StringBuilderToQString = callback;
}

void InstallStringBuilderFromQString(SetIntPtrFromCharStar callback)
{
	StringBuilderFromQString = callback;
}

void InstallStringListToQStringList(GetIntPtr callback)
{
	StringListToQStringList = callback;
}

void InstallListToPointerList(GetIntPtr callback)
{
	ListToPointerList = callback;
}

void InstallListIntToQListInt(GetIntPtr callback)
{
	ListIntToQListInt = callback;
}

void InstallConstructList(CreateInstanceFn callback)
{
	ConstructList = callback;
}

void InstallAddIntPtrToList(SetIntPtr callback)
{
	AddIntPtrToList = callback;
}

void InstallAddIntToListInt(AddInt callback)
{
	AddIntToListInt = callback;
}

void InstallConstructDictionary(ConstructDict callback)
{
	ConstructDictionary = callback;
}

void InstallAddObjectObjectToDictionary(InvokeMethodFn callback)
{
	AddObjectObjectToDictionary = callback;
}

void InstallAddIntObjectToDictionary(AddIntObject callback)
{
	AddIntObjectToDictionary = callback;
}

void InstallDictionaryToQMap(DictToMap callback)
{
	DictionaryToQMap = callback;
}

void* ConstructPointerList()
{
	void * list = (void*) new QList<void*>;
	return list;
}

void AddObjectToPointerList(void* ptr, void* obj)
{
	QList<void*> * list = (QList<void*>*) ptr;
	list->append(obj);
}

void* ConstructQListInt()
{
	void* list = (void*) new QList<int>;
	return list;
}

void AddIntToQList(void* ptr, int i)
{
	QList<int>* list = (QList<int>*) ptr;
	list->append(i);
}

void* ConstructQMap(int type)
{
	if (type == 0) {
		return (void*) new QMap<int, QVariant>();
	} else if (type == 1) {
		return (void*) new QMap<QString, QString>();
	} else if (type == 2) {
		return (void*) new QMap<QString, QVariant>();
	}
	return 0;
}

void AddIntQVariantToQMap(void* ptr, int i, void* qv)
{
	QMap<int, QVariant>* map = (QMap<int, QVariant>*) ptr;
	QVariant* variant = (QVariant*) value_obj_info(qv)->ptr;
	map->insert(i, *variant);
}

void AddQStringQStringToQMap(void* ptr, char* str1, char* str2)
{
	QMap<QString, QString>* map = (QMap<QString, QString>*) ptr;
	map->insert(QString(str1), QString(str2));
}

void AddQStringQVariantToQMap(void* ptr, char* str, void* qv)
{
	QMap<QString, QVariant>* map = (QMap<QString, QVariant>*) ptr;
	QVariant* variant = (QVariant*) value_obj_info(qv)->ptr;
	map->insert(QString(str), *variant);
}

extern void * set_obj_info(const char * className, smokeqyoto_object * o);
//extern void * IntPtrToCharStarStar(void * item);
};

extern bool isDerivedFromByName(Smoke *smoke, const char *className, const char *baseClassName);
extern void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr);

bool
IsInstanceContained(smokeqyoto_object *o)
{
    const char *className = o->smoke->classes[o->classId].className;
		
	if (	qstrcmp(className, "QObject") == 0
			|| qstrcmp(className, "QListBoxItem") == 0
			|| qstrcmp(className, "QStyleSheetItem") == 0
			|| qstrcmp(className, "QSqlCursor") == 0
			|| qstrcmp(className, "QModelIndex") == 0 )
	{
		return true;
	} else if (isDerivedFromByName(o->smoke, className, "QLayoutItem")) {
		QLayoutItem * item = (QLayoutItem *) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QLayoutItem"));
		if (item->layout() != 0 || item->widget() != 0 || item->spacerItem() != 0) {
			return true;
		}
	} else if (qstrcmp(className, "QListWidgetItem") == 0) {
		QListWidgetItem * item = (QListWidgetItem *) o->ptr;
		if (item->listWidget() != 0) {
			return true;
		}
	} else if (isDerivedFromByName(o->smoke, className, "QTableWidgetItem")) {
		QTableWidgetItem * item = (QTableWidgetItem *) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QTableWidgetItem"));
		if (item->tableWidget() != 0) {
			return true;
		}
	} else if (isDerivedFromByName(o->smoke, className, "QWidget")) {
		QWidget * qwidget = (QWidget *) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QWidget"));
		if (qwidget->parentWidget() != 0) {
			return true;
		}
	} else if (isDerivedFromByName(o->smoke, className, "QObject")) {
		QObject * qobject = (QObject *) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject"));
		if (qobject->parent() != 0) {
			return true;
		}
	}
	
    return false;
}

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
			return "Qyoto.QWidgetItem";
		} else if (item->spacerItem() != 0) {
			return "Qyoto.QSpacerItem";
		} else {
			return "Qyoto.QLayout";
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QListWidgetItem")) {
		QListWidgetItem * item = (QListWidgetItem *) smoke->cast(ptr, classId, smoke->idClass("QListWidgetItem"));
		switch (item->type()) {
		case 0:
			return "Qyoto.QListWidgetItem";
		default:
			return "Qyoto.QListWidgetItem";
			break;
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QTableWidgetItem")) {
		QTableWidgetItem * item = (QTableWidgetItem *) smoke->cast(ptr, classId, smoke->idClass("QTableWidgetItem"));
		switch (item->type()) {
		case 0:
			return "Qyoto.QTableWidgetItem";
		default:
			return "Qyoto.QTableWidgetItem";
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
	QString * result = new QString(QString::fromUtf8(str));
	return (void *) result;
}

char *
StringFromQString(void *ptr)
{
    QByteArray ba = ((QString *) ptr)->toUtf8();
    return strdup(ba.constData());
}

void *
StringArrayToQStringList(int length, char ** strArray)
{
	QStringList * result = new QStringList();
	char ** ca = (char**) StringArrayToCharStarStar(length, strArray);
	
	for (int i = 0; i < length; i++) {
		(*result) << QString(ca[i]);
	}
	return (void*) result;
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
		smokeqyoto_object  * o = alloc_smokeqyoto_object(false, m->smoke(), m->type().classId(), p);

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
		if (m->var().s_voidp != 0) {
			if (m->type().isConst()) {
				s = (QString *) (*IntPtrToQString)(m->var().s_voidp);
			} else {
				s = (QString *) (*StringBuilderToQString)(m->var().s_voidp);
			}
		} else {
			s = new QString(QString::null);
		}
		
		m->item().s_voidp = s;
	    m->next();
		
		if (!m->type().isConst() && m->var().s_voidp != 0 && s != 0) {
			(*StringBuilderFromQString)(m->var().s_voidp, (const char *) s->toUtf8());
		}
	    
		if (s && m->cleanup())
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

void marshall_QDBusVariant(Marshall *m) {
	switch(m->action()) {
	case Marshall::FromObject: 
	{
		if (m->var().s_class == 0) {
			m->item().s_class = 0;
			return;
		}

		smokeqyoto_object *o = value_obj_info(m->var().s_class);
		if (!o || !o->ptr) {
			if (m->type().isRef()) {
				m->unsupported();
			}
		    m->item().s_class = 0;
		    break;
		}
		m->item().s_class = o->ptr;
		break;
	}

	case Marshall::ToObject: 
	{
		if (m->item().s_voidp == 0) {
			m->var().s_voidp = 0;
		    break;
		}

		void *p = m->item().s_voidp;
		void * obj = getPointerObject(p);
		if(obj != 0) {
			m->var().s_voidp = obj;
		    break;
		}
		smokeqyoto_object  * o = alloc_smokeqyoto_object(false, m->smoke(), m->smoke()->idClass("QVariant"), p);
		
		obj = set_obj_info("Qyoto.QDBusVariant", o);
		if (do_debug & qtdb_calls) {
			printf("allocating %s %p -> %p\n", "QDBusVariant", o->ptr, (void*)obj);
		}

		if (m->type().isStack()) {
		    o->allocated = true;
			// Keep a mapping of the pointer so that it is only wrapped once
		    mapPointer(obj, o, o->classId, 0);
		}
		
		m->var().s_class = obj;
	}
	
	default:
		m->unsupported();
		break;
    }
}

void marshall_QMapintQVariant(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject: 
		{
			QMap<int, QVariant>* map = (QMap<int, QVariant>*) (*DictionaryToQMap)(m->var().s_voidp, 0);
			m->item().s_voidp = (void*) map;
			m->next();
			
			if (m->cleanup()) {
				delete map;
			}
			break;
		}

		case Marshall::ToObject: 
		{
			QMap<int, QVariant>* map = (QMap<int, QVariant>*) m->item().s_voidp;
			void* dict = (*ConstructDictionary)("System.Int32", "Qyoto.QVariant");
			
			int id = m->smoke()->idClass("QVariant");
			
			for (QMap<int, QVariant>::iterator i = map->begin(); i != map->end(); ++i) {
				void* v = (void*) &(i.value());
				smokeqyoto_object * vo = alloc_smokeqyoto_object(false, m->smoke(), id, v);
				void* value = set_obj_info("Qyoto.QVariant", vo);
				(*AddIntObjectToDictionary)(dict, i.key(), value);
			}
			
			m->var().s_voidp = dict;
			m->next();
			
			break;
		}
	
		default:
			m->unsupported();
			break;
    }
}

void marshall_QMapQStringQString(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject: 
		{
			QMap<QString, QString>* map = (QMap<QString, QString>*) (*DictionaryToQMap)(m->var().s_voidp, 1);
			m->item().s_voidp = (void*) map;
			m->next();
			
			if (m->cleanup()) {
				delete map;
			}
			break;
		}

		case Marshall::ToObject: 
		{
			QMap<QString, QString>* map = (QMap<QString, QString>*) m->item().s_voidp;
			void* dict = (*ConstructDictionary)("System.String", "System.String");
			
			for (QMap<QString, QString>::iterator i = map->begin(); i != map->end(); ++i) {
				(*AddObjectObjectToDictionary)(	dict,
								(void*) StringFromQString((void*) &(i.key())),
								(void*) StringFromQString((void*) &(i.value())));
			}
			
			m->var().s_voidp = dict;
			m->next();
			
			break;
		}
	
		default:
			m->unsupported();
			break;
    }
}

void marshall_QMapQStringQVariant(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject: 
		{
			QMap<QString, QVariant>* map = (QMap<QString, QVariant>*) (*DictionaryToQMap)(m->var().s_voidp, 2);
			m->item().s_voidp = (void*) map;
			m->next();
			
			if (m->cleanup()) {
				delete map;
			}
			break;
		}

		case Marshall::ToObject: 
		{
			QMap<QString, QVariant>* map = (QMap<QString, QVariant>*) m->item().s_voidp;
			void* dict = (*ConstructDictionary)("System.String", "Qyoto.QVariant");
			
			int id = m->smoke()->idClass("QVariant");
			
			for (QMap<QString, QVariant>::iterator i = map->begin(); i != map->end(); ++i) {
				void* v = (void*) &(i.value());
				smokeqyoto_object * vo = alloc_smokeqyoto_object(false, m->smoke(), id, v);
				void* value = set_obj_info("Qyoto.QVariant", vo);
				(*AddObjectObjectToDictionary)(	dict,
								(void*) StringFromQString((void*) &(i.key())),
								value);
			}
			
			m->var().s_voidp = dict;
			m->next();
			
			break;
		}
	
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
// 			int count = 0;
// 			QStringList *stringlist = new QStringList;

// 			for (long i = 0; i < count; i++) {
//				VALUE item = rb_ary_entry(list, i);
//					if(TYPE(item) != T_STRING) {
// 						stringlist->append(QString());
//						continue;
//					}
//				stringlist->append(*(qstringFromRString(item)));
// 			}
			
			QStringList *stringlist = (QStringList*) (*StringListToQStringList)(m->var().s_voidp);
			
			m->item().s_voidp = (void*) stringlist;
			m->next();

// 			if (stringlist != 0 && !m->type().isConst()) {
//				rb_ary_clear(list);
// 				for (QStringList::Iterator it = stringlist->begin(); it != stringlist->end(); ++it) {
//					rb_ary_push(list, rstringFromQString(&(*it)));
// 				}
// 			}
			
			if (m->cleanup()) {
				delete stringlist;
			}
	   
			break;
		}

      case Marshall::ToObject: 
	{
		QStringList *stringlist = static_cast<QStringList *>(m->item().s_voidp);
		if (!stringlist) {
// 			m->var().s_voidp = 0;
			break;
		}

//		VALUE av = rb_ary_new();
// 		for (QStringList::Iterator it = stringlist->begin(); it != stringlist->end(); ++it) {
//			VALUE rv = rstringFromQString(&(*it));
//			rb_ary_push(av, rv);
// 		}

//		*(m->var()) = av;
		void* al = (*ConstructList)("System.String");
		for (int i = 0; i < stringlist->count(); i++) {
			(*AddIntPtrToList)(al, (*IntPtrFromCharStar)((char*) (*stringlist)[i].toLatin1().constData()));
		}
		m->var().s_voidp = al;
		m->next();

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
void marshall_ItemList(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject:
		{
			ItemList *cpplist = new ItemList;
			QList<void*>* list = (QList<void*>*) (*ListToPointerList)(m->var().s_voidp);
			
			for (int i; i < list->size(); ++i) {
				smokeqyoto_object * o = value_obj_info(list->at(i));
				
				void* ptr = o->ptr;
				ptr = o->smoke->cast(
					ptr,                            // pointer
					o->classId,                             // from
					o->smoke->idClass(ItemSTR)              // to
				);
				
				cpplist->append((Item*) ptr);
			}
			
			m->item().s_voidp = cpplist;
			m->next();
			
			if (m->cleanup()) {
				delete cpplist;
			}
		}
		break;
      
		case Marshall::ToObject:
		{
			ItemList *valuelist = (ItemList*)m->item().s_voidp;
			if (valuelist == 0) {
				break;
			}

			int ix = m->smoke()->idClass(ItemSTR);
			const char * className = m->smoke()->binding->className(ix);
			
			void * al = (*ConstructList)(className);
			
			for (int i=0; i < valuelist->size() ; ++i) {
				void *p = (void *) valuelist->at(i);

				smokeqyoto_object * o = alloc_smokeqyoto_object(false, m->smoke(), ix, p);
				void * obj = set_obj_info(className, o);
				(*AddIntPtrToList)(al, obj);
			}

			m->var().s_voidp = al;
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

void marshall_QListInt(Marshall *m) {
    switch(m->action()) {
      case Marshall::FromObject:
	{
	    void* list = m->var().s_voidp;
	    void* valuelist = (*ListIntToQListInt)(list);
	    m->item().s_voidp = valuelist;
	    m->next();

		/*if (m->cleanup()) {
			delete valuelist;
	    }*/
	}
	break;
      case Marshall::ToObject:
	{
	    QList<int> *valuelist = (QList<int>*)m->item().s_voidp;
	    if(!valuelist) {
		m->var().s_voidp = 0;
		break;
	    }

	    void* av = (*ConstructList)("System.Int32");

		for (QList<int>::iterator i = valuelist->begin(); i != valuelist->end(); ++i )
		{
		    (*AddIntToListInt)(av, (int) *i);
		}
		
	    m->var().s_voidp = av;
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

#define DEF_LIST_MARSHALLER(ListIdent,ItemList,Item) namespace { char ListIdent##STR[] = #Item; };  \
        Marshall::HandlerFn marshall_##ListIdent = marshall_ItemList<Item,ItemList,ListIdent##STR>;

DEF_LIST_MARSHALLER( QAbstractButtonList, QList<QAbstractButton*>, QAbstractButton )
DEF_LIST_MARSHALLER( QListWidgetItemList, QList<QListWidgetItem*>, QListWidgetItem )
DEF_LIST_MARSHALLER( QTableWidgetItemList, QList<QTableWidgetItem*>, QTableWidgetItem )
DEF_LIST_MARSHALLER( QObjectList, QList<QObject*>, QObject )
DEF_LIST_MARSHALLER( QWidgetList, QList<QWidget*>, QWidget )
DEF_LIST_MARSHALLER( QActionList, QList<QAction*>, QAction )
DEF_LIST_MARSHALLER( QWidgetPtrList, QList<QWidget*>, QWidget )
DEF_LIST_MARSHALLER( QTextFrameList, QList<QTextFrame*>, QTextFrame )
DEF_LIST_MARSHALLER( QTreeWidgetItemList, QList<QTreeWidgetItem*>, QTreeWidgetItem )

#if QT_VERSION >= 0x40200
DEF_LIST_MARSHALLER( QGraphicsItemList, QList<QGraphicsItem*>, QGraphicsItem )
DEF_LIST_MARSHALLER( QStandardItemList, QList<QStandardItem*>, QStandardItem )
DEF_LIST_MARSHALLER( QUndoStackList, QList<QUndoStack*>, QUndoStack )
#endif

template <class Item, class ItemList, const char *ItemSTR >
void marshall_ValueListItem(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject:
		{
			ItemList *cpplist = new ItemList;
			QList<void*>* list = (QList<void*>*) (*ListToPointerList)(m->var().s_voidp);

			for (int i = 0; i < list->size(); ++i) {
				smokeqyoto_object * o = value_obj_info(list->at(i));
				
				void* ptr = o->ptr;
				ptr = o->smoke->cast(
					ptr,                            // pointer
					o->classId,                             // from
					o->smoke->idClass(ItemSTR)              // to
				);
				
				cpplist->append(*(Item*) ptr);
			}
			
			m->item().s_voidp = cpplist;
			m->next();
			
			delete list;

			if (m->cleanup()) {
				delete cpplist;
			}
		}
		break;
      
		case Marshall::ToObject:
		{
			ItemList *valuelist = (ItemList*)m->item().s_voidp;
			if (valuelist == 0) {
				break;
			}

			int ix = m->smoke()->idClass(ItemSTR);
			const char * className = m->smoke()->binding->className(ix);
			
			void * al = (*ConstructList)(className);

			for (int i=0; i < valuelist->size() ; ++i) {
				void *p = (void *) &(valuelist->at(i));

				void * obj = getPointerObject(p);
				if (obj == 0) {
					smokeqyoto_object * o = alloc_smokeqyoto_object(false, m->smoke(), ix, p);
					obj = set_obj_info(className, o);
				}
				(*AddIntPtrToList)(al, obj);
			}

			m->var().s_voidp = al;
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

DEF_VALUELIST_MARSHALLER( QTableWidgetSelectionRangeList, QList<QTableWidgetSelectionRange>, QTableWidgetSelectionRange )
DEF_VALUELIST_MARSHALLER( QTextLayoutFormatRangeList, QList<QTextLayout::FormatRange>, QTextLayout::FormatRange)
DEF_VALUELIST_MARSHALLER( QVariantList, QList<QVariant>, QVariant )
DEF_VALUELIST_MARSHALLER( QPixmapList, QList<QPixmap>, QPixmap )
DEF_VALUELIST_MARSHALLER( QModelIndexList, QList<QModelIndex>, QModelIndex )
DEF_VALUELIST_MARSHALLER( QHostAddressList, QList<QHostAddress>, QHostAddress )
DEF_VALUELIST_MARSHALLER( QPolygonFList, QList<QPolygonF>, QPolygonF )
DEF_VALUELIST_MARSHALLER( QImageTextKeyLangList, QList<QImageTextKeyLang>, QImageTextKeyLang )
DEF_VALUELIST_MARSHALLER( QUrlList, QList<QUrl>, QUrl )
DEF_VALUELIST_MARSHALLER( QFileInfoList, QFileInfoList, QFileInfo )
DEF_VALUELIST_MARSHALLER( QTextBlockList, QList<QTextBlock>, QTextBlock )

DEF_VALUELIST_MARSHALLER( QColorVector, QVector<QColor>, QColor )
DEF_VALUELIST_MARSHALLER( QRgbVector, QVector<QRgb>, QRgb )
DEF_VALUELIST_MARSHALLER( QVariantVector, QVector<QVariant>, QVariant )
DEF_VALUELIST_MARSHALLER( QTextFormatVector, QVector<QTextFormat>, QTextFormat )
DEF_VALUELIST_MARSHALLER( QTextLengthVector, QVector<QTextLength>, QTextLength )
DEF_VALUELIST_MARSHALLER( QPointFVector, QVector<QPointF>, QPointF )
DEF_VALUELIST_MARSHALLER( QPointVector, QVector<QPoint>, QPoint )
DEF_VALUELIST_MARSHALLER( QLineVector, QVector<QLine>, QLine )
DEF_VALUELIST_MARSHALLER( QLineFVector, QVector<QLineF>, QLineF )
DEF_VALUELIST_MARSHALLER( QRectVector, QVector<QRect>, QRect )
DEF_VALUELIST_MARSHALLER( QRectFVector, QVector<QRectF>, QRectF )


TypeHandler Qt_handlers[] = {
    { "QString", marshall_QString },
    { "QString&", marshall_QString },
    { "QString*", marshall_QString },
    { "int&", marshall_intR },
    { "int*", marshall_intR },
    { "char*", marshall_charP },
    { "char**", marshall_charP_array },
    { "QDBusVariant", marshall_QDBusVariant },
    { "QDBusVariant&", marshall_QDBusVariant },
    { "QStringList", marshall_QStringList },
    { "QStringList&", marshall_QStringList },
    { "QStringList*", marshall_QStringList },
//    { "void**", marshall_voidP_array },
    { "QList<int>", marshall_QListInt },
    { "QList<int>&", marshall_QListInt },
    { "QList<QTableWidgetSelectionRange>", marshall_QTableWidgetSelectionRangeList },
    { "QList<QTextLayout::FormatRange>", marshall_QTextLayoutFormatRangeList },
    { "QList<QTextLayout::FormatRange>&", marshall_QTextLayoutFormatRangeList },
    { "QList<QTextBlock>", marshall_QTextBlockList },
    { "QList<QPolygonF>", marshall_QPolygonFList },
    { "QList<QHostAddress>", marshall_QHostAddressList },
    { "QList<QHostAddress>&", marshall_QHostAddressList },
    { "QList<QVariant>", marshall_QVariantList },
    { "QList<QVariant>&", marshall_QVariantList },
    { "QVariantList&", marshall_QVariantList },
    { "QList<QPixmap>", marshall_QPixmapList },
    { "QList<QModelIndex>", marshall_QModelIndexList },
    { "QList<QModelIndex>&", marshall_QModelIndexList },
    { "QModelIndexList&", marshall_QModelIndexList },
    { "QModelIndexList", marshall_QModelIndexList },
    { "QList<QImageTextKeyLang>", marshall_QImageTextKeyLangList },
    { "QList<QUrl>", marshall_QUrlList },
    { "QList<QUrl>&", marshall_QUrlList },
    { "QVector<QPointF>", marshall_QPointFVector },
    { "QVector<QPointF>&", marshall_QPointFVector },
    { "QVector<QPoint>", marshall_QPointVector },
    { "QVector<QPoint>&", marshall_QPointVector },
    { "QVector<QLine>", marshall_QLineVector },
    { "QVector<QLine>&", marshall_QLineVector },
    { "QVector<QLineF>", marshall_QLineFVector },
    { "QVector<QLineF>&", marshall_QLineFVector },
    { "QVector<QRect>", marshall_QRectVector },
    { "QVector<QRect>&", marshall_QRectVector },
    { "QVector<QRectF>", marshall_QRectFVector },
    { "QVector<QRectF>&", marshall_QRectFVector },
    { "QVector<QColor>", marshall_QColorVector },
    { "QVector<QColor>&", marshall_QColorVector },
    { "QVector<QRgb>", marshall_QRgbVector },
    { "QVector<QRgb>&", marshall_QRgbVector },
    { "QVector<QVariant>", marshall_QVariantVector },
    { "QVector<QVariant>&", marshall_QVariantVector },
    { "QVector<QTextFormat>", marshall_QTextFormatVector },
    { "QVector<QTextFormat>&", marshall_QTextFormatVector },
    { "QVector<QTextLength>", marshall_QTextLengthVector },
    { "QVector<QTextLength>&", marshall_QTextLengthVector },
    { "QMap<int,QVariant>", marshall_QMapintQVariant },
    { "QMap<QString,QString>", marshall_QMapQStringQString },
    { "QMap<QString,QString>&", marshall_QMapQStringQString },
    { "QMap<QString,QVariant>", marshall_QMapQStringQVariant },
    { "QMap<QString,QVariant>&", marshall_QMapQStringQVariant },
    { "QList<QTextFrame*>", marshall_QTextFrameList },
    { "QList<QAction*>", marshall_QActionList },
    { "QList<QWidget*>", marshall_QWidgetPtrList },
    { "QList<QTreeWidgetItem*>", marshall_QTreeWidgetItemList },
    { "QList<QTreeWidgetItem*>&", marshall_QTreeWidgetItemList },
    { "QList<QAbstractButton*>", marshall_QAbstractButtonList },
    { "QList<QListWidgetItem*>", marshall_QListWidgetItemList },
    { "QList<QListWidgetItem*>&", marshall_QListWidgetItemList },
    { "QList<QTableWidgetItem*>", marshall_QTableWidgetItemList },
    { "QList<QTableWidgetItem*>&", marshall_QTableWidgetItemList },
    { "QWidgetList", marshall_QWidgetList },
    { "QWidgetList&", marshall_QWidgetList },
    { "QObjectList", marshall_QObjectList },
    { "QObjectList&", marshall_QObjectList },
    { "QFileInfoList", marshall_QFileInfoList },
#if QT_VERSION >= 0x40200
    { "QList<QGraphicsItem*>", marshall_QGraphicsItemList },
    { "QList<QGraphicsItem*>&", marshall_QGraphicsItemList },
    { "QList<QStandardItem*>", marshall_QStandardItemList },
    { "QList<QStandardItem*>&", marshall_QStandardItemList },
    { "QList<QUndoStack*>", marshall_QUndoStackList },
    { "QList<QUndoStack*>&", marshall_QUndoStackList },
#endif
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
