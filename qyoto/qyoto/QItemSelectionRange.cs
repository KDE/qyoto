//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;

	public class QItemSelectionRange : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QItemSelectionRange(Type dummy) {}
		interface IQItemSelectionRangeProxy {
			bool op_equals(QItemSelectionRange lhs, QItemSelectionRange other);
		}

		protected void CreateQItemSelectionRangeProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QItemSelectionRange), this);
			_interceptor = (QItemSelectionRange) realProxy.GetTransparentProxy();
		}
		private QItemSelectionRange ProxyQItemSelectionRange() {
			return (QItemSelectionRange) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QItemSelectionRange() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQItemSelectionRangeProxy), null);
			_staticInterceptor = (IQItemSelectionRangeProxy) realProxy.GetTransparentProxy();
		}
		private static IQItemSelectionRangeProxy StaticQItemSelectionRange() {
			return (IQItemSelectionRangeProxy) _staticInterceptor;
		}

		public QItemSelectionRange() : this((Type) null) {
			CreateQItemSelectionRangeProxy();
			NewQItemSelectionRange();
		}
		private void NewQItemSelectionRange() {
			ProxyQItemSelectionRange().NewQItemSelectionRange();
		}
		public QItemSelectionRange(QItemSelectionRange other) : this((Type) null) {
			CreateQItemSelectionRangeProxy();
			NewQItemSelectionRange(other);
		}
		private void NewQItemSelectionRange(QItemSelectionRange other) {
			ProxyQItemSelectionRange().NewQItemSelectionRange(other);
		}
		public QItemSelectionRange(QModelIndex topLeft, QModelIndex bottomRight) : this((Type) null) {
			CreateQItemSelectionRangeProxy();
			NewQItemSelectionRange(topLeft,bottomRight);
		}
		private void NewQItemSelectionRange(QModelIndex topLeft, QModelIndex bottomRight) {
			ProxyQItemSelectionRange().NewQItemSelectionRange(topLeft,bottomRight);
		}
		public QItemSelectionRange(QModelIndex index) : this((Type) null) {
			CreateQItemSelectionRangeProxy();
			NewQItemSelectionRange(index);
		}
		private void NewQItemSelectionRange(QModelIndex index) {
			ProxyQItemSelectionRange().NewQItemSelectionRange(index);
		}
		public int Top() {
			return ProxyQItemSelectionRange().Top();
		}
		public int Left() {
			return ProxyQItemSelectionRange().Left();
		}
		public int Bottom() {
			return ProxyQItemSelectionRange().Bottom();
		}
		public int Right() {
			return ProxyQItemSelectionRange().Right();
		}
		public int Width() {
			return ProxyQItemSelectionRange().Width();
		}
		public int Height() {
			return ProxyQItemSelectionRange().Height();
		}
		public QModelIndex TopLeft() {
			return ProxyQItemSelectionRange().TopLeft();
		}
		public QModelIndex BottomRight() {
			return ProxyQItemSelectionRange().BottomRight();
		}
		public QModelIndex Parent() {
			return ProxyQItemSelectionRange().Parent();
		}
		public QAbstractItemModel Model() {
			return ProxyQItemSelectionRange().Model();
		}
		public bool Contains(QModelIndex index) {
			return ProxyQItemSelectionRange().Contains(index);
		}
		public bool Intersects(QItemSelectionRange other) {
			return ProxyQItemSelectionRange().Intersects(other);
		}
		public QItemSelectionRange Intersect(QItemSelectionRange other) {
			return ProxyQItemSelectionRange().Intersect(other);
		}
		public static bool operator==(QItemSelectionRange lhs, QItemSelectionRange other) {
			return StaticQItemSelectionRange().op_equals(lhs,other);
		}
		public static bool operator!=(QItemSelectionRange lhs, QItemSelectionRange other) {
			return !StaticQItemSelectionRange().op_equals(lhs,other);
		}
		public override bool Equals(object o) {
			if (!(o is QItemSelectionRange)) { return false; }
			return this == (QItemSelectionRange) o;
		}
		public override int GetHashCode() {
			return ProxyQItemSelectionRange().GetHashCode();
		}
		public bool IsValid() {
			return ProxyQItemSelectionRange().IsValid();
		}
		// QModelIndexList indexes(); >>>> NOT CONVERTED
		~QItemSelectionRange() {
			ProxyQItemSelectionRange().Dispose();
		}
		public void Dispose() {
			ProxyQItemSelectionRange().Dispose();
		}
	}
}