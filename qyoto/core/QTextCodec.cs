//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;
	using System.Collections.Generic;

	[SmokeClass("QTextCodec")]
	public abstract class QTextCodec : Object {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected QTextCodec(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QTextCodec), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static QTextCodec() {
			staticInterceptor = new SmokeInvocation(typeof(QTextCodec), null);
		}
		public enum ConversionFlag : long {
			DefaultConversion = 0,
			ConvertInvalidToNull = 0x80000000,
			IgnoreHeader = 0x1,
		}
		// QString toUnicode(const char* arg1,int arg2,QTextCodec::ConverterState* arg3); >>>> NOT CONVERTED
		// QByteArray fromUnicode(const QChar* arg1,int arg2,QTextCodec::ConverterState* arg3); >>>> NOT CONVERTED
		// QString convertToUnicode(const char* arg1,int arg2,QTextCodec::ConverterState* arg3); >>>> NOT CONVERTED
		// QByteArray convertFromUnicode(const QChar* arg1,int arg2,QTextCodec::ConverterState* arg3); >>>> NOT CONVERTED
		public QTextDecoder MakeDecoder() {
			return (QTextDecoder) interceptor.Invoke("makeDecoder", "makeDecoder() const", typeof(QTextDecoder));
		}
		public QTextEncoder MakeEncoder() {
			return (QTextEncoder) interceptor.Invoke("makeEncoder", "makeEncoder() const", typeof(QTextEncoder));
		}
		public bool CanEncode(char arg1) {
			return (bool) interceptor.Invoke("canEncode#", "canEncode(QChar) const", typeof(bool), typeof(char), arg1);
		}
		public bool CanEncode(string arg1) {
			return (bool) interceptor.Invoke("canEncode$", "canEncode(const QString&) const", typeof(bool), typeof(string), arg1);
		}
		public string ToUnicode(QByteArray arg1) {
			return (string) interceptor.Invoke("toUnicode#", "toUnicode(const QByteArray&) const", typeof(string), typeof(QByteArray), arg1);
		}
		public string ToUnicode(string chars) {
			return (string) interceptor.Invoke("toUnicode$", "toUnicode(const char*) const", typeof(string), typeof(string), chars);
		}
		public QByteArray FromUnicode(string uc) {
			return (QByteArray) interceptor.Invoke("fromUnicode$", "fromUnicode(const QString&) const", typeof(QByteArray), typeof(string), uc);
		}
		public string ToUnicode(string arg1, int length) {
			return (string) interceptor.Invoke("toUnicode$$", "toUnicode(const char*, int) const", typeof(string), typeof(string), arg1, typeof(int), length);
		}
		public QByteArray FromUnicode(char arg1, int length) {
			return (QByteArray) interceptor.Invoke("fromUnicode#$", "fromUnicode(const QChar*, int) const", typeof(QByteArray), typeof(char), arg1, typeof(int), length);
		}
		[SmokeMethod("name() const")]
		public abstract QByteArray Name();
		[SmokeMethod("aliases() const")]
		public virtual List<QByteArray> Aliases() {
			return (List<QByteArray>) interceptor.Invoke("aliases", "aliases() const", typeof(List<QByteArray>));
		}
		[SmokeMethod("mibEnum() const")]
		public abstract int MibEnum();
		public QTextCodec() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QTextCodec", "QTextCodec()", typeof(void));
		}
		public static QTextCodec CodecForName(QByteArray name) {
			return (QTextCodec) staticInterceptor.Invoke("codecForName#", "codecForName(const QByteArray&)", typeof(QTextCodec), typeof(QByteArray), name);
		}
		public static QTextCodec CodecForName(string name) {
			return (QTextCodec) staticInterceptor.Invoke("codecForName$", "codecForName(const char*)", typeof(QTextCodec), typeof(string), name);
		}
		public static QTextCodec CodecForMib(int mib) {
			return (QTextCodec) staticInterceptor.Invoke("codecForMib$", "codecForMib(int)", typeof(QTextCodec), typeof(int), mib);
		}
		public static List<QByteArray> AvailableCodecs() {
			return (List<QByteArray>) staticInterceptor.Invoke("availableCodecs", "availableCodecs()", typeof(List<QByteArray>));
		}
		public static List<int> AvailableMibs() {
			return (List<int>) staticInterceptor.Invoke("availableMibs", "availableMibs()", typeof(List<int>));
		}
		public static QTextCodec CodecForLocale() {
			return (QTextCodec) staticInterceptor.Invoke("codecForLocale", "codecForLocale()", typeof(QTextCodec));
		}
		public static void SetCodecForLocale(QTextCodec c) {
			staticInterceptor.Invoke("setCodecForLocale#", "setCodecForLocale(QTextCodec*)", typeof(void), typeof(QTextCodec), c);
		}
		public static QTextCodec CodecForTr() {
			return (QTextCodec) staticInterceptor.Invoke("codecForTr", "codecForTr()", typeof(QTextCodec));
		}
		public static void SetCodecForTr(QTextCodec c) {
			staticInterceptor.Invoke("setCodecForTr#", "setCodecForTr(QTextCodec*)", typeof(void), typeof(QTextCodec), c);
		}
		public static QTextCodec CodecForCStrings() {
			return (QTextCodec) staticInterceptor.Invoke("codecForCStrings", "codecForCStrings()", typeof(QTextCodec));
		}
		public static void SetCodecForCStrings(QTextCodec c) {
			staticInterceptor.Invoke("setCodecForCStrings#", "setCodecForCStrings(QTextCodec*)", typeof(void), typeof(QTextCodec), c);
		}
		public static QTextCodec CodecForHtml(QByteArray ba) {
			return (QTextCodec) staticInterceptor.Invoke("codecForHtml#", "codecForHtml(const QByteArray&)", typeof(QTextCodec), typeof(QByteArray), ba);
		}
		public static QTextCodec CodecForHtml(QByteArray ba, QTextCodec defaultCodec) {
			return (QTextCodec) staticInterceptor.Invoke("codecForHtml##", "codecForHtml(const QByteArray&, QTextCodec*)", typeof(QTextCodec), typeof(QByteArray), ba, typeof(QTextCodec), defaultCodec);
		}
	}
}
