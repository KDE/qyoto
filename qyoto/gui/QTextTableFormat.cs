//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections.Generic;

	[SmokeClass("QTextTableFormat")]
	public class QTextTableFormat : QTextFrameFormat, IDisposable {
 		protected QTextTableFormat(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QTextTableFormat), this);
		}
		public QTextTableFormat() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QTextTableFormat", "QTextTableFormat()", typeof(void));
		}
		public new bool IsValid() {
			return (bool) interceptor.Invoke("isValid", "isValid() const", typeof(bool));
		}
		public int Columns() {
			return (int) interceptor.Invoke("columns", "columns() const", typeof(int));
		}
		public void SetColumns(int columns) {
			interceptor.Invoke("setColumns$", "setColumns(int)", typeof(void), typeof(int), columns);
		}
		public void SetColumnWidthConstraints(List<QTextLength> constraints) {
			interceptor.Invoke("setColumnWidthConstraints?", "setColumnWidthConstraints(const QVector<QTextLength>&)", typeof(void), typeof(List<QTextLength>), constraints);
		}
		public List<QTextLength> ColumnWidthConstraints() {
			return (List<QTextLength>) interceptor.Invoke("columnWidthConstraints", "columnWidthConstraints() const", typeof(List<QTextLength>));
		}
		public void ClearColumnWidthConstraints() {
			interceptor.Invoke("clearColumnWidthConstraints", "clearColumnWidthConstraints()", typeof(void));
		}
		public double CellSpacing() {
			return (double) interceptor.Invoke("cellSpacing", "cellSpacing() const", typeof(double));
		}
		public void SetCellSpacing(double spacing) {
			interceptor.Invoke("setCellSpacing$", "setCellSpacing(qreal)", typeof(void), typeof(double), spacing);
		}
		public double CellPadding() {
			return (double) interceptor.Invoke("cellPadding", "cellPadding() const", typeof(double));
		}
		public void SetCellPadding(double padding) {
			interceptor.Invoke("setCellPadding$", "setCellPadding(qreal)", typeof(void), typeof(double), padding);
		}
		public void SetAlignment(uint alignment) {
			interceptor.Invoke("setAlignment$", "setAlignment(Qt::Alignment)", typeof(void), typeof(uint), alignment);
		}
		public uint Alignment() {
			return (uint) interceptor.Invoke("alignment", "alignment() const", typeof(uint));
		}
		public void SetHeaderRowCount(int count) {
			interceptor.Invoke("setHeaderRowCount$", "setHeaderRowCount(int)", typeof(void), typeof(int), count);
		}
		public int HeaderRowCount() {
			return (int) interceptor.Invoke("headerRowCount", "headerRowCount() const", typeof(int));
		}
		public QTextTableFormat(QTextFormat fmt) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QTextTableFormat#", "QTextTableFormat(const QTextFormat&)", typeof(void), typeof(QTextFormat), fmt);
		}
		~QTextTableFormat() {
			interceptor.Invoke("~QTextTableFormat", "~QTextTableFormat()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~QTextTableFormat", "~QTextTableFormat()", typeof(void));
		}
	}
}
