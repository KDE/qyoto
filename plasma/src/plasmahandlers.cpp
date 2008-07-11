/***************************************************************************
                 plasmahandlers.cpp  -  Plasma specific marshallers
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

#include <qyoto.h>
#include <smokeqyoto.h>
#include <marshall_macros.h>

#include <plasma/packagestructure.h>
#include <plasma/containment.h>
#include <plasma/applet.h>

/*
void marshall_PackageStructurePtr(Marshall *m) {
	switch(m->action()) {
	case Marshall::FromVALUE: 
		{
		}
		break;
	case Marshall::ToVALUE: 
		{
		KSharedPtr<Plasma::PackageStructure> *ptr = new KSharedPtr<Plasma::PackageStructure>(*(KSharedPtr<Plasma::PackageStructure>*)m->item().s_voidp);
	    if(ptr == 0) {
		*(m->var()) = Qnil;
		break;
	    }
	    Plasma::PackageStructure * package = ptr->data();
	    
		VALUE obj = getPointerObject(package);
		if(obj == Qnil) {
		    smokeruby_object  * o = ALLOC(smokeruby_object);
		    o->smoke = m->smoke();
		    o->classId = m->smoke()->idClass("Plasma::PackageStructure").index;
		    o->ptr = package;
		    o->allocated = true;
		    obj = set_obj_info("Plasma::PackageStructure", o);
		}

	    *(m->var()) = obj;		
	    
		if(m->cleanup())
		;
		}
		break;
	default:
		m->unsupported();
		break;
	}
}
*/

void marshall_QHashQStringQVariant(Marshall *m) {
	switch(m->action()) {
		case Marshall::FromObject: 
		{
			if (m->var().s_class == 0) {
				m->item().s_class = 0;
				return;
			}
			QHash<QString, QVariant>* map = (QHash<QString, QVariant>*) (*DictionaryToQHash)(m->var().s_voidp, 2);
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
			QHash<QString, QVariant>* map = (QHash<QString, QVariant>*) m->item().s_voidp;
			void* dict = (*ConstructDictionary)("System.String", "Qyoto.QVariant");
			
			Smoke::ModuleIndex id = m->smoke()->findClass("QVariant");
			
			for (QHash<QString, QVariant>::iterator i = map->begin(); i != map->end(); ++i) {
				void* v = (void*) &(i.value());
				smokeqyoto_object * vo = alloc_smokeqyoto_object(false, id.smoke, id.index, v);
				void* value = (*CreateInstance)("Qyoto.QVariant", vo);
				void* string = (*IntPtrFromQString)((void*) &(i.key()));
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

DEF_LIST_MARSHALLER( PlasmaContainmentList, QList<Plasma::Containment*>, Plasma::Containment )
DEF_LIST_MARSHALLER( PlasmaAppletList, QList<Plasma::Applet*>, Plasma::Applet )

// DEF_HASH_MARSHALLER( QHashQStringApplet, Plasma::Applet )
// DEF_HASH_MARSHALLER( QHashQStringDataContainer, Plasma::DataContainer )
//DEF_HASH_MARSHALLER( QHashQStringDataEngine, Plasma::DataEngine )

TypeHandler Plasma_handlers[] = {
//    { "Plasma::PackageStructure::Ptr", marshall_PackageStructurePtr },
    { "QHash<QString,QVariant>", marshall_QHashQStringQVariant },
    { "QHash<QString,QVariant>&", marshall_QHashQStringQVariant },
    { "Plasma::DataEngine::Data", marshall_QHashQStringQVariant },
    { "Plasma::DataEngine::Data&", marshall_QHashQStringQVariant },
//    { "Plasma::DataEngine::SourceDict", marshall_QHashQStringDataContainer },
//    { "Plasma::DataEngine::Dict", marshall_QHashQStringDataEngine },
    { "QList<Plasma::Containment*>", marshall_PlasmaContainmentList },
    { "QList<Plasma::Containment*>&", marshall_PlasmaContainmentList },
    { "Plasma::Applet::List", marshall_PlasmaAppletList },
    { 0, 0 }
};
