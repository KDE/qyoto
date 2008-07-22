//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    using System.Collections.Generic;
    /// <remarks>
    ///  \class KConfigBase kconfigbase.h <KConfigBase>
    ///  </remarks>        <short>    \class KConfigBase kconfigbase.</short>
    [SmokeClass("KConfigBase")]
    public abstract class KConfigBase : Object {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected KConfigBase(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(KConfigBase), this);
        }
        /// <remarks>
        ///  Flags to control write entry
        ///      </remarks>        <short>    Flags to control write entry      </short>
        public enum WriteConfigFlag {
            Persistent = 0x01,
            Global = 0x02,
            Localized = 0x04,
            Normal = Persistent,
        }
        /// <remarks>
        ///  Possible return values for accessMode().
        ///      </remarks>        <short>    Possible return values for accessMode().</short>
        public enum AccessMode {
            NoAccess = 0,
            ReadOnly = 1,
            ReadWrite = 2,
        }
        /// <remarks>
        ///  Returns a list of groups that are known about.
        /// </remarks>        <return> The list of groups.
        /// </return>
        ///         <short>    Returns a list of groups that are known about.</short>
        [SmokeMethod("groupList() const")]
        public abstract List<string> GroupList();
        /// <remarks>
        ///  Returns true if the specified group is known about.
        /// <param> name="group" The group to search for.
        /// </param></remarks>        <return> true if the group exists.
        ///      </return>
        ///         <short>    Returns true if the specified group is known about.</short>
        public bool HasGroup(string group) {
            return (bool) interceptor.Invoke("hasGroup$", "hasGroup(const QString&) const", typeof(bool), typeof(string), group);
        }
        public bool HasGroup(QByteArray group) {
            return (bool) interceptor.Invoke("hasGroup#", "hasGroup(const QByteArray&) const", typeof(bool), typeof(QByteArray), group);
        }
        /// <remarks>
        ///  Returns an object for the named subgroup.
        /// <param> name="group" the group to open. Pass a null string on to the KConfig
        ///    object to obtain a handle on the root group.
        /// </param></remarks>        <return> The list of groups.
        /// </return>
        ///         <short>    Returns an object for the named subgroup.</short>
        public KConfigGroup Group(QByteArray group) {
            return (KConfigGroup) interceptor.Invoke("group#", "group(const QByteArray&)", typeof(KConfigGroup), typeof(QByteArray), group);
        }
        public KConfigGroup Group(string group) {
            return (KConfigGroup) interceptor.Invoke("group$", "group(const QString&)", typeof(KConfigGroup), typeof(string), group);
        }
        /// <remarks>
        ///  Delete <code>aGroup.</code> This marks <code>aGroup</code> as <b>deleted</b> in the config object. This effectively
        ///  removes any cascaded values from config files earlier in the stack.
        ///      </remarks>        <short>    Delete <code>aGroup.</code></short>
        public void DeleteGroup(QByteArray group, uint flags) {
            interceptor.Invoke("deleteGroup#$", "deleteGroup(const QByteArray&, KConfigBase::WriteConfigFlags)", typeof(void), typeof(QByteArray), group, typeof(uint), flags);
        }
        public void DeleteGroup(QByteArray group) {
            interceptor.Invoke("deleteGroup#", "deleteGroup(const QByteArray&)", typeof(void), typeof(QByteArray), group);
        }
        public void DeleteGroup(string group, uint flags) {
            interceptor.Invoke("deleteGroup$$", "deleteGroup(const QString&, KConfigBase::WriteConfigFlags)", typeof(void), typeof(string), group, typeof(uint), flags);
        }
        public void DeleteGroup(string group) {
            interceptor.Invoke("deleteGroup$", "deleteGroup(const QString&)", typeof(void), typeof(string), group);
        }
        /// <remarks>
        ///  Syncs the configuration object that this group belongs to.
        ///  Unrelated concurrent changes to the same file are merged and thus
        ///  not overwritten. Note however, that this object is <b>not</b> automatically
        ///  updated with those changes.
        ///      </remarks>        <short>    Syncs the configuration object that this group belongs to.</short>
        [SmokeMethod("sync()")]
        public abstract void Sync();
        /// <remarks>
        ///  Reset the dirty flags of all entries in the entry map, so the
        ///  values will not be written to disk on a later call to sync().
        ///      </remarks>        <short>    Reset the dirty flags of all entries in the entry map, so the  values will not be written to disk on a later call to sync().</short>
        [SmokeMethod("markAsClean()")]
        public abstract void MarkAsClean();
        /// <remarks>
        ///  Returns the access mode of the app-config object.
        ///  Possible return values
        ///  are NoAccess (the application-specific config file could not be
        ///  opened neither read-write nor read-only), ReadOnly (the
        ///  application-specific config file is opened read-only, but not
        ///  read-write) and ReadWrite (the application-specific config
        ///  file is opened read-write).
        /// </remarks>        <return> the access mode of the app-config object
        ///      </return>
        ///         <short>    Returns the access mode of the app-config object.</short>
        [SmokeMethod("accessMode() const")]
        public abstract KConfigBase.AccessMode accessMode();
        /// <remarks>
        ///  Checks whether this configuration object can be modified.
        /// </remarks>        <return> whether changes may be made to this configuration object.
        ///      </return>
        ///         <short>    Checks whether this configuration object can be modified.</short>
        [SmokeMethod("isImmutable() const")]
        public abstract bool IsImmutable();
        /// <remarks>
        ///  Can changes be made to the entries in <code>aGroup</code>?
        /// <param> name="aGroup" The group to check for immutability.
        /// </param></remarks>        <return> @c false if the entries in <code>aGroup</code> can be modified.
        ///      </return>
        ///         <short>    Can changes be made to the entries in <code>aGroup</code>? </short>
        public bool IsGroupImmutable(QByteArray aGroup) {
            return (bool) interceptor.Invoke("isGroupImmutable#", "isGroupImmutable(const QByteArray&) const", typeof(bool), typeof(QByteArray), aGroup);
        }
        public bool IsGroupImmutable(string aGroup) {
            return (bool) interceptor.Invoke("isGroupImmutable$", "isGroupImmutable(const QString&) const", typeof(bool), typeof(string), aGroup);
        }
        public KConfigBase() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KConfigBase", "KConfigBase()", typeof(void));
        }
        [SmokeMethod("hasGroupImpl(const QByteArray&) const")]
        protected abstract bool HasGroupImpl(QByteArray group);
        [SmokeMethod("groupImpl(const QByteArray&)")]
        protected abstract KConfigGroup GroupImpl(QByteArray b);
        [SmokeMethod("deleteGroupImpl(const QByteArray&, KConfigBase::WriteConfigFlags)")]
        protected abstract void DeleteGroupImpl(QByteArray group, uint flags);
        [SmokeMethod("isGroupImmutableImpl(const QByteArray&) const")]
        protected abstract bool IsGroupImmutableImpl(QByteArray aGroup);
    }
}
