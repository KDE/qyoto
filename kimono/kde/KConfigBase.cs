//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  This class forms the base for all %KDE configuration. It is an
	///  abstract base class, meaning that you cannot directly instantiate
	///  objects of this class. Either use KConfig (for usual %KDE
	///  configuration) or even KSharedConfig (stores values in shared memory).
	///  All configuration entries are key, value pairs.  Each entry also
	///  belongs to a specific group of related entries.  All configuration
	///  entries that do not explicitly specify which group they are in are
	///  in a special group called the default group.
	///  If there is a $ character in an entry, KConfigBase tries to expand
	///  environment variable and uses its value instead of its name. You
	///  can avoid this feature by having two consecutive $ characters in
	///  your config file which get expanded to one.
	///  <b>Note:<> the '=' char is not allowed in keys and the ']' char is not allowed in
	///  a group name.
	/// </remarks>		<author> Kalle Dalheimer <kalle@kde.org>, Preston Brown <pbrown@kde.org>
	/// </author>
	/// 		<short> KDE Configuration Management abstract base class.</short>
	/// 		<see> KGlobal#config</see>
	/// 		<see> KConfig</see>
	/// 		<see> KSharedConfig</see>

	[SmokeClass("KConfigBase")]
	public abstract class KConfigBase : KConfigFlags {
 		protected KConfigBase(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KConfigBase), this);
		}
		/// <remarks>
		///  Possible return values for getConfigState().
		/// </remarks>		<short>    Possible return values for getConfigState().</short>
		/// 		<see> getConfigState</see>
		public enum ConfigState {
			NoAccess = 0,
			ReadOnly = 1,
			ReadWrite = 2,
		}
		// void writeEntry(const char* arg1,const QStringList& arg2,char arg3,WriteConfigFlags arg4); >>>> NOT CONVERTED
		// void deleteGroup(const QString& arg1,WriteConfigFlags arg2); >>>> NOT CONVERTED
		// KEntryMap internalEntryMap(const QString& arg1); >>>> NOT CONVERTED
		// KEntryMap internalEntryMap(); >>>> NOT CONVERTED
		// void putData(const KEntryKey& arg1,const KEntry& arg2,bool arg3); >>>> NOT CONVERTED
		// void putData(const KEntryKey& arg1,const KEntry& arg2); >>>> NOT CONVERTED
		// KEntry lookupData(const KEntryKey& arg1); >>>> NOT CONVERTED
		/// <remarks>
		///  Construct a KConfigBase object.
		///    </remarks>		<short>    Construct a KConfigBase object.</short>
		public KConfigBase() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KConfigBase", "KConfigBase()", typeof(void));
		}
		/// <remarks>
		///  Construct a KConfigBase object.
		///    </remarks>		<short>    Construct a KConfigBase object.</short>
		public KConfigBase(KComponentData componentData) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KConfigBase#", "KConfigBase(const KComponentData&)", typeof(void), typeof(KComponentData), componentData);
		}
		public KComponentData ComponentData() {
			return (KComponentData) interceptor.Invoke("componentData", "componentData() const", typeof(KComponentData));
		}
		/// <remarks>
		///  Returns true if the specified group is known about.
		/// <param> name="group" The group to search for.
		/// </param></remarks>		<return> true if the group exists.
		///    </return>
		/// 		<short>    Returns true if the specified group is known about.</short>
		public bool HasGroup(string group) {
			return (bool) interceptor.Invoke("hasGroup$", "hasGroup(const QString&) const", typeof(bool), typeof(string), group);
		}
		/// <remarks>
		///  Returns a list of groups that are known about.
		/// </remarks>		<return> The list of groups.
		/// </return>
		/// 		<short>    Returns a list of groups that are known about.</short>
		[SmokeMethod("groupList() const")]
		public abstract List<string> GroupList();
		/// <remarks>
		///  Returns a the current locale.
		/// </remarks>		<return> A string representing the current locale.
		///    </return>
		/// 		<short>    Returns a the current locale.</short>
		public string Locale() {
			return (string) interceptor.Invoke("locale", "locale() const", typeof(string));
		}
		/// <remarks>
		///  writeEntry() overridden to accept a list of strings.
		/// <param> name="pKey" The key to write
		/// </param><param> name="value" The list to write
		/// </param><param> name="sep" The list separator (default is ",").
		/// </param><param> name="pFlags" The flags to use when writing this entry.
		/// </param></remarks>		<short>    writeEntry() overridden to accept a list of strings.</short>
		/// 		<see> writeEntry</see>
		public void WriteEntry(string pKey, List<string> value, char sep) {
			interceptor.Invoke("writeEntry$?$", "writeEntry(const char*, const QStringList&, char)", typeof(void), typeof(string), pKey, typeof(List<string>), value, typeof(char), sep);
		}
		public void WriteEntry(string pKey, List<string> value) {
			interceptor.Invoke("writeEntry$?", "writeEntry(const char*, const QStringList&)", typeof(void), typeof(string), pKey, typeof(List<string>), value);
		}
		/// <remarks>
		///  Deletes a configuration entry group
		///  If the group is not empty and Recursive is not set, nothing gets deleted
		///  If this group is the current group and it is deleted, the
		///  current group is undefined and should be set with setGroup()
		///  before the next operation on the configuration object.
		/// <param> name="group" The name of the group
		/// </param><param> name="pFlags" The flags to use when writing this entry.
		///    </param></remarks>		<short>    Deletes a configuration entry group </short>
		public void DeleteGroup(string group) {
			interceptor.Invoke("deleteGroup$", "deleteGroup(const QString&)", typeof(void), typeof(string), group);
		}
		/// <remarks>
		///  Turns on or off "dollar  expansion" (see KConfigBase introduction)
		///   when reading config entries.
		///  Dollar sign expansion is initially OFF.
		/// <param> name="_bExpand" Tf true, dollar expansion is turned on.
		///    </param></remarks>		<short>    Turns on or off "dollar  expansion" (see KConfigBase introduction)   when reading config entries.</short>
		public void SetDollarExpansion(bool _bExpand) {
			interceptor.Invoke("setDollarExpansion$", "setDollarExpansion(bool)", typeof(void), typeof(bool), _bExpand);
		}
		/// <remarks>
		///  Returns whether dollar expansion is on or off.  It is initially OFF.
		/// </remarks>		<return> true if dollar expansion is on.
		///    </return>
		/// 		<short>    Returns whether dollar expansion is on or off.</short>
		public bool IsDollarExpansion() {
			return (bool) interceptor.Invoke("isDollarExpansion", "isDollarExpansion() const", typeof(bool));
		}
		/// <remarks>
		///  Returns whether the locale has been set.
		/// </remarks>		<return> true if the locale has been initialized
		///    </return>
		/// 		<short>    Returns whether the locale has been set.</short>
		public bool LocaleInitialized() {
			return (bool) interceptor.Invoke("localeInitialized", "localeInitialized() const", typeof(bool));
		}
		/// <remarks>
		///  Mark the config object as "clean," i.e. don't write dirty entries
		///  at destruction time. If <code>bDeep</code> is false, only the global dirty
		///  flag of the KConfig object gets cleared. If you then call
		///  writeEntry() again, the global dirty flag is set again and all
		///  dirty entries will be written at a subsequent sync() call.
		///  Classes that derive from KConfigBase should override this
		///  method and implement storage-specific behavior, as well as
		///  calling the KConfigBase.Rollback() explicitly in the initializer.
		/// <param> name="bDeep" If true, the dirty flags of all entries are cleared,
		///         as well as the global dirty flag.
		///    </param></remarks>		<short>    Mark the config object as "clean," i.</short>
		[SmokeMethod("rollback(bool)")]
		public virtual void Rollback(bool bDeep) {
			interceptor.Invoke("rollback$", "rollback(bool)", typeof(void), typeof(bool), bDeep);
		}
		[SmokeMethod("rollback()")]
		public virtual void Rollback() {
			interceptor.Invoke("rollback", "rollback()", typeof(void));
		}
		/// <remarks>
		///  Flushes all changes that currently reside only in memory
		///  back to disk / permanent storage. Dirty configuration entries are
		///  written to the most specific file available.
		///  Asks the back end to flush out all pending writes, and then calls
		///  rollback().  No changes are made if the object has <code>readOnly</code>
		///  status.
		///  You should call this from your destructor in derivative classes.
		/// </remarks>		<short>    Flushes all changes that currently reside only in memory  back to disk / permanent storage.</short>
		/// 		<see> rollback</see>
		[SmokeMethod("sync()")]
		public virtual void Sync() {
			interceptor.Invoke("sync", "sync()", typeof(void));
		}
		/// <remarks>
		///  Checks whether the config file has any dirty (modified) entries.
		/// </remarks>		<return> true if the config file has any dirty (modified) entries.
		///    </return>
		/// 		<short>    Checks whether the config file has any dirty (modified) entries.</short>
		public bool IsDirty() {
			return (bool) interceptor.Invoke("isDirty", "isDirty() const", typeof(bool));
		}
		/// <remarks>
		///  Checks whether the key has an entry in the currently active group.
		///  Use this to determine whether a key is not specified for the current
		///  group (hasKey() returns false). Keys with null data are considered
		///  nonexistent.
		/// <param> name="key" The key to search for.
		/// </param></remarks>		<return> If true, the key is available.
		///    </return>
		/// 		<short>    Checks whether the key has an entry in the currently active group.</short>
		public bool HasKey(string key) {
			return (bool) interceptor.Invoke("hasKey$", "hasKey(const QString&) const", typeof(bool), typeof(string), key);
		}
		/// <remarks>
		///  Returns a map (tree) of entries for all entries in a particular
		///  group.  Only the actual entry string is returned, none of the
		///  other internal data should be included.
		/// <param> name="group" A group to get keys from.
		/// </param></remarks>		<return> A map of entries in the group specified, indexed by key.
		///          The returned map may be empty if the group is not found.
		/// </return>
		/// 		<short>    Returns a map (tree) of entries for all entries in a particular  group.</short>
		/// 		<see> QMap</see>
		[SmokeMethod("entryMap(const QString&) const")]
		public abstract Dictionary<string, string> EntryMap(string group);
		/// <remarks>
		///  Reparses all configuration files. This is useful for programs
		///  that use stand alone graphical configuration tools. The base
		///  method implemented here only clears the group list and then
		///  appends the default group.
		///  Derivative classes should clear any internal data structures and
		///  then simply call parseConfigFiles() when implementing this
		///  method.
		/// </remarks>		<short>    Reparses all configuration files.</short>
		/// 		<see> parseConfigFiles</see>
		[SmokeMethod("reparseConfiguration()")]
		public abstract void ReparseConfiguration();
		/// <remarks>
		///  Checks whether this configuration file can be modified.
		/// </remarks>		<return> whether changes may be made to this configuration file.
		///    </return>
		/// 		<short>    Checks whether this configuration file can be modified.</short>
		public bool IsImmutable() {
			return (bool) interceptor.Invoke("isImmutable", "isImmutable() const", typeof(bool));
		}
		/// <remarks>
		///  Checks whether it is possible to change the given group.
		/// <param> name="group" the group to check
		/// </param></remarks>		<return> whether changes may be made to <code>group</code> in this configuration
		///  file.
		///    </return>
		/// 		<short>    Checks whether it is possible to change the given group.</short>
		public bool GroupIsImmutable(string group) {
			return (bool) interceptor.Invoke("groupIsImmutable$", "groupIsImmutable(const QString&) const", typeof(bool), typeof(string), group);
		}
		/// <remarks>
		///  Checks whether it is possible to change the given entry.
		/// <param> name="key" the key to check
		/// </param></remarks>		<return> whether the entry <code>key</code> may be changed in the current group
		///  in this configuration file.
		///    </return>
		/// 		<short>    Checks whether it is possible to change the given entry.</short>
		public bool EntryIsImmutable(string key) {
			return (bool) interceptor.Invoke("entryIsImmutable$", "entryIsImmutable(const QString&) const", typeof(bool), typeof(string), key);
		}
		/// <remarks>
		///  Returns the state of the app-config object.
		///  Possible return values
		///  are NoAccess (the application-specific config file could not be
		///  opened neither read-write nor read-only), ReadOnly (the
		///  application-specific config file is opened read-only, but not
		///  read-write) and ReadWrite (the application-specific config
		///  file is opened read-write).
		/// </remarks>		<return> the state of the app-config object
		///    </return>
		/// 		<short>    Returns the state of the app-config object.</short>
		/// 		<see> ConfigState</see>
		public KConfigBase.ConfigState GetConfigState() {
			return (KConfigBase.ConfigState) interceptor.Invoke("getConfigState", "getConfigState() const", typeof(KConfigBase.ConfigState));
		}
		/// <remarks>
		///  Check whether the config files are writable.
		/// <param> name="warnUser" Warn the user if the configuration files are not writable.
		/// </param></remarks>		<return> Indicates that all of the configuration files used are writable.
		///    </return>
		/// 		<short>    Check whether the config files are writable.</short>
		public bool CheckConfigFilesWritable(bool warnUser) {
			return (bool) interceptor.Invoke("checkConfigFilesWritable$", "checkConfigFilesWritable(bool)", typeof(bool), typeof(bool), warnUser);
		}
		/// <remarks>
		///  When set, all readEntry and readXXXEntry calls return the system
		///  wide (default) values instead of the user's preference.
		///  This is off by default.
		///    </remarks>		<short>    When set, all readEntry and readXXXEntry calls return the system  wide (default) values instead of the user's preference.</short>
		public void SetReadDefaults(bool b) {
			interceptor.Invoke("setReadDefaults$", "setReadDefaults(bool)", typeof(void), typeof(bool), b);
		}
		/// <remarks>
		/// </remarks>		<return> true if all readEntry and readXXXEntry calls return the system
		///  wide (default) values instead of the user's preference.
		///    </return>
		/// 		<short>   </short>
		public bool ReadDefaults() {
			return (bool) interceptor.Invoke("readDefaults", "readDefaults() const", typeof(bool));
		}
		/// <remarks>
		///  Reverts the entry with key <code>key</code> in the current group in the
		///  application specific config file to either the system wide (default)
		///  value or the value specified in the global KDE config file.
		///  To revert entries in the global KDE config file, the global KDE config
		///  file should be opened explicitly in a separate config object.
		/// <param> name="key" The key of the entry to revert.
		///    </param></remarks>		<short>    Reverts the entry with key <code>key</code> in the current group in the  application specific config file to either the system wide (default)  value or the value specified in the global KDE config file.</short>
		public void RevertToDefault(string key) {
			interceptor.Invoke("revertToDefault$", "revertToDefault(const QString&)", typeof(void), typeof(string), key);
		}
		/// <remarks>
		///  Returns whether a default is specified for an entry in either the
		///  system wide configuration file or the global KDE config file.
		///  If an application computes a default value at runtime for
		///  a certain entry, e.g. like:
		///  <pre>
		///  QColor computedDefault = qApp.Palette().color(QPalette.Active, QPalette.Text)
		///  QColor color = config.ReadEntry(key, computedDefault);
		///  \encode
		///  Then it may wish to make the following check before
		///  writing back changes:
		///  <pre>
		///  if ( (value == computedDefault) && !config.HasDefault(key) )
		///     config.RevertToDefault(key)
		///  else
		///     config.WriteEntry(key, value)
		///  </pre>
		///  This ensures that as long as the entry is not modified to differ from
		///  the computed default, the application will keep using the computed default
		///  and will follow changes the computed default makes over time.
		/// <param> name="key" The key of the entry to check.
		///    </param></remarks>		<short>    Returns whether a default is specified for an entry in either the  system wide configuration file or the global KDE config file.</short>
		public bool HasDefault(string key) {
			return (bool) interceptor.Invoke("hasDefault$", "hasDefault(const QString&) const", typeof(bool), typeof(string), key);
		}
		public bool HasGroup(QByteArray _pGroup) {
			return (bool) interceptor.Invoke("hasGroup#", "hasGroup(const QByteArray&) const", typeof(bool), typeof(QByteArray), _pGroup);
		}
		/// <remarks>
		///  Reads the locale and put in the configuration data struct.
		///  Note that this should be done in the constructor, but this is not
		///  possible due to some mutual dependencies in KApplication.Init()
		///    </remarks>		<short>    Reads the locale and put in the configuration data struct.</short>
		protected void SetLocale() {
			interceptor.Invoke("setLocale", "setLocale()", typeof(void));
		}
		/// <remarks>
		///  Sets the global dirty flag of the config object
		/// <param> name="_bDirty" How to mark the object's dirty status
		///    </param></remarks>		<short>    Sets the global dirty flag of the config object </short>
		protected void SetDirty(bool _bDirty) {
			interceptor.Invoke("setDirty$", "setDirty(bool)", typeof(void), typeof(bool), _bDirty);
		}
		/// <remarks>
		///  Sets the backend to use with this config object.
		///  Ownership of the backend is taken over by the config object.
		///    </remarks>		<short>    Sets the backend to use with this config object.</short>
		protected void SetBackEnd(KConfigBackEnd backEnd) {
			interceptor.Invoke("setBackEnd#", "setBackEnd(KConfigBackEnd*)", typeof(void), typeof(KConfigBackEnd), backEnd);
		}
		/// <remarks>
		///  Returns the backend associated with this config object
		///    </remarks>		<short>    Returns the backend associated with this config object    </short>
		protected KConfigBackEnd BackEnd() {
			return (KConfigBackEnd) interceptor.Invoke("backEnd", "backEnd() const", typeof(KConfigBackEnd));
		}
		/// <remarks>
		///  Parses all configuration files for a configuration object.
		///  The actual parsing is done by the associated KConfigBackEnd.
		///    </remarks>		<short>    Parses all configuration files for a configuration object.</short>
		[SmokeMethod("parseConfigFiles()")]
		protected virtual void ParseConfigFiles() {
			interceptor.Invoke("parseConfigFiles", "parseConfigFiles()", typeof(void));
		}
		/// <remarks>
		///  Returns a map (tree) of the entries in the specified group.
		///  This may or may not return all entries that belong to the
		///  config object.  The only guarantee that you are given is that
		///  any entries that are dirty (i.e. modified and not yet written back
		///  to the disk) will be contained in the map.  Some derivative
		///  classes may choose to return everything.
		///  Do not use this function, the implementation / return type are
		///  subject to change.
		/// <param> name="pGroup" The group to provide a KEntryMap for.
		/// </param>   </remarks>		<return> The map of the entries in the group.
		/// </return>
		/// 		<short>    Returns a map (tree) of the entries in the specified group.</short>
		/// <remarks>
		///  Returns a map (tree) of the entries in the tree.
		///  Do not use this function, the implementation / return type are
		///  subject to change.
		///    </remarks>		<return> A map of the entries in the tree.
		/// </return>
		/// 		<short>    Returns a map (tree) of the entries in the tree.</short>
		/// <remarks>
		///  Inserts a (key/value) pair into the internal storage mechanism of
		///  the configuration object. Classes that derive from KConfigBase
		///  will need to implement this method in a storage-specific manner.
		///  Do not use this function, the implementation / return type are
		///  subject to change.
		/// <param> name="_key" The key to insert.  It contains information both on
		///         the group of the key and the key itself. If the key already
		///         exists, the old value will be replaced.
		/// </param><param> name="_data" the KEntry that is to be stored.
		/// </param><param> name="_checkGroup" When false, assume that the group already exists.
		/// </param>   </remarks>		<short>    Inserts a (key/value) pair into the internal storage mechanism of  the configuration object.</short>
		/// <remarks>
		///  Looks up an entry in the config object's internal structure.
		///  Classes that derive from KConfigBase will need to implement this
		///  method in a storage-specific manner.
		///  Do not use this function, the implementation and return type are
		///  subject to change.
		/// <param> name="_key" The key to look up  It contains information both on
		///         the group of the key and the entry's key itself.
		/// </param>   </remarks>		<return> The KEntry value (data) found for the key.  <code>KEntry.aValue</code>
		///  will be the null string if nothing was located.
		/// </return>
		/// 		<short>    Looks up an entry in the config object's internal structure.</short>
		/// <remarks>
		///    </remarks>		<short>   </short>
		[SmokeMethod("internalHasGroup(const QByteArray&) const")]
		protected abstract bool InternalHasGroup(QByteArray group);
		protected KConfigGroup InternalGroup() {
			return (KConfigGroup) interceptor.Invoke("internalGroup", "internalGroup() const", typeof(KConfigGroup));
		}
	}
}
