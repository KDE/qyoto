//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Text;

	/// See <see cref="IQSignalMapperSignals"></see> for signals emitted by QSignalMapper
	public class QSignalMapper : QObject, IDisposable {
 		protected QSignalMapper(Type dummy) : base((Type) null) {}
		interface IQSignalMapperProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected void CreateQSignalMapperProxy() {
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

		public new virtual QMetaObject MetaObject() {
			return ProxyQSignalMapper().MetaObject();
		}
		// void* qt_metacast(const char* arg1); >>>> NOT CONVERTED
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QSignalMapper(QObject parent) : this((Type) null) {
			CreateQSignalMapperProxy();
			NewQSignalMapper(parent);
		}
		private void NewQSignalMapper(QObject parent) {
			ProxyQSignalMapper().NewQSignalMapper(parent);
		}
		public QSignalMapper() : this((Type) null) {
			CreateQSignalMapperProxy();
			NewQSignalMapper();
		}
		private void NewQSignalMapper() {
			ProxyQSignalMapper().NewQSignalMapper();
		}
		public void SetMapping(QObject sender, int id) {
			ProxyQSignalMapper().SetMapping(sender,id);
		}
		public void SetMapping(QObject sender, string text) {
			ProxyQSignalMapper().SetMapping(sender,text);
		}
		public void SetMapping(QObject sender, QWidget widget) {
			ProxyQSignalMapper().SetMapping(sender,widget);
		}
		public void RemoveMappings(QObject sender) {
			ProxyQSignalMapper().RemoveMappings(sender);
		}
		public QObject Mapping(int id) {
			return ProxyQSignalMapper().Mapping(id);
		}
		public QObject Mapping(string text) {
			return ProxyQSignalMapper().Mapping(text);
		}
		public QObject Mapping(QWidget widget) {
			return ProxyQSignalMapper().Mapping(widget);
		}
		public void Map() {
			ProxyQSignalMapper().Map();
		}
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
			ProxyQSignalMapper().Dispose();
		}
		public new void Dispose() {
			ProxyQSignalMapper().Dispose();
		}
	}

	public interface IQSignalMapperSignals {
		void Mapped(int arg1);
		void Mapped(string arg1);
		void Mapped(QWidget arg1);
	}
}