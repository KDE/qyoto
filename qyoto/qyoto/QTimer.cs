//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Text;

	///<remarks>*************************************************
	///
	///* Copyright (C) 1992-2006 Trolltech AS. All rights reserved.
	///
	///* This file is part of the QtCore module of the Qt Toolkit.
	///
	///* This file may be used under the terms of the GNU General Public
	/// License version 2.0 as published by the Free Software Foundation
	/// and appearing in the file LICENSE.GPL included in the packaging of
	/// this file.  Please review the following information to ensure GNU
	/// General Public Licensing requirements will be met:
	/// http://www.trolltech.com/products/qt/opensource.html
	///
	///* If you are unsure which license is appropriate for your use, please
	/// review the following information:
	/// http://www.trolltech.com/products/qt/licensing.html or contact the
	/// sales department at sales@trolltech.com.
	///
	///* This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
	/// WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
	///
	///************************************************** See <see cref="IQTimerSignals"></see> for signals emitted by QTimer
	///</remarks>		<short>                                                                                 Copyright (C) 1992-2006 Trolltech AS.</short>

	[SmokeClass("QTimer")]
	public class QTimer : QObject, IDisposable {
 		protected QTimer(Type dummy) : base((Type) null) {}
		interface IQTimerProxy {
			string Tr(string s, string c);
			string Tr(string s);
			void SingleShot(int msec, QObject receiver, string member);
		}

		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QTimer), this);
			_interceptor = (QTimer) realProxy.GetTransparentProxy();
		}
		private QTimer ProxyQTimer() {
			return (QTimer) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QTimer() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQTimerProxy), null);
			_staticInterceptor = (IQTimerProxy) realProxy.GetTransparentProxy();
		}
		private static IQTimerProxy StaticQTimer() {
			return (IQTimerProxy) _staticInterceptor;
		}

		// int qt_metacall(QMetaObject::Call arg1,int arg2,void** arg3); >>>> NOT CONVERTED
		public QTimer(QObject parent) : this((Type) null) {
			CreateProxy();
			NewQTimer(parent);
		}
		[SmokeMethod("QTimer(QObject*)")]
		private void NewQTimer(QObject parent) {
			ProxyQTimer().NewQTimer(parent);
		}
		public QTimer() : this((Type) null) {
			CreateProxy();
			NewQTimer();
		}
		[SmokeMethod("QTimer()")]
		private void NewQTimer() {
			ProxyQTimer().NewQTimer();
		}
		[SmokeMethod("isActive() const")]
		public bool IsActive() {
			return ProxyQTimer().IsActive();
		}
		[SmokeMethod("timerId() const")]
		public int TimerId() {
			return ProxyQTimer().TimerId();
		}
		[SmokeMethod("setInterval(int)")]
		public void SetInterval(int msec) {
			ProxyQTimer().SetInterval(msec);
		}
		[SmokeMethod("interval() const")]
		public int Interval() {
			return ProxyQTimer().Interval();
		}
		[SmokeMethod("setSingleShot(bool)")]
		public void SetSingleShot(bool singleShot) {
			ProxyQTimer().SetSingleShot(singleShot);
		}
		[SmokeMethod("isSingleShot() const")]
		public bool IsSingleShot() {
			return ProxyQTimer().IsSingleShot();
		}
		[SmokeMethod("start(int)")]
		public void Start(int msec) {
			ProxyQTimer().Start(msec);
		}
		[SmokeMethod("start()")]
		public void Start() {
			ProxyQTimer().Start();
		}
		[SmokeMethod("stop()")]
		public void Stop() {
			ProxyQTimer().Stop();
		}
		[SmokeMethod("tr(const char*, const char*)")]
		public static new string Tr(string s, string c) {
			return StaticQTimer().Tr(s,c);
		}
		[SmokeMethod("tr(const char*)")]
		public static new string Tr(string s) {
			return StaticQTimer().Tr(s);
		}
		[SmokeMethod("singleShot(int, QObject*, const char*)")]
		public static void SingleShot(int msec, QObject receiver, string member) {
			StaticQTimer().SingleShot(msec,receiver,member);
		}
		[SmokeMethod("timerEvent(QTimerEvent*)")]
		protected new void TimerEvent(QTimerEvent arg1) {
			ProxyQTimer().TimerEvent(arg1);
		}
		~QTimer() {
			DisposeQTimer();
		}
		public new void Dispose() {
			DisposeQTimer();
		}
		private void DisposeQTimer() {
			ProxyQTimer().DisposeQTimer();
		}
		protected new IQTimerSignals Emit() {
			return (IQTimerSignals) Q_EMIT;
		}
	}

	public interface IQTimerSignals : IQObjectSignals {
		[Q_SIGNAL("void timeout()")]
		void Timeout();
	}
}
