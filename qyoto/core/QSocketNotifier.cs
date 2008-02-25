//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	/// <remarks>*************************************************
	/// 
	/// * Copyright (C) 1992-2008 Trolltech ASA. All rights reserved.
	/// 
	/// * This file is part of the QtCore module of the Qt Toolkit.
	/// 
	/// * This file may be used under the terms of the GNU General Public
	///  License versions 2.0 or 3.0 as published by the Free Software
	///  Foundation and appearing in the files LICENSE.GPL2 and LICENSE.GPL3
	///  included in the packaging of this file.  Alternatively you may (at
	///  your option) use any later version of the GNU General Public
	///  License if such license has been publicly approved by Trolltech ASA
	///  (or its successors, if any) and the KDE Free Qt Foundation. In
	///  addition, as a special exception, Trolltech gives you certain
	///  additional rights. These rights are described in the Trolltech GPL
	///  Exception version 1.1, which can be found at
	///  http://www.trolltech.com/products/qt/gplexception/ and in the file
	///  GPL_EXCEPTION.txt in this package.
	/// 
	/// * Please review the following information to ensure GNU General
	///  Public Licensing requirements will be met:
	///  http://trolltech.com/products/qt/licenses/licensing/opensource/. If
	///  you are unsure which license is appropriate for your use, please
	///  review the following information:
	///  http://trolltech.com/products/qt/licenses/licensing/licensingoverview
	///  or contact the sales department at sales@trolltech.com.
	/// 
	/// * In addition, as a special exception, Trolltech, as the sole
	///  copyright holder for Qt Designer, grants users of the Qt/Eclipse
	///  Integration plug-in the right for the Qt/Eclipse Integration to
	///  link to functionality provided by Qt Designer and its related
	///  libraries.
	/// 
	/// * This file is provided "AS IS" with NO WARRANTY OF ANY KIND,
	///  INCLUDING THE WARRANTIES OF DESIGN, MERCHANTABILITY AND FITNESS FOR
	///  A PARTICULAR PURPOSE. Trolltech reserves all rights not expressly
	///  granted herein.
	/// 
	/// * This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
	///  WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
	/// 
	/// ************************************************** See <see cref="IQSocketNotifierSignals"></see> for signals emitted by QSocketNotifier
	/// </remarks>		<short>                                                                                 Copyright (C) 1992-2008 Trolltech ASA.</short>

	[SmokeClass("QSocketNotifier")]
	public class QSocketNotifier : QObject, IDisposable {
 		protected QSocketNotifier(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QSocketNotifier), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QSocketNotifier() {
			staticInterceptor = new SmokeInvocation(typeof(QSocketNotifier), null);
		}
		public enum TypeOf {
			Read = 0,
			Write = 1,
			Exception = 2,
		}
		public QSocketNotifier(int socket, QSocketNotifier.TypeOf arg2, QObject parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QSocketNotifier$$#", "QSocketNotifier(int, QSocketNotifier::Type, QObject*)", typeof(void), typeof(int), socket, typeof(QSocketNotifier.TypeOf), arg2, typeof(QObject), parent);
		}
		public QSocketNotifier(int socket, QSocketNotifier.TypeOf arg2) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QSocketNotifier$$", "QSocketNotifier(int, QSocketNotifier::Type)", typeof(void), typeof(int), socket, typeof(QSocketNotifier.TypeOf), arg2);
		}
		public int Socket() {
			return (int) interceptor.Invoke("socket", "socket() const", typeof(int));
		}
		public QSocketNotifier.TypeOf type() {
			return (QSocketNotifier.TypeOf) interceptor.Invoke("type", "type() const", typeof(QSocketNotifier.TypeOf));
		}
		public bool IsEnabled() {
			return (bool) interceptor.Invoke("isEnabled", "isEnabled() const", typeof(bool));
		}
		[Q_SLOT("void setEnabled(bool)")]
		public void SetEnabled(bool arg1) {
			interceptor.Invoke("setEnabled$", "setEnabled(bool)", typeof(void), typeof(bool), arg1);
		}
		[SmokeMethod("event(QEvent*)")]
		protected new virtual bool Event(QEvent arg1) {
			return (bool) interceptor.Invoke("event#", "event(QEvent*)", typeof(bool), typeof(QEvent), arg1);
		}
		~QSocketNotifier() {
			interceptor.Invoke("~QSocketNotifier", "~QSocketNotifier()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~QSocketNotifier", "~QSocketNotifier()", typeof(void));
		}
		public static new string Tr(string s, string c) {
			return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
		}
		public static new string Tr(string s) {
			return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
		}
		protected new IQSocketNotifierSignals Emit {
			get { return (IQSocketNotifierSignals) Q_EMIT; }
		}
	}

	public interface IQSocketNotifierSignals : IQObjectSignals {
		[Q_SIGNAL("void activated(int)")]
		void Activated(int socket);
	}
}
