//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	/// See <see cref="IQSignalMapperSignals"></see> for signals emitted by QSignalMapper
	[SmokeClass("QSignalMapper")]
	public class QSignalMapper : QObject, IDisposable {
 		protected QSignalMapper(Type dummy) : base((Type) null) {}
		interface IQSignalMapperProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QSignalMapper), this);
			_interceptor = (QSignalMapper) realProxy.GetTransparentProxy();
		}
		private QSignalMapper ProxyQSignalMapper() {
			return (QSignalMapper) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QSignalMapper() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQSignalMapperProxy), null);
			_staticInterceptor = (IQSignalMapperProxy) realProxy.GetTransparentProxy();
		}
		private static IQSignalMapperProxy StaticQSignalMapper() {
			return (IQSignalMapperProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QSignalMapper(QObject parent) : this((Type) null) {
			CreateProxy();
			NewQSignalMapper(parent);
		}
		[SmokeMethod("QSignalMapper", "(QObject*)", "#")]
		private void NewQSignalMapper(QObject parent) {
			ProxyQSignalMapper().NewQSignalMapper(parent);
		}
		public QSignalMapper() : this((Type) null) {
			CreateProxy();
			NewQSignalMapper();
		}
		[SmokeMethod("QSignalMapper", "()", "")]
		private void NewQSignalMapper() {
			ProxyQSignalMapper().NewQSignalMapper();
		}
		[SmokeMethod("setMapping", "(QObject*, int)", "#$")]
		public void SetMapping(QObject sender, int id) {
			ProxyQSignalMapper().SetMapping(sender,id);
		}
		[SmokeMethod("setMapping", "(QObject*, const QString&)", "#$")]
		public void SetMapping(QObject sender, string text) {
			ProxyQSignalMapper().SetMapping(sender,text);
		}
		[SmokeMethod("setMapping", "(QObject*, QWidget*)", "##")]
		public void SetMapping(QObject sender, QWidget widget) {
			ProxyQSignalMapper().SetMapping(sender,widget);
		}
		[SmokeMethod("setMapping", "(QObject*, QObject*)", "##")]
		public void SetMapping(QObject sender, QObject arg2) {
			ProxyQSignalMapper().SetMapping(sender,arg2);
		}
		[SmokeMethod("removeMappings", "(QObject*)", "#")]
		public void RemoveMappings(QObject sender) {
			ProxyQSignalMapper().RemoveMappings(sender);
		}
		[SmokeMethod("mapping", "(int) const", "$")]
		public QObject Mapping(int id) {
			return ProxyQSignalMapper().Mapping(id);
		}
		[SmokeMethod("mapping", "(const QString&) const", "$")]
		public QObject Mapping(string text) {
			return ProxyQSignalMapper().Mapping(text);
		}
		[SmokeMethod("mapping", "(QWidget*) const", "#")]
		public QObject Mapping(QWidget widget) {
			return ProxyQSignalMapper().Mapping(widget);
		}
		[SmokeMethod("mapping", "(QObject*) const", "#")]
		public QObject Mapping(QObject arg1) {
			return ProxyQSignalMapper().Mapping(arg1);
		}
		[Q_SLOT("void map()")]
		[SmokeMethod("map", "()", "")]
		public void Map() {
			ProxyQSignalMapper().Map();
		}
		[Q_SLOT("void map(QObject*)")]
		[SmokeMethod("map", "(QObject*)", "#")]
		public void Map(QObject sender) {
			ProxyQSignalMapper().Map(sender);
		}
		public static new string Tr(string s, string c) {
			return StaticQSignalMapper().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQSignalMapper().Tr(s);
		}
		~QSignalMapper() {
			DisposeQSignalMapper();
		}
		public new void Dispose() {
			DisposeQSignalMapper();
		}
		[SmokeMethod("~QSignalMapper", "()", "")]
		private void DisposeQSignalMapper() {
			ProxyQSignalMapper().DisposeQSignalMapper();
		}
		protected new IQSignalMapperSignals Emit {
			get {
				return (IQSignalMapperSignals) Q_EMIT;
			}
		}
	}

	public interface IQSignalMapperSignals : IQObjectSignals {
		[Q_SIGNAL("void mapped(int)")]
		void Mapped(int arg1);
		[Q_SIGNAL("void mapped(const QString&)")]
		void Mapped(string arg1);
		[Q_SIGNAL("void mapped(QWidget*)")]
		void Mapped(QWidget arg1);
		[Q_SIGNAL("void mapped(QObject*)")]
		void Mapped(QObject arg1);
	}
}
