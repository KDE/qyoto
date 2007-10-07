//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections.Generic;

	[SmokeClass("QSortFilterProxyModel")]
	public class QSortFilterProxyModel : QAbstractProxyModel, IDisposable {
 		protected QSortFilterProxyModel(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QSortFilterProxyModel), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QSortFilterProxyModel() {
			staticInterceptor = new SmokeInvocation(typeof(QSortFilterProxyModel), null);
		}
		[Q_PROPERTY("QRegExp", "filterRegExp")]
		public QRegExp FilterRegExp {
			get { return (QRegExp) interceptor.Invoke("filterRegExp", "filterRegExp()", typeof(QRegExp)); }
			set { interceptor.Invoke("setFilterRegExp#", "setFilterRegExp(QRegExp)", typeof(void), typeof(QRegExp), value); }
		}
		[Q_PROPERTY("int", "filterKeyColumn")]
		public int FilterKeyColumn {
			get { return (int) interceptor.Invoke("filterKeyColumn", "filterKeyColumn()", typeof(int)); }
			set { interceptor.Invoke("setFilterKeyColumn$", "setFilterKeyColumn(int)", typeof(void), typeof(int), value); }
		}
		[Q_PROPERTY("bool", "dynamicSortFilter")]
		public bool DynamicSortFilter {
			get { return (bool) interceptor.Invoke("dynamicSortFilter", "dynamicSortFilter()", typeof(bool)); }
			set { interceptor.Invoke("setDynamicSortFilter$", "setDynamicSortFilter(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("Qt::CaseSensitivity", "filterCaseSensitivity")]
		public Qt.CaseSensitivity FilterCaseSensitivity {
			get { return (Qt.CaseSensitivity) interceptor.Invoke("filterCaseSensitivity", "filterCaseSensitivity()", typeof(Qt.CaseSensitivity)); }
			set { interceptor.Invoke("setFilterCaseSensitivity$", "setFilterCaseSensitivity(Qt::CaseSensitivity)", typeof(void), typeof(Qt.CaseSensitivity), value); }
		}
		[Q_PROPERTY("Qt::CaseSensitivity", "sortCaseSensitivity")]
		public Qt.CaseSensitivity SortCaseSensitivity {
			get { return (Qt.CaseSensitivity) interceptor.Invoke("sortCaseSensitivity", "sortCaseSensitivity()", typeof(Qt.CaseSensitivity)); }
			set { interceptor.Invoke("setSortCaseSensitivity$", "setSortCaseSensitivity(Qt::CaseSensitivity)", typeof(void), typeof(Qt.CaseSensitivity), value); }
		}
		[Q_PROPERTY("bool", "isSortLocaleAware")]
		public bool IsSortLocaleAware {
			get { return (bool) interceptor.Invoke("isSortLocaleAware", "isSortLocaleAware()", typeof(bool)); }
			set { interceptor.Invoke("setSortLocaleAware$", "setSortLocaleAware(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("int", "sortRole")]
		public int SortRole {
			get { return (int) interceptor.Invoke("sortRole", "sortRole()", typeof(int)); }
			set { interceptor.Invoke("setSortRole$", "setSortRole(int)", typeof(void), typeof(int), value); }
		}
		[Q_PROPERTY("int", "filterRole")]
		public int FilterRole {
			get { return (int) interceptor.Invoke("filterRole", "filterRole()", typeof(int)); }
			set { interceptor.Invoke("setFilterRole$", "setFilterRole(int)", typeof(void), typeof(int), value); }
		}
		public QSortFilterProxyModel(QObject parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QSortFilterProxyModel#", "QSortFilterProxyModel(QObject*)", typeof(void), typeof(QObject), parent);
		}
		public QSortFilterProxyModel() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QSortFilterProxyModel", "QSortFilterProxyModel()", typeof(void));
		}
		[SmokeMethod("setSourceModel(QAbstractItemModel*)")]
		public override void SetSourceModel(QAbstractItemModel sourceModel) {
			interceptor.Invoke("setSourceModel#", "setSourceModel(QAbstractItemModel*)", typeof(void), typeof(QAbstractItemModel), sourceModel);
		}
		[SmokeMethod("mapToSource(const QModelIndex&) const")]
		public override QModelIndex MapToSource(QModelIndex proxyIndex) {
			return (QModelIndex) interceptor.Invoke("mapToSource#", "mapToSource(const QModelIndex&) const", typeof(QModelIndex), typeof(QModelIndex), proxyIndex);
		}
		[SmokeMethod("mapFromSource(const QModelIndex&) const")]
		public override QModelIndex MapFromSource(QModelIndex sourceIndex) {
			return (QModelIndex) interceptor.Invoke("mapFromSource#", "mapFromSource(const QModelIndex&) const", typeof(QModelIndex), typeof(QModelIndex), sourceIndex);
		}
		[SmokeMethod("mapSelectionToSource(const QItemSelection&) const")]
		public override QItemSelection MapSelectionToSource(QItemSelection proxySelection) {
			return (QItemSelection) interceptor.Invoke("mapSelectionToSource#", "mapSelectionToSource(const QItemSelection&) const", typeof(QItemSelection), typeof(QItemSelection), proxySelection);
		}
		[SmokeMethod("mapSelectionFromSource(const QItemSelection&) const")]
		public override QItemSelection MapSelectionFromSource(QItemSelection sourceSelection) {
			return (QItemSelection) interceptor.Invoke("mapSelectionFromSource#", "mapSelectionFromSource(const QItemSelection&) const", typeof(QItemSelection), typeof(QItemSelection), sourceSelection);
		}
		public new QObject Parent() {
			return (QObject) interceptor.Invoke("parent", "parent() const", typeof(QObject));
		}
		[SmokeMethod("index(int, int, const QModelIndex&) const")]
		public override QModelIndex Index(int row, int column, QModelIndex parent) {
			return (QModelIndex) interceptor.Invoke("index$$#", "index(int, int, const QModelIndex&) const", typeof(QModelIndex), typeof(int), row, typeof(int), column, typeof(QModelIndex), parent);
		}
		[SmokeMethod("index(int, int) const")]
		public virtual QModelIndex Index(int row, int column) {
			return (QModelIndex) interceptor.Invoke("index$$", "index(int, int) const", typeof(QModelIndex), typeof(int), row, typeof(int), column);
		}
		[SmokeMethod("parent(const QModelIndex&) const")]
		public override QModelIndex Parent(QModelIndex child) {
			return (QModelIndex) interceptor.Invoke("parent#", "parent(const QModelIndex&) const", typeof(QModelIndex), typeof(QModelIndex), child);
		}
		[SmokeMethod("rowCount(const QModelIndex&) const")]
		public override int RowCount(QModelIndex parent) {
			return (int) interceptor.Invoke("rowCount#", "rowCount(const QModelIndex&) const", typeof(int), typeof(QModelIndex), parent);
		}
		[SmokeMethod("rowCount() const")]
		public virtual int RowCount() {
			return (int) interceptor.Invoke("rowCount", "rowCount() const", typeof(int));
		}
		[SmokeMethod("columnCount(const QModelIndex&) const")]
		public override int ColumnCount(QModelIndex parent) {
			return (int) interceptor.Invoke("columnCount#", "columnCount(const QModelIndex&) const", typeof(int), typeof(QModelIndex), parent);
		}
		[SmokeMethod("columnCount() const")]
		public virtual int ColumnCount() {
			return (int) interceptor.Invoke("columnCount", "columnCount() const", typeof(int));
		}
		[SmokeMethod("hasChildren(const QModelIndex&) const")]
		public override bool HasChildren(QModelIndex parent) {
			return (bool) interceptor.Invoke("hasChildren#", "hasChildren(const QModelIndex&) const", typeof(bool), typeof(QModelIndex), parent);
		}
		[SmokeMethod("hasChildren() const")]
		public override bool HasChildren() {
			return (bool) interceptor.Invoke("hasChildren", "hasChildren() const", typeof(bool));
		}
		[SmokeMethod("data(const QModelIndex&, int) const")]
		public override QVariant Data(QModelIndex index, int role) {
			return (QVariant) interceptor.Invoke("data#$", "data(const QModelIndex&, int) const", typeof(QVariant), typeof(QModelIndex), index, typeof(int), role);
		}
		[SmokeMethod("data(const QModelIndex&) const")]
		public override QVariant Data(QModelIndex index) {
			return (QVariant) interceptor.Invoke("data#", "data(const QModelIndex&) const", typeof(QVariant), typeof(QModelIndex), index);
		}
		[SmokeMethod("setData(const QModelIndex&, const QVariant&, int)")]
		public override bool SetData(QModelIndex index, QVariant value, int role) {
			return (bool) interceptor.Invoke("setData##$", "setData(const QModelIndex&, const QVariant&, int)", typeof(bool), typeof(QModelIndex), index, typeof(QVariant), value, typeof(int), role);
		}
		[SmokeMethod("setData(const QModelIndex&, const QVariant&)")]
		public override bool SetData(QModelIndex index, QVariant value) {
			return (bool) interceptor.Invoke("setData##", "setData(const QModelIndex&, const QVariant&)", typeof(bool), typeof(QModelIndex), index, typeof(QVariant), value);
		}
		[SmokeMethod("headerData(int, Qt::Orientation, int) const")]
		public override QVariant HeaderData(int section, Qt.Orientation orientation, int role) {
			return (QVariant) interceptor.Invoke("headerData$$$", "headerData(int, Qt::Orientation, int) const", typeof(QVariant), typeof(int), section, typeof(Qt.Orientation), orientation, typeof(int), role);
		}
		[SmokeMethod("headerData(int, Qt::Orientation) const")]
		public override QVariant HeaderData(int section, Qt.Orientation orientation) {
			return (QVariant) interceptor.Invoke("headerData$$", "headerData(int, Qt::Orientation) const", typeof(QVariant), typeof(int), section, typeof(Qt.Orientation), orientation);
		}
		[SmokeMethod("setHeaderData(int, Qt::Orientation, const QVariant&, int)")]
		public override bool SetHeaderData(int section, Qt.Orientation orientation, QVariant value, int role) {
			return (bool) interceptor.Invoke("setHeaderData$$#$", "setHeaderData(int, Qt::Orientation, const QVariant&, int)", typeof(bool), typeof(int), section, typeof(Qt.Orientation), orientation, typeof(QVariant), value, typeof(int), role);
		}
		[SmokeMethod("setHeaderData(int, Qt::Orientation, const QVariant&)")]
		public override bool SetHeaderData(int section, Qt.Orientation orientation, QVariant value) {
			return (bool) interceptor.Invoke("setHeaderData$$#", "setHeaderData(int, Qt::Orientation, const QVariant&)", typeof(bool), typeof(int), section, typeof(Qt.Orientation), orientation, typeof(QVariant), value);
		}
		[SmokeMethod("mimeData(const QModelIndexList&) const")]
		public override QMimeData MimeData(List<QModelIndex> indexes) {
			return (QMimeData) interceptor.Invoke("mimeData?", "mimeData(const QModelIndexList&) const", typeof(QMimeData), typeof(List<QModelIndex>), indexes);
		}
		[SmokeMethod("dropMimeData(const QMimeData*, Qt::DropAction, int, int, const QModelIndex&)")]
		public override bool DropMimeData(QMimeData data, Qt.DropAction action, int row, int column, QModelIndex parent) {
			return (bool) interceptor.Invoke("dropMimeData#$$$#", "dropMimeData(const QMimeData*, Qt::DropAction, int, int, const QModelIndex&)", typeof(bool), typeof(QMimeData), data, typeof(Qt.DropAction), action, typeof(int), row, typeof(int), column, typeof(QModelIndex), parent);
		}
		[SmokeMethod("insertRows(int, int, const QModelIndex&)")]
		public override bool InsertRows(int row, int count, QModelIndex parent) {
			return (bool) interceptor.Invoke("insertRows$$#", "insertRows(int, int, const QModelIndex&)", typeof(bool), typeof(int), row, typeof(int), count, typeof(QModelIndex), parent);
		}
		[SmokeMethod("insertRows(int, int)")]
		public override bool InsertRows(int row, int count) {
			return (bool) interceptor.Invoke("insertRows$$", "insertRows(int, int)", typeof(bool), typeof(int), row, typeof(int), count);
		}
		[SmokeMethod("insertColumns(int, int, const QModelIndex&)")]
		public override bool InsertColumns(int column, int count, QModelIndex parent) {
			return (bool) interceptor.Invoke("insertColumns$$#", "insertColumns(int, int, const QModelIndex&)", typeof(bool), typeof(int), column, typeof(int), count, typeof(QModelIndex), parent);
		}
		[SmokeMethod("insertColumns(int, int)")]
		public override bool InsertColumns(int column, int count) {
			return (bool) interceptor.Invoke("insertColumns$$", "insertColumns(int, int)", typeof(bool), typeof(int), column, typeof(int), count);
		}
		[SmokeMethod("removeRows(int, int, const QModelIndex&)")]
		public override bool RemoveRows(int row, int count, QModelIndex parent) {
			return (bool) interceptor.Invoke("removeRows$$#", "removeRows(int, int, const QModelIndex&)", typeof(bool), typeof(int), row, typeof(int), count, typeof(QModelIndex), parent);
		}
		[SmokeMethod("removeRows(int, int)")]
		public override bool RemoveRows(int row, int count) {
			return (bool) interceptor.Invoke("removeRows$$", "removeRows(int, int)", typeof(bool), typeof(int), row, typeof(int), count);
		}
		[SmokeMethod("removeColumns(int, int, const QModelIndex&)")]
		public override bool RemoveColumns(int column, int count, QModelIndex parent) {
			return (bool) interceptor.Invoke("removeColumns$$#", "removeColumns(int, int, const QModelIndex&)", typeof(bool), typeof(int), column, typeof(int), count, typeof(QModelIndex), parent);
		}
		[SmokeMethod("removeColumns(int, int)")]
		public override bool RemoveColumns(int column, int count) {
			return (bool) interceptor.Invoke("removeColumns$$", "removeColumns(int, int)", typeof(bool), typeof(int), column, typeof(int), count);
		}
		[SmokeMethod("fetchMore(const QModelIndex&)")]
		public override void FetchMore(QModelIndex parent) {
			interceptor.Invoke("fetchMore#", "fetchMore(const QModelIndex&)", typeof(void), typeof(QModelIndex), parent);
		}
		[SmokeMethod("canFetchMore(const QModelIndex&) const")]
		public override bool CanFetchMore(QModelIndex parent) {
			return (bool) interceptor.Invoke("canFetchMore#", "canFetchMore(const QModelIndex&) const", typeof(bool), typeof(QModelIndex), parent);
		}
		[SmokeMethod("flags(const QModelIndex&) const")]
		public override uint Flags(QModelIndex index) {
			return (uint) interceptor.Invoke("flags#", "flags(const QModelIndex&) const", typeof(uint), typeof(QModelIndex), index);
		}
		[SmokeMethod("buddy(const QModelIndex&) const")]
		public override QModelIndex Buddy(QModelIndex index) {
			return (QModelIndex) interceptor.Invoke("buddy#", "buddy(const QModelIndex&) const", typeof(QModelIndex), typeof(QModelIndex), index);
		}
		[SmokeMethod("match(const QModelIndex&, int, const QVariant&, int, Qt::MatchFlags) const")]
		public override List<QModelIndex> Match(QModelIndex start, int role, QVariant value, int hits, uint flags) {
			return (List<QModelIndex>) interceptor.Invoke("match#$#$$", "match(const QModelIndex&, int, const QVariant&, int, Qt::MatchFlags) const", typeof(List<QModelIndex>), typeof(QModelIndex), start, typeof(int), role, typeof(QVariant), value, typeof(int), hits, typeof(uint), flags);
		}
		[SmokeMethod("match(const QModelIndex&, int, const QVariant&, int) const")]
		public override List<QModelIndex> Match(QModelIndex start, int role, QVariant value, int hits) {
			return (List<QModelIndex>) interceptor.Invoke("match#$#$", "match(const QModelIndex&, int, const QVariant&, int) const", typeof(List<QModelIndex>), typeof(QModelIndex), start, typeof(int), role, typeof(QVariant), value, typeof(int), hits);
		}
		[SmokeMethod("match(const QModelIndex&, int, const QVariant&) const")]
		public override List<QModelIndex> Match(QModelIndex start, int role, QVariant value) {
			return (List<QModelIndex>) interceptor.Invoke("match#$#", "match(const QModelIndex&, int, const QVariant&) const", typeof(List<QModelIndex>), typeof(QModelIndex), start, typeof(int), role, typeof(QVariant), value);
		}
		[SmokeMethod("span(const QModelIndex&) const")]
		public override QSize Span(QModelIndex index) {
			return (QSize) interceptor.Invoke("span#", "span(const QModelIndex&) const", typeof(QSize), typeof(QModelIndex), index);
		}
		[SmokeMethod("sort(int, Qt::SortOrder)")]
		public override void Sort(int column, Qt.SortOrder order) {
			interceptor.Invoke("sort$$", "sort(int, Qt::SortOrder)", typeof(void), typeof(int), column, typeof(Qt.SortOrder), order);
		}
		[SmokeMethod("sort(int)")]
		public override void Sort(int column) {
			interceptor.Invoke("sort$", "sort(int)", typeof(void), typeof(int), column);
		}
		[SmokeMethod("mimeTypes() const")]
		public override List<string> MimeTypes() {
			return (List<string>) interceptor.Invoke("mimeTypes", "mimeTypes() const", typeof(List<string>));
		}
		[SmokeMethod("supportedDropActions() const")]
		public override uint SupportedDropActions() {
			return (uint) interceptor.Invoke("supportedDropActions", "supportedDropActions() const", typeof(uint));
		}
		[Q_SLOT("void setFilterRegExp(const QString&)")]
		public void SetFilterRegExp(string pattern) {
			interceptor.Invoke("setFilterRegExp$", "setFilterRegExp(const QString&)", typeof(void), typeof(string), pattern);
		}
		[Q_SLOT("void setFilterWildcard(const QString&)")]
		public void SetFilterWildcard(string pattern) {
			interceptor.Invoke("setFilterWildcard$", "setFilterWildcard(const QString&)", typeof(void), typeof(string), pattern);
		}
		[Q_SLOT("void setFilterFixedString(const QString&)")]
		public void SetFilterFixedString(string pattern) {
			interceptor.Invoke("setFilterFixedString$", "setFilterFixedString(const QString&)", typeof(void), typeof(string), pattern);
		}
		[Q_SLOT("void clear()")]
		public void Clear() {
			interceptor.Invoke("clear", "clear()", typeof(void));
		}
		[Q_SLOT("void invalidate()")]
		public void Invalidate() {
			interceptor.Invoke("invalidate", "invalidate()", typeof(void));
		}
		[SmokeMethod("filterAcceptsRow(int, const QModelIndex&) const")]
		protected virtual bool FilterAcceptsRow(int source_row, QModelIndex source_parent) {
			return (bool) interceptor.Invoke("filterAcceptsRow$#", "filterAcceptsRow(int, const QModelIndex&) const", typeof(bool), typeof(int), source_row, typeof(QModelIndex), source_parent);
		}
		[SmokeMethod("filterAcceptsColumn(int, const QModelIndex&) const")]
		protected virtual bool FilterAcceptsColumn(int source_column, QModelIndex source_parent) {
			return (bool) interceptor.Invoke("filterAcceptsColumn$#", "filterAcceptsColumn(int, const QModelIndex&) const", typeof(bool), typeof(int), source_column, typeof(QModelIndex), source_parent);
		}
		[SmokeMethod("lessThan(const QModelIndex&, const QModelIndex&) const")]
		protected virtual bool LessThan(QModelIndex left, QModelIndex right) {
			return (bool) interceptor.Invoke("lessThan##", "lessThan(const QModelIndex&, const QModelIndex&) const", typeof(bool), typeof(QModelIndex), left, typeof(QModelIndex), right);
		}
		protected void FilterChanged() {
			interceptor.Invoke("filterChanged", "filterChanged()", typeof(void));
		}
		protected void InvalidateFilter() {
			interceptor.Invoke("invalidateFilter", "invalidateFilter()", typeof(void));
		}
		~QSortFilterProxyModel() {
			interceptor.Invoke("~QSortFilterProxyModel", "~QSortFilterProxyModel()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~QSortFilterProxyModel", "~QSortFilterProxyModel()", typeof(void));
		}
		public static new string Tr(string s, string c) {
			return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
		}
		public static new string Tr(string s) {
			return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
		}
		protected new IQSortFilterProxyModelSignals Emit {
			get { return (IQSortFilterProxyModelSignals) Q_EMIT; }
		}
	}

	public interface IQSortFilterProxyModelSignals : IQAbstractProxyModelSignals {
	}
}
