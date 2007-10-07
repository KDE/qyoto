//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  KFileMetaInfo provides metadata extracted from a file or other resource.
	///  When instantiating an instance of this class, the metadata related to it
	///  will be retrieved and stored in the instance. The data can be inspected
	///  through KFileMetaDataItem objects.
	/// </remarks>		<short>    KFileMetaInfo provides metadata extracted from a file or other resource.</short>

	[SmokeClass("KFileMetaInfo")]
	public class KFileMetaInfo : Object, IDisposable {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected KFileMetaInfo(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KFileMetaInfo), this);
		}
		/// <remarks>
		///  This is used to specify what a KFileMetaInfo object should read, so
		///  you can specify if you want to read "expensive" items or not.
		///  This is like a preset which can be customized by passing additional
		///  parameters to constructors.
		///      </remarks>		<short>    This is used to specify what a KFileMetaInfo object should read, so  you can specify if you want to read "expensive" items or not.</short>
		public enum What {
			Fastest = 0x1,
			TechnicalInfo = 0x4,
			ContentInfo = 0x8,
			ExternalSources = 0x10,
			Thumbnail = 0x20,
			LinkedData = 0x80,
			Everything = 0xffff,
		}
		// const QHash<QString, KFileMetaInfoItem>& items(); >>>> NOT CONVERTED
		// KFileMetaInfoItem& item(const QString& arg1); >>>> NOT CONVERTED
		// const KFileMetaInfoItem& item(const QString& arg1); >>>> NOT CONVERTED
		// KFileMetaInfoGroupList groups(); >>>> NOT CONVERTED
		/// <remarks>
		///  @brief Construct a KFileMetaInfo that contains metainformation about
		///  the resource pointed to by <code>path.</code>
		/// </remarks>		<short>    @brief Construct a KFileMetaInfo that contains metainformation about  the resource pointed to by <code>path.</code></short>
		public KFileMetaInfo(string path, string mimetype, uint w) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KFileMetaInfo$$$", "KFileMetaInfo(const QString&, const QString&, KFileMetaInfo::WhatFlags)", typeof(void), typeof(string), path, typeof(string), mimetype, typeof(uint), w);
		}
		public KFileMetaInfo(string path, string mimetype) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KFileMetaInfo$$", "KFileMetaInfo(const QString&, const QString&)", typeof(void), typeof(string), path, typeof(string), mimetype);
		}
		public KFileMetaInfo(string path) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KFileMetaInfo$", "KFileMetaInfo(const QString&)", typeof(void), typeof(string), path);
		}
		/// <remarks>
		///  @brief Construct a KFileMetaInfo that contains metainformation about
		///  the resource pointed to by <code>url.</code>
		/// </remarks>		<short>    @brief Construct a KFileMetaInfo that contains metainformation about  the resource pointed to by <code>url.</code></short>
		public KFileMetaInfo(KUrl url) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KFileMetaInfo#", "KFileMetaInfo(const KUrl&)", typeof(void), typeof(KUrl), url);
		}
		/// <remarks>
		///  @brief Construct an empty, invalid KFileMetaInfo instance.
		/// </remarks>		<short>    @brief Construct an empty, invalid KFileMetaInfo instance.</short>
		public KFileMetaInfo() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KFileMetaInfo", "KFileMetaInfo()", typeof(void));
		}
		/// <remarks>
		///  @brief Construct a KFileMetaInfo instance from another one.
		/// </remarks>		<short>    @brief Construct a KFileMetaInfo instance from another one.</short>
		public KFileMetaInfo(KFileMetaInfo arg1) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KFileMetaInfo#", "KFileMetaInfo(const KFileMetaInfo&)", typeof(void), typeof(KFileMetaInfo), arg1);
		}
		/// <remarks>
		///  @brief Save the changes made to this KFileMetaInfo instance.
		///      </remarks>		<short>    @brief Save the changes made to this KFileMetaInfo instance.</short>
		public bool ApplyChanges() {
			return (bool) interceptor.Invoke("applyChanges", "applyChanges()", typeof(bool));
		}
		/// <remarks>
		///  @brief Retrieve all the items.
		/// </remarks>		<short>    @brief Retrieve all the items.</short>
		public bool IsValid() {
			return (bool) interceptor.Invoke("isValid", "isValid() const", typeof(bool));
		}
		/// <remarks>
		///  Deprecated
		/// </remarks>		<short>    Deprecated </short>
		public List<string> PreferredKeys() {
			return (List<string>) interceptor.Invoke("preferredKeys", "preferredKeys() const", typeof(List<string>));
		}
		/// <remarks>
		///  Deprecated
		/// </remarks>		<short>    Deprecated </short>
		public List<string> SupportedKeys() {
			return (List<string>) interceptor.Invoke("supportedKeys", "supportedKeys() const", typeof(List<string>));
		}
		public List<string> Keys() {
			return (List<string>) interceptor.Invoke("keys", "keys() const", typeof(List<string>));
		}
		public KUrl Url() {
			return (KUrl) interceptor.Invoke("url", "url() const", typeof(KUrl));
		}
		~KFileMetaInfo() {
			interceptor.Invoke("~KFileMetaInfo", "~KFileMetaInfo()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~KFileMetaInfo", "~KFileMetaInfo()", typeof(void));
		}
	}
}
