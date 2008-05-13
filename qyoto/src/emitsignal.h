#ifndef EMIT_SIGNAL_H
#define EMIT_SIGNAL_H

#include <smoke.h>
#include "marshall.h"
#include "smokeqyoto.h"

class QObject;

class Q_DECL_EXPORT EmitSignal : public Marshall {
private:
	QObject *_qobj;
	int _id;
	MocArgument *_args;
	Smoke::StackItem * _sp;
	int _items;
	int _cur;
	Smoke::Stack _stack;
	bool _called;
public:
	EmitSignal(QObject *qobj, int id, int items, MocArgument * args, Smoke::StackItem *sp);

	~EmitSignal();

	inline const MocArgument &arg() { return _args[_cur + 1]; }
	inline SmokeType type() { return arg().st; }
	inline Marshall::Action action() { return Marshall::FromObject; }
	inline Smoke::StackItem &item() { return _stack[_cur]; }
	inline Smoke::StackItem &var() { return _sp[_cur + 1]; }

	void unsupported();

	inline Smoke *smoke() { return type().smoke(); }

	void emitSignal();

	void next();

	inline bool cleanup() { return true; }
};

#endif // EMIT_SIGNAL_H
