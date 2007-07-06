//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  A dialog for requesting a password and optionaly a login from the end user.
	///  \section usage Usage Exemple
	///  Requesting a simple password, assynchronous
	///  <pre>
	///   KPasswordDialog dlg = new KPasswordDialog( parent );
	///   dlg.SetPrompt( i18n( "Enter a password" );
	///   connect( dlg, SIGNAL("gotPassword( string , bool )")  , this, SLOT("setPassword( string)") );
	///   connect( dlg, SIGNAL("rejected()")  , this, SLOT("slotCancel()") );
	///   dlg.Show();
	///  </pre>
	///  Requesting a login and a password, synchronous
	///  <pre>
	///   KPasswordDialog dlg( parent , KPasswordDialog.ShowUsername );
	///   dlg.setPrompt( i18n( "Enter a login and a password" );
	///   if( !dlg.exec() )
	///       return; //the user canceled
	///   use( dlg.username() , dlg.password() );
	///  </pre>
	///  See <see cref="IKPasswordDialogSignals"></see> for signals emitted by KPasswordDialog
	/// </remarks>		<short> dialog for requesting login and password from the end user.</short>

	[SmokeClass("KPasswordDialog")]
	public class KPasswordDialog : KDialog, IDisposable {
 		protected KPasswordDialog(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KPasswordDialog), this);
		}
		public enum KPasswordDialogFlag {
			NoFlags = 0x00,
			ShowKeepPassword = 0x01,
			ShowUsernameLine = 0x02,
			UsernameReadOnly = 0x04,
		}
		public enum ErrorType {
			UnknownError = 0,
			/***Aproblemwiththeusernameasentered**/UsernameError = 1,
			PasswordError = 2,
			FatalError = 3,
		}
		// KPasswordDialog* KPasswordDialog(QWidget* arg1,const KPasswordDialogFlags& arg2,const KDialog::ButtonCodes arg3); >>>> NOT CONVERTED
		// KPasswordDialog* KPasswordDialog(QWidget* arg1,const KPasswordDialogFlags& arg2); >>>> NOT CONVERTED
		/// <remarks>
		///  create a password dialog 
		/// <param> name="parent" the parent widget (default:NULL).
		/// </param><param> name="flags" a set of KPasswordDialogFlag flags
		/// </param><param> name="otherButtons" buttons to show in the dialog besides Ok and Cancel.
		///                      Useful for adding application-specific buttons like
		///                      "ignore" or "skip".
		///      </param></remarks>		<short>    create a password dialog  </short>
		public KPasswordDialog(QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KPasswordDialog#", "KPasswordDialog(QWidget*)", typeof(void), typeof(QWidget), parent);
		}
		public KPasswordDialog() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KPasswordDialog", "KPasswordDialog()", typeof(void));
		}
		/// <remarks>
		///  Sets the prompt to show to the user.
		/// <param> name="prompt" instructional text to be shown.
		///      </param></remarks>		<short>    Sets the prompt to show to the user.</short>
		public void SetPrompt(string prompt) {
			interceptor.Invoke("setPrompt$", "setPrompt(const QString&)", typeof(void), typeof(string), prompt);
		}
		/// <remarks>
		///  Returns the prompt
		///      </remarks>		<short>    Returns the prompt      </short>
		public string Prompt() {
			return (string) interceptor.Invoke("prompt", "prompt() const", typeof(string));
		}
		/// <remarks>
		///  set an image that appears next to the prompt.
		///      </remarks>		<short>    set an image that appears next to the prompt.</short>
		public void SetPixmap(QPixmap arg1) {
			interceptor.Invoke("setPixmap#", "setPixmap(const QPixmap&)", typeof(void), typeof(QPixmap), arg1);
		}
		/// <remarks>
		///      </remarks>		<short>   </short>
		public QPixmap Pixmap() {
			return (QPixmap) interceptor.Invoke("pixmap", "pixmap() const", typeof(QPixmap));
		}
		/// <remarks>
		///  Adds a comment line to the dialog.
		///  This function allows you to add one additional comment
		///  line to this widget.  Calling this function after a
		///  comment has already been added will not have any effect.
		/// <param> name="label" label for comment (ex:"Command:")
		/// </param><param> name="comment" the actual comment text.
		///      </param></remarks>		<short>    Adds a comment line to the dialog.</short>
		public void AddCommentLine(string label, string comment) {
			interceptor.Invoke("addCommentLine$$", "addCommentLine(const QString&, const QString&)", typeof(void), typeof(string), label, typeof(string), comment);
		}
		/// <remarks>
		///  Shows an error message in the dialog box. Prevents having to show a dialog-on-a-dialog.
		/// <param> name="message" the error message to show
		///      </param></remarks>		<short>    Shows an error message in the dialog box.</short>
		public void ShowErrorMessage(string message, KPasswordDialog.ErrorType type) {
			interceptor.Invoke("showErrorMessage$$", "showErrorMessage(const QString&, const KPasswordDialog::ErrorType)", typeof(void), typeof(string), message, typeof(KPasswordDialog.ErrorType), type);
		}
		public void ShowErrorMessage(string message) {
			interceptor.Invoke("showErrorMessage$", "showErrorMessage(const QString&)", typeof(void), typeof(string), message);
		}
		/// <remarks>
		///  Returns the password entered by the user.
		/// </remarks>		<return> the password
		///      </return>
		/// 		<short>    Returns the password entered by the user.</short>
		public string Password() {
			return (string) interceptor.Invoke("password", "password() const", typeof(string));
		}
		/// <remarks>
		///  set the default username.
		///      </remarks>		<short>    set the default username.</short>
		public void SetUsername(string arg1) {
			interceptor.Invoke("setUsername$", "setUsername(const QString&)", typeof(void), typeof(string), arg1);
		}
		/// <remarks>
		///  Returns the username entered by the user.
		/// </remarks>		<return> the user name
		///      </return>
		/// 		<short>    Returns the username entered by the user.</short>
		public string Username() {
			return (string) interceptor.Invoke("username", "username() const", typeof(string));
		}
		/// <remarks>
		///  Determines whether supplied authorization should
		///  persist even after the application has been closed.
		///  this is set with the check password checkbox is the ShowKeepCheckBox flag
		///  is set in the constructor, if it is not set, this function return false
		/// </remarks>		<return> true to keep the password
		///      </return>
		/// 		<short>    Determines whether supplied authorization should  persist even after the application has been closed.</short>
		public bool KeepPassword() {
			return (bool) interceptor.Invoke("keepPassword", "keepPassword() const", typeof(bool));
		}
		/// <remarks>
		///  Check or uncheck the "keep password" checkbox.
		///  This can be used to check it before showing the dialog, to tell
		///  the user that the password is stored already (e.g. in the wallet).
		///  enableKeep must have been set to true in the constructor.
		///  has only effect if ShowKeepCheckBox is set in the constructor
		///      </remarks>		<short>    Check or uncheck the "keep password" checkbox.</short>
		public void SetKeepPassword(bool b) {
			interceptor.Invoke("setKeepPassword$", "setKeepPassword(bool)", typeof(void), typeof(bool), b);
		}
		/// <remarks>
		///  Sets the username field read-only and sets the
		///  focus to the password field.
		///  this can also be set by passing UsernameReadOnly as flag in the constructor
		/// <param> name="readOnly" true to set the user field to read-only
		///      </param></remarks>		<short>    Sets the username field read-only and sets the  focus to the password field.</short>
		public void SetUsernameReadOnly(bool readOnly) {
			interceptor.Invoke("setUsernameReadOnly$", "setUsernameReadOnly(bool)", typeof(void), typeof(bool), readOnly);
		}
		/// <remarks>
		///  Presets the password.
		/// <param> name="password" the password to set
		///      </param></remarks>		<short>    Presets the password.</short>
		public void SetPassword(string password) {
			interceptor.Invoke("setPassword$", "setPassword(const QString&)", typeof(void), typeof(string), password);
		}
		/// <remarks>
		///  Presets a number of login+password pairs that the user can choose from.
		///  The passwords can be empty if you simply want to offer usernames to choose from.
		///  This require the flag ShowUnernameLine to be set in the constructoe, and not the flag UsernameReadOnly
		/// <param> name="knownLogins" map of known logins: the keys are usernames, the values are passwords.
		///      </param></remarks>		<short>    Presets a number of login+password pairs that the user can choose from.</short>
		public void SetKnownLogins(Dictionary<string, string> knownLogins) {
			interceptor.Invoke("setKnownLogins?", "setKnownLogins(const QMap<QString, QString>&)", typeof(void), typeof(Dictionary<string, string>), knownLogins);
		}
		/// <remarks>
		///      </remarks>		<short>   </short>
		[SmokeMethod("accept()")]
		public override void Accept() {
			interceptor.Invoke("accept", "accept()", typeof(void));
		}
		/// <remarks>
		///  Virtual function that can be overridden to provide password
		///  checking in derived classes. It should return <code>true</code> if the
		///  password is valid, <code>false</code> otherwise.
		///      </remarks>		<short>    Virtual function that can be overridden to provide password  checking in derived classes.</short>
		[SmokeMethod("checkPassword()")]
		protected virtual bool CheckPassword() {
			return (bool) interceptor.Invoke("checkPassword", "checkPassword()", typeof(bool));
		}
		~KPasswordDialog() {
			interceptor.Invoke("~KPasswordDialog", "~KPasswordDialog()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KPasswordDialog", "~KPasswordDialog()", typeof(void));
		}
		protected new IKPasswordDialogSignals Emit {
			get { return (IKPasswordDialogSignals) Q_EMIT; }
		}
	}

	public interface IKPasswordDialogSignals : IKDialogSignals {
		/// <remarks>
		///  emitted when the dialog has been accepted
		/// <param> name="password" the entered password
		/// </param><param> name="keep" true if the "remember password" checkbox was checked, false otherwhise.  false if ShowKeepPassword was not set in the constructor
		///      </param></remarks>		<short>    emitted when the dialog has been accepted </short>
		[Q_SIGNAL("void gotPassword(const QString&, bool)")]
		void GotPassword(string password, bool keep);
		/// <remarks>
		///  emitted when the dialog has been accepted, and ShowUsernameLine was set on the constructor
		/// <param> name="username" the entered username
		/// </param><param> name="password" the entered password
		/// </param><param> name="keep" true if the "remember password" checkbox was checked, false otherwhise.  false if ShowKeepPassword was not set in the constructor
		///      </param></remarks>		<short>    emitted when the dialog has been accepted, and ShowUsernameLine was set on the constructor </short>
		[Q_SIGNAL("void gotUsernameAndPassword(const QString&, const QString&, bool)")]
		void GotUsernameAndPassword(string username, string password, bool keep);
	}
}
