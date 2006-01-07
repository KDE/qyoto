//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	[SmokeClass("QImageFormatPlugin")]
	public class QImageFormatPlugin : QGPlugin {
 		protected QImageFormatPlugin(Type dummy) : base((Type) null) {}
		interface IQImageFormatPluginProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
		}

		protected void CreateQImageFormatPluginProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QImageFormatPlugin), this);
			_interceptor = (QImageFormatPlugin) realProxy.GetTransparentProxy();
		}
		private QImageFormatPlugin ProxyQImageFormatPlugin() {
			return (QImageFormatPlugin) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QImageFormatPlugin() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQImageFormatPluginProxy), null);
			_staticInterceptor = (IQImageFormatPluginProxy) realProxy.GetTransparentProxy();
		}
		private static IQImageFormatPluginProxy StaticQImageFormatPlugin() {
			return (IQImageFormatPluginProxy) _staticInterceptor;
		}

		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQImageFormatPlugin().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQImageFormatPlugin().ClassName();
		}
		public QImageFormatPlugin() : this((Type) null) {
			CreateQImageFormatPluginProxy();
			CreateQImageFormatPluginSignalProxy();
			NewQImageFormatPlugin();
		}
		[SmokeMethod("QImageFormatPlugin()")]
		private void NewQImageFormatPlugin() {
			ProxyQImageFormatPlugin().NewQImageFormatPlugin();
		}
		[SmokeMethod("keys() const")]
		public virtual ArrayList Keys() {
			return ProxyQImageFormatPlugin().Keys();
		}
		[SmokeMethod("loadImage(const QString&, const QString&, QImage*)")]
		public virtual bool LoadImage(string format, string filename, QImage image) {
			return ProxyQImageFormatPlugin().LoadImage(format,filename,image);
		}
		[SmokeMethod("saveImage(const QString&, const QString&, const QImage&)")]
		public virtual bool SaveImage(string format, string filename, QImage image) {
			return ProxyQImageFormatPlugin().SaveImage(format,filename,image);
		}
		[SmokeMethod("installIOHandler(const QString&)")]
		public virtual bool InstallIOHandler(string format) {
			return ProxyQImageFormatPlugin().InstallIOHandler(format);
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQImageFormatPlugin().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQImageFormatPlugin().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQImageFormatPlugin().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQImageFormatPlugin().TrUtf8(arg1);
		}
		~QImageFormatPlugin() {
			DisposeQImageFormatPlugin();
		}
		public new void Dispose() {
			DisposeQImageFormatPlugin();
		}
		private void DisposeQImageFormatPlugin() {
			ProxyQImageFormatPlugin().DisposeQImageFormatPlugin();
		}
		protected void CreateQImageFormatPluginSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQImageFormatPluginSignals), this);
			Q_EMIT = (IQImageFormatPluginSignals) realProxy.GetTransparentProxy();
		}
		protected new IQImageFormatPluginSignals Emit() {
			return (IQImageFormatPluginSignals) Q_EMIT;
		}
	}

	public interface IQImageFormatPluginSignals : IQGPluginSignals {
	}
}