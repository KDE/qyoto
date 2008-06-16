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
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

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
			const char * className = ix.smoke->binding->className(ix.index);
			
			void * al = (*ConstructList)(className);
			
			for (int i=0; i < list->size() ; ++i) {
				void *p = (void *) list->at(i);
				void * obj = (*GetInstance)(p, true);
				if (obj == 0) {
					smokeqyoto_object * o = alloc_smokeqyoto_object(false, ix.smoke, ix.index, p);
					obj = (*CreateInstance)(resolve_classname(o), o);
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
				break;
			}

			Smoke::ModuleIndex ix = m->smoke()->findClass(ItemSTR);
			const char * className = ix.smoke->binding->className(ix.index);
			
			void * al = (*ConstructList)(className);

			for (int i=0; i < valuelist->size() ; ++i) {
				void *p = (void *) &(valuelist->at(i));
				void * obj = (*GetInstance)(p, true);

				if (obj == 0) {
					smokeqyoto_object * o = alloc_smokeqyoto_object(false, ix.smoke, ix.index, p);
					obj = (*CreateInstance)(resolve_classname(o), o);
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

#define DEF_VALUELIST_MARSHALLER(ListIdent,ItemList,Item) namespace { char ListIdent##STR[] = #Item; }  \
        Marshall::HandlerFn marshall_##ListIdent = marshall_ValueListItem<Item,ItemList,ListIdent##STR>;
