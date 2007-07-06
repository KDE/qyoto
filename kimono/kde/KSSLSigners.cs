//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  KDE SSL Signer Database
	///  This class is used to manipulate the KDE SSL signer database.  It
	///  communicates to the KDE SSL daemon via dcop for backend integration.
	/// </remarks>		<author> George Staikos <staikos@kde.org>
	/// </author>
	/// 		<short> KDE SSL Signer Database.</short>
	/// 		<see> KSSL</see>
	/// 		<see> KSSLCertificate</see>

	[SmokeClass("KSSLSigners")]
	public class KSSLSigners : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KSSLSigners(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KSSLSigners), this);
		}
		/// <remarks>
		///   Construct a KSSLSigner object.
		/// 	 </remarks>		<short>     Construct a KSSLSigner object.</short>
		public KSSLSigners() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KSSLSigners", "KSSLSigners()", typeof(void));
		}
		/// <remarks>
		///   Add a signer to the database.
		/// <param> name="cert" the signer's certificate
		/// </param><param> name="ssl" allow it to sign for SSL
		/// </param><param> name="email" allow it to sign for S/MIME
		/// </param><param> name="code" allow it to sign for code signing
		/// </param></remarks>		<return> true on success
		/// 	 </return>
		/// 		<short>     Add a signer to the database.</short>
		public bool AddCA(KSSLCertificate cert, bool ssl, bool email, bool code) {
			return (bool) interceptor.Invoke("addCA#$$$", "addCA(KSSLCertificate&, bool, bool, bool) const", typeof(bool), typeof(KSSLCertificate), cert, typeof(bool), ssl, typeof(bool), email, typeof(bool), code);
		}
		/// <remarks>
		///   Add a signer to the database.
		/// <param> name="cert" the signer's certificate in base64 form
		/// </param><param> name="ssl" allow it to sign for SSL
		/// </param><param> name="email" allow it to sign for S/MIME
		/// </param><param> name="code" allow it to sign for code signing
		/// </param></remarks>		<return> true on success
		/// 	 </return>
		/// 		<short>     Add a signer to the database.</short>
		public bool AddCA(string cert, bool ssl, bool email, bool code) {
			return (bool) interceptor.Invoke("addCA$$$$", "addCA(const QString&, bool, bool, bool) const", typeof(bool), typeof(string), cert, typeof(bool), ssl, typeof(bool), email, typeof(bool), code);
		}
		/// <remarks>
		///   Regenerate the signer-root file from the user's settings.
		/// </remarks>		<return> true on success
		/// 	 </return>
		/// 		<short>     Regenerate the signer-root file from the user's settings.</short>
		public bool Regenerate() {
			return (bool) interceptor.Invoke("regenerate", "regenerate()", typeof(bool));
		}
		/// <remarks>
		///   Determine if a certificate can be used for SSL certificate signing
		/// <param> name="cert" the certificate
		/// </param></remarks>		<return> true if it can be used for SSL
		/// 	 </return>
		/// 		<short>     Determine if a certificate can be used for SSL certificate signing </short>
		public bool UseForSSL(KSSLCertificate cert) {
			return (bool) interceptor.Invoke("useForSSL#", "useForSSL(KSSLCertificate&) const", typeof(bool), typeof(KSSLCertificate), cert);
		}
		/// <remarks>
		///   Determine if a certificate can be used for SSL certificate signing
		/// <param> name="subject" the certificate subject
		/// </param></remarks>		<return> true if it can be used for SSL
		/// 	 </return>
		/// 		<short>     Determine if a certificate can be used for SSL certificate signing </short>
		public bool UseForSSL(string subject) {
			return (bool) interceptor.Invoke("useForSSL$", "useForSSL(const QString&) const", typeof(bool), typeof(string), subject);
		}
		/// <remarks>
		///   Determine if a certificate can be used for S/MIME certificate signing
		/// <param> name="cert" the certificate
		/// </param></remarks>		<return> true if it can be used for S/MIME
		/// 	 </return>
		/// 		<short>     Determine if a certificate can be used for S/MIME certificate signing </short>
		public bool UseForEmail(KSSLCertificate cert) {
			return (bool) interceptor.Invoke("useForEmail#", "useForEmail(KSSLCertificate&) const", typeof(bool), typeof(KSSLCertificate), cert);
		}
		/// <remarks>
		///   Determine if a certificate can be used for S/MIME certificate signing
		/// <param> name="subject" the certificate subject
		/// </param></remarks>		<return> true if it can be used for S/MIME
		/// 	 </return>
		/// 		<short>     Determine if a certificate can be used for S/MIME certificate signing </short>
		public bool UseForEmail(string subject) {
			return (bool) interceptor.Invoke("useForEmail$", "useForEmail(const QString&) const", typeof(bool), typeof(string), subject);
		}
		/// <remarks>
		///   Determine if a certificate can be used for code certificate signing
		/// <param> name="cert" the certificate
		/// </param></remarks>		<return> true if it can be used for code
		/// 	 </return>
		/// 		<short>     Determine if a certificate can be used for code certificate signing </short>
		public bool UseForCode(KSSLCertificate cert) {
			return (bool) interceptor.Invoke("useForCode#", "useForCode(KSSLCertificate&) const", typeof(bool), typeof(KSSLCertificate), cert);
		}
		/// <remarks>
		///   Determine if a certificate can be used for code certificate signing
		/// <param> name="subject" the certificate subject
		/// </param></remarks>		<return> true if it can be used for code
		/// 	 </return>
		/// 		<short>     Determine if a certificate can be used for code certificate signing </short>
		public bool UseForCode(string subject) {
			return (bool) interceptor.Invoke("useForCode$", "useForCode(const QString&) const", typeof(bool), typeof(string), subject);
		}
		/// <remarks>
		///   Remove a certificate signer from the database
		/// <param> name="cert" the certificate to remove
		/// </param></remarks>		<return> true on success
		/// 	 </return>
		/// 		<short>     Remove a certificate signer from the database </short>
		public bool Remove(KSSLCertificate cert) {
			return (bool) interceptor.Invoke("remove#", "remove(KSSLCertificate&)", typeof(bool), typeof(KSSLCertificate), cert);
		}
		/// <remarks>
		///   Remove a certificate signer from the database
		/// <param> name="subject" the subject of the certificate to remove
		/// </param></remarks>		<return> true on success
		/// 	 </return>
		/// 		<short>     Remove a certificate signer from the database </short>
		public bool Remove(string subject) {
			return (bool) interceptor.Invoke("remove$", "remove(const QString&)", typeof(bool), typeof(string), subject);
		}
		/// <remarks>
		///   List the signers in the database.
		/// </remarks>		<return> the list of subjects in the database
		/// </return>
		/// 		<short>     List the signers in the database.</short>
		/// 		<see> getCert</see>
		public List<string> List() {
			return (List<string>) interceptor.Invoke("list", "list()", typeof(List<string>));
		}
		/// <remarks>
		///   Get a signer certificate from the database.
		/// <param> name="subject" the subject of the certificate desired
		/// </param></remarks>		<return> the base64 encoded certificate
		/// 	 </return>
		/// 		<short>     Get a signer certificate from the database.</short>
		public string GetCert(string subject) {
			return (string) interceptor.Invoke("getCert$", "getCert(const QString&)", typeof(string), typeof(string), subject);
		}
		/// <remarks>
		///   Set the use of a particular entry in the certificate signer database.
		/// <param> name="subject" the subject of the certificate in question
		/// </param><param> name="ssl" allow this for SSL certificate signing
		/// </param><param> name="email" allow this for S/MIME certificate signing
		/// </param><param> name="code" allow this for code certificate signing
		/// </param></remarks>		<return> true on success
		/// 	 </return>
		/// 		<short>     Set the use of a particular entry in the certificate signer database.</short>
		public bool SetUse(string subject, bool ssl, bool email, bool code) {
			return (bool) interceptor.Invoke("setUse$$$$", "setUse(const QString&, bool, bool, bool)", typeof(bool), typeof(string), subject, typeof(bool), ssl, typeof(bool), email, typeof(bool), code);
		}
		~KSSLSigners() {
			interceptor.Invoke("~KSSLSigners", "~KSSLSigners()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~KSSLSigners", "~KSSLSigners()", typeof(void));
		}
	}
}
