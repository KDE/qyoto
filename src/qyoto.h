#ifndef QYOTO_H
#define QYOTO_H

#include <qglobal.h>
#include <QHash>

#include "marshall.h"

#ifdef QYOTO_BUILDING
	#define QYOTO_EXPORT Q_DECL_EXPORT
#else
	#define QYOTO_EXPORT Q_DECL_IMPORT
#endif

class QMetaObject;

class SmokeBinding;

struct MocArgument;

struct smokeqyoto_object {
    void *ptr;
    bool allocated;
    Smoke *smoke;
    int classId;
};

struct TypeHandler {
    const char *name;
    Marshall::HandlerFn fn;
};

typedef const char* (*resolveClassNameFn)(smokeqyoto_object * o);
typedef bool (*IsContainedInstanceFn)(smokeqyoto_object *o);

struct QyotoModule {
    const char *name;
    resolveClassNameFn resolve_classname;
    IsContainedInstanceFn IsContainedInstance;
    SmokeBinding* binding;
};

// keep this enum in sync with Qyoto.cs

enum QtDebugChannel {
    qtdb_none = 0x00,
    qtdb_ambiguous = 0x01,
    qtdb_transparent_proxy = 0x02,
    qtdb_calls = 0x04,
    qtdb_gc = 0x08,
    qtdb_virtual = 0x10,
    qtdb_verbose = 0x20
};

typedef void * GCHandle;

extern QYOTO_EXPORT QHash<Smoke*, QyotoModule> qyoto_modules;

extern QYOTO_EXPORT int do_debug; // evil

extern QYOTO_EXPORT bool application_terminated;

extern QYOTO_EXPORT Marshall::HandlerFn getMarshallFn(const SmokeType &type);

extern QYOTO_EXPORT smokeqyoto_object* alloc_smokeqyoto_object(bool allocated, Smoke* smoke, int classId, void* ptr);

extern QYOTO_EXPORT void free_smokeqyoto_object(smokeqyoto_object* o);

extern QYOTO_EXPORT void mapPointer(void * obj, smokeqyoto_object *o, Smoke::Index classId, void *lastptr);
extern QYOTO_EXPORT void unmapPointer(smokeqyoto_object *, Smoke::Index, void *);

extern QYOTO_EXPORT bool IsContainedInstance(smokeqyoto_object *o);
extern QYOTO_EXPORT const char* qyoto_resolve_classname(smokeqyoto_object * o);

extern QYOTO_EXPORT QMetaObject* get_meta_object(const char* classname);
extern QYOTO_EXPORT void* construct_copy(smokeqyoto_object *o);

extern QYOTO_EXPORT void smokeStackToQtStack(Smoke::Stack stack, void ** o, int start, int end, QList<MocArgument*> args);
extern QYOTO_EXPORT void smokeStackFromQtStack(Smoke::Stack stack, void ** _o, int start, int end, QList<MocArgument*> args);

extern QYOTO_EXPORT void qyoto_install_handlers(TypeHandler *h);

extern QYOTO_EXPORT QList<MocArgument*> GetMocArguments(Smoke* smoke, const char * typeName, QList<QByteArray> methodTypes);

extern "C" {
extern QYOTO_EXPORT void SetDebug(int channel);
extern QYOTO_EXPORT int DebugChannel();

extern QYOTO_EXPORT void SetApplicationTerminated();

extern QYOTO_EXPORT Smoke::ModuleIndex FindMethodId(const char * classname, const char * mungedname, const char * signature);
}

#endif
