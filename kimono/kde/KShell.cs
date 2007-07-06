//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Runtime.InteropServices;
	using System.Collections.Generic;

	/// <remarks>
	///  \namespace KShell
	///  Provides some basic POSIX shell and bash functionality.
	/// </remarks>		<short>    \namespace KShell  Provides some basic POSIX shell and bash functionality.</short>
	/// 		<see> KStringHandler</see>

	[SmokeClass("KShell")]
	public class KShell : Object {
		protected SmokeInvocation interceptor = null;
		private static SmokeInvocation staticInterceptor = null;
		static KShell() {
			staticInterceptor = new SmokeInvocation(typeof(KShell), null);
		}
		/// <remarks>
		///  Flags for splitArgs().
		///      </remarks>		<short>    Flags for splitArgs().</short>
		public enum Options {
			NoOptions = 0,
			TildeExpand = 1,
			AbortOnMeta = 2,
		}
		/// <remarks>
		///  Status codes from splitArgs()
		///      </remarks>		<short>    Status codes from splitArgs()      </short>
		public enum Errors {
			NoError = 0,
			BadQuoting = 1,
			FoundMeta = 2,
		}
		// QString joinArgs(const char** arg1,int arg2); >>>> NOT CONVERTED
		// QString joinArgs(const char** arg1); >>>> NOT CONVERTED
		/// <remarks>
		///  Splits <code>cmd</code> according to POSIX shell word splitting and quoting rules.
		///  Can optionally perform tilde expansion and/or abort if it finds shell
		///  meta characters it cannot process.
		/// <param> name="cmd" the command to split
		/// </param><param> name="flags" operation flags, see Options
		/// </param><param> name="err" if not NULL, a status code will be stored at the pointer
		///   target, see Errors
		/// </param></remarks>		<return> a list of unquoted words or an empty list if an error occurred
		///      </return>
		/// 		<short>    Splits <code>cmd</code> according to POSIX shell word splitting and quoting rules.</short>
		public static List<string> SplitArgs(string cmd, int flags, ref int err) {
			StackItem[] stack = new StackItem[4];
#if DEBUG
			stack[1].s_class = (IntPtr) DebugGCHandle.Alloc(cmd);
#else
			stack[1].s_class = (IntPtr) GCHandle.Alloc(cmd);
#endif
			stack[2].s_int = flags;
			stack[3].s_int = err;
			staticInterceptor.Invoke("splitArgs$$$", "splitArgs(const QString&, int, int*)", stack);
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[1].s_class);
#else
			((GCHandle) stack[1].s_class).Free();
#endif
			err = stack[3].s_int;
			object returnValue = ((GCHandle) stack[0].s_class).Target;
#if DEBUG
			DebugGCHandle.Free((GCHandle) stack[0].s_class);
#else
			((GCHandle) stack[0].s_class).Free();
#endif
			return (List<string>) returnValue;
		}
		public static List<string> SplitArgs(string cmd, int flags) {
			return (List<string>) staticInterceptor.Invoke("splitArgs$$", "splitArgs(const QString&, int)", typeof(List<string>), typeof(string), cmd, typeof(int), flags);
		}
		public static List<string> SplitArgs(string cmd) {
			return (List<string>) staticInterceptor.Invoke("splitArgs$", "splitArgs(const QString&)", typeof(List<string>), typeof(string), cmd);
		}
		/// <remarks>
		///  Quotes and joins <code>args</code> together according to POSIX shell rules.
		/// <param> name="args" a list of strings to quote and join
		/// </param></remarks>		<return> a command suitable for shell execution
		///      </return>
		/// 		<short>    Quotes and joins <code>args</code> together according to POSIX shell rules.</short>
		public static string JoinArgs(List<string> args) {
			return (string) staticInterceptor.Invoke("joinArgs?", "joinArgs(const QStringList&)", typeof(string), typeof(List<string>), args);
		}
		/// <remarks>
		///  Same as above, but $'' is used instead of '' for the quoting.
		///  The output is suitable for splitArgs(), bash, zsh and possibly
		///  other bourne-compatible shells, but not for plain sh. The advantage
		///  is, that control characters (ASCII less than 32) are escaped into
		///  human-readable strings.
		/// <param> name="args" a list of strings to quote and join
		/// </param></remarks>		<return> a command suitable for shell execution
		///      </return>
		/// 		<short>    Same as above, but $'' is used instead of '' for the quoting.</short>
		public static string JoinArgsDQ(List<string> args) {
			return (string) staticInterceptor.Invoke("joinArgsDQ?", "joinArgsDQ(const QStringList&)", typeof(string), typeof(List<string>), args);
		}
		/// <remarks>
		///  Quotes and joins <code>argv</code> together according to POSIX shell rules.
		/// <param> name="argv" an array of c strings to quote and join.
		///   The strings are expected to be in local-8-bit encoding.
		/// </param></remarks>		<return> a command suitable for shell execution
		///      </return>
		/// 		<short>    Quotes and joins <code>argv</code> together according to POSIX shell rules.</short>
		/// <remarks>
		///  Quotes <code>arg</code> according to POSIX shell rules.
		///  This function can be used to quote an argument string such that
		///  the shell processes it properly. This is e.g. necessary for
		///  user-provided file names which may contain spaces or quotes.
		///  It also prevents expansion of wild cards and environment variables.
		/// <param> name="arg" the argument to quote
		/// </param></remarks>		<return> the quoted argument
		///      </return>
		/// 		<short>    Quotes <code>arg</code> according to POSIX shell rules.</short>
		public static string QuoteArg(string arg) {
			return (string) staticInterceptor.Invoke("quoteArg$", "quoteArg(const QString&)", typeof(string), typeof(string), arg);
		}
		/// <remarks>
		///  Performs tilde expansion on <code>path.</code> Interprets "~/path" and
		///  "~user/path".
		/// <param> name="path" the path to tilde-expand
		/// </param></remarks>		<return> the expanded path
		///      </return>
		/// 		<short>    Performs tilde expansion on <code>path.</code></short>
		public static string TildeExpand(string path) {
			return (string) staticInterceptor.Invoke("tildeExpand$", "tildeExpand(const QString&)", typeof(string), typeof(string), path);
		}
		/// <remarks>
		///  Obtain a <code>user</code>'s home directory.
		/// <param> name="user" The name of the user whose home dir should be obtained.
		///   An empty string denotes the current user.
		/// </param></remarks>		<return> The user's home directory.
		///      </return>
		/// 		<short>    Obtain a <code>user</code>'s home directory.</short>
		public static string HomeDir(string user) {
			return (string) staticInterceptor.Invoke("homeDir$", "homeDir(const QString&)", typeof(string), typeof(string), user);
		}
		public static bool MatchFileName(string filename, string pattern) {
			return (bool) staticInterceptor.Invoke("matchFileName$$", "matchFileName(const QString&, const QString&)", typeof(bool), typeof(string), filename, typeof(string), pattern);
		}
	}
}
