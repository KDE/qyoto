//Auto-generated by kalyptus. DO NOT EDIT.
namespace KParts {
    using Kimono;
    using System;
    using Qyoto;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Collections.Generic;
    /// <remarks>
    ///  An extension class for LiveConnect, i.e. a call from JavaScript
    ///  from a HTML page which embeds this part.
    ///  A part can have an object hierarchie by using objid as a reference
    ///  to an object.
    ///  </remarks>        <short>    An extension class for LiveConnect, i.</short>
    [SmokeClass("KParts::LiveConnectExtension")]
    public class LiveConnectExtension : QObject, IDisposable {
        protected LiveConnectExtension(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(LiveConnectExtension), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static LiveConnectExtension() {
            staticInterceptor = new SmokeInvocation(typeof(LiveConnectExtension), null);
        }
        public enum TypeOf {
            TypeVoid = 0,
            TypeBool = 1,
            TypeFunction = 2,
            TypeNumber = 3,
            TypeObject = 4,
            TypeString = 5,
        }
        public LiveConnectExtension(KParts.ReadOnlyPart parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("LiveConnectExtension#", "LiveConnectExtension(KParts::ReadOnlyPart*)", typeof(void), typeof(KParts.ReadOnlyPart), parent);
        }
        /// <remarks>
        ///  get a field value from objid, return true on success
        ///    </remarks>        <short>    get a field value from objid, return true on success    </short>
        [SmokeMethod("get(const unsigned long, const QString&, KParts::LiveConnectExtension::Type&, unsigned long&, QString&)")]
        public virtual bool Get(ulong objid, string field, KParts.LiveConnectExtension.TypeOf type, ref ulong retobjid, StringBuilder value) {
            StackItem[] stack = new StackItem[6];
            stack[1].s_ulong = objid;
#if DEBUG
            stack[2].s_class = (IntPtr) DebugGCHandle.Alloc(field);
#else
            stack[2].s_class = (IntPtr) GCHandle.Alloc(field);
#endif
            stack[3].s_int = (int) type;
            stack[4].s_ulong = retobjid;
#if DEBUG
            stack[5].s_class = (IntPtr) DebugGCHandle.Alloc(value);
#else
            stack[5].s_class = (IntPtr) GCHandle.Alloc(value);
#endif
            interceptor.Invoke("get$$$$$", "get(const unsigned long, const QString&, KParts::LiveConnectExtension::Type&, unsigned long&, QString&)", stack);
#if DEBUG
            DebugGCHandle.Free((GCHandle) stack[2].s_class);
#else
            ((GCHandle) stack[2].s_class).SynchronizedFree();
#endif
            retobjid = stack[4].s_ulong;
#if DEBUG
            DebugGCHandle.Free((GCHandle) stack[5].s_class);
#else
            ((GCHandle) stack[5].s_class).SynchronizedFree();
#endif
            return stack[0].s_bool;
        }
        /// <remarks>
        ///  put a field value in objid, return true on success
        ///    </remarks>        <short>    put a field value in objid, return true on success    </short>
        [SmokeMethod("put(const unsigned long, const QString&, const QString&)")]
        public virtual bool Put(ulong objid, string field, string value) {
            return (bool) interceptor.Invoke("put$$$", "put(const unsigned long, const QString&, const QString&)", typeof(bool), typeof(ulong), objid, typeof(string), field, typeof(string), value);
        }
        /// <remarks>
        ///  calls a function of objid, return true on success
        ///    </remarks>        <short>    calls a function of objid, return true on success    </short>
        [SmokeMethod("call(const unsigned long, const QString&, const QStringList&, KParts::LiveConnectExtension::Type&, unsigned long&, QString&)")]
        public virtual bool Call(ulong objid, string func, List<string> args, KParts.LiveConnectExtension.TypeOf type, ref ulong retobjid, StringBuilder value) {
            StackItem[] stack = new StackItem[7];
            stack[1].s_ulong = objid;
#if DEBUG
            stack[2].s_class = (IntPtr) DebugGCHandle.Alloc(func);
#else
            stack[2].s_class = (IntPtr) GCHandle.Alloc(func);
#endif
#if DEBUG
            stack[3].s_class = (IntPtr) DebugGCHandle.Alloc(args);
#else
            stack[3].s_class = (IntPtr) GCHandle.Alloc(args);
#endif
            stack[4].s_int = (int) type;
            stack[5].s_ulong = retobjid;
#if DEBUG
            stack[6].s_class = (IntPtr) DebugGCHandle.Alloc(value);
#else
            stack[6].s_class = (IntPtr) GCHandle.Alloc(value);
#endif
            interceptor.Invoke("call$$?$$$", "call(const unsigned long, const QString&, const QStringList&, KParts::LiveConnectExtension::Type&, unsigned long&, QString&)", stack);
#if DEBUG
            DebugGCHandle.Free((GCHandle) stack[2].s_class);
#else
            ((GCHandle) stack[2].s_class).SynchronizedFree();
#endif
#if DEBUG
            DebugGCHandle.Free((GCHandle) stack[3].s_class);
#else
            ((GCHandle) stack[3].s_class).SynchronizedFree();
#endif
            retobjid = stack[5].s_ulong;
#if DEBUG
            DebugGCHandle.Free((GCHandle) stack[6].s_class);
#else
            ((GCHandle) stack[6].s_class).SynchronizedFree();
#endif
            return stack[0].s_bool;
        }
        /// <remarks>
        ///  notifies the part that there is no reference anymore to objid
        ///    </remarks>        <short>    notifies the part that there is no reference anymore to objid    </short>
        [SmokeMethod("unregister(const unsigned long)")]
        public virtual void Unregister(ulong objid) {
            interceptor.Invoke("unregister$", "unregister(const unsigned long)", typeof(void), typeof(ulong), objid);
        }
        /// <remarks>
        ///  notify a event from the part of object objid
        ///    </remarks>        <short>    notify a event from the part of object objid    </short>
        public void PartEvent(ulong objid, string arg2, List<QPair<string, KParts.LiveConnectExtension.TypeOf>> args) {
            interceptor.Invoke("partEvent$$?", "partEvent(const unsigned long, const QString&, const QList<QPair<KParts::LiveConnectExtension::Type,QString> >&)", typeof(void), typeof(ulong), objid, typeof(string), arg2, typeof(List<QPair<string, KParts.LiveConnectExtension.TypeOf>>), args);
        }
        ~LiveConnectExtension() {
            interceptor.Invoke("~LiveConnectExtension", "~LiveConnectExtension()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~LiveConnectExtension", "~LiveConnectExtension()", typeof(void));
        }
        public static KParts.LiveConnectExtension ChildObject(QObject arg1) {
            return (KParts.LiveConnectExtension) staticInterceptor.Invoke("childObject#", "childObject(QObject*)", typeof(KParts.LiveConnectExtension), typeof(QObject), arg1);
        }
        protected new ILiveConnectExtensionSignals Emit {
            get { return (ILiveConnectExtensionSignals) Q_EMIT; }
        }
    }

    public interface ILiveConnectExtensionSignals : IQObjectSignals {
    }
}
