#include <ksharedptr.h>
#include <cstdio>

template<class Item, const char *ItemSTR>
void marshall_KSharedPtr(Marshall *m) {
	switch(m->action()) {
	case Marshall::FromObject:
	{
		if (m->var().s_class == 0) {
			m->item().s_class = 0;
			(*FreeGCHandle)(m->var().s_class);
			return;
		}

		smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(m->var().s_class);
		if (o == 0 || o->ptr == 0) {
			if (m->type().isRef()) {
				m->unsupported();
			}
		    m->item().s_class = 0;
		    break;
		}
		m->item().s_class = new KSharedPtr<Item>((Item*) o->ptr);
		(*FreeGCHandle)(m->var().s_class);
		break;
	}
	case Marshall::ToObject:
	{
		if (m->item().s_voidp == 0) {
			m->var().s_voidp = 0;
		    break;
		}

		KSharedPtr<Item> *ptr = new KSharedPtr<Item>(*(KSharedPtr<Item>*)m->item().s_voidp);
		if (ptr == 0) {
			m->var().s_voidp = 0;
			break;
		}
	    Item * config = ptr->data();

		void * obj = (*GetInstance)(config, true);
		if(obj != 0) {
			m->var().s_voidp = obj;
		    break;
		}
		
		Smoke::ModuleIndex id = m->smoke()->findClass(ItemSTR);
		smokeqyoto_object  * o = alloc_smokeqyoto_object(false, id.smoke, id.index, config);
		const char *resolved = qyoto_modules[id.smoke].resolve_classname(o);
		obj = (*CreateInstance)(resolved, o);
		if (do_debug & qtdb_calls) {
			printf("allocating %s %p -> %p\n", ItemSTR, o->ptr, (void*)obj);
		}

		if (m->type().isStack()) {
// 		    o->allocated = true;
			// Keep a mapping of the pointer so that it is only wrapped once
		    mapPointer(obj, o, o->classId, 0);
		}
		
		m->var().s_class = obj;
		break;
	}
	default:
		m->unsupported();
		break;
	}
}

#define DEF_KSHAREDPTR_MARSHALLER(Item, ItemSTR) namespace { char ItemSTR##STR[] = #Item; }  \
        Marshall::HandlerFn marshall_KSharedPtr_##ItemSTR = marshall_KSharedPtr<Item,ItemSTR##STR>;
