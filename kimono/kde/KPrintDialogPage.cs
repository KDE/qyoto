//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Text;
	using System.Collections.Generic;

	/// <remarks>
	///  This class is intended to be used as base class for customized print dialog page. One of
	///  the feature of the KDE print framework is to allow to customize the print dialog to
	///  add some application specific print options. This is done by subclassing KPrintDialogPage
	///  and reimplementing the 3 functions getOptions, setOptions and
	///  isValid(). The print options will be stored in the KPrinter object, and will be
	///  accessible via KPrinter.Option(). The option name should follow the form
	///  "kde-appname-optionname" for internal reasons.
	///  <pre>
	///  #include <kdeprint/kprintdialogpage.h>
	///  class MyDialogPage : public KPrintDialogPage
	///  {
	///  public    MyDialogPage( QWidget parent = 0, string name = 0 );
	///    //reimplement functions
	///    void getOptions( QMap<string,string>& opts, bool incldef = false );
	///    void setOptions( const QMap<string,string>& opts );
	///    bool isValid( string msg );
	///  private:
	///    QComboBox m_fontcombo;
	///  }
	///  MyDialogPage.MyDialogPage( QWidget parent, string name )
	///  {
	///    setTitle( i18n( "My Page" ) );
	///  }
	///  void MyDialogPage.GetOptions( QMap<string,string>& opts, bool incldef )
	///  {
	///    if ( incldef || m_fontcombo.CurrentText() != mydefaultvalue )
	///      opts[ "kde-myapp-fontname" ] = m_fontcombo.CurrentText();
	///  }
	///  void MyDialogPage.SetOptions( const QMap<string,string>& opts )
	///  {
	///    string fntname = opts[ "kde-myapp-fontname" ];
	///    m_fontcombo.SetEditText( fntname );
	///  }
	///  bool MyDialogPage.IsValid( string msg)
	///  {
	///    if ( m_fontcombo.CurrentText().isEmpty() )
	///    {
	///      msg = i18n( "Font name cannot be empty." );
	///      return false;
	///    }
	///    return true;
	///  }
	///  </pre>
	/// </remarks>		<short> Base class for customized print dialog pages. </short>
	/// 		<see> KPrinter</see>

	[SmokeClass("KPrintDialogPage")]
	public class KPrintDialogPage : QWidget, IDisposable {
 		protected KPrintDialogPage(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KPrintDialogPage), this);
		}
		// KPrintDialogPage* KPrintDialogPage(KMPrinter* arg1,DrMain* arg2,QWidget* arg3); >>>> NOT CONVERTED
		// KPrintDialogPage* KPrintDialogPage(KMPrinter* arg1,DrMain* arg2); >>>> NOT CONVERTED
		// KPrintDialogPage* KPrintDialogPage(KMPrinter* arg1); >>>> NOT CONVERTED
		// DrMain* driver(); >>>> NOT CONVERTED
		// KMPrinter* printer(); >>>> NOT CONVERTED
		/// <remarks>
		///  Standard constructor.
		///      </remarks>		<short>    Standard constructor.</short>
		public KPrintDialogPage(QWidget parent) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KPrintDialogPage#", "KPrintDialogPage(QWidget*)", typeof(void), typeof(QWidget), parent);
		}
		public KPrintDialogPage() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KPrintDialogPage", "KPrintDialogPage()", typeof(void));
		}
		/// <remarks>
		///  Modified constructor. For internal use only.
		///      </remarks>		<short>    Modified constructor.</short>
		/// <remarks>
		///  This function is called to fill the structure <code>opts</code> with the selected options from this dialog
		///  page. If <code>incldef</code> is true, include also options with default values, otherwise discard them.
		///  Reimplement this function in subclasses.
		/// <param> name="opts" the option set to fill
		/// </param><param> name="incldef" if true, include also options with default values
		/// </param></remarks>		<short>    This function is called to fill the structure <code>opts</code> with the selected options from this dialog  page.</short>
		/// 		<see> setOptions</see>
		[SmokeMethod("getOptions(QMap<QString, QString>&, bool)")]
		public virtual void GetOptions(Dictionary<string, string> opts, bool incldef) {
			interceptor.Invoke("getOptions?$", "getOptions(QMap<QString, QString>&, bool)", typeof(void), typeof(Dictionary<string, string>), opts, typeof(bool), incldef);
		}
		[SmokeMethod("getOptions(QMap<QString, QString>&)")]
		public virtual void GetOptions(Dictionary<string, string> opts) {
			interceptor.Invoke("getOptions?", "getOptions(QMap<QString, QString>&)", typeof(void), typeof(Dictionary<string, string>), opts);
		}
		/// <remarks>
		///  This function is called to update the current page with the options contained in <code>opts.</code>
		///  Reimplement it in subclasses.
		/// <param> name="opts" the structure containing the options to update the page
		///      </param></remarks>		<short>    This function is called to update the current page with the options contained in <code>opts.</code></short>
		[SmokeMethod("setOptions(const QMap<QString, QString>&)")]
		public virtual void SetOptions(Dictionary<string, string> opts) {
			interceptor.Invoke("setOptions?", "setOptions(const QMap<QString, QString>&)", typeof(void), typeof(Dictionary<string, string>), opts);
		}
		/// <remarks>
		///  Returns true if options selected in the page are valid (no conflict), false otherwise.
		///  When returning false, <code>msg</code> should contain an error message explaining what is wrong
		///  in the selected options.
		/// <param> name="msg" should contain an error message when returning false
		/// </param></remarks>		<return> valid status
		///      </return>
		/// 		<short>    Returns true if options selected in the page are valid (no conflict), false otherwise.</short>
		[SmokeMethod("isValid(QString&)")]
		public virtual bool IsValid(StringBuilder msg) {
			return (bool) interceptor.Invoke("isValid$", "isValid(QString&)", typeof(bool), typeof(StringBuilder), msg);
		}
		/// <remarks>
		///  Get the ID of the page. Not used yet.
		/// </remarks>		<return> the page ID
		/// </return>
		/// 		<short>    Get the ID of the page.</short>
		/// 		<see> setId</see>
		public int Id() {
			return (int) interceptor.Invoke("id", "id() const", typeof(int));
		}
		/// <remarks>
		///  Set the ID of the page. Not used yet.
		/// <param> name="ID" the ID number
		/// </param></remarks>		<short>    Set the ID of the page.</short>
		/// 		<see> id</see>
		public void SetId(int ID) {
			interceptor.Invoke("setId$", "setId(int)", typeof(void), typeof(int), ID);
		}
		/// <remarks>
		///  Get the page title.
		/// </remarks>		<return> the page title
		/// </return>
		/// 		<short>    Get the page title.</short>
		/// 		<see> setTitle</see>
		public string Title() {
			return (string) interceptor.Invoke("title", "title() const", typeof(string));
		}
		/// <remarks>
		///  Set the page title. This title will be used as tab name for this page in the print
		///  dialog.
		/// <param> name="txt" the page title
		/// </param></remarks>		<short>    Set the page title.</short>
		/// 		<see> title</see>
		public void SetTitle(string txt) {
			interceptor.Invoke("setTitle$", "setTitle(const QString&)", typeof(void), typeof(string), txt);
		}
		/// <remarks>
		///  Tell wether or not the page should be disable if a non real printer (special
		///  printer) is selected in the print dialog. Returns false by default. Application
		///  specific pages usually corresponds to printer-independent options, so the
		///  page should be kept enabled whatever the selected printer. The default value
		///  is then correct and your application doesn't to change anything.
		/// </remarks>		<return> true if the page should be disabled for non real printers
		/// </return>
		/// 		<short>    Tell wether or not the page should be disable if a non real printer (special  printer) is selected in the print dialog.</short>
		/// 		<see> setOnlyRealPrinters</see>
		public bool OnlyRealPrinters() {
			return (bool) interceptor.Invoke("onlyRealPrinters", "onlyRealPrinters() const", typeof(bool));
		}
		/// <remarks>
		///  Change the page state when a non real printer is selected in the print dialog.
		///  Usually, the default value (false) is OK in most cases and you don't need to
		///  call this function explicitly.
		/// <param> name="on" if true, then the page will be disabled if a non real printer is selected
		/// </param></remarks>		<short>    Change the page state when a non real printer is selected in the print dialog.</short>
		/// 		<see> onlyRealPrinters</see>
		public void SetOnlyRealPrinters(bool on) {
			interceptor.Invoke("setOnlyRealPrinters$", "setOnlyRealPrinters(bool)", typeof(void), typeof(bool), on);
		}
		public void SetOnlyRealPrinters() {
			interceptor.Invoke("setOnlyRealPrinters", "setOnlyRealPrinters()", typeof(void));
		}
		/// <remarks>
		///  For internal use only.
		///      </remarks>		<short>    For internal use only.</short>
		/// <remarks>
		///  For internal use only
		///      </remarks>		<short>    For internal use only      </short>
		~KPrintDialogPage() {
			interceptor.Invoke("~KPrintDialogPage", "~KPrintDialogPage()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KPrintDialogPage", "~KPrintDialogPage()", typeof(void));
		}
		protected new IKPrintDialogPageSignals Emit {
			get { return (IKPrintDialogPageSignals) Q_EMIT; }
		}
	}

	public interface IKPrintDialogPageSignals : IQWidgetSignals {
	}
}
