//Auto-generated by kalyptus. DO NOT EDIT.
namespace Soprano.Vocabulary.XMLSchema {

	using Soprano;
	using System;
	using Qyoto;




	[SmokeClass("Soprano::Vocabulary::XMLSchema")]
	public class Global {
		private static SmokeInvocation staticInterceptor = null;
		static Global() {
			staticInterceptor = new SmokeInvocation(typeof(Global), null);
		}
		/// <remarks>
		///  http://www.w3.org/2001/XMLSchema#
		///              </remarks>		<short>    http://www.</short>
		public static QUrl XsdNamespace() {
			return (QUrl) staticInterceptor.Invoke("xsdNamespace", "xsdNamespace()", typeof(QUrl));
		}
		public static QUrl XsdInt() {
			return (QUrl) staticInterceptor.Invoke("xsdInt", "xsdInt()", typeof(QUrl));
		}
		public static QUrl Integer() {
			return (QUrl) staticInterceptor.Invoke("integer", "integer()", typeof(QUrl));
		}
		public static QUrl NegativeInteger() {
			return (QUrl) staticInterceptor.Invoke("negativeInteger", "negativeInteger()", typeof(QUrl));
		}
		public static QUrl NonNegativeInteger() {
			return (QUrl) staticInterceptor.Invoke("nonNegativeInteger", "nonNegativeInteger()", typeof(QUrl));
		}
		public static QUrl Decimal() {
			return (QUrl) staticInterceptor.Invoke("decimal", "decimal()", typeof(QUrl));
		}
		public static QUrl XsdShort() {
			return (QUrl) staticInterceptor.Invoke("xsdShort", "xsdShort()", typeof(QUrl));
		}
		public static QUrl XsdLong() {
			return (QUrl) staticInterceptor.Invoke("xsdLong", "xsdLong()", typeof(QUrl));
		}
		public static QUrl UnsignedInt() {
			return (QUrl) staticInterceptor.Invoke("unsignedInt", "unsignedInt()", typeof(QUrl));
		}
		public static QUrl UnsignedShort() {
			return (QUrl) staticInterceptor.Invoke("unsignedShort", "unsignedShort()", typeof(QUrl));
		}
		public static QUrl UnsignedLong() {
			return (QUrl) staticInterceptor.Invoke("unsignedLong", "unsignedLong()", typeof(QUrl));
		}
		public static QUrl String() {
			return (QUrl) staticInterceptor.Invoke("string", "string()", typeof(QUrl));
		}
		public static QUrl XsdFloat() {
			return (QUrl) staticInterceptor.Invoke("xsdFloat", "xsdFloat()", typeof(QUrl));
		}
		public static QUrl XsdDouble() {
			return (QUrl) staticInterceptor.Invoke("xsdDouble", "xsdDouble()", typeof(QUrl));
		}
		public static QUrl Boolean() {
			return (QUrl) staticInterceptor.Invoke("boolean", "boolean()", typeof(QUrl));
		}
		public static QUrl Date() {
			return (QUrl) staticInterceptor.Invoke("date", "date()", typeof(QUrl));
		}
		public static QUrl DateTime() {
			return (QUrl) staticInterceptor.Invoke("dateTime", "dateTime()", typeof(QUrl));
		}
		public static QUrl Time() {
			return (QUrl) staticInterceptor.Invoke("time", "time()", typeof(QUrl));
		}
		public static QUrl Base64Binary() {
			return (QUrl) staticInterceptor.Invoke("base64Binary", "base64Binary()", typeof(QUrl));
		}
	}
}
