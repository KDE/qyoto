//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;

	/// <remarks>
	///  KPageWidgetItem is used by <see cref="KPageWidget"></see> and represents
	///  a page.
	///  <li><b>Example:</b></li>
	///  <pre>
	///   ColorPage page = new ColorPage;
	///   KPageWidgetItem item = new KPageWidgetItem( page, i18n( "Colors" ) );
	///   item.SetHeader( i18n( "Colors of Main Window" ) );
	///   item.SetIcon( KIcon( "colors" ) );
	///   KPageWidget pageWidget = new KPageWidget( this );
	///   pageWidget.AddPage( item );
	///  </pre>
	///  See <see cref="IKPageWidgetItemSignals"></see> for signals emitted by KPageWidgetItem
	/// </remarks>		<author> Tobias Koenig (tokoe@kde.org)
	///  </author>
	/// 		<short>    KPageWidgetItem is used by @ref KPageWidget and represents  a page.</short>

	[SmokeClass("KPageWidgetItem")]
	public class KPageWidgetItem : QObject, IDisposable {
 		protected KPageWidgetItem(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KPageWidgetItem), this);
		}
		[Q_PROPERTY("QString", "name")]
		public string Name {
			get { return (string) interceptor.Invoke("name", "name()", typeof(string)); }
			set { interceptor.Invoke("setName$", "setName(QString)", typeof(void), typeof(string), value); }
		}
		[Q_PROPERTY("QString", "header")]
		public string Header {
			get { return (string) interceptor.Invoke("header", "header()", typeof(string)); }
			set { interceptor.Invoke("setHeader$", "setHeader(QString)", typeof(void), typeof(string), value); }
		}
		[Q_PROPERTY("KIcon", "icon")]
		public KIcon icon {
			get { return (KIcon) interceptor.Invoke("icon", "icon()", typeof(KIcon)); }
			set { interceptor.Invoke("setIcon#", "setIcon(KIcon)", typeof(void), typeof(KIcon), value); }
		}
		[Q_PROPERTY("bool", "checkable")]
		public bool Checkable {
			get { return (bool) interceptor.Invoke("isCheckable", "isCheckable()", typeof(bool)); }
			set { interceptor.Invoke("setCheckable$", "setCheckable(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("bool", "checked")]
		public bool Checked {
			get { return (bool) interceptor.Invoke("isChecked", "isChecked()", typeof(bool)); }
			set { interceptor.Invoke("setChecked$", "setChecked(bool)", typeof(void), typeof(bool), value); }
		}
		[Q_PROPERTY("bool", "enabled")]
		public bool Enabled {
			get { return (bool) interceptor.Invoke("isEnabled", "isEnabled()", typeof(bool)); }
			set { interceptor.Invoke("setEnabled$", "setEnabled(bool)", typeof(void), typeof(bool), value); }
		}
		/// <remarks>
		///  Creates a new page widget item.
		/// <param> name="widget" The widget that is shown as page in the KPageWidget.
		///      </param></remarks>		<short>    Creates a new page widget item.</short>
		public KPageWidgetItem(QWidget widget) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KPageWidgetItem#", "KPageWidgetItem(QWidget*)", typeof(void), typeof(QWidget), widget);
		}
		/// <remarks>
		///  Creates a new page widget item.
		/// <param> name="widget" The widget that is shown as page in the KPageWidget.
		/// </param><param> name="name" The localized string that is show in the navigation view
		///              of the KPageWidget.
		///      </param></remarks>		<short>    Creates a new page widget item.</short>
		public KPageWidgetItem(QWidget widget, string name) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("KPageWidgetItem#$", "KPageWidgetItem(QWidget*, const QString&)", typeof(void), typeof(QWidget), widget, typeof(string), name);
		}
		/// <remarks>
		///  Returns the widget of the page widget item.
		///      </remarks>		<short>    Returns the widget of the page widget item.</short>
		public QWidget Widget() {
			return (QWidget) interceptor.Invoke("widget", "widget() const", typeof(QWidget));
		}
		[Q_SLOT("void setEnabled(bool)")]
		public void SetEnabled(bool arg1) {
			interceptor.Invoke("setEnabled$", "setEnabled(bool)", typeof(void), typeof(bool), arg1);
		}
		/// <remarks>
		///  Sets whether the page widget item is checked.
		///          </remarks>		<short>    Sets whether the page widget item is checked.</short>
		[Q_SLOT("void setChecked(bool)")]
		public void SetChecked(bool arg1) {
			interceptor.Invoke("setChecked$", "setChecked(bool)", typeof(void), typeof(bool), arg1);
		}
		~KPageWidgetItem() {
			interceptor.Invoke("~KPageWidgetItem", "~KPageWidgetItem()", typeof(void));
		}
		public new void Dispose() {
			interceptor.Invoke("~KPageWidgetItem", "~KPageWidgetItem()", typeof(void));
		}
		protected new IKPageWidgetItemSignals Emit {
			get { return (IKPageWidgetItemSignals) Q_EMIT; }
		}
	}

	public interface IKPageWidgetItemSignals : IQObjectSignals {
		/// <remarks>
		///  This signal is emitted whenever the icon or header
		///  is changed.
		///      </remarks>		<short>    This signal is emitted whenever the icon or header  is changed.</short>
		[Q_SIGNAL("void changed()")]
		void Changed();
		/// <remarks>
		///  This signal is emitted whenever the user checks or
		///  unchecks the item of @see setChecked() is called.
		///      </remarks>		<short>    This signal is emitted whenever the user checks or  unchecks the item of @see setChecked() is called.</short>
		[Q_SIGNAL("void toggled(bool)")]
		void Toggled(bool arg1);
	}
}
