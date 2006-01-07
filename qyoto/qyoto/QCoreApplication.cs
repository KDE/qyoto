//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	/// See <see cref="IQCoreApplicationSignals"></see> for signals emitted by QCoreApplication
	public class QCoreApplication : QObject, IDisposable {
 		protected QCoreApplication(Type dummy) : base((Type) null) {}
		interface IQCoreApplicationProxy {
			string Tr(string s, string c);
			string Tr(string s);
			void SetOrganizationDomain(string orgDomain);
			string OrganizationDomain();
			void SetOrganizationName(string orgName);
			string OrganizationName();
			void SetApplicationName(string application);
			string ApplicationName();
			QCoreApplication Instance();
			int Exec();
			void ProcessEvents(uint flags);
			void ProcessEvents();
			void ProcessEvents(uint flags, int maxtime);
			void Exit(int retcode);
			void Exit();
			bool SendEvent(QObject receiver, QEvent arg2);
			void PostEvent(QObject receiver, QEvent arg2);
			void SendPostedEvents(QObject receiver, int event_type);
			void SendPostedEvents();
			void RemovePostedEvents(QObject receiver);
			bool HasPendingEvents();
			bool StartingUp();
			bool ClosingDown();
			string ApplicationDirPath();
			string ApplicationFilePath();
			void SetLibraryPaths(string[] arg1);
			ArrayList LibraryPaths();
			void AddLibraryPath(string arg1);
			void RemoveLibraryPath(string arg1);
			void InstallTranslator(QTranslator arg1);
			void RemoveTranslator(QTranslator arg1);
			string Translate(string context, string key, string comment, int encoding);
			string Translate(string context, string key, string comment);
			string Translate(string context, string key);
			void Flush();
			void WatchUnixSignal(int signal, bool watch);
			void Quit();
		}

		protected void CreateQCoreApplicationProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QCoreApplication), this);
			_interceptor = (QCoreApplication) realProxy.GetTransparentProxy();
		}
		private QCoreApplication ProxyQCoreApplication() {
			return (QCoreApplication) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QCoreApplication() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQCoreApplicationProxy), null);
			_staticInterceptor = (IQCoreApplicationProxy) realProxy.GetTransparentProxy();
		}
		private static IQCoreApplicationProxy StaticQCoreApplication() {
			return (IQCoreApplicationProxy) _staticInterceptor;
		}

		enum Encoding {
			DefaultCodec = 0,
			UnicodeUTF8 = 1,
		}
		public new virtual QMetaObject MetaObject() {
			return ProxyQCoreApplication().MetaObject();
		}
		// void* qt_metacast(const char* arg1); >>>> NOT CONVERTED
		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QCoreApplication(out int argc, string[] argv) : this((Type) null) {
			CreateQCoreApplicationProxy();
			NewQCoreApplication(out argc,argv);
		}
		private void NewQCoreApplication(out int argc, string[] argv) {
			ProxyQCoreApplication().NewQCoreApplication(out argc,argv);
		}
		public virtual bool Notify(QObject arg1, QEvent arg2) {
			return ProxyQCoreApplication().Notify(arg1,arg2);
		}
		// EventFilter setEventFilter(EventFilter arg1); >>>> NOT CONVERTED
		// bool filterEvent(void* arg1,long* arg2); >>>> NOT CONVERTED
		public static new string Tr(string s, string c) {
			return StaticQCoreApplication().Tr(s,c);
		}
		public static new string Tr(string s) {
			return StaticQCoreApplication().Tr(s);
		}
		public static void SetOrganizationDomain(string orgDomain) {
			StaticQCoreApplication().SetOrganizationDomain(orgDomain);
		}
		public static string OrganizationDomain() {
			return StaticQCoreApplication().OrganizationDomain();
		}
		public static void SetOrganizationName(string orgName) {
			StaticQCoreApplication().SetOrganizationName(orgName);
		}
		public static string OrganizationName() {
			return StaticQCoreApplication().OrganizationName();
		}
		public static void SetApplicationName(string application) {
			StaticQCoreApplication().SetApplicationName(application);
		}
		public static string ApplicationName() {
			return StaticQCoreApplication().ApplicationName();
		}
		public static QCoreApplication Instance() {
			return StaticQCoreApplication().Instance();
		}
		public static int Exec() {
			return StaticQCoreApplication().Exec();
		}
		public static void ProcessEvents(uint flags) {
			StaticQCoreApplication().ProcessEvents(flags);
		}
		public static void ProcessEvents() {
			StaticQCoreApplication().ProcessEvents();
		}
		public static void ProcessEvents(uint flags, int maxtime) {
			StaticQCoreApplication().ProcessEvents(flags,maxtime);
		}
		public static void Exit(int retcode) {
			StaticQCoreApplication().Exit(retcode);
		}
		public static void Exit() {
			StaticQCoreApplication().Exit();
		}
		public static bool SendEvent(QObject receiver, QEvent arg2) {
			return StaticQCoreApplication().SendEvent(receiver,arg2);
		}
		public static void PostEvent(QObject receiver, QEvent arg2) {
			StaticQCoreApplication().PostEvent(receiver,arg2);
		}
		public static void SendPostedEvents(QObject receiver, int event_type) {
			StaticQCoreApplication().SendPostedEvents(receiver,event_type);
		}
		public static void SendPostedEvents() {
			StaticQCoreApplication().SendPostedEvents();
		}
		public static void RemovePostedEvents(QObject receiver) {
			StaticQCoreApplication().RemovePostedEvents(receiver);
		}
		public static bool HasPendingEvents() {
			return StaticQCoreApplication().HasPendingEvents();
		}
		public static bool StartingUp() {
			return StaticQCoreApplication().StartingUp();
		}
		public static bool ClosingDown() {
			return StaticQCoreApplication().ClosingDown();
		}
		public static string ApplicationDirPath() {
			return StaticQCoreApplication().ApplicationDirPath();
		}
		public static string ApplicationFilePath() {
			return StaticQCoreApplication().ApplicationFilePath();
		}
		public static void SetLibraryPaths(string[] arg1) {
			StaticQCoreApplication().SetLibraryPaths(arg1);
		}
		public static ArrayList LibraryPaths() {
			return StaticQCoreApplication().LibraryPaths();
		}
		public static void AddLibraryPath(string arg1) {
			StaticQCoreApplication().AddLibraryPath(arg1);
		}
		public static void RemoveLibraryPath(string arg1) {
			StaticQCoreApplication().RemoveLibraryPath(arg1);
		}
		public static void InstallTranslator(QTranslator arg1) {
			StaticQCoreApplication().InstallTranslator(arg1);
		}
		public static void RemoveTranslator(QTranslator arg1) {
			StaticQCoreApplication().RemoveTranslator(arg1);
		}
		public static string Translate(string context, string key, string comment, int encoding) {
			return StaticQCoreApplication().Translate(context,key,comment,encoding);
		}
		public static string Translate(string context, string key, string comment) {
			return StaticQCoreApplication().Translate(context,key,comment);
		}
		public static string Translate(string context, string key) {
			return StaticQCoreApplication().Translate(context,key);
		}
		public static void Flush() {
			StaticQCoreApplication().Flush();
		}
		public static void WatchUnixSignal(int signal, bool watch) {
			StaticQCoreApplication().WatchUnixSignal(signal,watch);
		}
		public static void Quit() {
			StaticQCoreApplication().Quit();
		}
		public new bool Event(QEvent arg1) {
			return ProxyQCoreApplication().Event(arg1);
		}
		// bool compressEvent(QEvent* arg1,QObject* arg2,QPostEventList* arg3); >>>> NOT CONVERTED
		// QCoreApplication* QCoreApplication(QCoreApplicationPrivate& arg1); >>>> NOT CONVERTED
		~QCoreApplication() {
			ProxyQCoreApplication().Dispose();
		}
		public new void Dispose() {
			ProxyQCoreApplication().Dispose();
		}
	}

	public interface IQCoreApplicationSignals {
		void AboutToQuit();
		void UnixSignal(int arg1);
	}
}