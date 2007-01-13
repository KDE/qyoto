//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections;
	using System.Collections.Generic; 
	using System.Text;

	[SmokeClass("QDBusConnectionInterface")]
	public class QDBusConnectionInterface : QDBusAbstractInterface {
 		protected QDBusConnectionInterface(Type dummy) : base((Type) null) {}
		interface IQDBusConnectionInterfaceProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QDBusConnectionInterface), this);
			_interceptor = (QDBusConnectionInterface) realProxy.GetTransparentProxy();
		}
		private QDBusConnectionInterface ProxyQDBusConnectionInterface() {
			return (QDBusConnectionInterface) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QDBusConnectionInterface() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQDBusConnectionInterfaceProxy), null);
			_staticInterceptor = (IQDBusConnectionInterfaceProxy) realProxy.GetTransparentProxy();
		}
		private static IQDBusConnectionInterfaceProxy StaticQDBusConnectionInterface() {
			return (IQDBusConnectionInterfaceProxy) _staticInterceptor;
		}

		public enum ServiceQueueOptions {
			DontQueueService = 0,
			QueueService = 1,
			ReplaceExistingService = 2,
		}
		public enum ServiceReplacementOptions {
			DontAllowReplacement = 0,
			AllowReplacement = 1,
		}
		public enum RegisterServiceReply {
			ServiceNotRegistered = 0,
			ServiceRegistered = 1,
			ServiceQueued = 2,
		}
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED

		public QDBusReply<List<string>> RegisteredServiceNames() {
			return new QDBusReply<List<string>>(InternalConstCall(QDBus.CallMode.AutoDetect,"ListNames"));
		}

		public QDBusReply<string> ServiceOwner(string name) {
			ArrayList nameArg = new ArrayList();
			nameArg.Add(new QVariant(name));
			return new QDBusReply<string>(InternalConstCall(QDBus.CallMode.AutoDetect,"GetNameOwner", nameArg));
		}
		// QDBusReply<bool> unregisterService(const QString& arg1); >>>> NOT CONVERTED
		// QDBusReply<QDBusConnectionInterface::RegisterServiceReply> registerService(const QString& arg1,QDBusConnectionInterface::ServiceQueueOptions arg2,QDBusConnectionInterface::ServiceReplacementOptions arg3); >>>> NOT CONVERTED
		// QDBusReply<QDBusConnectionInterface::RegisterServiceReply> registerService(const QString& arg1,QDBusConnectionInterface::ServiceQueueOptions arg2); >>>> NOT CONVERTED
		// QDBusReply<QDBusConnectionInterface::RegisterServiceReply> registerService(const QString& arg1); >>>> NOT CONVERTED

		public QDBusReply<bool> IsServiceRegistered(string serviceName) {
			ArrayList serviceArg = new ArrayList();
			serviceArg.Add(new QVariant(serviceName));
			return new QDBusReply<bool>(InternalConstCall(QDBus.CallMode.AutoDetect,"NameHasOwner", serviceArg));
		}

		public QDBusReply<uint> ServicePid(string serviceName) {
			ArrayList serviceArg = new ArrayList();
			serviceArg.Add(new QVariant(serviceName));
			return new QDBusReply<uint>(InternalConstCall(QDBus.CallMode.AutoDetect, "GetConnectionUnixProcessID", serviceArg));
		}

		public QDBusReply<uint> ServiceUid(string serviceName) {
			ArrayList serviceArg = new ArrayList();
			serviceArg.Add(new QVariant(serviceName));
			return new QDBusReply<uint>(InternalConstCall(QDBus.CallMode.AutoDetect, "GetConnectionUnixUser", serviceArg));
		}

		public QDBusReply<int> StartService(string name) {
			return new QDBusReply<int>(Call("StartServiceByName", new QVariant(name), new QVariant(0)));
		}

		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQDBusConnectionInterface().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQDBusConnectionInterface().Tr(s);
		}
		protected new IQDBusConnectionInterfaceSignals Emit() {
			return (IQDBusConnectionInterfaceSignals) Q_EMIT;
		}
	}

	public interface IQDBusConnectionInterfaceSignals : IQDBusAbstractInterfaceSignals {
	}
}
