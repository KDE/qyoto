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

#define DEF_QLIST_MARSHALLER(ItemStr, Item) \
	Marshall::HandlerFn marshall_QList_##ItemStr = marshall_QList<Item>;

#define DEF_QVECTOR_MARSHALLER(ItemStr, Item) \
	Marshall::HandlerFn marshall_QVector_##ItemStr = marshall_QVector<Item>;

#define DEF_QMAP_MARSHALLER(KeyStr, ValueStr, Key, Value) \
	Marshall::HandlerFn marshall_QMap_##KeyStr##_##ValueStr = marshall_QMap<Key, Value>;

#include <QtDebug>

class QListInternal
{
public:
	struct Node {
		void* v;
	};

	union { QListData p; QListData::Data *d; };

	void append(void* ptr, size_t size) {
		if (size > sizeof(void*))
			reinterpret_cast<Node*>(p.append())->v = ptr;
		else
			memcpy(p.append(), ptr, size);
	}

	void* at(int i, size_t size) {
		if (size > sizeof(void*))
			return reinterpret_cast<Node*>(p.at(i))->v;
		else
			return p.at(i);
	}
};

template <class Item>
void marshall_QList(Marshall *m) {
	QByteArray typeName = m->type().name();
	typeName.remove(0, typeName.indexOf('<') + 1);
	typeName.remove(typeName.lastIndexOf('>'), typeName.length() - typeName.lastIndexOf('>'));
	
	QByteArray className(typeName);
	className.replace("*", "").replace("&", "");
	
	bool pointer = typeName.contains("*");
	
	switch(m->action()) {
		case Marshall::FromObject:
		{
			if (!m->var().s_class) {
				m->item().s_class = 0;
				return;
			}
			
			QList<void*> *cpplist = new QList<void*>;
			QListInternal* l = (QListInternal*) cpplist; // get the private stuff
			QList<void*>* list = (QList<void*>*) (*ListToPointerList)(m->var().s_voidp);
			
			foreach (void* gchandle, *list) {
				smokeqyoto_object * o = (smokeqyoto_object*) (*GetSmokeObject)(gchandle);
				void* ptr = o->ptr;
				o->smoke->cast(ptr, o->classId, o->smoke->idClass(className).index);
				
				if(pointer)  // we have a pointer type, so we can simply add it to the QList<void*>
					cpplist->append(ptr);
				else {
					cpplist->detach();
					l->append(ptr, sizeof(Item));  // otherwise make use of the internals
				}
				
				(*FreeGCHandle)(gchandle);
			}
			
			m->item().s_voidp = cpplist;
			m->next();
			
			delete list;
			(*FreeGCHandle)(m->var().s_voidp);
			if (m->cleanup())
				delete cpplist;
		}
		break;
		
		case Marshall::ToObject:
		{
			QList<void*> *list = (QList<void*>*) m->item().s_voidp;
			if (!list) break;
			QListInternal* l = (QListInternal*) list; // get the private stuff
			
			Smoke::ModuleIndex ix = m->smoke()->findClass(className);
			const char* csharpClassName = qyoto_modules[ix.smoke].binding->className(ix.index);
			void* al = (*ConstructList)(csharpClassName);
			
			for (int i = 0; i < list->size(); i++) {
				void* p = pointer? list->at(i) : l->at(i, sizeof(Item));
				void* obj = (*GetInstance)(p, true);
				if (!obj) {
					smokeqyoto_object* o = alloc_smokeqyoto_object(false, ix.smoke, ix.index, p);
					obj = (*CreateInstance)(qyoto_resolve_classname(o), o);
				}
				(*AddIntPtrToList)(al, obj);
				(*FreeGCHandle)(obj);
			}
			
			m->var().s_voidp = al;
			m->next();

			if (m->cleanup())
				delete list;
		}
		break;
		
		default:
			m->unsupported();
		break;
	}
}

struct _QVectorTypedData
{
	QBasicAtomicInt ref;
	int alloc;
	int size;
#if defined(Q_OS_SOLARIS) && defined(Q_CC_GNU) && defined(__LP64__) && defined(QT_BOOTSTRAPPED)
	// workaround for bug in gcc 3.4.2
	uint sharable;
	uint capacity;
#else
	uint sharable : 1;
	uint capacity : 1;
#endif
	void* array[1];
};

class QVectorInternal
{
public:
	union { QVectorData* p; _QVectorTypedData *d; };
};

template <class Item>
void marshall_QVector(Marshall *m) {
	QByteArray typeName = m->type().name();
	typeName.remove(0, typeName.indexOf('<') + 1);
	typeName.remove(typeName.lastIndexOf('>'), typeName.length() - typeName.lastIndexOf('>'));
	
	QByteArray className(typeName);
	className.replace("*", "").replace("&", "");
	
	bool pointer = typeName.contains("*");
	
	switch(m->action()) {
		case Marshall::FromObject:
		{
			if (!m->var().s_class) {
				m->item().s_class = 0;
				return;
			}
			
			QVector<void*> *cpplist = new QVector<void*>;
			QVectorInternal* v = (QVectorInternal*) cpplist; // get the private stuff
			QList<void*>* list = (QList<void*>*) (*ListToPointerList)(m->var().s_voidp);
			
			if (!pointer) {
				int s = list->size();
				v->p = QVectorData::malloc(sizeof(QVectorData) + sizeof(Item), s, sizeof(Item), v->p);
				v->p->alloc = v->p->size = s;
			}
			
			int i = 0;
			foreach(void* gchandle, *list) {
				smokeqyoto_object * o = (smokeqyoto_object*) (*GetSmokeObject)(gchandle);
				void* ptr = o->ptr;
				o->smoke->cast(ptr, o->classId, o->smoke->idClass(className).index);
				
				if(pointer)  // we have a pointer type, so we can simply add it to the QList<void*>
					cpplist->append(ptr);
				else
					memcpy(((char*) v->d->array) + sizeof(Item) * i, ptr, sizeof(Item));  // otherwise make use of the internals
				
				(*FreeGCHandle)(gchandle);
				i++;
			}
			
			m->item().s_voidp = cpplist;
			m->next();
			
			delete list;
			(*FreeGCHandle)(m->var().s_voidp);
			if (m->cleanup())
				delete cpplist;
		}
		break;
		
		case Marshall::ToObject:
		{
			QVector<void*> *vector = (QVector<void*>*) m->item().s_voidp;
			if (!vector) break;
			QVectorInternal* v = (QVectorInternal*) vector; // get the private stuff
			
			Smoke::ModuleIndex ix = m->smoke()->findClass(className);
			const char* csharpClassName = qyoto_modules[ix.smoke].binding->className(ix.index);
			void* al = (*ConstructList)(csharpClassName);
			
			for (int i = 0; i < vector->size(); i++) {
				void* p = pointer? vector->at(i) : ((char*) v->d->array) + i * sizeof(Item);
				void* obj = (*GetInstance)(p, true);
				if (!obj) {
					smokeqyoto_object* o = alloc_smokeqyoto_object(false, ix.smoke, ix.index, p);
					obj = (*CreateInstance)(qyoto_resolve_classname(o), o);
				}
				(*AddIntPtrToList)(al, obj);
				(*FreeGCHandle)(obj);
			}
			
			m->var().s_voidp = al;
			m->next();

			if (m->cleanup())
				delete vector;
		}
		break;
		
		default:
			m->unsupported();
		break;
	}
}

class QMapInternal
{
public:
	union {
		QMapData *d;
		QMapData::Node *e;
	};
	
	static inline void *key(QMapData::Node *node, size_t keysize, size_t valuesize) {
		return reinterpret_cast<char *>(node) - keysize - valuesize;
	}
	static inline void *value(QMapData::Node *node, size_t valuesize) {
		return reinterpret_cast<char *>(node) - valuesize;
	}
	inline void append(void* key, size_t keysize, void* value, size_t valuesize) {
		QMapData::Node* update[QMapData::LastLevel + 1];
		QMapData::Node* node = d->node_create(update, keysize + valuesize);
		memcpy(this->key(node, keysize, valuesize), key, keysize);
		memcpy(this->value(node, valuesize), value, valuesize);
	}
};

template <class Key, class Value>
void marshall_QMap(Marshall *m) {
	QByteArray typeName = m->type().name();
	typeName.remove(0, typeName.indexOf('<') + 1);
	typeName.remove(typeName.lastIndexOf('>'), typeName.length() - typeName.lastIndexOf('>'));
	
	QByteArray keyType = typeName.left(typeName.indexOf(','));
	QByteArray valueType = typeName.right(typeName.length() - typeName.indexOf(',') - 1);
	qDebug() << keyType << valueType;
	
	bool keyIsPointer = keyType.contains("*");
	bool valueIsPointer = valueType.contains("*");
	
	QByteArray keyClass(keyType);
	keyClass.replace("*", "").replace("&", "");
	QByteArray valueClass(valueType);
	valueClass.replace("*", "").replace("&", "");
	m->unsupported();
	return;

#if 0
	switch(m->action()) {
		case Marshall::FromObject:
		{
			if (!m->var().s_class) {
				m->item().s_class = 0;
				return;
			}
			
			QMap<void*, void*> *map = new QMap<void*, void*>;
			QMapInternal* m = (QMapInternal*) map; // get the private stuff
			QList<void*>* list = (QList<void*>*) (*ListToPointerList)(m->var().s_voidp);
			
			if (!pointer) {
				int s = list->size();
				v->p = QVectorData::malloc(sizeof(QVectorData) + sizeof(Item), s, sizeof(Item), v->p);
				v->p->alloc = v->p->size = s;
			}
			
			int i = 0;
			foreach(void* gchandle, *list) {
				smokeqyoto_object * o = (smokeqyoto_object*) (*GetSmokeObject)(gchandle);
				void* ptr = o->ptr;
				o->smoke->cast(ptr, o->classId, o->smoke->idClass(className).index);
				
				if(pointer)  // we have a pointer type, so we can simply add it to the QList<void*>
					cpplist->append(ptr);
				else
					memcpy(((char*) v->d->array) + sizeof(Item) * i, ptr, sizeof(Item));  // otherwise make use of the internals
				
				(*FreeGCHandle)(gchandle);
				i++;
			}
			
			m->item().s_voidp = cpplist;
			m->next();
			
			delete list;
			(*FreeGCHandle)(m->var().s_voidp);
			if (m->cleanup())
				delete cpplist;
		}
		break;
		
		case Marshall::ToObject:
		{
			QVector<void*> *vector = (QVector<void*>*) m->item().s_voidp;
			if (!vector) break;
			QVectorInternal* v = (QVectorInternal*) vector; // get the private stuff
			
			Smoke::ModuleIndex ix = m->smoke()->findClass(className);
			const char* csharpClassName = qyoto_modules[ix.smoke].binding->className(ix.index);
			void* al = (*ConstructList)(csharpClassName);
			
			for (int i = 0; i < vector->size(); i++) {
				void* p = pointer? vector->at(i) : ((char*) v->d->array) + i * sizeof(Item);
				void* obj = (*GetInstance)(p, true);
				if (!obj) {
					smokeqyoto_object* o = alloc_smokeqyoto_object(false, ix.smoke, ix.index, p);
					obj = (*CreateInstance)(qyoto_resolve_classname(o), o);
				}
				(*AddIntPtrToList)(al, obj);
				(*FreeGCHandle)(obj);
			}
			
			m->var().s_voidp = al;
			m->next();

			if (m->cleanup())
				delete vector;
		}
		break;
		
		default:
			m->unsupported();
		break;
	}
#endif
}

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
			if (!list) {
				m->item().s_class = 0;
				return;
			}
			
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
			if (!list) {
				m->item().s_class = 0;
				return;
			}

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
