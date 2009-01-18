namespace Qyoto {
	using System;

	[SmokeClass("QAbstractListModel")]
	internal class QAbstractListModelInternal : QAbstractListModel {
		protected QAbstractListModelInternal(Type dummy) : base((Type) null) {}

		public override int ColumnCount(QModelIndex parent) {
			return (int) interceptor.Invoke("columnCount#", "columnCount(const QModelIndex&) const", typeof(int), typeof(QModelIndex), parent);
		}
		
		public override QVariant Data(QModelIndex index, int role) {
			return (QVariant) interceptor.Invoke("data#$", "data(const QModelIndex&, int) const", typeof(QVariant), typeof(QModelIndex), index, typeof(int), role);
		}
		
		public override QModelIndex Parent(QModelIndex child) {
			return (QModelIndex) interceptor.Invoke("parent#", "parent(const QModelIndex&) const", typeof(QModelIndex), typeof(QModelIndex), child);
		}
		
		public override int RowCount(QModelIndex parent) {
			return (int) interceptor.Invoke("rowCount#", "rowCount(const QModelIndex&) const", typeof(int), typeof(QModelIndex), parent);
		}
	}
}
