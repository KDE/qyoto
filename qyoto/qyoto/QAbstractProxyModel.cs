//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QAbstractProxyModel")]
	public class QAbstractProxyModel : QAbstractItemModel {
 		protected QAbstractProxyModel(Type dummy) : base((Type) null) {}
		interface IQAbstractProxyModelProxy {
			string Tr(string s, string c);
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QAbstractProxyModel), this);
			_interceptor = (QAbstractProxyModel) realProxy.GetTransparentProxy();
		}
		private QAbstractProxyModel ProxyQAbstractProxyModel() {
			return (QAbstractProxyModel) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QAbstractProxyModel() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQAbstractProxyModelProxy), null);
			_staticInterceptor = (IQAbstractProxyModelProxy) realProxy.GetTransparentProxy();
		}
		private static IQAbstractProxyModelProxy StaticQAbstractProxyModel() {
			return (IQAbstractProxyModelProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QAbstractProxyModel(QObject parent) : this((Type) null) {
			CreateProxy();
			NewQAbstractProxyModel(parent);
		}
		[SmokeMethod("QAbstractProxyModel(QObject*)")]
		private void NewQAbstractProxyModel(QObject parent) {
			ProxyQAbstractProxyModel().NewQAbstractProxyModel(parent);
		}
		public QAbstractProxyModel() : this((Type) null) {
			CreateProxy();
			NewQAbstractProxyModel();
		}
		[SmokeMethod("QAbstractProxyModel()")]
		private void NewQAbstractProxyModel() {
			ProxyQAbstractProxyModel().NewQAbstractProxyModel();
		}
		[SmokeMethod("setSourceModel(QAbstractItemModel*)")]
		public virtual void SetSourceModel(QAbstractItemModel sourceModel) {
			ProxyQAbstractProxyModel().SetSourceModel(sourceModel);
		}
		[SmokeMethod("sourceModel() const")]
		public QAbstractItemModel SourceModel() {
			return ProxyQAbstractProxyModel().SourceModel();
		}
		[SmokeMethod("mapToSource(const QModelIndex&) const")]
		public virtual QModelIndex MapToSource(QModelIndex proxyIndex) {
			return ProxyQAbstractProxyModel().MapToSource(proxyIndex);
		}
		[SmokeMethod("mapFromSource(const QModelIndex&) const")]
		public virtual QModelIndex MapFromSource(QModelIndex sourceIndex) {
			return ProxyQAbstractProxyModel().MapFromSource(sourceIndex);
		}
		[SmokeMethod("mapSelectionToSource(const QItemSelection&) const")]
		public virtual QItemSelection MapSelectionToSource(QItemSelection selection) {
			return ProxyQAbstractProxyModel().MapSelectionToSource(selection);
		}
		[SmokeMethod("mapSelectionFromSource(const QItemSelection&) const")]
		public virtual QItemSelection MapSelectionFromSource(QItemSelection selection) {
			return ProxyQAbstractProxyModel().MapSelectionFromSource(selection);
		}
		[SmokeMethod("submit()")]
		public new bool Submit() {
			return ProxyQAbstractProxyModel().Submit();
		}
		[SmokeMethod("revert()")]
		public new void Revert() {
			ProxyQAbstractProxyModel().Revert();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQAbstractProxyModel().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQAbstractProxyModel().Tr(s);
		}
		~QAbstractProxyModel() {
			DisposeQAbstractProxyModel();
		}
		public new void Dispose() {
			DisposeQAbstractProxyModel();
		}
		private void DisposeQAbstractProxyModel() {
			ProxyQAbstractProxyModel().DisposeQAbstractProxyModel();
		}
		protected new IQAbstractProxyModelSignals Emit() {
			return (IQAbstractProxyModelSignals) Q_EMIT;
		}
	}

	public interface IQAbstractProxyModelSignals : IQAbstractItemModelSignals {
	}
}
