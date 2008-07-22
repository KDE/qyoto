//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    using System.Text;
    using System.Collections.Generic;
    /// <remarks> See <see cref="IOrgKdeKLauncherInterfaceSignals"></see> for signals emitted by OrgKdeKLauncherInterface
    /// </remarks>
    [SmokeClass("OrgKdeKLauncherInterface")]
    public class OrgKdeKLauncherInterface : QDBusAbstractInterface, IDisposable {
        protected OrgKdeKLauncherInterface(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(OrgKdeKLauncherInterface), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static OrgKdeKLauncherInterface() {
            staticInterceptor = new SmokeInvocation(typeof(OrgKdeKLauncherInterface), null);
        }
        // QDBusReply<void> autoStart(); >>>> NOT CONVERTED
        // QDBusReply<void> autoStart(int arg1); >>>> NOT CONVERTED
        // QDBusReply<void> exec_blind(const QString& arg1,const QStringList& arg2,const QStringList& arg3,const QString& arg4); >>>> NOT CONVERTED
        // QDBusReply<void> exec_blind(const QString& arg1,const QStringList& arg2); >>>> NOT CONVERTED
        // QDBusReply<int> kdeinit_exec(const QString& arg1,const QStringList& arg2,const QStringList& arg3,const QString& arg4,QString& arg5,QString& arg6,int& arg7); >>>> NOT CONVERTED
        // QDBusReply<int> kdeinit_exec_wait(const QString& arg1,const QStringList& arg2,const QStringList& arg3,const QString& arg4,QString& arg5,QString& arg6,int& arg7); >>>> NOT CONVERTED
        // QDBusReply<void> reparseConfiguration(); >>>> NOT CONVERTED
        // QDBusReply<int> requestHoldSlave(const QString& arg1,const QString& arg2); >>>> NOT CONVERTED
        // QDBusReply<int> requestSlave(const QString& arg1,const QString& arg2,const QString& arg3,QString& arg4); >>>> NOT CONVERTED
        // QDBusReply<void> setLaunchEnv(const QString& arg1,const QString& arg2); >>>> NOT CONVERTED
        // QDBusReply<int> start_service_by_desktop_name(const QString& arg1,const QStringList& arg2,const QStringList& arg3,const QString& arg4,bool arg5,QString& arg6,QString& arg7,int& arg8); >>>> NOT CONVERTED
        // QDBusReply<int> start_service_by_desktop_path(const QString& arg1,const QStringList& arg2,const QStringList& arg3,const QString& arg4,bool arg5,QString& arg6,QString& arg7,int& arg8); >>>> NOT CONVERTED
        // QDBusReply<int> start_service_by_name(const QString& arg1,const QStringList& arg2,const QStringList& arg3,const QString& arg4,bool arg5,QString& arg6,QString& arg7,int& arg8); >>>> NOT CONVERTED
        // QDBusReply<void> waitForSlave(int arg1); >>>> NOT CONVERTED
        public OrgKdeKLauncherInterface(string service, string path, QDBusConnection connection, QObject parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("OrgKdeKLauncherInterface$$##", "OrgKdeKLauncherInterface(const QString&, const QString&, const QDBusConnection&, QObject*)", typeof(void), typeof(string), service, typeof(string), path, typeof(QDBusConnection), connection, typeof(QObject), parent);
        }
        public OrgKdeKLauncherInterface(string service, string path, QDBusConnection connection) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("OrgKdeKLauncherInterface$$#", "OrgKdeKLauncherInterface(const QString&, const QString&, const QDBusConnection&)", typeof(void), typeof(string), service, typeof(string), path, typeof(QDBusConnection), connection);
        }
        ~OrgKdeKLauncherInterface() {
            interceptor.Invoke("~OrgKdeKLauncherInterface", "~OrgKdeKLauncherInterface()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~OrgKdeKLauncherInterface", "~OrgKdeKLauncherInterface()", typeof(void));
        }
        public static string StaticInterfaceName() {
            return (string) staticInterceptor.Invoke("staticInterfaceName", "staticInterfaceName()", typeof(string));
        }
        protected new IOrgKdeKLauncherInterfaceSignals Emit {
            get { return (IOrgKdeKLauncherInterfaceSignals) Q_EMIT; }
        }
    }

    public interface IOrgKdeKLauncherInterfaceSignals : IQDBusAbstractInterfaceSignals {
        [Q_SIGNAL("void autoStart0Done()")]
        void AutoStart0Done();
        [Q_SIGNAL("void autoStart1Done()")]
        void AutoStart1Done();
        [Q_SIGNAL("void autoStart2Done()")]
        void AutoStart2Done();
    }
}
