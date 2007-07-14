//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  This class contains utility functions for handling strings.
	///  This class is <b>not</b> a substitute for the string class. What
	///  I tried to do with this class is provide an easy way to
	///  cut/slice/splice words inside sentences in whatever order desired.
	///  While the main focus of this class are words (ie characters
	///  separated by spaces/tabs), the two core functions here ( split()
	///  and join() ) will function given any char to use as a separator.
	///  This will make it easy to redefine what a 'word' means in the
	///  future if needed.
	///  I freely stole some of the function names from python. I also think
	///  some of these were influenced by mIRC (yes, believe it if you will, I
	///  used to write a LOT of scripts in mIRC).
	///  The ranges are a fairly powerful way of getting/stripping words from
	///  a string. These ranges function, for the large part, as they would in
	///  python. See the word(string, int) and remword(string, int) functions for more detail.
	///  This class contains no data members of it own. All strings are cut
	///  on the fly and returned as new qstrings/qstringlists.
	/// </remarks>		<author> Ian Zepp <icszepp@islc.net>
	/// </author>
	/// 		<short> Namespace for manipulating words and sentences in strings.</short>
	/// 		<see> KShell</see>

	[SmokeClass("KStringHandler")]
	public class KStringHandler : Object {
		protected SmokeInvocation interceptor = null;
		private static SmokeInvocation staticInterceptor = null;
		static KStringHandler() {
			staticInterceptor = new SmokeInvocation(typeof(KStringHandler), null);
		}
		/// <remarks> Capitalizes each word in the string
		///  "hello there" becomes "Hello There"        (string)
		/// <param> name="text" the text to capitalize
		/// </param></remarks>		<return> the resulting string
		///       </return>
		/// 		<short>   Capitalizes each word in the string  "hello there" becomes "Hello There"        (string) </short>
		public static string Capwords(string text) {
			return (string) staticInterceptor.Invoke("capwords$", "capwords(const QString&)", typeof(string), typeof(string), text);
		}
		/// <remarks> Capitalizes each word in the list
		///  [hello, there] becomes [Hello, There]    (list)
		/// <param> name="list" the list to capitalize
		/// </param></remarks>		<return> the resulting list
		///       </return>
		/// 		<short>   Capitalizes each word in the list  [hello, there] becomes [Hello, There]    (list) </short>
		public static List<string> Capwords(List<string> list) {
			return (List<string>) staticInterceptor.Invoke("capwords?", "capwords(const QStringList&)", typeof(List<string>), typeof(List<string>), list);
		}
		/// <remarks> Substitute characters at the beginning of a string by "...".
		/// <param> name="str" is the string to modify
		/// </param><param> name="maxlen" is the maximum length the modified string will have
		///  If the original string is shorter than "maxlen", it is returned verbatim
		/// </param></remarks>		<return> the modified string
		///      </return>
		/// 		<short>   Substitute characters at the beginning of a string by ".</short>
		public static string Lsqueeze(string str, int maxlen) {
			return (string) staticInterceptor.Invoke("lsqueeze$$", "lsqueeze(const QString&, int)", typeof(string), typeof(string), str, typeof(int), maxlen);
		}
		public static string Lsqueeze(string str) {
			return (string) staticInterceptor.Invoke("lsqueeze$", "lsqueeze(const QString&)", typeof(string), typeof(string), str);
		}
		/// <remarks> Substitute characters at the middle of a string by "...".
		/// <param> name="str" is the string to modify
		/// </param><param> name="maxlen" is the maximum length the modified string will have
		///  If the original string is shorter than "maxlen", it is returned verbatim
		/// </param></remarks>		<return> the modified string
		///      </return>
		/// 		<short>   Substitute characters at the middle of a string by ".</short>
		public static string Csqueeze(string str, int maxlen) {
			return (string) staticInterceptor.Invoke("csqueeze$$", "csqueeze(const QString&, int)", typeof(string), typeof(string), str, typeof(int), maxlen);
		}
		public static string Csqueeze(string str) {
			return (string) staticInterceptor.Invoke("csqueeze$", "csqueeze(const QString&)", typeof(string), typeof(string), str);
		}
		/// <remarks> Substitute characters at the end of a string by "...".
		/// <param> name="str" is the string to modify
		/// </param><param> name="maxlen" is the maximum length the modified string will have
		///  If the original string is shorter than "maxlen", it is returned verbatim
		/// </param></remarks>		<return> the modified string
		///      </return>
		/// 		<short>   Substitute characters at the end of a string by ".</short>
		public static string Rsqueeze(string str, int maxlen) {
			return (string) staticInterceptor.Invoke("rsqueeze$$", "rsqueeze(const QString&, int)", typeof(string), typeof(string), str, typeof(int), maxlen);
		}
		public static string Rsqueeze(string str) {
			return (string) staticInterceptor.Invoke("rsqueeze$", "rsqueeze(const QString&)", typeof(string), typeof(string), str);
		}
		/// <remarks>
		///  Split a string into a List<string> in a similar fashion to the static
		///  List<string> function in Qt, except you can specify a maximum number
		///  of tokens. If max is specified (!= 0) then only that number of tokens
		///  will be extracted. The final token will be the remainder of the string.
		///  Example:
		///  <pre>
		///  perlSplit("__", "some__string__for__you__here", 4)
		///  List<string> contains: "some", "string", "for", "you__here"
		///  </pre>
		/// <param> name="sep" is the string to use to delimit s.
		/// </param><param> name="s" is the input string
		/// </param><param> name="max" is the maximum number of extractions to perform, or 0.
		/// </param></remarks>		<return> A List<string> containing tokens extracted from s.
		///      </return>
		/// 		<short>    Split a string into a List<string> in a similar fashion to the static  List<string> function in Qt, except you can specify a maximum number  of tokens.</short>
		public static List<string> PerlSplit(string sep, string s, int max) {
			return (List<string>) staticInterceptor.Invoke("perlSplit$$$", "perlSplit(const QString&, const QString&, int)", typeof(List<string>), typeof(string), sep, typeof(string), s, typeof(int), max);
		}
		public static List<string> PerlSplit(string sep, string s) {
			return (List<string>) staticInterceptor.Invoke("perlSplit$$", "perlSplit(const QString&, const QString&)", typeof(List<string>), typeof(string), sep, typeof(string), s);
		}
		/// <remarks>
		///  Split a string into a List<string> in a similar fashion to the static
		///  List<string> function in Qt, except you can specify a maximum number
		///  of tokens. If max is specified (!= 0) then only that number of tokens
		///  will be extracted. The final token will be the remainder of the string.
		///  Example:
		///  <pre>
		///  perlSplit(' ', "kparts reaches the parts other parts can't", 3)
		///  List<string> contains: "kparts", "reaches", "the parts other parts can't"
		///  </pre>
		/// <param> name="sep" is the character to use to delimit s.
		/// </param><param> name="s" is the input string
		/// </param><param> name="max" is the maximum number of extractions to perform, or 0.
		/// </param></remarks>		<return> A List<string> containing tokens extracted from s.
		///      </return>
		/// 		<short>    Split a string into a List<string> in a similar fashion to the static  List<string> function in Qt, except you can specify a maximum number  of tokens.</short>
		public static List<string> PerlSplit(char sep, string s, int max) {
			return (List<string>) staticInterceptor.Invoke("perlSplit#$$", "perlSplit(const QChar&, const QString&, int)", typeof(List<string>), typeof(char), sep, typeof(string), s, typeof(int), max);
		}
		public static List<string> PerlSplit(char sep, string s) {
			return (List<string>) staticInterceptor.Invoke("perlSplit#$", "perlSplit(const QChar&, const QString&)", typeof(List<string>), typeof(char), sep, typeof(string), s);
		}
		/// <remarks>
		///  Split a string into a List<string> in a similar fashion to the static
		///  List<string> function in Qt, except you can specify a maximum number
		///  of tokens. If max is specified (!= 0) then only that number of tokens
		///  will be extracted. The final token will be the remainder of the string.
		///  Example:
		///  <pre>
		///  perlSplit(QRegExp("[! ]"), "Split me up ! I'm bored ! OK ?", 3)
		///  List<string> contains: "Split", "me", "up ! I'm bored ! OK ?"
		///  </pre>
		/// <param> name="sep" is the regular expression to use to delimit s.
		/// </param><param> name="s" is the input string
		/// </param><param> name="max" is the maximum number of extractions to perform, or 0.
		/// </param></remarks>		<return> A List<string> containing tokens extracted from s.
		///      </return>
		/// 		<short>    Split a string into a List<string> in a similar fashion to the static  List<string> function in Qt, except you can specify a maximum number  of tokens.</short>
		public static List<string> PerlSplit(QRegExp sep, string s, int max) {
			return (List<string>) staticInterceptor.Invoke("perlSplit#$$", "perlSplit(const QRegExp&, const QString&, int)", typeof(List<string>), typeof(QRegExp), sep, typeof(string), s, typeof(int), max);
		}
		public static List<string> PerlSplit(QRegExp sep, string s) {
			return (List<string>) staticInterceptor.Invoke("perlSplit#$", "perlSplit(const QRegExp&, const QString&)", typeof(List<string>), typeof(QRegExp), sep, typeof(string), s);
		}
		/// <remarks>
		///  This method auto-detects URLs in strings, and adds HTML markup to them
		///  so that richtext or HTML-enabled widgets will display the URL correctly.
		/// <param> name="text" the string which may contain URLs
		/// </param></remarks>		<return> the resulting text
		///      </return>
		/// 		<short>    This method auto-detects URLs in strings, and adds HTML markup to them  so that richtext or HTML-enabled widgets will display the URL correctly.</short>
		public static string TagUrls(string text) {
			return (string) staticInterceptor.Invoke("tagUrls$", "tagUrls(const QString&)", typeof(string), typeof(string), text);
		}
		/// <remarks>
		///       Obscure string by using a simple symmetric encryption. Applying the
		///       function to a string obscured by this function will result in the original
		///       string.
		///       The function can be used to obscure passwords stored to configuration
		///       files. Note that this won't give you any more security than preventing
		///       that the password is directly copied and pasted.
		/// <param> name="str" string to be obscured
		/// </param></remarks>		<return> obscured string
		///     </return>
		/// 		<short>         Obscure string by using a simple symmetric encryption.</short>
		public static string Obscure(string str) {
			return (string) staticInterceptor.Invoke("obscure$", "obscure(const QString&)", typeof(string), typeof(string), str);
		}
		/// <remarks>
		///       Guess whether a string is UTF8 encoded.
		/// <param> name="str" the string to check
		/// </param></remarks>		<return> true if UTF8. If false, the string is probably in Local8Bit.
		///      </return>
		/// 		<short>         Guess whether a string is UTF8 encoded.</short>
		public static bool IsUtf8(string str) {
			return (bool) staticInterceptor.Invoke("isUtf8$", "isUtf8(const char*)", typeof(bool), typeof(string), str);
		}
		/// <remarks>
		///       Construct string from a c string, guessing whether it is UTF8- or
		///       Local8Bit-encoded.
		/// <param> name="str" the input string
		/// </param></remarks>		<return> the (hopefully correctly guessed) string representation of <code>str</code>
		///      </return>
		/// 		<short>         Construct string from a c string, guessing whether it is UTF8- or       Local8Bit-encoded.</short>
		public static string From8Bit(string str) {
			return (string) staticInterceptor.Invoke("from8Bit$", "from8Bit(const char*)", typeof(string), typeof(string), str);
		}
	}
}