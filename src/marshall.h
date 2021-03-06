#ifndef MARSHALL_H
#define MARSHALL_H

#include <smoke.h>

class SmokeType;

class Marshall {
public:
    /**
     * FromObject is used for virtual function return values and regular
     * method arguments.
     *
     * ToObject is used for method return-values and virtual function
     * arguments.
     */
    typedef void (*HandlerFn)(Marshall *);
    enum Action { FromObject, ToObject };
    virtual SmokeType type() = 0;
    virtual Action action() = 0;
    virtual Smoke::StackItem &item() = 0;
    virtual Smoke::StackItem &var() = 0;
    virtual void unsupported() = 0;
    virtual Smoke *smoke() = 0;
    /**
     * For return-values, next() does nothing.
     * For FromObject, next() calls the method and returns.
     * For ToObject, next() calls the virtual function and returns.
     *
     * Required to reset Marshall object to the state it was
     * before being called when it returns.
     */
    virtual void next() = 0;
    /**
     * For FromObject, cleanup() returns false when the handler should free
     * any allocated memory after next().
     *
     * For ToObject, cleanup() returns true when the handler should delete
     * the pointer passed to it.
     */
    virtual bool cleanup() = 0;

    virtual ~Marshall() {}
};    
#endif
