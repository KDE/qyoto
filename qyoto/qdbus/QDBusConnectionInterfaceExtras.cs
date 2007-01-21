namespace Qyoto {

	using System;
	using System.Collections;
	using System.Collections.Generic; 
	using System.Text;

	public partial class QDBusConnectionInterface {

		public QDBusReply<List<string>> RegisteredServiceNames() {
			return new QDBusReply<List<string>>(InternalConstCall(QDBus.CallMode.AutoDetect,"ListNames"));
		}

		public QDBusReply<string> ServiceOwner(string name) {
			ArrayList nameArg = new ArrayList();
			nameArg.Add(new QVariant(name));
			return new QDBusReply<string>(InternalConstCall(QDBus.CallMode.AutoDetect,"GetNameOwner", nameArg));
		}

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
	}
}

