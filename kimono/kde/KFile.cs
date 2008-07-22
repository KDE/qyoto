//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    /// <remarks>
    ///  KFile is a class which provides a namespace for some enumerated
    ///  values associated with the kfile library.  You will never need to
    ///  construct a KFile object itself.
    ///  </remarks>        <short>    KFile is a class which provides a namespace for some enumerated  values associated with the kfile library.</short>
    [SmokeClass("KFile")]
    public class KFile : Object {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected KFile(Type dummy) {}
        private static SmokeInvocation staticInterceptor = null;
        static KFile() {
            staticInterceptor = new SmokeInvocation(typeof(KFile), null);
        }
        /// <remarks>
        ///  Modes of operation for the dialog.
        /// 
        /// <li>
        /// <code>File</code> - Get a single file name from the user.
        /// </li>
        /// 
        /// <li>
        /// <code>Directory</code> - Get a directory name from the user.
        /// </li>
        /// 
        /// <li>
        /// <code>Files</code> - Get multiple file names from the user.
        /// </li>
        /// 
        /// <li>
        /// <code>ExistingOnly</code> - Never return a filename which does not exist yet
        /// </li>
        /// 
        /// <li>
        /// <code>LocalOnly</code> - Don't return remote filenames
        ///      
        /// </li></remarks>        <short>    Modes of operation for the dialog.</short>
        public enum Mode {
            File = 1,
            Directory = 2,
            Files = 4,
            ExistingOnly = 8,
            LocalOnly = 16,
            ModeMax = 65536,
        }
        public enum FileView {
            Default = 0,
            Simple = 1,
            Detail = 2,
            SeparateDirs = 4,
            PreviewContents = 8,
            PreviewInfo = 16,
            Tree = 32,
            DetailTree = 64,
            FileViewMax = 65536,
        }
        public enum SelectionMode {
            Single = 1,
            Multi = 2,
            Extended = 4,
            NoSelection = 8,
        }
        public static bool IsSortByName(uint sort) {
            return (bool) staticInterceptor.Invoke("isSortByName$", "isSortByName(const QDir::SortFlags&)", typeof(bool), typeof(uint), sort);
        }
        public static bool IsSortBySize(uint sort) {
            return (bool) staticInterceptor.Invoke("isSortBySize$", "isSortBySize(const QDir::SortFlags&)", typeof(bool), typeof(uint), sort);
        }
        public static bool IsSortByDate(uint sort) {
            return (bool) staticInterceptor.Invoke("isSortByDate$", "isSortByDate(const QDir::SortFlags&)", typeof(bool), typeof(uint), sort);
        }
        public static bool IsSortByType(uint sort) {
            return (bool) staticInterceptor.Invoke("isSortByType$", "isSortByType(const QDir::SortFlags&)", typeof(bool), typeof(uint), sort);
        }
        public static bool IsSortDirsFirst(uint sort) {
            return (bool) staticInterceptor.Invoke("isSortDirsFirst$", "isSortDirsFirst(const QDir::SortFlags&)", typeof(bool), typeof(uint), sort);
        }
        public static bool IsSortCaseInsensitive(uint sort) {
            return (bool) staticInterceptor.Invoke("isSortCaseInsensitive$", "isSortCaseInsensitive(const QDir::SortFlags&)", typeof(bool), typeof(uint), sort);
        }
        public static bool IsDefaultView(KFile.FileView view) {
            return (bool) staticInterceptor.Invoke("isDefaultView$", "isDefaultView(const KFile::FileView&)", typeof(bool), typeof(KFile.FileView), view);
        }
        public static bool IsSimpleView(KFile.FileView view) {
            return (bool) staticInterceptor.Invoke("isSimpleView$", "isSimpleView(const KFile::FileView&)", typeof(bool), typeof(KFile.FileView), view);
        }
        public static bool IsDetailView(KFile.FileView view) {
            return (bool) staticInterceptor.Invoke("isDetailView$", "isDetailView(const KFile::FileView&)", typeof(bool), typeof(KFile.FileView), view);
        }
        public static bool IsSeparateDirs(KFile.FileView view) {
            return (bool) staticInterceptor.Invoke("isSeparateDirs$", "isSeparateDirs(const KFile::FileView&)", typeof(bool), typeof(KFile.FileView), view);
        }
        public static bool IsPreviewContents(KFile.FileView view) {
            return (bool) staticInterceptor.Invoke("isPreviewContents$", "isPreviewContents(const KFile::FileView&)", typeof(bool), typeof(KFile.FileView), view);
        }
        public static bool IsPreviewInfo(KFile.FileView view) {
            return (bool) staticInterceptor.Invoke("isPreviewInfo$", "isPreviewInfo(const KFile::FileView&)", typeof(bool), typeof(KFile.FileView), view);
        }
        public static bool IsTreeView(KFile.FileView view) {
            return (bool) staticInterceptor.Invoke("isTreeView$", "isTreeView(const KFile::FileView&)", typeof(bool), typeof(KFile.FileView), view);
        }
        public static bool IsDetailTreeView(KFile.FileView view) {
            return (bool) staticInterceptor.Invoke("isDetailTreeView$", "isDetailTreeView(const KFile::FileView&)", typeof(bool), typeof(KFile.FileView), view);
        }
    }
}
