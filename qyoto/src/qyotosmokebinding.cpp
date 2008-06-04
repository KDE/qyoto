/***************************************************************************
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004 by Richard Dale
    email                : Richard_Dale@tipitina.demon.co.uk
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 ***************************************************************************/

#include "qyotosmokebinding.h"
#include "qyoto.h"
#include "virtualmethodcall.h"

#include <cstdlib>

QyotoSmokeBinding::QyotoSmokeBinding(Smoke *s, QHash<int, char*> *classname) : SmokeBinding(s), _classname(classname) {}

void
QyotoSmokeBinding::deleted(Smoke::Index classId, void *ptr)
{
	void * obj = (*GetInstance)(ptr, true);
	if (obj == 0) {
		return;
	}

	smokeqyoto_object *o = (smokeqyoto_object*) (*GetSmokeObject)(obj);

	if (do_debug & qtdb_gc) {
		printf("%p->~%s()\n", ptr, smoke->className(classId));
		fflush(stdout);
	}

	if (o == 0 || o->ptr == 0) {
		(*FreeGCHandle)(obj);
		return;
	}
	unmapPointer(o, o->classId, 0);
	(*SetSmokeObject)(obj, 0);
	free_smokeqyoto_object(o);
	(*FreeGCHandle)(obj);
}

bool
QyotoSmokeBinding::callMethod(Smoke::Index method, void *ptr, Smoke::Stack args, bool isAbstract)
{
	// don't call anything if the application has already terminated
	if (application_terminated) return false;
	void * obj = (*GetInstance)(ptr, false);

	if (obj == 0 && !isAbstract) {
		return false;
	}

	Smoke::Method & meth = smoke->methods[method];
	QByteArray signature(smoke->methodNames[meth.name]);
	signature += "(";

	for (int i = 0; i < meth.numArgs; i++) {
		if (i != 0) signature += ", ";
		signature += smoke->types[smoke->argumentList[meth.args + i]].name;
	}

	signature += ")";
	if (meth.flags & Smoke::mf_const) {
		signature += " const";
	}

	if (obj == 0) {
		printf(	"Fatal error: C# instance has been wrongly GC'd for virtual %p->%s::%s call\n", 
					ptr,
					smoke->classes[smoke->methods[method].classId].className,
					(const char *) signature );
			std::exit(1);
	}
		if (do_debug & qtdb_virtual) {
		printf(	"virtual %p->%s::%s called\n", 
					ptr,
					smoke->classes[smoke->methods[method].classId].className,
					(const char *) signature );
		fflush(stdout);
	}

	if (strcmp(signature, "qt_metacall(QMetaObject::Call, int, void**)") == 0) {
		QMetaObject::Call _c = (QMetaObject::Call)args[1].s_int;
		int _id = args[2].s_int;
		void** _o = (void**)args[3].s_voidp;
		
		args[0].s_int = qt_metacall(obj, _c, _id, _o);

		(*FreeGCHandle)(obj);
		return true;
	}
	void * overridenMethod = (*OverridenMethod)(obj, (const char *) signature);
	if (overridenMethod == 0) {
		(*FreeGCHandle)(obj);
		return false;
	}

	VirtualMethodCall c(smoke, method, args, obj, overridenMethod);
	c.next();
	return true;
}

char*
QyotoSmokeBinding::className(Smoke::Index classId)
{
	return _classname->value((int) classId);
}
