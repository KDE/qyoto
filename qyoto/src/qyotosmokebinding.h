#ifndef QYOTO_SMOKE_BINDING_H
#define QYOTO_SMOKE_BINDING_H

#include <smoke.h>
#include <QHash>

class Q_DECL_EXPORT QyotoSmokeBinding : public SmokeBinding {
protected:
	QHash<int, char*> *_classname;
public:
	QyotoSmokeBinding(Smoke *s, QHash<int, char*> *classname);
	void deleted(Smoke::Index classId, void *ptr);
	bool callMethod(Smoke::Index method, void *ptr, Smoke::Stack args, bool isAbstract);
	char *className(Smoke::Index classId);
};

#endif // QYOTO_SMOKE_BINDING_H
