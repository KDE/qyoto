#ifndef DELEGATEINVOCATION_H
#define DELEGATEINVOCATION_H

#include <QtCore/qbytearray.h>
#include <QtCore/qlist.h>
#include <QtCore/qobject.h>
#include <QtCore/qmetaobject.h>
#include <QtCore/qvariant.h>

#include "marshall.h"
#include "qyoto.h"

/* adapted from QSignalSpy in testlib/qsignalspy.h */
class DelegateInvocation : public QObject, public Marshall
{
public:
    DelegateInvocation(QObject *obj, const char *aSignal, void *delegate)
        : QObject(obj), _delegate(delegate), _cur(-1)
    {
#ifdef Q_CC_BOR
        const int memberOffset = QObject::staticMetaObject.methodCount();
#else
        static const int memberOffset = QObject::staticMetaObject.methodCount();
#endif
        Q_ASSERT(obj);
        Q_ASSERT(aSignal);

        if (aSignal[0] - '0' != QSIGNAL_CODE) {
            qWarning("QSignalSpy: Not a valid signal, use the SIGNAL macro");
            return;
        }

        QByteArray ba = QMetaObject::normalizedSignature(aSignal + 1);
        const QMetaObject *mo = obj->metaObject();
        int sigIndex = mo->indexOfMethod(ba.constData());
        if (sigIndex < 0) {
            qWarning("QSignalSpy: No such signal: '%s'", ba.constData());
            return;
        }

        if (!QMetaObject::connect(obj, sigIndex, this, memberOffset,
                    Qt::DirectConnection, 0)) {
            qWarning("QSignalSpy: QMetaObject::connect returned false. Unable to connect.");
            return;
        }
        sig = ba;
        _mocargs = GetMocArgumentsNumber("", sig, _items);
        _sp = new Smoke::StackItem[_items];
        _stack = new Smoke::StackItem[_items];
    }

    ~DelegateInvocation() {
        delete[] _stack;
        delete[] _sp;
        delete[] _mocargs;
    }

    inline bool isValid() const { return !sig.isEmpty(); }
    inline QByteArray signal() const { return sig; }


    int qt_metacall(QMetaObject::Call call, int id, void **a)
    {
        id = QObject::qt_metacall(call, id, a);
        if (id < 0)
            return id;

        if (call == QMetaObject::InvokeMetaMethod) {
            if (id == 0) {
                smokeStackFromQtStack(_stack, a + 1, _items, _mocargs + 1);
                next();
                (*InvokeDelegate)(_delegate, _sp);
            }
            --id;
        }
        return id;
    }

	inline const MocArgument &arg() { return _mocargs[_cur + 1]; }
	inline SmokeType type() { return arg().st; }
	inline Marshall::Action action() { return Marshall::ToObject; }
	inline Smoke::StackItem &item() { return _stack[_cur]; }
	inline Smoke::StackItem &var() { return _sp[_cur]; }
	inline Smoke *smoke() { return type().smoke(); }

	inline bool cleanup() { return false; }
	inline void unsupported() { qFatal("Cannot handle '%s' as slot argument\n", type().name()); }

	void next() {
		int oldcur = _cur;
		_cur++;

		while (_cur < _items) {
			Marshall::HandlerFn fn = getMarshallFn(type());
			(*fn)(this);
			_cur++;
		}

		_cur = oldcur;
	}

private:
    // the full, normalized signal name
    QByteArray sig;

    MocArgument *_mocargs;
    void *_delegate;
    int _cur;
    int _items;
    Smoke::Stack _sp;
    Smoke::Stack _stack;
};

#endif
