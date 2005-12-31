//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	/// See <see cref="IQProcessSignals"></see> for signals emitted by QProcess
	public class QProcess : QObject, IDisposable {
 		protected QProcess(Type dummy) : base((Type) null) {}
		interface IQProcessProxy {
			string Tr(string arg1, string arg2);
			string Tr(string arg1);
			string TrUtf8(string arg1, string arg2);
			string TrUtf8(string arg1);
		}

		protected void CreateQProcessProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QProcess), this);
			_interceptor = (QProcess) realProxy.GetTransparentProxy();
		}
		private QProcess ProxyQProcess() {
			return (QProcess) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QProcess() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQProcessProxy), null);
			_staticInterceptor = (IQProcessProxy) realProxy.GetTransparentProxy();
		}
		private static IQProcessProxy StaticQProcess() {
			return (IQProcessProxy) _staticInterceptor;
		}

		enum E_Communication {
			Stdin = 0x01,
			Stdout = 0x02,
			Stderr = 0x04,
			DupStderr = 0x08,
		}
		[SmokeMethod("metaObject() const")]
		public new virtual QMetaObject MetaObject() {
			return ProxyQProcess().MetaObject();
		}
		[SmokeMethod("className() const")]
		public new virtual string ClassName() {
			return ProxyQProcess().ClassName();
		}
		public QProcess(QObject parent, string name) : this((Type) null) {
			CreateQProcessProxy();
			CreateQProcessSignalProxy();
			NewQProcess(parent,name);
		}
		[SmokeMethod("QProcess(QObject*, const char*)")]
		private void NewQProcess(QObject parent, string name) {
			ProxyQProcess().NewQProcess(parent,name);
		}
		public QProcess(QObject parent) : this((Type) null) {
			CreateQProcessProxy();
			CreateQProcessSignalProxy();
			NewQProcess(parent);
		}
		[SmokeMethod("QProcess(QObject*)")]
		private void NewQProcess(QObject parent) {
			ProxyQProcess().NewQProcess(parent);
		}
		public QProcess() : this((Type) null) {
			CreateQProcessProxy();
			CreateQProcessSignalProxy();
			NewQProcess();
		}
		[SmokeMethod("QProcess()")]
		private void NewQProcess() {
			ProxyQProcess().NewQProcess();
		}
		public QProcess(string arg0, QObject parent, string name) : this((Type) null) {
			CreateQProcessProxy();
			CreateQProcessSignalProxy();
			NewQProcess(arg0,parent,name);
		}
		[SmokeMethod("QProcess(const QString&, QObject*, const char*)")]
		private void NewQProcess(string arg0, QObject parent, string name) {
			ProxyQProcess().NewQProcess(arg0,parent,name);
		}
		public QProcess(string arg0, QObject parent) : this((Type) null) {
			CreateQProcessProxy();
			CreateQProcessSignalProxy();
			NewQProcess(arg0,parent);
		}
		[SmokeMethod("QProcess(const QString&, QObject*)")]
		private void NewQProcess(string arg0, QObject parent) {
			ProxyQProcess().NewQProcess(arg0,parent);
		}
		public QProcess(string arg0) : this((Type) null) {
			CreateQProcessProxy();
			CreateQProcessSignalProxy();
			NewQProcess(arg0);
		}
		[SmokeMethod("QProcess(const QString&)")]
		private void NewQProcess(string arg0) {
			ProxyQProcess().NewQProcess(arg0);
		}
		public QProcess(string[] args, QObject parent, string name) : this((Type) null) {
			CreateQProcessProxy();
			CreateQProcessSignalProxy();
			NewQProcess(args,parent,name);
		}
		[SmokeMethod("QProcess(const QStringList&, QObject*, const char*)")]
		private void NewQProcess(string[] args, QObject parent, string name) {
			ProxyQProcess().NewQProcess(args,parent,name);
		}
		public QProcess(string[] args, QObject parent) : this((Type) null) {
			CreateQProcessProxy();
			CreateQProcessSignalProxy();
			NewQProcess(args,parent);
		}
		[SmokeMethod("QProcess(const QStringList&, QObject*)")]
		private void NewQProcess(string[] args, QObject parent) {
			ProxyQProcess().NewQProcess(args,parent);
		}
		public QProcess(string[] args) : this((Type) null) {
			CreateQProcessProxy();
			CreateQProcessSignalProxy();
			NewQProcess(args);
		}
		[SmokeMethod("QProcess(const QStringList&)")]
		private void NewQProcess(string[] args) {
			ProxyQProcess().NewQProcess(args);
		}
		[SmokeMethod("arguments() const")]
		public ArrayList Arguments() {
			return ProxyQProcess().Arguments();
		}
		[SmokeMethod("clearArguments()")]
		public void ClearArguments() {
			ProxyQProcess().ClearArguments();
		}
		[SmokeMethod("setArguments(const QStringList&)")]
		public virtual void SetArguments(string[] args) {
			ProxyQProcess().SetArguments(args);
		}
		[SmokeMethod("addArgument(const QString&)")]
		public virtual void AddArgument(string arg) {
			ProxyQProcess().AddArgument(arg);
		}
		[SmokeMethod("workingDirectory() const")]
		public QDir WorkingDirectory() {
			return ProxyQProcess().WorkingDirectory();
		}
		[SmokeMethod("setWorkingDirectory(const QDir&)")]
		public virtual void SetWorkingDirectory(QDir dir) {
			ProxyQProcess().SetWorkingDirectory(dir);
		}
		[SmokeMethod("setCommunication(int)")]
		public void SetCommunication(int c) {
			ProxyQProcess().SetCommunication(c);
		}
		[SmokeMethod("communication() const")]
		public int Communication() {
			return ProxyQProcess().Communication();
		}
		[SmokeMethod("start(QStringList*)")]
		public virtual bool Start(string[] arg1) {
			return ProxyQProcess().Start(arg1);
		}
		[SmokeMethod("start()")]
		public virtual bool Start() {
			return ProxyQProcess().Start();
		}
		[SmokeMethod("launch(const QString&, QStringList*)")]
		public virtual bool Launch(string buf, string[] arg2) {
			return ProxyQProcess().Launch(buf,arg2);
		}
		[SmokeMethod("launch(const QString&)")]
		public virtual bool Launch(string buf) {
			return ProxyQProcess().Launch(buf);
		}
		[SmokeMethod("launch(const QByteArray&, QStringList*)")]
		public virtual bool Launch(QByteArray buf, string[] arg2) {
			return ProxyQProcess().Launch(buf,arg2);
		}
		[SmokeMethod("launch(const QByteArray&)")]
		public virtual bool Launch(QByteArray buf) {
			return ProxyQProcess().Launch(buf);
		}
		[SmokeMethod("isRunning() const")]
		public bool IsRunning() {
			return ProxyQProcess().IsRunning();
		}
		[SmokeMethod("normalExit() const")]
		public bool NormalExit() {
			return ProxyQProcess().NormalExit();
		}
		[SmokeMethod("exitStatus() const")]
		public int ExitStatus() {
			return ProxyQProcess().ExitStatus();
		}
		[SmokeMethod("readStdout()")]
		public virtual QByteArray ReadStdout() {
			return ProxyQProcess().ReadStdout();
		}
		[SmokeMethod("readStderr()")]
		public virtual QByteArray ReadStderr() {
			return ProxyQProcess().ReadStderr();
		}
		[SmokeMethod("canReadLineStdout() const")]
		public bool CanReadLineStdout() {
			return ProxyQProcess().CanReadLineStdout();
		}
		[SmokeMethod("canReadLineStderr() const")]
		public bool CanReadLineStderr() {
			return ProxyQProcess().CanReadLineStderr();
		}
		[SmokeMethod("readLineStdout()")]
		public virtual string ReadLineStdout() {
			return ProxyQProcess().ReadLineStdout();
		}
		[SmokeMethod("readLineStderr()")]
		public virtual string ReadLineStderr() {
			return ProxyQProcess().ReadLineStderr();
		}
		[SmokeMethod("processIdentifier()")]
		public long ProcessIdentifier() {
			return ProxyQProcess().ProcessIdentifier();
		}
		[SmokeMethod("flushStdin()")]
		public void FlushStdin() {
			ProxyQProcess().FlushStdin();
		}
		[Q_SLOT("void tryTerminate() const")]
		[SmokeMethod("tryTerminate() const")]
		public void TryTerminate() {
			ProxyQProcess().TryTerminate();
		}
		[Q_SLOT("void kill() const")]
		[SmokeMethod("kill() const")]
		public void Kill() {
			ProxyQProcess().Kill();
		}
		[Q_SLOT("void writeToStdin(const QByteArray&)")]
		[SmokeMethod("writeToStdin(const QByteArray&)")]
		public virtual void WriteToStdin(QByteArray buf) {
			ProxyQProcess().WriteToStdin(buf);
		}
		[Q_SLOT("void writeToStdin(const QString&)")]
		[SmokeMethod("writeToStdin(const QString&)")]
		public virtual void WriteToStdin(string buf) {
			ProxyQProcess().WriteToStdin(buf);
		}
		[Q_SLOT("void closeStdin()")]
		[SmokeMethod("closeStdin()")]
		public virtual void CloseStdin() {
			ProxyQProcess().CloseStdin();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string arg1, string arg2) {
			return StaticQProcess().Tr(arg1,arg2);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string arg1) {
			return StaticQProcess().Tr(arg1);
		}
		[SmokeMethod("trUtf8(const char*, const char*)")]
		public static new string TrUtf8(string arg1, string arg2) {
			return StaticQProcess().TrUtf8(arg1,arg2);
		}
		[SmokeMethod("trUtf8(const char*)")]
		public static new string TrUtf8(string arg1) {
			return StaticQProcess().TrUtf8(arg1);
		}
		[SmokeMethod("connectNotify(const char*)")]
		protected new void ConnectNotify(string signal) {
			ProxyQProcess().ConnectNotify(signal);
		}
		[SmokeMethod("disconnectNotify(const char*)")]
		protected new void DisconnectNotify(string signal) {
			ProxyQProcess().DisconnectNotify(signal);
		}
		~QProcess() {
			DisposeQProcess();
		}
		public new void Dispose() {
			DisposeQProcess();
		}
		private void DisposeQProcess() {
			ProxyQProcess().DisposeQProcess();
		}
		protected void CreateQProcessSignalProxy() {
			SignalInvocation realProxy = new SignalInvocation(typeof(IQProcessSignals), this);
			_signalInterceptor = (IQProcessSignals) realProxy.GetTransparentProxy();
		}
		protected new IQProcessSignals Emit() {
			return (IQProcessSignals) _signalInterceptor;
		}
	}

	public interface IQProcessSignals : IQObjectSignals {
		[Q_SIGNAL("void readyReadStdout()")]
		void ReadyReadStdout();
		[Q_SIGNAL("void readyReadStderr()")]
		void ReadyReadStderr();
		[Q_SIGNAL("void processExited()")]
		void ProcessExited();
		[Q_SIGNAL("void wroteToStdin()")]
		void WroteToStdin();
		[Q_SIGNAL("void launchFinished()")]
		void LaunchFinished();
	}
}
