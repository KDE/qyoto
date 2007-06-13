/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

#include <QtCore/qbytearray.h>
#include <QtCore/qdir.h>
#include <QtCore/qhash.h>
#include <QtCore/qlinkedlist.h>
#include <QtCore/qmetaobject.h>
#include <QtCore/qobject.h>
#include <QtCore/qpair.h>
#include <QtCore/qprocess.h>
#include <QtCore/qrect.h>
#include <QtCore/qregexp.h>
#include <QtCore/qstring.h>
#include <QtCore/qtextcodec.h>
#include <QtCore/qurl.h>
#include <QtGui/qabstractbutton.h>
#include <QtGui/qaction.h>
#include <QtGui/qapplication.h>
#include <QtGui/qdockwidget.h>
#include <QtGui/qevent.h>
#include <QtGui/qlayout.h>
#include <QtGui/qlistwidget.h>
#include <QtGui/qpainter.h>
#include <QtGui/qpalette.h>
#include <QtGui/qpixmap.h>
#include <QtGui/qpolygon.h>
#include <QtGui/qtabbar.h>
#include <QtGui/qtablewidget.h>
#include <QtGui/qtextlayout.h>
#include <QtGui/qtextobject.h>
#include <QtGui/qtoolbar.h>
#include <QtGui/qtreewidget.h>
#include <QtGui/qwidget.h>
#include <QtNetwork/qhostaddress.h>
#include <QtNetwork/qnetworkinterface.h>
#include <QtNetwork/qurlinfo.h>

#if QT_VERSION >= 0x40200
#include <QtGui/qgraphicsitem.h>
#include <QtGui/qgraphicsscene.h>
#include <QtGui/qstandarditemmodel.h>
#include <QtGui/qundostack.h>
#endif

#if QT_VERSION >= 0x40300
#include <QtGui/qmdisubwindow.h>
#include <QtNetwork/qsslcertificate.h>
#include <QtNetwork/qsslcipher.h>
#include <QtNetwork/qsslerror.h>
#include <QtXml/qxmlstream.h>
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
static GetIntPtr ListUIntToQListQRgb;
static CreateListFn ConstructList;
static SetIntPtr AddIntPtrToList;
static AddInt AddIntToListInt;
static AddUInt AddUIntToListUInt;
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

void InstallConstructList(CreateListFn callback)
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

void InstallListUIntToQListQRgb(GetIntPtr callback)
{
	ListUIntToQListQRgb = callback;
}

void InstallAddUIntToListUInt(AddUInt callback)
{
	AddUIntToListUInt = callback;
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
	QVariant* variant = (QVariant*) ((smokeqyoto_object*) (*GetSmokeObject)(qv))->ptr;
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
	QVariant* variant = (QVariant*) ((smokeqyoto_object*) (*GetSmokeObject)(qv))->ptr;
	map->insert(QString(str), *variant);
}

void* ConstructQListQRgb()
{
	return (void*) new QList<QRgb>;
}

void AddUIntToQListQRgb(void* ptr, uint i)
{
	QList<QRgb>* list = (QList<QRgb>*) ptr;
	list->append(i);
}

};

extern bool isDerivedFromByName(Smoke *smoke, const char *className, const char *baseClassName);
extern void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr);

bool
IsContainedInstance(smokeqyoto_object *o)
{
    const char *className = o->smoke->classes[o->classId].className;
		
	if (	qstrcmp(className, "QListBoxItem") == 0
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
		// Don't garbage collect custom subclasses of QWidget classes for now
		const QMetaObject * meta = qwidget->metaObject();
		Smoke::Index classId = o->smoke->idClass(meta->className());
		return (classId == 0);
	} else if (isDerivedFromByName(o->smoke, className, "QObject")) {
		QObject * qobject = (QObject *) o->smoke->cast(o->ptr, o->classId, o->smoke->idClass("QObject"));
		if (qobject->parent() != 0) {
			return true;
		}
	} else if (isDerivedFromByName(o->smoke, className, "QTextBlockUserData")) {
		return true;
	} else if (isDerivedFromByName(o->smoke, className, "QGraphicsItem")) {
		return true;
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
		QObject * qobject = (QObject *) smoke->cast(ptr, classId, smoke->idClass("QObject"));
		const QMetaObject * meta = qobject->metaObject();

		if (strcmp(smoke->classes[classId].className, "QAbstractItemModel") == 0)
			return "Qyoto.QItemModel";
		if (strcmp(smoke->classes[classId].className, "QAbstractButton") == 0)
			return "Qyoto.QAbstractButtonInternal";
		if (strcmp(smoke->classes[classId].className, "QAbstractProxyModel") == 0)
			return "Qyoto.QAbstractProxyModelInternal";
		if (strcmp(smoke->classes[classId].className, "QAbstractItemDelegate") == 0)
			return "Qyoto.QAbstractItemDelegateInternal";
		if (strcmp(smoke->classes[classId].className, "QAbstractItemView") == 0)
			return "Qyoto.QAbstractItemViewInternal";
		if (strcmp(smoke->classes[classId].className, "QAbstractTextDocumentLayout") == 0)
			return "Qyoto.QAbstractTextDocumentLayoutInternal";

		while (meta != 0) {
			Smoke::Index classId = smoke->idClass(meta->className());
			if (classId != 0) {
				return smoke->binding->className(classId);
			}

			meta = meta->superClass();
		}
	} else if (isDerivedFromByName(smoke, smoke->classes[classId].className, "QGraphicsItem")) {
		QGraphicsItem * item = (QGraphicsItem *) smoke->cast(ptr, classId, smoke->idClass("QGraphicsItem"));
		switch (item->type()) {
		case 1:
			return "Qyoto.QGraphicsItem";
		case 2:
			return "Qyoto.QGraphicsPathItem";
		case 3:
			return "Qyoto.QGraphicsRectItem";
		case 4:
			return "Qyoto.QGraphicsEllipseItem";
		case 5:
			return "Qyoto.QGraphicsPolygonItem";
		case 6:
			return "Qyoto.QGraphicsLineItem";
		case 7:
			return "Qyoto.QGraphicsPixmapItem";
		case 8:
			return "Qyoto.QGraphicsTextItem";
		case 9:
			return "Qyoto.QGraphicsSimpleTextItem";
		case 10:
			return "Qyoto.QGraphicsItemGroup";
		default:
			return "Qyoto.QGraphicsItem";
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
	return (type.name() && qstrcmp(type.name(), argtype) == 0);
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
		void * obj = m->var().s_voidp;
		if (obj == 0) {
			m->item().s_class = 0;
			return;
		}

		smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
		if (!o || !o->ptr) {
			if (m->type().isRef()) {
				m->unsupported();
			}
		    m->item().s_class = 0;
		    break;
		}

		void *ptr = o->ptr;
		if (!m->cleanup() && m->type().isStack()) {
		    ptr = construct_copy(o);
		}
		const Smoke::Class &c = m->smoke()->classes[m->type().classId()];
		ptr = o->smoke->cast(
		    ptr,				// pointer
		    o->classId,				// from
		    o->smoke->idClass(c.className)	// to
		);
		m->item().s_class = ptr;
		(*FreeGCHandle)(obj);
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
		void * obj = (*GetInstance)(p, true);
		if(obj != 0) {
			m->var().s_voidp = obj;
		    break;
		}

		smokeqyoto_object  * o = alloc_smokeqyoto_object(false, m->smoke(), m->type().classId(), p);
		const char * classname = resolve_classname(o->smoke, o->classId, o->ptr);

		if(m->type().isConst() && m->type().isRef()) {
			p = construct_copy( o );
			if (p != 0) {
				o->ptr = p;
				o->allocated = true;
		    }
		}
		
		obj = (*CreateInstance)(classname, o);
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
			(*FreeGCHandle)(m->var().s_voidp);
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
	    
		if (s && m->cleanup()) {
			delete s;
		}

		(*FreeGCHandle)(m->var().s_voidp);
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
		m->item().s_voidp = &(m->var().s_int);
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

/*
static void marshall_intR(Marshall *m) {
	switch(m->action()) {
	case Marshall::FromObject:
	{
		m->item().s_voidp = &(m->var().s_int);
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
*/

static void marshall_shortR(Marshall *m) {
	switch(m->action()) {
	case Marshall::FromObject:
	{
		m->item().s_voidp = &(m->var().s_short);
	}
	break;

	case Marshall::ToObject:
	{
		short *ip = (short*)m->item().s_voidp;
		m->var().s_short = *ip;
	}
	break;

	default:
		m->unsupported();
		break;
	}
}

static void marshall_doubleR(Marshall *m) {
    switch(m->action()) {
	case Marshall::FromObject:
	{
		m->item().s_voidp = &(m->var().s_double);
	}
	break;

	case Marshall::ToObject:
	{
		double *dp = (double*)m->item().s_voidp;
		m->var().s_double = *dp;
	}
	break;

	default:
		m->unsupported();
		break;
	}
}

static void marshall_boolR(Marshall *m) {
    switch(m->action()) {
	case Marshall::FromObject:
	{
		m->item().s_voidp = &(m->var().s_bool);
	}
	break;

	case Marshall::ToObject:
	{
		bool *dp = (bool*)m->item().s_voidp;
		m->var().s_bool = *dp;
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
//            char ** temp = (char **) m->item().s_voidp;
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
			(*FreeGCHandle)(m->var().s_class);
			return;
		}

		smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(m->var().s_class);
		if (!o || !o->ptr) {
			if (m->type().isRef()) {
				m->unsupported();
			}
		    m->item().s_class = 0;
		    break;
		}
		m->item().s_class = o->ptr;
		(*FreeGCHandle)(m->var().s_class);
		break;
	}

	case Marshall::ToObject: 
	{
		if (m->item().s_voidp == 0) {
			m->var().s_voidp = 0;
		    break;
		}

		void *p = m->item().s_voidp;
		void * obj = (*GetInstance)(p, true);
		if(obj != 0) {
			m->var().s_voidp = obj;
		    break;
		}
		smokeqyoto_object  * o = alloc_smokeqyoto_object(false, m->smoke(), m->smoke()->idClass("QVariant"), p);
		
		obj = (*CreateInstance)("Qyoto.QDBusVariant", o);
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
			(*FreeGCHandle)(m->var().s_voidp);
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
				void* value = (*CreateInstance)("Qyoto.QVariant", vo);
				(*AddIntObjectToDictionary)(dict, i.key(), value);
				(*FreeGCHandle)(value);
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
			(*FreeGCHandle)(m->var().s_voidp);
			break;
		}

		case Marshall::ToObject: 
		{
			QMap<QString, QString>* map = (QMap<QString, QString>*) m->item().s_voidp;
			void* dict = (*ConstructDictionary)("System.String", "System.String");
			
			for (QMap<QString, QString>::iterator i = map->begin(); i != map->end(); ++i) {
				void* string1 = (void*) StringFromQString((void*) &(i.key()));
				void* string2 = (void*) StringFromQString((void*) &(i.value()));
				(*AddObjectObjectToDictionary)(	dict,
								string1,
								string2);
				(*FreeGCHandle)(string1);
				(*FreeGCHandle)(string2);
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
			(*FreeGCHandle)(m->var().s_voidp);
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
				void* value = (*CreateInstance)("Qyoto.QVariant", vo);
				void* string = (void*) StringFromQString((void*) &(i.key()));
				(*AddObjectObjectToDictionary)(	dict,
								string,
								value);
				(*FreeGCHandle)(string);
				(*FreeGCHandle)(value);
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
			(*FreeGCHandle)(m->var().s_voidp);
	   
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
			
			for (int i = 0; i < list->size(); ++i) {
				void* obj = list->at(i);
				smokeqyoto_object * o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
				
				void* ptr = o->ptr;
				ptr = o->smoke->cast(
					ptr,                            // pointer
					o->classId,                             // from
					o->smoke->idClass(ItemSTR)              // to
				);
				
				cpplist->append((Item*) ptr);
				(*FreeGCHandle)(obj);
			}
			
			m->item().s_voidp = cpplist;
			m->next();
			
			delete list;
			(*FreeGCHandle)(m->var().s_voidp);
			
			if (m->cleanup()) {
				delete cpplist;
			}
		}
		break;
      
		case Marshall::ToObject:
		{
			ItemList *list = (ItemList*)m->item().s_voidp;
			if (list == 0) {
				break;
			}

			int ix = m->smoke()->idClass(ItemSTR);
			const char * className = m->smoke()->binding->className(ix);
			
			void * al = (*ConstructList)(className);
			
			for (int i=0; i < list->size() ; ++i) {
				void *p = (void *) list->at(i);
				void * obj = (*GetInstance)(p, true);
				if (obj == 0) {
					smokeqyoto_object * o = alloc_smokeqyoto_object(false, m->smoke(), ix, p);
					obj = (*CreateInstance)(resolve_classname(o->smoke, o->classId, o->ptr), o);
				}
				(*AddIntPtrToList)(al, obj);
				(*FreeGCHandle)(obj);
			}

			m->var().s_voidp = al;
			m->next();

			if (m->cleanup()) {
				delete list;
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

	    (*FreeGCHandle)(m->var().s_voidp);

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
DEF_LIST_MARSHALLER( QActionGroupList, QList<QActionGroup*>, QActionGroup )
DEF_LIST_MARSHALLER( QActionList, QList<QAction*>, QAction )
DEF_LIST_MARSHALLER( QListWidgetItemList, QList<QListWidgetItem*>, QListWidgetItem )
DEF_LIST_MARSHALLER( QObjectList, QList<QObject*>, QObject )
DEF_LIST_MARSHALLER( QTableWidgetList, QList<QTableWidget*>, QTableWidget )
DEF_LIST_MARSHALLER( QTableWidgetItemList, QList<QTableWidgetItem*>, QTableWidgetItem )
DEF_LIST_MARSHALLER( QTextFrameList, QList<QTextFrame*>, QTextFrame )
DEF_LIST_MARSHALLER( QTreeWidgetItemList, QList<QTreeWidgetItem*>, QTreeWidgetItem )
DEF_LIST_MARSHALLER( QTreeWidgetList, QList<QTreeWidget*>, QTreeWidget )
DEF_LIST_MARSHALLER( QWidgetList, QList<QWidget*>, QWidget )
DEF_LIST_MARSHALLER( QWidgetPtrList, QList<QWidget*>, QWidget )

#if QT_VERSION >= 0x40200
DEF_LIST_MARSHALLER( QGraphicsItemList, QList<QGraphicsItem*>, QGraphicsItem )
DEF_LIST_MARSHALLER( QStandardItemList, QList<QStandardItem*>, QStandardItem )
DEF_LIST_MARSHALLER( QUndoStackList, QList<QUndoStack*>, QUndoStack )
#endif

#if QT_VERSION >= 0x40300
DEF_LIST_MARSHALLER( QMdiSubWindowList, QList<QMdiSubWindow*>, QMdiSubWindow )
#endif

template <class Item, class ItemList, const char *ItemSTR >
void marshall_ValueListItem(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject:
		{
			ItemList *cpplist = new ItemList;
			QList<void*>* list = (QList<void*>*) (*ListToPointerList)(m->var().s_voidp);

			for (int i = 0; i < list->size(); ++i) {
				void* obj = list->at(i);
				smokeqyoto_object * o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
				
				void* ptr = o->ptr;
				ptr = o->smoke->cast(
					ptr,                            // pointer
					o->classId,                             // from
					o->smoke->idClass(ItemSTR)              // to
				);
				
				cpplist->append(*(Item*) ptr);
				(*FreeGCHandle)(obj);
			}
			
			m->item().s_voidp = cpplist;
			m->next();
			
			delete list;
			(*FreeGCHandle)(m->var().s_voidp);

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
				void * obj = (*GetInstance)(p, true);

				if (obj == 0) {
					smokeqyoto_object * o = alloc_smokeqyoto_object(false, m->smoke(), ix, p);
					obj = (*CreateInstance)(resolve_classname(o->smoke, o->classId, o->ptr), o);
				}

				(*AddIntPtrToList)(al, obj);
				(*FreeGCHandle)(obj);
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

void marshall_QRgbVector(Marshall *m)
{
	switch(m->action()) {
		case Marshall::FromObject:
		{
			QList<QRgb>* cpplist = (QList<QRgb>*) (*ListUIntToQListQRgb)(m->var().s_voidp);
			m->item().s_voidp = cpplist;
			m->next();
			
			(*FreeGCHandle)(m->var().s_voidp);

			if (m->cleanup()) {
				delete cpplist;
			}
		}
		break;
      
		case Marshall::ToObject:
		{
			QList<QRgb> *valuelist = (QList<QRgb>*) m->item().s_voidp;
			if (valuelist == 0) {
				break;
			}

			void * al = (*ConstructList)("System.UInt32");

			for (int i=0; i < valuelist->size() ; ++i) {
				(*AddUIntToListUInt)(al, valuelist->at(i));
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


DEF_VALUELIST_MARSHALLER( QByteArrayList, QList<QByteArray>, QByteArray )
DEF_VALUELIST_MARSHALLER( QColorVector, QVector<QColor>, QColor )
DEF_VALUELIST_MARSHALLER( QFileInfoList, QFileInfoList, QFileInfo )
// DEF_VALUELIST_MARSHALLER( QHostAddressList, QList<QHostAddress>, QHostAddress )
DEF_VALUELIST_MARSHALLER( QImageTextKeyLangList, QList<QImageTextKeyLang>, QImageTextKeyLang )
DEF_VALUELIST_MARSHALLER( QKeySequenceList, QList<QKeySequence>, QKeySequence )
DEF_VALUELIST_MARSHALLER( QLineFVector, QVector<QLineF>, QLineF )
DEF_VALUELIST_MARSHALLER( QLineVector, QVector<QLine>, QLine )
DEF_VALUELIST_MARSHALLER( QModelIndexList, QList<QModelIndex>, QModelIndex )
DEF_VALUELIST_MARSHALLER( QNetworkAddressEntryList, QList<QNetworkAddressEntry>, QNetworkAddressEntry )
DEF_VALUELIST_MARSHALLER( QNetworkInterfaceList, QList<QNetworkInterface>, QNetworkInterface )
DEF_VALUELIST_MARSHALLER( QPixmapList, QList<QPixmap>, QPixmap )
DEF_VALUELIST_MARSHALLER( QPointFVector, QVector<QPointF>, QPointF )
DEF_VALUELIST_MARSHALLER( QPointVector, QVector<QPoint>, QPoint )
DEF_VALUELIST_MARSHALLER( QPolygonFList, QList<QPolygonF>, QPolygonF )
DEF_VALUELIST_MARSHALLER( QRectFList, QList<QRectF>, QRectF )
DEF_VALUELIST_MARSHALLER( QRectFVector, QVector<QRectF>, QRectF )
DEF_VALUELIST_MARSHALLER( QRectVector, QVector<QRect>, QRect )
// DEF_VALUELIST_MARSHALLER( QRgbVector, QVector<QRgb>, QRgb )
DEF_VALUELIST_MARSHALLER( QTableWidgetSelectionRangeList, QList<QTableWidgetSelectionRange>, QTableWidgetSelectionRange )
DEF_VALUELIST_MARSHALLER( QTextBlockList, QList<QTextBlock>, QTextBlock )
DEF_VALUELIST_MARSHALLER( QTextFormatVector, QVector<QTextFormat>, QTextFormat )
DEF_VALUELIST_MARSHALLER( QTextLayoutFormatRangeList, QList<QTextLayout::FormatRange>, QTextLayout::FormatRange)
DEF_VALUELIST_MARSHALLER( QTextLengthVector, QVector<QTextLength>, QTextLength )
DEF_VALUELIST_MARSHALLER( QUrlList, QList<QUrl>, QUrl )
DEF_VALUELIST_MARSHALLER( QVariantList, QList<QVariant>, QVariant )
DEF_VALUELIST_MARSHALLER( QVariantVector, QVector<QVariant>, QVariant )

#if QT_VERSION >= 0x40300
DEF_VALUELIST_MARSHALLER( QSslCertificateList, QList<QSslCertificate>, QSslCertificate )
DEF_VALUELIST_MARSHALLER( QSslCipherList, QList<QSslCipher>, QSslCipher )
DEF_VALUELIST_MARSHALLER( QSslErrorList, QList<QSslError>, QSslError )
DEF_VALUELIST_MARSHALLER( QXmlStreamEntityDeclarations, QVector<QXmlStreamEntityDeclaration>, QXmlStreamEntityDeclaration )
DEF_VALUELIST_MARSHALLER( QXmlStreamNamespaceDeclarations, QVector<QXmlStreamNamespaceDeclaration>, QXmlStreamNamespaceDeclaration )
DEF_VALUELIST_MARSHALLER( QXmlStreamNotationDeclarations, QVector<QXmlStreamNotationDeclaration>, QXmlStreamNotationDeclaration )
#endif

TypeHandler Qt_handlers[] = {
    { "bool*", marshall_boolR },
    { "bool&", marshall_boolR },
    { "char*", marshall_charP },
    { "char**", marshall_charP_array },
    { "double*", marshall_doubleR },
    { "double&", marshall_doubleR },
    { "int*", marshall_intR },
    { "int&", marshall_intR },
    { "QDBusVariant", marshall_QDBusVariant },
    { "QDBusVariant&", marshall_QDBusVariant },
    { "QFileInfoList", marshall_QFileInfoList },
    { "QList<int>", marshall_QListInt },
    { "QList<int>&", marshall_QListInt },
    { "QList<QAbstractButton*>", marshall_QAbstractButtonList },
    { "QList<QActionGroup*>", marshall_QActionGroupList },
    { "QList<QAction*>", marshall_QActionList },
    { "QList<QAction*>&", marshall_QActionList },
    { "QList<QByteArray>", marshall_QByteArrayList },
    { "QList<QByteArray>*", marshall_QByteArrayList },
    { "QList<QByteArray>&", marshall_QByteArrayList },
   // { "QList<QHostAddress>", marshall_QHostAddressList },
   // { "QList<QHostAddress>&", marshall_QHostAddressList },
    { "QList<QImageTextKeyLang>", marshall_QImageTextKeyLangList },
    { "QList<QKeySequence>", marshall_QKeySequenceList },
    { "QList<QKeySequence>&", marshall_QKeySequenceList },
    { "QList<QListWidgetItem*>", marshall_QListWidgetItemList },
    { "QList<QListWidgetItem*>&", marshall_QListWidgetItemList },
    { "QList<QMdiSubWindow*>", marshall_QMdiSubWindowList },
    { "QList<QModelIndex>", marshall_QModelIndexList },
    { "QList<QModelIndex>&", marshall_QModelIndexList },
    { "QList<QNetworkAddressEntry>", marshall_QNetworkAddressEntryList },
    { "QList<QNetworkInterface>", marshall_QNetworkInterfaceList },
    { "QList<QPixmap>", marshall_QPixmapList },
    { "QList<QPolygonF>", marshall_QPolygonFList },
    { "QList<QRectF>", marshall_QRectFList },
    { "QList<QRectF>&", marshall_QRectFList },
    { "QList<QStandardItem*>", marshall_QStandardItemList },
    { "QList<QStandardItem*>&", marshall_QStandardItemList },
    { "QList<QTableWidgetItem*>", marshall_QTableWidgetItemList },
    { "QList<QTableWidgetItem*>&", marshall_QTableWidgetItemList },
    { "QList<QTableWidgetSelectionRange>", marshall_QTableWidgetSelectionRangeList },
    { "QList<QTextBlock>", marshall_QTextBlockList },
    { "QList<QTextFrame*>", marshall_QTextFrameList },
    { "QList<QTextLayout::FormatRange>", marshall_QTextLayoutFormatRangeList },
    { "QList<QTextLayout::FormatRange>&", marshall_QTextLayoutFormatRangeList },
    { "QList<QTreeWidgetItem*>", marshall_QTreeWidgetItemList },
    { "QList<QTreeWidgetItem*>&", marshall_QTreeWidgetItemList },
    { "QList<QTreeWidget*>&", marshall_QTreeWidgetList },
    { "QList<QUndoStack*>", marshall_QUndoStackList },
    { "QList<QUndoStack*>&", marshall_QUndoStackList },
    { "QList<QUrl>", marshall_QUrlList },
    { "QList<QUrl>&", marshall_QUrlList },
    { "QList<QVariant>", marshall_QVariantList },
    { "QList<QVariant>&", marshall_QVariantList },
    { "QList<QWidget*>", marshall_QWidgetPtrList },
    { "QList<QWidget*>&", marshall_QWidgetPtrList },
    { "QMap<int,QVariant>", marshall_QMapintQVariant },
    { "QMap<QString,QString>", marshall_QMapQStringQString },
    { "QMap<QString,QString>&", marshall_QMapQStringQString },
    { "QMap<QString,QVariant>", marshall_QMapQStringQVariant },
    { "QMap<QString,QVariant>&", marshall_QMapQStringQVariant },
    { "QModelIndexList", marshall_QModelIndexList },
    { "QModelIndexList&", marshall_QModelIndexList },
    { "QObjectList", marshall_QObjectList },
    { "QObjectList&", marshall_QObjectList },
    { "qreal*", marshall_doubleR },
    { "qreal&", marshall_doubleR },
    { "QStringList", marshall_QStringList },
    { "QStringList*", marshall_QStringList },
    { "QStringList&", marshall_QStringList },
    { "QString", marshall_QString },
    { "QString*", marshall_QString },
    { "QString&", marshall_QString },
    { "QVariantList&", marshall_QVariantList },
    { "QVector<QColor>", marshall_QColorVector },
    { "QVector<QColor>&", marshall_QColorVector },
    { "QVector<QLineF>", marshall_QLineFVector },
    { "QVector<QLineF>&", marshall_QLineFVector },
    { "QVector<QLine>", marshall_QLineVector },
    { "QVector<QLine>&", marshall_QLineVector },
    { "QVector<QPointF>", marshall_QPointFVector },
    { "QVector<QPointF>&", marshall_QPointFVector },
    { "QVector<QPoint>", marshall_QPointVector },
    { "QVector<QPoint>&", marshall_QPointVector },
    { "QVector<QRectF>", marshall_QRectFVector },
    { "QVector<QRectF>&", marshall_QRectFVector },
    { "QVector<QRect>", marshall_QRectVector },
    { "QVector<QRect>&", marshall_QRectVector },
    { "QVector<QRgb>", marshall_QRgbVector },
    { "QVector<QRgb>&", marshall_QRgbVector },
    { "QVector<QTextFormat>", marshall_QTextFormatVector },
    { "QVector<QTextFormat>&", marshall_QTextFormatVector },
    { "QVector<QTextLength>", marshall_QTextLengthVector },
    { "QVector<QTextLength>&", marshall_QTextLengthVector },
    { "QVector<QVariant>", marshall_QVariantVector },
    { "QVector<QVariant>&", marshall_QVariantVector },
    { "QWidgetList", marshall_QWidgetList },
    { "QWidgetList&", marshall_QWidgetList },
    { "short*", marshall_shortR },
    { "short&", marshall_shortR },
//    { "void**", marshall_voidP_array },
#if QT_VERSION >= 0x40200
    { "QList<QGraphicsItem*>", marshall_QGraphicsItemList },
    { "QList<QGraphicsItem*>&", marshall_QGraphicsItemList },
    { "QList<QStandardItem*>", marshall_QStandardItemList },
    { "QList<QStandardItem*>&", marshall_QStandardItemList },
    { "QList<QUndoStack*>", marshall_QUndoStackList },
    { "QList<QUndoStack*>&", marshall_QUndoStackList },
#endif
#if QT_VERSION >= 0x40300
    { "QList<QMdiSubWindow*>", marshall_QMdiSubWindowList },
    { "QList<QSslCertificate>", marshall_QSslCertificateList },
    { "QList<QSslCertificate>&", marshall_QSslCertificateList },
    { "QList<QSslCipher>", marshall_QSslCipherList },
    { "QList<QSslCipher>&", marshall_QSslCipherList },
    { "QList<QSslError>&", marshall_QSslErrorList },
    { "QXmlStreamEntityDeclarations", marshall_QXmlStreamEntityDeclarations },
    { "QXmlStreamNamespaceDeclarations", marshall_QXmlStreamNamespaceDeclarations },
    { "QXmlStreamNotationDeclarations", marshall_QXmlStreamNotationDeclarations },
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
	if (type.elem())
		return marshall_basetype;
	if (!type.name())
		return marshall_void;
	TypeHandler *h = type_handlers[type.name()];
	if (h == 0 && type.isConst() && strlen(type.name()) > strlen("const ")) {
    	h = type_handlers[type.name() + strlen("const ")];
	}
	
	if(h != 0) {
		return h->fn;
	}

	return marshall_unknown;
}
