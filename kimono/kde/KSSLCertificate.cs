//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  KDE X.509 Certificate
	///  This class represents an X.509 (SSL) certificate.
	///  Note: this object is VERY HEAVY TO COPY.  Please try to use reference
	///        or pointer whenever possible
	/// </remarks>		<author> George Staikos <staikos@kde.org>
	/// </author>
	/// 		<short> KDE X.509 Certificate.</short>
	/// 		<see> KSSL</see>

	[SmokeClass("KSSLCertificate")]
	public class KSSLCertificate : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KSSLCertificate(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KSSLCertificate), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static KSSLCertificate() {
			staticInterceptor = new SmokeInvocation(typeof(KSSLCertificate), null);
		}
		/// <remarks>
		///  A CA certificate can be validated as Irrelevant when it was
		///  not used to sign any other relevant certificate.
		///          </remarks>		<short>    A CA certificate can be validated as Irrelevant when it was  not used to sign any other relevant certificate.</short>
		public enum KSSLValidation {
			Unknown = 0,
			Ok = 1,
			NoCARoot = 2,
			InvalidPurpose = 3,
			PathLengthExceeded = 4,
			InvalidCA = 5,
			Expired = 6,
			SelfSigned = 7,
			ErrorReadingRoot = 8,
			NoSSL = 9,
			Revoked = 10,
			Untrusted = 11,
			SignatureFailed = 12,
			Rejected = 13,
			PrivateKeyFailed = 14,
			InvalidHost = 15,
			Irrelevant = 16,
			SelfSignedChain = 17,
		}
		public enum KSSLPurpose {
			None = 0,
			SSLServer = 1,
			SSLClient = 2,
			SMIMESign = 3,
			SMIMEEncrypt = 4,
			Any = 5,
		}
		// KSSLCertificate::KSSLValidationList validateVerbose(KSSLCertificate::KSSLPurpose arg1); >>>> NOT CONVERTED
		// KSSLCertificate::KSSLValidationList validateVerbose(KSSLCertificate::KSSLPurpose arg1,KSSLCertificate* arg2); >>>> NOT CONVERTED
		// KSSLCertificate* fromX509(X509* arg1); >>>> NOT CONVERTED
		// void setCert(X509* arg1); >>>> NOT CONVERTED
		// void setChain(void* arg1); >>>> NOT CONVERTED
		// X509* getCert(); >>>> NOT CONVERTED
		/// <remarks>
		///   Convert this certificate to a string.
		/// </remarks>		<return> the certificate in base64 format
		/// 	 </return>
		/// 		<short>     Convert this certificate to a string.</short>
		public new string ToString() {
			return (string) interceptor.Invoke("toString", "toString()", typeof(string));
		}
		/// <remarks>
		///   Get the subject of the certificate (X.509 map).
		/// </remarks>		<return> the subject
		/// 	 </return>
		/// 		<short>     Get the subject of the certificate (X.</short>
		public string GetSubject() {
			return (string) interceptor.Invoke("getSubject", "getSubject() const", typeof(string));
		}
		/// <remarks>
		///   Get the issuer of the certificate (X.509 map).
		/// </remarks>		<return> the issuer
		/// 	 </return>
		/// 		<short>     Get the issuer of the certificate (X.</short>
		public string GetIssuer() {
			return (string) interceptor.Invoke("getIssuer", "getIssuer() const", typeof(string));
		}
		/// <remarks>
		///   Get the date that the certificate becomes valid on.
		/// </remarks>		<return> the date as a string, localised
		/// 	 </return>
		/// 		<short>     Get the date that the certificate becomes valid on.</short>
		public string GetNotBefore() {
			return (string) interceptor.Invoke("getNotBefore", "getNotBefore() const", typeof(string));
		}
		/// <remarks>
		///   Get the date that the certificate is valid until.
		/// </remarks>		<return> the date as a string, localised
		/// 	 </return>
		/// 		<short>     Get the date that the certificate is valid until.</short>
		public string GetNotAfter() {
			return (string) interceptor.Invoke("getNotAfter", "getNotAfter() const", typeof(string));
		}
		/// <remarks>
		///   Get the date that the certificate becomes valid on.
		/// </remarks>		<return> the date
		/// 	 </return>
		/// 		<short>     Get the date that the certificate becomes valid on.</short>
		public QDateTime GetQDTNotBefore() {
			return (QDateTime) interceptor.Invoke("getQDTNotBefore", "getQDTNotBefore() const", typeof(QDateTime));
		}
		/// <remarks>
		///   Get the date that the certificate is valid until.
		/// </remarks>		<return> the date
		/// 	 </return>
		/// 		<short>     Get the date that the certificate is valid until.</short>
		public QDateTime GetQDTNotAfter() {
			return (QDateTime) interceptor.Invoke("getQDTNotAfter", "getQDTNotAfter() const", typeof(QDateTime));
		}
		/// <remarks>
		///   Convert the certificate to DER (ASN.1) format.
		/// </remarks>		<return> the binary data of the DER encoding
		/// 	 </return>
		/// 		<short>     Convert the certificate to DER (ASN.</short>
		public QByteArray ToDer() {
			return (QByteArray) interceptor.Invoke("toDer", "toDer()", typeof(QByteArray));
		}
		/// <remarks>
		///   Convert the certificate to PEM (base64) format.
		/// </remarks>		<return> the binary data of the PEM encoding
		/// 	 </return>
		/// 		<short>     Convert the certificate to PEM (base64) format.</short>
		public QByteArray ToPem() {
			return (QByteArray) interceptor.Invoke("toPem", "toPem()", typeof(QByteArray));
		}
		/// <remarks>
		///   Convert the certificate to Netscape format.
		/// </remarks>		<return> the binary data of the Netscape encoding
		/// 	 </return>
		/// 		<short>     Convert the certificate to Netscape format.</short>
		public QByteArray ToNetscape() {
			return (QByteArray) interceptor.Invoke("toNetscape", "toNetscape()", typeof(QByteArray));
		}
		/// <remarks>
		///   Convert the certificate to OpenSSL plain text format.
		/// </remarks>		<return> the OpenSSL text encoding
		/// 	 </return>
		/// 		<short>     Convert the certificate to OpenSSL plain text format.</short>
		public string ToText() {
			return (string) interceptor.Invoke("toText", "toText()", typeof(string));
		}
		/// <remarks>
		///   Get the serial number of the certificate.
		/// </remarks>		<return> the serial number as a string
		/// 	 </return>
		/// 		<short>     Get the serial number of the certificate.</short>
		public string GetSerialNumber() {
			return (string) interceptor.Invoke("getSerialNumber", "getSerialNumber() const", typeof(string));
		}
		/// <remarks>
		///   Get the key type (RSA, DSA, etc).
		/// </remarks>		<return> the key type as a string
		/// 	 </return>
		/// 		<short>     Get the key type (RSA, DSA, etc).</short>
		public string GetKeyType() {
			return (string) interceptor.Invoke("getKeyType", "getKeyType() const", typeof(string));
		}
		/// <remarks>
		///   Get the public key.
		/// </remarks>		<return> the public key as a hexidecimal string
		/// 	 </return>
		/// 		<short>     Get the public key.</short>
		public string GetPublicKeyText() {
			return (string) interceptor.Invoke("getPublicKeyText", "getPublicKeyText() const", typeof(string));
		}
		/// <remarks>
		///   Get the MD5 digest of the certificate.
		///   Result is padded with : to separate bytes - it's a text version!
		/// </remarks>		<return> the MD5 digest in a hexidecimal string
		/// 	 </return>
		/// 		<short>     Get the MD5 digest of the certificate.</short>
		public string GetMD5DigestText() {
			return (string) interceptor.Invoke("getMD5DigestText", "getMD5DigestText() const", typeof(string));
		}
		/// <remarks>
		///   Get the MD5 digest of the certificate.
		/// </remarks>		<return> the MD5 digest in a hexidecimal string
		/// 	 </return>
		/// 		<short>     Get the MD5 digest of the certificate.</short>
		public string GetMD5Digest() {
			return (string) interceptor.Invoke("getMD5Digest", "getMD5Digest() const", typeof(string));
		}
		/// <remarks>
		///   Get the signature.
		/// </remarks>		<return> the signature in text format
		/// 	 </return>
		/// 		<short>     Get the signature.</short>
		public string GetSignatureText() {
			return (string) interceptor.Invoke("getSignatureText", "getSignatureText() const", typeof(string));
		}
		/// <remarks>
		///   Check if this is a valid certificate.  Will use cached data.
		/// </remarks>		<return> true if it is valid
		/// 	 </return>
		/// 		<short>     Check if this is a valid certificate.</short>
		public bool IsValid() {
			return (bool) interceptor.Invoke("isValid", "isValid()", typeof(bool));
		}
		/// <remarks>
		///   Check if this is a valid certificate.  Will use cached data.
		/// <param> name="p" the purpose to validate for
		/// </param></remarks>		<return> true if it is valid
		/// 	 </return>
		/// 		<short>     Check if this is a valid certificate.</short>
		public bool IsValid(KSSLCertificate.KSSLPurpose p) {
			return (bool) interceptor.Invoke("isValid$", "isValid(KSSLCertificate::KSSLPurpose)", typeof(bool), typeof(KSSLCertificate.KSSLPurpose), p);
		}
		/// <remarks>
		///   The alternate subject name.
		/// </remarks>		<return> string list with subjectAltName
		/// 	 </return>
		/// 		<short>     The alternate subject name.</short>
		public List<string> SubjAltNames() {
			return (List<string>) interceptor.Invoke("subjAltNames", "subjAltNames() const", typeof(List<string>));
		}
		/// <remarks>
		///   Check if this is a valid certificate.  Will use cached data.
		/// </remarks>		<return> the result of the validation
		/// 	 </return>
		/// 		<short>     Check if this is a valid certificate.</short>
		public KSSLCertificate.KSSLValidation Validate() {
			return (KSSLCertificate.KSSLValidation) interceptor.Invoke("validate", "validate()", typeof(KSSLCertificate.KSSLValidation));
		}
		/// <remarks>
		///   Check if this is a valid certificate.  Will use cached data.
		/// <param> name="p" the purpose to validate for
		/// </param></remarks>		<return> the result of the validation
		/// 	 </return>
		/// 		<short>     Check if this is a valid certificate.</short>
		public KSSLCertificate.KSSLValidation Validate(KSSLCertificate.KSSLPurpose p) {
			return (KSSLCertificate.KSSLValidation) interceptor.Invoke("validate$", "validate(KSSLCertificate::KSSLPurpose)", typeof(KSSLCertificate.KSSLValidation), typeof(KSSLCertificate.KSSLPurpose), p);
		}
		/// <remarks>
		///   Check if this is a valid certificate.  Will use cached data.
		/// <param> name="p" the purpose to validate for
		/// </param></remarks>		<return> all problems encountered during validation
		/// 	 </return>
		/// 		<short>     Check if this is a valid certificate.</short>
		/// <remarks>
		///   Check if the certificate ca is a proper CA for this
		///   certificate.
		/// <param> name="p" the purpose to validate for
		/// </param><param> name="ca" the certificate to check
		/// </param></remarks>		<return> all problems encountered during validation
		/// 	 </return>
		/// 		<short>     Check if the certificate ca is a proper CA for this   certificate.</short>
		/// <remarks>
		///   Check if this is a valid certificate.  Will NOT use cached data.
		/// </remarks>		<return> the result of the validation
		/// 	 </return>
		/// 		<short>     Check if this is a valid certificate.</short>
		public KSSLCertificate.KSSLValidation Revalidate() {
			return (KSSLCertificate.KSSLValidation) interceptor.Invoke("revalidate", "revalidate()", typeof(KSSLCertificate.KSSLValidation));
		}
		/// <remarks>
		///   Check if this is a valid certificate.  Will NOT use cached data.
		/// <param> name="p" the purpose to validate for
		/// </param></remarks>		<return> the result of the validation
		/// 	 </return>
		/// 		<short>     Check if this is a valid certificate.</short>
		public KSSLCertificate.KSSLValidation Revalidate(KSSLCertificate.KSSLPurpose p) {
			return (KSSLCertificate.KSSLValidation) interceptor.Invoke("revalidate$", "revalidate(KSSLCertificate::KSSLPurpose)", typeof(KSSLCertificate.KSSLValidation), typeof(KSSLCertificate.KSSLPurpose), p);
		}
		/// <remarks>
		///   Get a reference to the certificate chain.
		/// </remarks>		<return> reference to the chain
		/// 	 </return>
		/// 		<short>     Get a reference to the certificate chain.</short>
		public KSSLCertChain Chain() {
			return (KSSLCertChain) interceptor.Invoke("chain", "chain()", typeof(KSSLCertChain));
		}
		/// <remarks>
		///   Explicitly make a copy of this certificate.
		/// </remarks>		<return> a copy of the certificate
		/// 	 </return>
		/// 		<short>     Explicitly make a copy of this certificate.</short>
		public KSSLCertificate Replicate() {
			return (KSSLCertificate) interceptor.Invoke("replicate", "replicate()", typeof(KSSLCertificate));
		}
		/// <remarks>
		///   Copy constructor.  Beware, this is very expensive.
		/// <param> name="x" the object to copy from
		/// 	 </param></remarks>		<short>     Copy constructor.</short>
		public KSSLCertificate(KSSLCertificate x) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KSSLCertificate#", "KSSLCertificate(const KSSLCertificate&)", typeof(void), typeof(KSSLCertificate), x);
		}
		/// <remarks>
		///   Re-set the certificate from a base64 string.
		/// <param> name="cert" the certificate to set to
		/// </param></remarks>		<return> true on success
		/// 	 </return>
		/// 		<short>     Re-set the certificate from a base64 string.</short>
		public bool SetCert(string cert) {
			return (bool) interceptor.Invoke("setCert$", "setCert(const QString&)", typeof(bool), typeof(string), cert);
		}
		/// <remarks>
		///   Access the X.509v3 parameters.
		/// </remarks>		<return> reference to the extension object
		/// </return>
		/// 		<short>     Access the X.</short>
		/// 		<see> KSSLX509V3</see>
		public KSSLX509V3 X509V3Extensions() {
			return (KSSLX509V3) interceptor.Invoke("x509V3Extensions", "x509V3Extensions()", typeof(KSSLX509V3));
		}
		/// <remarks>
		///   Check if this is a signer certificate.
		/// </remarks>		<return> true if this is a signer certificate
		/// 	 </return>
		/// 		<short>     Check if this is a signer certificate.</short>
		public bool IsSigner() {
			return (bool) interceptor.Invoke("isSigner", "isSigner()", typeof(bool));
		}
		/// <remarks>
		///   FIXME: document
		/// 	 </remarks>		<short>     FIXME: document 	 </short>
		public void GetEmails(List<string> to) {
			interceptor.Invoke("getEmails?", "getEmails(QStringList&) const", typeof(void), typeof(List<string>), to);
		}
		/// <remarks>
		///  KDEKey is a concatenation "Subject (MD5)", mostly needed for SMIME.
		///  The result of getKDEKey might change and should not be used for
		///  persistant storage.
		/// 	 </remarks>		<short>    KDEKey is a concatenation "Subject (MD5)", mostly needed for SMIME.</short>
		public string GetKDEKey() {
			return (string) interceptor.Invoke("getKDEKey", "getKDEKey() const", typeof(string));
		}
		public KSSLCertificate() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KSSLCertificate", "KSSLCertificate()", typeof(void));
		}
		protected KSSLCertificate.KSSLValidation ProcessError(int ec) {
			return (KSSLCertificate.KSSLValidation) interceptor.Invoke("processError$", "processError(int)", typeof(KSSLCertificate.KSSLValidation), typeof(int), ec);
		}
		~KSSLCertificate() {
			interceptor.Invoke("~KSSLCertificate", "~KSSLCertificate()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~KSSLCertificate", "~KSSLCertificate()", typeof(void));
		}
		public override bool Equals(object o) {
			if (!(o is KSSLCertificate)) { return false; }
			return this == (KSSLCertificate) o;
		}
		public override int GetHashCode() {
			return interceptor.GetHashCode();
		}
		/// <remarks>
		///   Create an X.509 certificate from a base64 encoded string.
		/// <param> name="cert" the certificate in base64 form
		/// </param></remarks>		<return> the X.509 certificate, or NULL
		/// 	 </return>
		/// 		<short>     Create an X.</short>
		public static KSSLCertificate FromString(QByteArray cert) {
			return (KSSLCertificate) staticInterceptor.Invoke("fromString#", "fromString(const QByteArray&)", typeof(KSSLCertificate), typeof(QByteArray), cert);
		}
		/// <remarks>
		///   Create an X.509 certificate from the internal representation.
		///   This one duplicates the X509 object for itself.
		/// <param> name="x5" the OpenSSL representation of the certificate
		/// </param>	 </remarks>		<return> the X.509 certificate, or NULL
		/// </return>
		/// 		<short>     Create an X.</short>
		/// <remarks>
		///   Obtain the localized message that corresponds to a validation result.
		/// <param> name="x" the code to look up
		/// </param></remarks>		<return> the message text corresponding to the validation code
		/// 	 </return>
		/// 		<short>     Obtain the localized message that corresponds to a validation result.</short>
		public static string VerifyText(KSSLCertificate.KSSLValidation x) {
			return (string) staticInterceptor.Invoke("verifyText$", "verifyText(KSSLCertificate::KSSLValidation)", typeof(string), typeof(KSSLCertificate.KSSLValidation), x);
		}
		/// <remarks>
		///  Aegypten semantics force us to search by MD5Digest only.
		/// 	 </remarks>		<short>    Aegypten semantics force us to search by MD5Digest only.</short>
		public static string GetMD5DigestFromKDEKey(string k) {
			return (string) staticInterceptor.Invoke("getMD5DigestFromKDEKey$", "getMD5DigestFromKDEKey(const QString&)", typeof(string), typeof(string), k);
		}
		public static int operator==(KSSLCertificate x, KSSLCertificate y) {
			return (int) staticInterceptor.Invoke("operator==##", "operator==(KSSLCertificate&, KSSLCertificate&)", typeof(int), typeof(KSSLCertificate), x, typeof(KSSLCertificate), y);
		}
		public static bool operator!=(KSSLCertificate x, KSSLCertificate y) {
			return !(bool) staticInterceptor.Invoke("operator==##", "operator==(KSSLCertificate&, KSSLCertificate&)", typeof(int), typeof(KSSLCertificate), x, typeof(KSSLCertificate), y);
		}
	}
}
