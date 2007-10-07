//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QPersistentModelIndex")]
	public class QPersistentModelIndex : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected QPersistentModelIndex(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QPersistentModelIndex), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QPersistentModelIndex() {
			staticInterceptor = new SmokeInvocation(typeof(QPersistentModelIndex), null);
		}
		//  operator const QModelIndex&(); >>>> NOT CONVERTED
		// void* internalPointer(); >>>> NOT CONVERTED
		public QPersistentModelIndex() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QPersistentModelIndex", "QPersistentModelIndex()", typeof(void));
		}
		public QPersistentModelIndex(QModelIndex index) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QPersistentModelIndex#", "QPersistentModelIndex(const QModelIndex&)", typeof(void), typeof(QModelIndex), index);
		}
		public QPersistentModelIndex(QPersistentModelIndex other) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QPersistentModelIndex#", "QPersistentModelIndex(const QPersistentModelIndex&)", typeof(void), typeof(QPersistentModelIndex), other);
		}
		public override bool Equals(object o) {
			if (!(o is QPersistentModelIndex)) { return false; }
			return this == (QPersistentModelIndex) o;
		}
		public override int GetHashCode() {
			return interceptor.GetHashCode();
		}
		public int Row() {
			return (int) interceptor.Invoke("row", "row() const", typeof(int));
		}
		public int Column() {
			return (int) interceptor.Invoke("column", "column() const", typeof(int));
		}
		public long InternalId() {
			return (long) interceptor.Invoke("internalId", "internalId() const", typeof(long));
		}
		public QModelIndex Parent() {
			return (QModelIndex) interceptor.Invoke("parent", "parent() const", typeof(QModelIndex));
		}
		public QModelIndex Sibling(int row, int column) {
			return (QModelIndex) interceptor.Invoke("sibling$$", "sibling(int, int) const", typeof(QModelIndex), typeof(int), row, typeof(int), column);
		}
		public QModelIndex Child(int row, int column) {
			return (QModelIndex) interceptor.Invoke("child$$", "child(int, int) const", typeof(QModelIndex), typeof(int), row, typeof(int), column);
		}
		public QVariant Data(int role) {
			return (QVariant) interceptor.Invoke("data$", "data(int) const", typeof(QVariant), typeof(int), role);
		}
		public QVariant Data() {
			return (QVariant) interceptor.Invoke("data", "data() const", typeof(QVariant));
		}
		public uint Flags() {
			return (uint) interceptor.Invoke("flags", "flags() const", typeof(uint));
		}
		public QAbstractItemModel Model() {
			return (QAbstractItemModel) interceptor.Invoke("model", "model() const", typeof(QAbstractItemModel));
		}
		public bool IsValid() {
			return (bool) interceptor.Invoke("isValid", "isValid() const", typeof(bool));
		}
		~QPersistentModelIndex() {
			interceptor.Invoke("~QPersistentModelIndex", "~QPersistentModelIndex()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~QPersistentModelIndex", "~QPersistentModelIndex()", typeof(void));
		}
		public static bool operator<(QPersistentModelIndex lhs, QPersistentModelIndex other) {
			return (bool) staticInterceptor.Invoke("operator<#", "operator<(const QPersistentModelIndex&) const", typeof(bool), typeof(QPersistentModelIndex), lhs, typeof(QPersistentModelIndex), other);
		}
		public static bool operator>(QPersistentModelIndex lhs, QPersistentModelIndex other) {
			return !(bool) staticInterceptor.Invoke("operator<#", "operator<(const QPersistentModelIndex&) const", typeof(bool), typeof(QPersistentModelIndex), lhs, typeof(QPersistentModelIndex), other)
						&& !(bool) staticInterceptor.Invoke("operator==#", "operator==(const QPersistentModelIndex&) const", typeof(bool), typeof(QPersistentModelIndex), lhs, typeof(QPersistentModelIndex), other);
		}
		public static bool operator==(QPersistentModelIndex lhs, QPersistentModelIndex other) {
			return (bool) staticInterceptor.Invoke("operator==#", "operator==(const QPersistentModelIndex&) const", typeof(bool), typeof(QPersistentModelIndex), lhs, typeof(QPersistentModelIndex), other);
		}
		public static bool operator!=(QPersistentModelIndex lhs, QPersistentModelIndex other) {
			return !(bool) staticInterceptor.Invoke("operator==#", "operator==(const QPersistentModelIndex&) const", typeof(bool), typeof(QPersistentModelIndex), lhs, typeof(QPersistentModelIndex), other);
		}
		public static bool operator==(QPersistentModelIndex lhs, QModelIndex other) {
			return (bool) staticInterceptor.Invoke("operator==#", "operator==(const QModelIndex&) const", typeof(bool), typeof(QPersistentModelIndex), lhs, typeof(QModelIndex), other);
		}
		public static bool operator!=(QPersistentModelIndex lhs, QModelIndex other) {
			return !(bool) staticInterceptor.Invoke("operator==#", "operator==(const QModelIndex&) const", typeof(bool), typeof(QPersistentModelIndex), lhs, typeof(QModelIndex), other);
		}
	}
}
