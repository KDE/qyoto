/***************************************************************************
                       modelfunctions.cpp  -  description
                             -------------------
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004 by Richard Dale <Richard_Dale@tipitina.demon.co.uk>
                           (C) 2009 by Arno Rehn <arno@arnorehn.de>
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU Lesser General Public License as        *
 *   published by the Free Software Foundation; either version 2 of the    *
 *   License, or (at your option) any later version.                       *
 *                                                                         *
 ***************************************************************************/

#include <QAbstractItemDelegate>
#include <QAbstractItemView>
#include <QAbstractProxyModel>
#include <QAbstractTextDocumentLayout>
#include <QModelIndex>

#include "qyoto.h"
#include "callbacks.h"

extern "C" {

Q_DECL_EXPORT void *
ModelIndexInternalPointer(void *obj)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    QModelIndex *modelIndex = (QModelIndex*) o->ptr;
    void *ptr = modelIndex->internalPointer();
    (*FreeGCHandle)(obj);
    return ptr;
}

Q_DECL_EXPORT void *
AbstractItemModelCreateIndex(void* obj, int row, int column, void *ptr)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);

    Smoke::Index method = FindMethodId((char*) "QAbstractItemModel", (char*) "createIndex$$$", (char*) "(int, int, void*) const").index;
    if (method == -1) {
        return 0;
    }
    Smoke::Method &methodId = o->smoke->methods[method];
    Smoke::ClassFn fn = o->smoke->classes[methodId.classId].classFn;
    Smoke::StackItem i[4];
    i[1].s_int = row;
    i[2].s_int = column;
    i[3].s_voidp = ptr;
    (*fn)(methodId.method, o->ptr, i);

    if (i[0].s_voidp == 0) {
        return 0;
    }

    int id = o->smoke->idClass("QModelIndex").index;
    smokeqyoto_object *ret = alloc_smokeqyoto_object(true, o->smoke, id, i[0].s_voidp);
    (*FreeGCHandle)(obj);
    return (*CreateInstance)("Qyoto.QModelIndex", ret);
}

Q_DECL_EXPORT void *
QAbstractItemModelParent(void* obj, void * modelIndex)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(modelIndex);
    QModelIndex ix = ((QAbstractItemModel*) o->ptr)->parent(*(((QModelIndex*) i->ptr)));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(modelIndex);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(   true,
                                                        o->smoke,
                                                        o->smoke->idClass("QModelIndex").index,
                                                        new QModelIndex(ix) );
    return (*CreateInstance)("Qyoto.QModelIndex", ret);
}

Q_DECL_EXPORT int
QAbstractItemModelColumnCount(void* obj, void * modelIndex)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(modelIndex);
    int result = ((QAbstractItemModel*) o->ptr)->columnCount(*(((QModelIndex*) i->ptr)));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(modelIndex);
    return result;
}

Q_DECL_EXPORT int
QAbstractItemModelRowCount(void* obj, void * modelIndex)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(modelIndex);
    int result = ((QAbstractItemModel*) o->ptr)->rowCount(*(((QModelIndex*) i->ptr)));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(modelIndex);
    return result;
}

Q_DECL_EXPORT void*
QAbstractItemModelData(void* obj, void * modelIndex, int role)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(modelIndex);
    QVariant result = ((QAbstractItemModel*) o->ptr)->data(*(((QModelIndex*) i->ptr)), role);
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(modelIndex);
    smokeqyoto_object * ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QVariant").index, &result);
    return (*CreateInstance)("Qyoto.QVariant", ret);
}

Q_DECL_EXPORT void*
QAbstractItemModelIndex(void* obj, int row, int column, void * modelIndex)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(modelIndex);
    QModelIndex result = ((QAbstractItemModel*) o->ptr)->index(row, column, *(((QModelIndex*) i->ptr)));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(modelIndex);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QModelIndex").index, &result);
    return (*CreateInstance)("Qyoto.QModelIndex", ret);
}

Q_DECL_EXPORT void*
QAbstractProxyModelMapFromSource(void* obj, void* sourceIndex)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(sourceIndex);
    QModelIndex result = ((QAbstractProxyModel*) o->ptr)->mapFromSource(*(((QModelIndex*) i->ptr)));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(sourceIndex);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QModelIndex").index, &result);
    return (*CreateInstance)("Qyoto.QModelIndex", ret);
}

Q_DECL_EXPORT void*
QAbstractProxyModelMapToSource(void* obj, void* proxyIndex)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(proxyIndex);
    QModelIndex result = ((QAbstractProxyModel*) o->ptr)->mapToSource(*(((QModelIndex*) i->ptr)));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(proxyIndex);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QModelIndex").index, &result);
    return (*CreateInstance)("Qyoto.QModelIndex", ret);
}

Q_DECL_EXPORT void
QAbstractItemDelegatePaint(void* obj, void* painter, void* option, void* index)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *p = (smokeqyoto_object*) (*GetSmokeObject)(painter);
    smokeqyoto_object *opt = (smokeqyoto_object*) (*GetSmokeObject)(option);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(index);
    ((QAbstractItemDelegate*) o->ptr)->paint((QPainter*) p->ptr, *((QStyleOptionViewItem*) opt->ptr),
                        *(((QModelIndex*) i->ptr)));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(painter);
    (*FreeGCHandle)(option);
    (*FreeGCHandle)(index);
}

Q_DECL_EXPORT void*
QAbstractItemDelegateSizeHint(void* obj, void* option, void* index)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *opt = (smokeqyoto_object*) (*GetSmokeObject)(option);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(index);
    QSize result = ((QAbstractItemDelegate*) o->ptr)->sizeHint(*((QStyleOptionViewItem*) opt->ptr),
                                    *(((QModelIndex*) i->ptr)));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(option);
    (*FreeGCHandle)(index);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QSize").index, &result);
    return (*CreateInstance)("Qyoto.QSize", ret);
}

Q_DECL_EXPORT void*
QAbstractItemViewIndexAt(void* obj, void* point)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *p = (smokeqyoto_object*) (*GetSmokeObject)(point);
    QModelIndex result = ((QAbstractItemView*) o->ptr)->indexAt(*((QPoint*) p->ptr));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(point);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QModelIndex").index, &result);
    return (*CreateInstance)("Qyoto.QModelIndex", ret);
}

Q_DECL_EXPORT void
QAbstractItemViewScrollTo(void* obj, void* index, int hint)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(index);
    ((QAbstractItemView*) o->ptr)->scrollTo(*((QModelIndex*) i->ptr), (QAbstractItemView::ScrollHint) hint);
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(index);
}

Q_DECL_EXPORT void*
QAbstractItemViewVisualRect(void* obj, void* index)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *i = (smokeqyoto_object*) (*GetSmokeObject)(index);
    QRect result = ((QAbstractItemView*) o->ptr)->visualRect(*((QModelIndex*) i->ptr));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(index);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QRect").index, &result);
    return (*CreateInstance)("Qyoto.QRect", ret);
}

Q_DECL_EXPORT void*
QAbstractTextDocumentLayoutBlockBoundingRect(void* obj, void* block)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *b = (smokeqyoto_object*) (*GetSmokeObject)(block);
    QRectF result = ((QAbstractTextDocumentLayout*) o->ptr)->blockBoundingRect(*((QTextBlock*) b->ptr));
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(block);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QRectF").index, &result);
    return (*CreateInstance)("Qyoto.QRectF", ret);
}

Q_DECL_EXPORT void*
QAbstractTextDocumentLayoutDocumentSize(void* obj)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    QSizeF result = ((QAbstractTextDocumentLayout*) o->ptr)->documentSize();
    (*FreeGCHandle)(obj);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QSizeF").index, &result);
    return (*CreateInstance)("Qyoto.QSizeF", ret);
}

Q_DECL_EXPORT void*
QAbstractTextDocumentLayoutFrameBoundingRect(void* obj, void* frame)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *f = (smokeqyoto_object*) (*GetSmokeObject)(frame);
    QRectF result = ((QAbstractTextDocumentLayout*) o->ptr)->frameBoundingRect((QTextFrame*) f->ptr);
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(frame);
    smokeqyoto_object *ret = alloc_smokeqyoto_object(false, o->smoke, o->smoke->idClass("QRectF").index, &result);
    return (*CreateInstance)("Qyoto.QRectF", ret);
}

Q_DECL_EXPORT int
QAbstractTextDocumentLayoutHitTest(void* obj, void* point, int accuracy)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    smokeqyoto_object *p = (smokeqyoto_object*) (*GetSmokeObject)(point);
    int result = ((QAbstractTextDocumentLayout*) o->ptr)->hitTest(*((QPointF*) p->ptr), (Qt::HitTestAccuracy) accuracy);
    (*FreeGCHandle)(obj);
    (*FreeGCHandle)(point);
    return result;
}

Q_DECL_EXPORT int
QAbstractTextDocumentLayoutPageCount(void* obj)
{
    smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
    int result = ((QAbstractTextDocumentLayout*) o->ptr)->pageCount();
    (*FreeGCHandle)(obj);
    return result;
}

}
