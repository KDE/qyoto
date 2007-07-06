//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Runtime.InteropServices;
	using System.Collections.Generic;

	/// <remarks>
	///  KServiceGroup represents a group of service, for example
	///  screensavers.
	///  This class is typically used like this:
	///  <pre>
	///  // Lookup screensaver group
	///  KServiceGroup.Ptr group = KServiceGroup.BaseGroup("screensavers");
	///  if (!group || !group.IsValid()) return;
	///  KServiceGroup.List list = group.Entries();
	///  // Iterate over all entries in the group
	///  for( KServiceGroup.List.ConstIterator it = list.begin();
	///       it != list.end(); it++)
	///  {
	///     KSycocaEntry p = (it);
	///     if (p.IsType(KST_KService))
	///     {
	///        KService s = (KService)(p);
	///        printf("Name = %s\n", s.Name().toLatin1());
	///     }
	///     else if (p.IsType(KST_KServiceGroup))
	///     {
	///        KServiceGroup g = (KServiceGroup)(p);
	///        // Sub group ...
	///     }
	///  }
	///  </pre>
	/// </remarks>		<short> Represents a group of services.</short>

	[SmokeClass("KServiceGroup")]
	public class KServiceGroup : KSycocaEntry, IDisposable {
 		protected KServiceGroup(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KServiceGroup), this);
		}
		// KServiceGroup::List entries(bool arg1,bool arg2,bool arg3,bool arg4); >>>> NOT CONVERTED
		// KServiceGroup::List entries(bool arg1,bool arg2,bool arg3); >>>> NOT CONVERTED
		// KServiceGroup::List entries(bool arg1,bool arg2); >>>> NOT CONVERTED
		// KServiceGroup::List entries(bool arg1); >>>> NOT CONVERTED
		// KServiceGroup::List entries(); >>>> NOT CONVERTED
		// KServiceGroup::Ptr baseGroup(const QString& arg1); >>>> NOT CONVERTED
		// KServiceGroup::Ptr root(); >>>> NOT CONVERTED
		// KServiceGroup::Ptr group(const QString& arg1); >>>> NOT CONVERTED
		// KServiceGroup::Ptr childGroup(const QString& arg1); >>>> NOT CONVERTED
		// void addEntry(const KSycocaEntry::Ptr& arg1); >>>> NOT CONVERTED
		/// <remarks>
		///  Construct a dummy servicegroup indexed with <code>name.</code>
		/// <param> name="name" the name of the service group
		///    </param></remarks>		<short>    Construct a dummy servicegroup indexed with <code>name.</code></short>
		public KServiceGroup(string name) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KServiceGroup$", "KServiceGroup(const QString&)", typeof(void), typeof(string), name);
		}
		/// <remarks>
		///  Construct a service and take all information from a config file
		/// <param> name="_fullpath" full path to the config file
		/// </param><param> name="_relpath" relative path to the config file
		///    </param></remarks>		<short>    Construct a service and take all information from a config file </short>
		public KServiceGroup(string _fullpath, string _relpath) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KServiceGroup$$", "KServiceGroup(const QString&, const QString&)", typeof(void), typeof(string), _fullpath, typeof(string), _relpath);
		}
		/// <remarks>
		///  The stream must already be positionned at the correct offset
		///    </remarks>		<short>   </short>
		public KServiceGroup(QDataStream _str, int offset, bool deep) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KServiceGroup#$$", "KServiceGroup(QDataStream&, int, bool)", typeof(void), typeof(QDataStream), _str, typeof(int), offset, typeof(bool), deep);
		}
		/// <remarks>
		///  Checks whether the entry is valid, returns always true.
		/// </remarks>		<return> true
		///    </return>
		/// 		<short>    Checks whether the entry is valid, returns always true.</short>
		[SmokeMethod("isValid() const")]
		public override bool IsValid() {
			return (bool) interceptor.Invoke("isValid", "isValid() const", typeof(bool));
		}
		/// <remarks>
		///  Name used for indexing.
		/// </remarks>		<return> the service group's name
		///    </return>
		/// 		<short>    Name used for indexing.</short>
		[SmokeMethod("name() const")]
		public override string Name() {
			return (string) interceptor.Invoke("name", "name() const", typeof(string));
		}
		/// <remarks>
		///  Returns the relative path of the service group.
		/// </remarks>		<return> the service group's relative path
		///    </return>
		/// 		<short>    Returns the relative path of the service group.</short>
		[SmokeMethod("relPath() const")]
		public virtual string RelPath() {
			return (string) interceptor.Invoke("relPath", "relPath() const", typeof(string));
		}
		/// <remarks>
		///  Returns the caption of this group.
		/// </remarks>		<return> the caption of this group
		///    </return>
		/// 		<short>    Returns the caption of this group.</short>
		public string Caption() {
			return (string) interceptor.Invoke("caption", "caption() const", typeof(string));
		}
		/// <remarks>
		///  Returns the name of the icon associated with the group.
		/// </remarks>		<return> the name of the icon associated with the group,
		///          or string() if not set
		///    </return>
		/// 		<short>    Returns the name of the icon associated with the group.</short>
		public string Icon() {
			return (string) interceptor.Invoke("icon", "icon() const", typeof(string));
		}
		/// <remarks>
		///  Returns the comment about this service group.
		/// </remarks>		<return> the descriptive comment for the group, if there is one,
		///          or string() if not set
		///    </return>
		/// 		<short>    Returns the comment about this service group.</short>
		public string Comment() {
			return (string) interceptor.Invoke("comment", "comment() const", typeof(string));
		}
		/// <remarks>
		///  Returns the total number of displayable services in this group and
		///  any of its subgroups.
		/// </remarks>		<return> the number of child services
		///    </return>
		/// 		<short>    Returns the total number of displayable services in this group and  any of its subgroups.</short>
		public int ChildCount() {
			return (int) interceptor.Invoke("childCount", "childCount() const", typeof(int));
		}
		/// <remarks>
		///  Returns true if the NoDisplay flag was set, i.e. if this
		///  group should be hidden from menus, while still being in ksycoca.
		/// </remarks>		<return> true to hide this service group, false to display it
		///    </return>
		/// 		<short>    Returns true if the NoDisplay flag was set, i.</short>
		public bool NoDisplay() {
			return (bool) interceptor.Invoke("noDisplay", "noDisplay() const", typeof(bool));
		}
		/// <remarks>
		///  Return true if we want to display empty menu entry
		/// </remarks>		<return> true to show this service group as menu entry is empty, false to hide it
		///    </return>
		/// 		<short>    Return true if we want to display empty menu entry </short>
		public bool ShowEmptyMenu() {
			return (bool) interceptor.Invoke("showEmptyMenu", "showEmptyMenu() const", typeof(bool));
		}
		public void SetShowEmptyMenu(bool b) {
			interceptor.Invoke("setShowEmptyMenu$", "setShowEmptyMenu(bool)", typeof(void), typeof(bool), b);
		}
		/// <remarks>
		/// </remarks>		<return> true to show an inline header into menu
		///    </return>
		/// 		<short>   </short>
		public bool ShowInlineHeader() {
			return (bool) interceptor.Invoke("showInlineHeader", "showInlineHeader() const", typeof(bool));
		}
		public void SetShowInlineHeader(bool _b) {
			interceptor.Invoke("setShowInlineHeader$", "setShowInlineHeader(bool)", typeof(void), typeof(bool), _b);
		}
		/// <remarks>
		/// </remarks>		<return> true to show an inline alias item into menu
		///    </return>
		/// 		<short>   </short>
		public bool InlineAlias() {
			return (bool) interceptor.Invoke("inlineAlias", "inlineAlias() const", typeof(bool));
		}
		public void SetInlineAlias(bool _b) {
			interceptor.Invoke("setInlineAlias$", "setInlineAlias(bool)", typeof(void), typeof(bool), _b);
		}
		/// <remarks>
		/// </remarks>		<return> true if we allow to inline menu.
		///    </return>
		/// 		<short>   </short>
		public bool AllowInline() {
			return (bool) interceptor.Invoke("allowInline", "allowInline() const", typeof(bool));
		}
		public void SetAllowInline(bool _b) {
			interceptor.Invoke("setAllowInline$", "setAllowInline(bool)", typeof(void), typeof(bool), _b);
		}
		/// <remarks>
		/// </remarks>		<return> inline limite value
		///    </return>
		/// 		<short>   </short>
		public int InlineValue() {
			return (int) interceptor.Invoke("inlineValue", "inlineValue() const", typeof(int));
		}
		public void SetInlineValue(int _val) {
			interceptor.Invoke("setInlineValue$", "setInlineValue(int)", typeof(void), typeof(int), _val);
		}
		/// <remarks>
		///  Returns a list of untranslated generic names that should be
		///  be suppressed when showing this group.
		///  E.g. The group "Games/Arcade" might want to suppress the generic name
		///  "Arcade Game" since it's redundant in this particular context.
		///    </remarks>		<short>    Returns a list of untranslated generic names that should be  be suppressed when showing this group.</short>
		public List<string> SuppressGenericNames() {
			return (List<string>) interceptor.Invoke("suppressGenericNames", "suppressGenericNames() const", typeof(List<string>));
		}
		/// <remarks>
		///  Sets information related to the layout of services in this group.
		///    </remarks>		<short>   </short>
		public void SetLayoutInfo(List<string> layout) {
			interceptor.Invoke("setLayoutInfo?", "setLayoutInfo(const QStringList&)", typeof(void), typeof(List<string>), layout);
		}
		/// <remarks>
		///  Returns information related to the layout of services in this group.
		///    </remarks>		<short>   </short>
		public List<string> LayoutInfo() {
			return (List<string>) interceptor.Invoke("layoutInfo", "layoutInfo() const", typeof(List<string>));
		}
		/// <remarks>
		///  Load the service from a stream.
		///    </remarks>		<short>   </short>
		[SmokeMethod("load(QDataStream&)")]
		public override void Load(QDataStream arg1) {
			interceptor.Invoke("load#", "load(QDataStream&)", typeof(void), typeof(QDataStream), arg1);
		}
		/// <remarks>
		///  Save the service to a stream.
		///    </remarks>		<short>   </short>
		[SmokeMethod("save(QDataStream&)")]
		public override void Save(QDataStream arg1) {
			interceptor.Invoke("save#", "save(QDataStream&)", typeof(void), typeof(QDataStream), arg1);
		}
		/// <remarks>
		///  List of all Services and ServiceGroups within this
		///  ServiceGroup.
		/// <param> name="sorted" true to sort items
		/// </param><param> name="excludeNoDisplay" true to exclude items marked "NoDisplay"
		/// </param><param> name="allowSeparators" true to allow separator items to be included
		/// </param><param> name="sortByGenericName" true to sort GenericName+Name instead of Name+GenericName
		/// </param></remarks>		<return> the list of entries
		///    </return>
		/// 		<short>    List of all Services and ServiceGroups within this  ServiceGroup.</short>
		/// <remarks>
		///  List of all Services and ServiceGroups within this
		///  ServiceGroup.
		/// <param> name="sorted" true to sort items
		/// </param></remarks>		<return> the list of entried
		///    </return>
		/// 		<short>    List of all Services and ServiceGroups within this  ServiceGroup.</short>
		/// <remarks>
		///  Returns a non-empty string if the group is a special base group.
		///  By default, "Settings/" is the kcontrol base group ("settings")
		///  and "System/Screensavers/" is the screensavers base group ("screensavers").
		///  This allows moving the groups without breaking those apps.
		///  The base group is defined by the X-KDE-BaseGroup key
		///  in the .directory file.
		/// </remarks>		<return> the base group name, or null if no base group
		///    </return>
		/// 		<short>    Returns a non-empty string if the group is a special base group.</short>
		public string BaseGroupName() {
			return (string) interceptor.Invoke("baseGroupName", "baseGroupName() const", typeof(string));
		}
		/// <remarks>
		///  Returns a path to the .directory file describing this service group.
		///  The path is either absolute or relative to the "apps" resource.
		///    </remarks>		<short>    Returns a path to the .</short>
		public string DirectoryEntryPath() {
			return (string) interceptor.Invoke("directoryEntryPath", "directoryEntryPath() const", typeof(string));
		}
		/// <remarks>
		///  This function parse attributes into menu
		///    </remarks>		<short>    This function parse attributes into menu    </short>
		public void ParseAttribute(string item, bool showEmptyMenu, bool showInline, bool showInlineHeader, bool showInlineAlias, ref int inlineValue) {
			StackItem[] stack = new StackItem[7];
#if DEBUG
			stack[1].s_class = (IntPtr) DebugGCHandle.Alloc(item);
#else
			stack[1].s_class = (IntPtr) GCHandle.Alloc(item);
#endif
			stack[2].s_bool = showEmptyMenu;
			stack[3].s_bool = showInline;
			stack[4].s_bool = showInlineHeader;
			stack[5].s_bool = showInlineAlias;
			stack[6].s_int = inlineValue;
			interceptor.Invoke("parseAttribute$$$$$$", "parseAttribute(const QString&, bool&, bool&, bool&, bool&, int&)", stack);
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[1].s_class);
#else
			((GCHandle) stack[1].s_class).Free();
#endif
			inlineValue = stack[6].s_int;
			return;
		}
		/// <remarks>
		///  Add a service to this group
		///    </remarks>		<short>   </short>
		~KServiceGroup() {
			interceptor.Invoke("~KServiceGroup", "~KServiceGroup()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~KServiceGroup", "~KServiceGroup()", typeof(void));
		}
		/// <remarks>
		///  Returns the group for the given baseGroupName.
		///  Can return null if the directory (or the .directory file) was deleted.
		/// </remarks>		<return> the base group with the given name, or 0 if not available.
		///    </return>
		/// 		<short>    Returns the group for the given baseGroupName.</short>
		/// <remarks>
		///  Returns the root service group.
		/// </remarks>		<return> the root service group
		///    </return>
		/// 		<short>    Returns the root service group.</short>
		/// <remarks>
		///  Returns the group with the given relative path.
		/// <param> name="relPath" the path of the service group
		/// </param></remarks>		<return> the group with the given relative path name.
		///    </return>
		/// 		<short>    Returns the group with the given relative path.</short>
		/// <remarks>
		///  Returns the group of services that have X-KDE-ParentApp equal
		///  to <code>parent</code> (siblings).
		/// <param> name="parent" the name of the service's parent
		/// </param></remarks>		<return> the services group
		///    </return>
		/// 		<short>    Returns the group of services that have X-KDE-ParentApp equal  to <code>parent</code> (siblings).</short>
	}
}
