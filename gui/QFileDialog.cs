//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    using System.Text;
    using System.Collections.Generic;
    /// <remarks> See <see cref="IQFileDialogSignals"></see> for signals emitted by QFileDialog
    /// </remarks>
    [SmokeClass("QFileDialog")]
    public class QFileDialog : QDialog, IDisposable {
        protected QFileDialog(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QFileDialog), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QFileDialog() {
            staticInterceptor = new SmokeInvocation(typeof(QFileDialog), null);
        }
        public enum ViewMode {
            Detail = 0,
            List = 1,
        }
        public enum FileMode {
            AnyFile = 0,
            ExistingFile = 1,
            Directory = 2,
            ExistingFiles = 3,
            DirectoryOnly = 4,
        }
        public enum AcceptMode {
            AcceptOpen = 0,
            AcceptSave = 1,
        }
        public enum DialogLabel {
            LookIn = 0,
            FileName = 1,
            FileType = 2,
            Accept = 3,
            Reject = 4,
        }
        public enum Option {
            ShowDirsOnly = 0x00000001,
            DontResolveSymlinks = 0x00000002,
            DontConfirmOverwrite = 0x00000004,
            DontUseSheet = 0x00000008,
            DontUseNativeDialog = 0x00000010,
            ReadOnly = 0x00000020,
            HideNameFilterDetails = 0x00000040,
        }
        [Q_PROPERTY("QFileDialog::ViewMode", "viewMode")]
        public QFileDialog.ViewMode viewMode {
            get { return (QFileDialog.ViewMode) interceptor.Invoke("viewMode", "viewMode()", typeof(QFileDialog.ViewMode)); }
            set { interceptor.Invoke("setViewMode$", "setViewMode(QFileDialog::ViewMode)", typeof(void), typeof(QFileDialog.ViewMode), value); }
        }
        [Q_PROPERTY("QFileDialog::FileMode", "fileMode")]
        public QFileDialog.FileMode fileMode {
            get { return (QFileDialog.FileMode) interceptor.Invoke("fileMode", "fileMode()", typeof(QFileDialog.FileMode)); }
            set { interceptor.Invoke("setFileMode$", "setFileMode(QFileDialog::FileMode)", typeof(void), typeof(QFileDialog.FileMode), value); }
        }
        [Q_PROPERTY("QFileDialog::AcceptMode", "acceptMode")]
        public QFileDialog.AcceptMode acceptMode {
            get { return (QFileDialog.AcceptMode) interceptor.Invoke("acceptMode", "acceptMode()", typeof(QFileDialog.AcceptMode)); }
            set { interceptor.Invoke("setAcceptMode$", "setAcceptMode(QFileDialog::AcceptMode)", typeof(void), typeof(QFileDialog.AcceptMode), value); }
        }
        [Q_PROPERTY("bool", "readOnly")]
        public bool ReadOnly {
            get { return (bool) interceptor.Invoke("isReadOnly", "isReadOnly()", typeof(bool)); }
            set { interceptor.Invoke("setReadOnly$", "setReadOnly(bool)", typeof(void), typeof(bool), value); }
        }
        [Q_PROPERTY("bool", "resolveSymlinks")]
        public bool ResolveSymlinks {
            get { return (bool) interceptor.Invoke("resolveSymlinks", "resolveSymlinks()", typeof(bool)); }
            set { interceptor.Invoke("setResolveSymlinks$", "setResolveSymlinks(bool)", typeof(void), typeof(bool), value); }
        }
        [Q_PROPERTY("bool", "confirmOverwrite")]
        public bool ConfirmOverwrite {
            get { return (bool) interceptor.Invoke("confirmOverwrite", "confirmOverwrite()", typeof(bool)); }
            set { interceptor.Invoke("setConfirmOverwrite$", "setConfirmOverwrite(bool)", typeof(void), typeof(bool), value); }
        }
        [Q_PROPERTY("QString", "defaultSuffix")]
        public string DefaultSuffix {
            get { return (string) interceptor.Invoke("defaultSuffix", "defaultSuffix()", typeof(string)); }
            set { interceptor.Invoke("setDefaultSuffix$", "setDefaultSuffix(QString)", typeof(void), typeof(string), value); }
        }
        [Q_PROPERTY("bool", "nameFilterDetailsVisible")]
        public bool NameFilterDetailsVisible {
            get { return (bool) interceptor.Invoke("isNameFilterDetailsVisible", "isNameFilterDetailsVisible()", typeof(bool)); }
            set { interceptor.Invoke("setNameFilterDetailsVisible$", "setNameFilterDetailsVisible(bool)", typeof(void), typeof(bool), value); }
        }
        [Q_PROPERTY("QFileDialog::Options", "options")]
        public uint Options {
            get { return (uint) interceptor.Invoke("options", "options()", typeof(uint)); }
            set { interceptor.Invoke("setOptions$", "setOptions(QFileDialog::Options)", typeof(void), typeof(uint), value); }
        }
        // QFileDialog* QFileDialog(const QFileDialogArgs& arg1); >>>> NOT CONVERTED
        public QFileDialog(QWidget parent, uint f) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QFileDialog#$", "QFileDialog(QWidget*, Qt::WindowFlags)", typeof(void), typeof(QWidget), parent, typeof(uint), f);
        }
        public QFileDialog(QWidget parent, string caption, string directory, string filter) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QFileDialog#$$$", "QFileDialog(QWidget*, const QString&, const QString&, const QString&)", typeof(void), typeof(QWidget), parent, typeof(string), caption, typeof(string), directory, typeof(string), filter);
        }
        public QFileDialog(QWidget parent, string caption, string directory) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QFileDialog#$$", "QFileDialog(QWidget*, const QString&, const QString&)", typeof(void), typeof(QWidget), parent, typeof(string), caption, typeof(string), directory);
        }
        public QFileDialog(QWidget parent, string caption) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QFileDialog#$", "QFileDialog(QWidget*, const QString&)", typeof(void), typeof(QWidget), parent, typeof(string), caption);
        }
        public QFileDialog(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QFileDialog#", "QFileDialog(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public QFileDialog() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QFileDialog", "QFileDialog()", typeof(void));
        }
        public void SetDirectory(string directory) {
            interceptor.Invoke("setDirectory$", "setDirectory(const QString&)", typeof(void), typeof(string), directory);
        }
        public void SetDirectory(QDir directory) {
            interceptor.Invoke("setDirectory#", "setDirectory(const QDir&)", typeof(void), typeof(QDir), directory);
        }
        public QDir Directory() {
            return (QDir) interceptor.Invoke("directory", "directory() const", typeof(QDir));
        }
        public void SelectFile(string filename) {
            interceptor.Invoke("selectFile$", "selectFile(const QString&)", typeof(void), typeof(string), filename);
        }
        public List<string> SelectedFiles() {
            return (List<string>) interceptor.Invoke("selectedFiles", "selectedFiles() const", typeof(List<string>));
        }
        public void SetNameFilter(string filter) {
            interceptor.Invoke("setNameFilter$", "setNameFilter(const QString&)", typeof(void), typeof(string), filter);
        }
        public void SetNameFilters(List<string> filters) {
            interceptor.Invoke("setNameFilters?", "setNameFilters(const QStringList&)", typeof(void), typeof(List<string>), filters);
        }
        public List<string> NameFilters() {
            return (List<string>) interceptor.Invoke("nameFilters", "nameFilters() const", typeof(List<string>));
        }
        public void SelectNameFilter(string filter) {
            interceptor.Invoke("selectNameFilter$", "selectNameFilter(const QString&)", typeof(void), typeof(string), filter);
        }
        public string SelectedNameFilter() {
            return (string) interceptor.Invoke("selectedNameFilter", "selectedNameFilter() const", typeof(string));
        }
        public uint Filter() {
            return (uint) interceptor.Invoke("filter", "filter() const", typeof(uint));
        }
        public void SetFilter(uint filters) {
            interceptor.Invoke("setFilter$", "setFilter(QDir::Filters)", typeof(void), typeof(uint), filters);
        }
        public void SetSidebarUrls(List<QUrl> urls) {
            interceptor.Invoke("setSidebarUrls?", "setSidebarUrls(const QList<QUrl>&)", typeof(void), typeof(List<QUrl>), urls);
        }
        public List<QUrl> SidebarUrls() {
            return (List<QUrl>) interceptor.Invoke("sidebarUrls", "sidebarUrls() const", typeof(List<QUrl>));
        }
        public QByteArray SaveState() {
            return (QByteArray) interceptor.Invoke("saveState", "saveState() const", typeof(QByteArray));
        }
        public bool RestoreState(QByteArray state) {
            return (bool) interceptor.Invoke("restoreState#", "restoreState(const QByteArray&)", typeof(bool), typeof(QByteArray), state);
        }
        public void SetHistory(List<string> paths) {
            interceptor.Invoke("setHistory?", "setHistory(const QStringList&)", typeof(void), typeof(List<string>), paths);
        }
        public List<string> History() {
            return (List<string>) interceptor.Invoke("history", "history() const", typeof(List<string>));
        }
        public void SetItemDelegate(QAbstractItemDelegate arg1) {
            interceptor.Invoke("setItemDelegate#", "setItemDelegate(QAbstractItemDelegate*)", typeof(void), typeof(QAbstractItemDelegate), arg1);
        }
        public QAbstractItemDelegate ItemDelegate() {
            return (QAbstractItemDelegate) interceptor.Invoke("itemDelegate", "itemDelegate() const", typeof(QAbstractItemDelegate));
        }
        public void SetIconProvider(QFileIconProvider provider) {
            interceptor.Invoke("setIconProvider#", "setIconProvider(QFileIconProvider*)", typeof(void), typeof(QFileIconProvider), provider);
        }
        public QFileIconProvider IconProvider() {
            return (QFileIconProvider) interceptor.Invoke("iconProvider", "iconProvider() const", typeof(QFileIconProvider));
        }
        public void SetLabelText(QFileDialog.DialogLabel label, string text) {
            interceptor.Invoke("setLabelText$$", "setLabelText(QFileDialog::DialogLabel, const QString&)", typeof(void), typeof(QFileDialog.DialogLabel), label, typeof(string), text);
        }
        public string LabelText(QFileDialog.DialogLabel label) {
            return (string) interceptor.Invoke("labelText$", "labelText(QFileDialog::DialogLabel) const", typeof(string), typeof(QFileDialog.DialogLabel), label);
        }
        public void SetProxyModel(QAbstractProxyModel model) {
            interceptor.Invoke("setProxyModel#", "setProxyModel(QAbstractProxyModel*)", typeof(void), typeof(QAbstractProxyModel), model);
        }
        public QAbstractProxyModel ProxyModel() {
            return (QAbstractProxyModel) interceptor.Invoke("proxyModel", "proxyModel() const", typeof(QAbstractProxyModel));
        }
        public void SetOption(QFileDialog.Option option, bool on) {
            interceptor.Invoke("setOption$$", "setOption(QFileDialog::Option, bool)", typeof(void), typeof(QFileDialog.Option), option, typeof(bool), on);
        }
        public void SetOption(QFileDialog.Option option) {
            interceptor.Invoke("setOption$", "setOption(QFileDialog::Option)", typeof(void), typeof(QFileDialog.Option), option);
        }
        public bool TestOption(QFileDialog.Option option) {
            return (bool) interceptor.Invoke("testOption$", "testOption(QFileDialog::Option) const", typeof(bool), typeof(QFileDialog.Option), option);
        }
        public new void Open() {
            interceptor.Invoke("open", "open()", typeof(void));
        }
        public void Open(QObject receiver, string member) {
            interceptor.Invoke("open#$", "open(QObject*, const char*)", typeof(void), typeof(QObject), receiver, typeof(string), member);
        }
        [SmokeMethod("setVisible(bool)")]
        public override void SetVisible(bool visible) {
            interceptor.Invoke("setVisible$", "setVisible(bool)", typeof(void), typeof(bool), visible);
        }
        [SmokeMethod("done(int)")]
        protected new virtual void Done(int result) {
            interceptor.Invoke("done$", "done(int)", typeof(void), typeof(int), result);
        }
        [SmokeMethod("accept()")]
        protected new virtual void Accept() {
            interceptor.Invoke("accept", "accept()", typeof(void));
        }
        [SmokeMethod("changeEvent(QEvent*)")]
        protected override void ChangeEvent(QEvent e) {
            interceptor.Invoke("changeEvent#", "changeEvent(QEvent*)", typeof(void), typeof(QEvent), e);
        }
        ~QFileDialog() {
            interceptor.Invoke("~QFileDialog", "~QFileDialog()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~QFileDialog", "~QFileDialog()", typeof(void));
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        public static string GetOpenFileName(QWidget parent, string caption, string dir, string filter, StringBuilder selectedFilter, uint options) {
            return (string) staticInterceptor.Invoke("getOpenFileName#$$$$$", "getOpenFileName(QWidget*, const QString&, const QString&, const QString&, QString*, QFileDialog::Options)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(string), filter, typeof(StringBuilder), selectedFilter, typeof(uint), options);
        }
        public static string GetOpenFileName(QWidget parent, string caption, string dir, string filter, StringBuilder selectedFilter) {
            return (string) staticInterceptor.Invoke("getOpenFileName#$$$$", "getOpenFileName(QWidget*, const QString&, const QString&, const QString&, QString*)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(string), filter, typeof(StringBuilder), selectedFilter);
        }
        public static string GetOpenFileName(QWidget parent, string caption, string dir, string filter) {
            return (string) staticInterceptor.Invoke("getOpenFileName#$$$", "getOpenFileName(QWidget*, const QString&, const QString&, const QString&)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(string), filter);
        }
        public static string GetOpenFileName(QWidget parent, string caption, string dir) {
            return (string) staticInterceptor.Invoke("getOpenFileName#$$", "getOpenFileName(QWidget*, const QString&, const QString&)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir);
        }
        public static string GetOpenFileName(QWidget parent, string caption) {
            return (string) staticInterceptor.Invoke("getOpenFileName#$", "getOpenFileName(QWidget*, const QString&)", typeof(string), typeof(QWidget), parent, typeof(string), caption);
        }
        public static string GetOpenFileName(QWidget parent) {
            return (string) staticInterceptor.Invoke("getOpenFileName#", "getOpenFileName(QWidget*)", typeof(string), typeof(QWidget), parent);
        }
        public static string GetOpenFileName() {
            return (string) staticInterceptor.Invoke("getOpenFileName", "getOpenFileName()", typeof(string));
        }
        public static string GetSaveFileName(QWidget parent, string caption, string dir, string filter, StringBuilder selectedFilter, uint options) {
            return (string) staticInterceptor.Invoke("getSaveFileName#$$$$$", "getSaveFileName(QWidget*, const QString&, const QString&, const QString&, QString*, QFileDialog::Options)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(string), filter, typeof(StringBuilder), selectedFilter, typeof(uint), options);
        }
        public static string GetSaveFileName(QWidget parent, string caption, string dir, string filter, StringBuilder selectedFilter) {
            return (string) staticInterceptor.Invoke("getSaveFileName#$$$$", "getSaveFileName(QWidget*, const QString&, const QString&, const QString&, QString*)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(string), filter, typeof(StringBuilder), selectedFilter);
        }
        public static string GetSaveFileName(QWidget parent, string caption, string dir, string filter) {
            return (string) staticInterceptor.Invoke("getSaveFileName#$$$", "getSaveFileName(QWidget*, const QString&, const QString&, const QString&)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(string), filter);
        }
        public static string GetSaveFileName(QWidget parent, string caption, string dir) {
            return (string) staticInterceptor.Invoke("getSaveFileName#$$", "getSaveFileName(QWidget*, const QString&, const QString&)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir);
        }
        public static string GetSaveFileName(QWidget parent, string caption) {
            return (string) staticInterceptor.Invoke("getSaveFileName#$", "getSaveFileName(QWidget*, const QString&)", typeof(string), typeof(QWidget), parent, typeof(string), caption);
        }
        public static string GetSaveFileName(QWidget parent) {
            return (string) staticInterceptor.Invoke("getSaveFileName#", "getSaveFileName(QWidget*)", typeof(string), typeof(QWidget), parent);
        }
        public static string GetSaveFileName() {
            return (string) staticInterceptor.Invoke("getSaveFileName", "getSaveFileName()", typeof(string));
        }
        public static string GetExistingDirectory(QWidget parent, string caption, string dir, uint options) {
            return (string) staticInterceptor.Invoke("getExistingDirectory#$$$", "getExistingDirectory(QWidget*, const QString&, const QString&, QFileDialog::Options)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(uint), options);
        }
        public static string GetExistingDirectory(QWidget parent, string caption, string dir) {
            return (string) staticInterceptor.Invoke("getExistingDirectory#$$", "getExistingDirectory(QWidget*, const QString&, const QString&)", typeof(string), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir);
        }
        public static string GetExistingDirectory(QWidget parent, string caption) {
            return (string) staticInterceptor.Invoke("getExistingDirectory#$", "getExistingDirectory(QWidget*, const QString&)", typeof(string), typeof(QWidget), parent, typeof(string), caption);
        }
        public static string GetExistingDirectory(QWidget parent) {
            return (string) staticInterceptor.Invoke("getExistingDirectory#", "getExistingDirectory(QWidget*)", typeof(string), typeof(QWidget), parent);
        }
        public static string GetExistingDirectory() {
            return (string) staticInterceptor.Invoke("getExistingDirectory", "getExistingDirectory()", typeof(string));
        }
        public static List<string> GetOpenFileNames(QWidget parent, string caption, string dir, string filter, StringBuilder selectedFilter, uint options) {
            return (List<string>) staticInterceptor.Invoke("getOpenFileNames#$$$$$", "getOpenFileNames(QWidget*, const QString&, const QString&, const QString&, QString*, QFileDialog::Options)", typeof(List<string>), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(string), filter, typeof(StringBuilder), selectedFilter, typeof(uint), options);
        }
        public static List<string> GetOpenFileNames(QWidget parent, string caption, string dir, string filter, StringBuilder selectedFilter) {
            return (List<string>) staticInterceptor.Invoke("getOpenFileNames#$$$$", "getOpenFileNames(QWidget*, const QString&, const QString&, const QString&, QString*)", typeof(List<string>), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(string), filter, typeof(StringBuilder), selectedFilter);
        }
        public static List<string> GetOpenFileNames(QWidget parent, string caption, string dir, string filter) {
            return (List<string>) staticInterceptor.Invoke("getOpenFileNames#$$$", "getOpenFileNames(QWidget*, const QString&, const QString&, const QString&)", typeof(List<string>), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir, typeof(string), filter);
        }
        public static List<string> GetOpenFileNames(QWidget parent, string caption, string dir) {
            return (List<string>) staticInterceptor.Invoke("getOpenFileNames#$$", "getOpenFileNames(QWidget*, const QString&, const QString&)", typeof(List<string>), typeof(QWidget), parent, typeof(string), caption, typeof(string), dir);
        }
        public static List<string> GetOpenFileNames(QWidget parent, string caption) {
            return (List<string>) staticInterceptor.Invoke("getOpenFileNames#$", "getOpenFileNames(QWidget*, const QString&)", typeof(List<string>), typeof(QWidget), parent, typeof(string), caption);
        }
        public static List<string> GetOpenFileNames(QWidget parent) {
            return (List<string>) staticInterceptor.Invoke("getOpenFileNames#", "getOpenFileNames(QWidget*)", typeof(List<string>), typeof(QWidget), parent);
        }
        public static List<string> GetOpenFileNames() {
            return (List<string>) staticInterceptor.Invoke("getOpenFileNames", "getOpenFileNames()", typeof(List<string>));
        }
        protected new IQFileDialogSignals Emit {
            get { return (IQFileDialogSignals) Q_EMIT; }
        }
    }

    public interface IQFileDialogSignals : IQDialogSignals {
        [Q_SIGNAL("void fileSelected(QString)")]
        void FileSelected(string file);
        [Q_SIGNAL("void filesSelected(QStringList)")]
        void FilesSelected(List<string> files);
        [Q_SIGNAL("void currentChanged(QString)")]
        void CurrentChanged(string path);
        [Q_SIGNAL("void directoryEntered(QString)")]
        void DirectoryEntered(string directory);
        [Q_SIGNAL("void filterSelected(QString)")]
        void FilterSelected(string filter);
    }
}