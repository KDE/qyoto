//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	[SmokeClass("QAbstractTableModel")]
	public class QAbstractTableModel : QAbstractItemModel, IDisposable {
 		protected QAbstractTableModel(Type dummy) : base((Type) null) {}
		interface IQAbstractTableModelProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QAbstractTableModel), this);
			_interceptor = (QAbstractTableModel) realProxy.GetTransparentProxy();
		}
		private QAbstractTableModel ProxyQAbstractTableModel() {
			return (QAbstractTableModel) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QAbstractTableModel() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQAbstractTableModelProxy), null);
			_staticInterceptor = (IQAbstractTableModelProxy) realProxy.GetTransparentProxy();
		}
		private static IQAbstractTableModelProxy StaticQAbstractTableModel() {
			return (IQAbstractTableModelProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QAbstractTableModel(QObject parent) : this((Type) null) {
			CreateProxy();
			NewQAbstractTableModel(parent);
		}
		[SmokeMethod("QAbstractTableModel", "(QObject*)", "#")]
		private void NewQAbstractTableModel(QObject parent) {
			ProxyQAbstractTableModel().NewQAbstractTableModel(parent);
		}
		public QAbstractTableModel() : this((Type) null) {
			CreateProxy();
			NewQAbstractTableModel();
		}
		[SmokeMethod("QAbstractTableModel", "()", "")]
		private void NewQAbstractTableModel() {
			ProxyQAbstractTableModel().NewQAbstractTableModel();
		}
		[SmokeMethod("index", "(int, int, const QModelIndex&) const", "$$#")]
		public new QModelIndex Index(int row, int column, QModelIndex parent) {
			return ProxyQAbstractTableModel().Index(row,column,parent);
		}
		[SmokeMethod("index", "(int, int) const", "$$")]
		public new QModelIndex Index(int row, int column) {
			return ProxyQAbstractTableModel().Index(row,column);
		}
		[SmokeMethod("dropMimeData", "(const QMimeData*, Qt::DropAction, int, int, const QModelIndex&)", "#$$$#")]
		public new bool DropMimeData(QMimeData data, Qt.DropAction action, int row, int column, QModelIndex parent) {
			return ProxyQAbstractTableModel().DropMimeData(data,action,row,column,parent);
		}
		public static new string Tr(string s, string c) {
			return StaticQAbstractTableModel().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQAbstractTableModel().Tr(s);
		}
		~QAbstractTableModel() {
			DisposeQAbstractTableModel();
		}
		public new void Dispose() {
			DisposeQAbstractTableModel();
		}
		[SmokeMethod("~QAbstractTableModel", "()", "")]
		private void DisposeQAbstractTableModel() {
			ProxyQAbstractTableModel().DisposeQAbstractTableModel();
		}
		protected new IQAbstractTableModelSignals Emit {
			get {
				return (IQAbstractTableModelSignals) Q_EMIT;
			}
		}
	}

	public interface IQAbstractTableModelSignals : IQAbstractItemModelSignals {
	}
}
