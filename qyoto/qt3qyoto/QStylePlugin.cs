//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	[SmokeClass("QStylePlugin")]
	public class QStylePlugin : QGPlugin {
 		protected QStylePlugin(Type dummy) : base((Type) null) {}
		interface IQStylePluginProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
		}

		protected void CreateQStylePluginProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QStylePlugin), this);
			_interceptor = (QStylePlugin) realProxy.GetTransparentProxy();
		}
		private QStylePlugin ProxyQStylePlugin() {
			return (QStylePlugin) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QStylePlugin() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQStylePluginProxy), null);
			_staticInterceptor = (IQStylePluginProxy) realProxy.GetTransparentProxy();
		}
		private static IQStylePluginProxy StaticQStylePlugin() {
			return (IQStylePluginProxy) _staticInterceptor;
		}

		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQStylePlugin().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQStylePlugin().ClassName();
		}
		public QStylePlugin() : this((Type) null) {
			CreateQStylePluginProxy();
			CreateQStylePluginSignalProxy();
			NewQStylePlugin();
		}
		[SmokeMethod("QStylePlugin()")]
		private void NewQStylePlugin() {
			ProxyQStylePlugin().NewQStylePlugin();
		}
		[SmokeMethod("keys() const")]
		public virtual ArrayList Keys() {
			return ProxyQStylePlugin().Keys();
		}
		[SmokeMethod("create(const QString&)")]
		public virtual QStyle Create(string key) {
			return ProxyQStylePlugin().Create(key);
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQStylePlugin().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQStylePlugin().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQStylePlugin().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQStylePlugin().TrUtf8(arg1);
		}
		~QStylePlugin() {
			DisposeQStylePlugin();
		}
		public new void Dispose() {
			DisposeQStylePlugin();
		}
		private void DisposeQStylePlugin() {
			ProxyQStylePlugin().DisposeQStylePlugin();
		}
		protected void CreateQStylePluginSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQStylePluginSignals), this);
			Q_EMIT = (IQStylePluginSignals) realProxy.GetTransparentProxy();
		}
		protected new IQStylePluginSignals Emit() {
			return (IQStylePluginSignals) Q_EMIT;
		}
	}

	public interface IQStylePluginSignals : IQGPluginSignals {
	}
}