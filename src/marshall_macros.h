/***************************************************************************
  marshall_macros.h  -  Useful template based marshallers for QLists, QVectors
                        and QLinkedLists
                             -------------------
    begin                : Sun Jun 15 2008
    copyright            : (C) 2008 by Richard Dale
    email                : richard.j.dale@gmail.com
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU Lesser General Public License as        *
 *   published by the Free Software Foundation; either version 2 of the    *
 *   License, or (at your option) any later version.                       *
 *                                                                         *
 ***************************************************************************/

#ifndef MARSHALL_MACROS_H
#define MARSHALL_MACROS_H

#include "callbacks.h"

template <class Item, class ItemList, const char *ItemSTR >
void marshall_ItemList(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject:
		{
			if (m->var().s_class == 0) {
				m->item().s_class = 0;
				return;
			}
			ItemList *cpplist = new ItemList;
			QList<void*>* list = (QList<void*>*) (*ListToPointerList)(m->var().s_voidp);
			
			for (int i = 0; i < list->size(); ++i) {
				void* obj = list->at(i);
				smokeqyoto_object * o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
				
				void* ptr = o->ptr;
				ptr = o->smoke->cast(
					ptr,                            // pointer
					o->classId,                             // from
					o->smoke->idClass(ItemSTR).index              // to
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

			Smoke::ModuleIndex ix = m->smoke()->findClass(ItemSTR);
			const char * className = qyoto_modules[ix.smoke].binding->className(ix.index);
			
			void * al = (*ConstructList)(className);
			
			for (int i=0; i < list->size() ; ++i) {
				void *p = (void *) list->at(i);
				void * obj = (*GetInstance)(p, true);
				if (obj == 0) {
					smokeqyoto_object * o = alloc_smokeqyoto_object(false, ix.smoke, ix.index, p);
					obj = (*CreateInstance)(qyoto_resolve_classname(o), o);
				}
				(*AddIntPtrToList)(al, obj);
				(*FreeGCHandle)(obj);
			}

			m->var().s_voidp = al;
			m->next();

			if (m->type().isStack()) {
				delete list;
			}
			

		}
		break;
      
		default:
			m->unsupported();
		break;
	}
}

#define DEF_LIST_MARSHALLER(ListIdent,ItemList,Item) namespace { char ListIdent##STR[] = #Item; }  \
        Marshall::HandlerFn marshall_##ListIdent = marshall_ItemList<Item,ItemList,ListIdent##STR>;

template <class Item, class ItemList, const char *ItemSTR >
void marshall_ValueListItem(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject:
		{
			if (m->var().s_class == 0) {
				m->item().s_class = 0;
				return;
			}
			ItemList *cpplist = new ItemList;
			QList<void*>* list = (QList<void*>*) (*ListToPointerList)(m->var().s_voidp);

			for (int i = 0; i < list->size(); ++i) {
				void* obj = list->at(i);
				smokeqyoto_object * o = (smokeqyoto_object*) (*GetSmokeObject)(obj);
				
				void* ptr = o->ptr;
				ptr = o->smoke->cast(
					ptr,                            // pointer
					o->classId,                             // from
					o->smoke->idClass(ItemSTR).index              // to
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
				m->var().s_voidp = 0;
				break;
			}

			Smoke::ModuleIndex ix = m->smoke()->findClass(ItemSTR);
			const char * className = qyoto_modules[ix.smoke].binding->className(ix.index);
			
			void * al = (*ConstructList)(className);

			for (int i=0; i < valuelist->size() ; ++i) {
				void *p = (void *) &(valuelist->at(i));
				void * obj = (*GetInstance)(p, true);

				if (obj == 0) {
					smokeqyoto_object * o = alloc_smokeqyoto_object(false, ix.smoke, ix.index, p);
					obj = (*CreateInstance)(qyoto_resolve_classname(o), o);
				}

				(*AddIntPtrToList)(al, obj);
				(*FreeGCHandle)(obj);
			}

			m->var().s_voidp = al;
			m->next();

			if (m->type().isStack()) {
				delete valuelist;
			}
			

		}
		break;
      
		default:
			m->unsupported();
		break;
	}
}

#define DEF_VALUELIST_MARSHALLER(ListIdent,ItemList,Item) namespace { char ListIdent##STR[] = #Item; }  \
        Marshall::HandlerFn marshall_##ListIdent = marshall_ValueListItem<Item,ItemList,ListIdent##STR>;

template <class Item1, class Item2, const char *Item1STR, const char *Item2STR,
          const char *Item1CliSTR, const char *Item2CliSTR >
void marshall_QPair(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject:
		{
			if (m->var().s_class == 0) {
				m->item().s_class = 0;
				return;
			}
			QPair<Item1, Item2> *pair = new QPair<Item1, Item2>();
			
			void *first = (*QPairGetFirst)(m->var().s_class);
			if (Smoke::classMap[Item1STR].smoke) {
				smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(first);
				if (o) pair->first = *(Item1*) o->ptr;
			} else {
				Smoke::StackItem item;
				(*UnboxToStackItem)(first, &item);
				// Smoke::StackItem is a union, so we can simply copy the data from 'item'
				// when we know the size of it.
				memcpy(&pair->first, &item, sizeof(Item1));
			}
			(*FreeGCHandle)(first);
			
			void *second = (*QPairGetSecond)(m->var().s_class);
			if (Smoke::classMap[Item2STR].smoke) {
				smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(second);
				if (o) pair->second = *(Item2*) o->ptr;
			} else {
				Smoke::StackItem item;
				(*UnboxToStackItem)(second, &item);
				memcpy(&pair->second, &item, sizeof(Item2));
			}
			(*FreeGCHandle)(second);
			
			m->item().s_voidp = pair;
			m->next();
			
			(*FreeGCHandle)(m->var().s_voidp);

			if (m->cleanup() || m->type().isStack()) {
				delete pair;
			}
		}
		break;
      
		case Marshall::ToObject:
		{
			QPair<Item1, Item2> *qpair = (QPair<Item1, Item2>*) m->item().s_voidp;
			if (qpair == 0) {
				m->var().s_voidp = 0;
				return;
			}

			void *first, *second;
			if (Smoke::classMap[Item1STR].smoke) {
				Smoke::ModuleIndex mi = m->smoke()->findClass(Item1STR);
				Item1 *copy = new Item1(qpair->first);
				smokeqyoto_object *o = alloc_smokeqyoto_object(true, mi.smoke, mi.index, copy);
				first = (*CreateInstance)(Item1CliSTR, o);
			} else {
				Smoke::StackItem item;
				memcpy(&item, &qpair->first, sizeof(Item1));
				first = (*BoxFromStackItem)(Item1CliSTR, &item);
			}
			
			if (Smoke::classMap[Item2STR].smoke) {
				Smoke::ModuleIndex mi = m->smoke()->findClass(Item2STR);
				Item2 *copy = new Item2(qpair->second);
				smokeqyoto_object *o = alloc_smokeqyoto_object(true, mi.smoke, mi.index, copy);
				second = (*CreateInstance)(Item2CliSTR, o);
			} else {
				Smoke::StackItem item;
				memcpy(&item, &qpair->second, sizeof(Item2));
				second = (*BoxFromStackItem)(Item2CliSTR, &item);
			}
			
			void *pair = (*CreateQPair)(first, second);
			(*FreeGCHandle)(first);
			(*FreeGCHandle)(second);
			
			m->var().s_voidp = pair;
			m->next();

			if (m->type().isStack()) {
				delete qpair;
			}
		}
		break;
      
		default:
			m->unsupported();
		break;
	}
}

#define DEF_QPAIR_MARSHALLER(PairIdent,Item1,Item2,Item1CLI,Item2CLI) \
        namespace { \
            char PairIdent##Item1STR[] = #Item1; char PairIdent##Item2STR[] = #Item2; \
            char PairIdent##Item1CliSTR[] = Item1CLI; char PairIdent##Item2CliSTR[] = Item2CLI; \
        }  \
        Marshall::HandlerFn marshall_##PairIdent = marshall_QPair<Item1,Item2,PairIdent##Item1STR,PairIdent##Item2STR, \
            PairIdent##Item1CliSTR,PairIdent##Item2CliSTR>;

#endif // MARSHALL_MACROS_H
