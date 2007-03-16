//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QLayout")]
	public abstract class QLayout : QObject, IQLayoutItem {
 		protected QLayout(Type dummy) : base((Type) null) {}
		[SmokeClass("QLayout")]
		interface IQLayoutProxy {
			[SmokeMethod("tr", "(const char*, const char*)", "$$")]
			string Tr(string s, string c);
			[SmokeMethod("tr", "(const char*)", "$")]
			string Tr(string s);
			[SmokeMethod("closestAcceptableSize", "(const QWidget*, const QSize&)", "##")]
			QSize ClosestAcceptableSize(QWidget w, QSize s);
		}
		protected new void CreateProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QLayout), this);
			_interceptor = (QLayout) realProxy.GetTransparentProxy();
		}
		private QLayout ProxyQLayout() {
			return (QLayout) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QLayout() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQLayoutProxy), null);
			_staticInterceptor = (IQLayoutProxy) realProxy.GetTransparentProxy();
		}
		private static IQLayoutProxy StaticQLayout() {
			return (IQLayoutProxy) _staticInterceptor;
		}
		public enum SizeConstraint {
			SetDefaultConstraint = 0,
			SetNoConstraint = 1,
			SetMinimumSize = 2,
			SetFixedSize = 3,
			SetMaximumSize = 4,
			SetMinAndMaxSize = 5,
		}
		[Q_PROPERTY("int", "margin")]
		public int Margin {
			get { return Property("margin").Value<int>(); }
			set { SetProperty("margin", QVariant.FromValue<int>(value)); }
		}
		[Q_PROPERTY("int", "spacing")]
		public int Spacing {
			get { return Property("spacing").Value<int>(); }
			set { SetProperty("spacing", QVariant.FromValue<int>(value)); }
		}
		[Q_PROPERTY("QLayout::SizeConstraint", "sizeConstraint")]
		public QLayout.SizeConstraint sizeConstraint {
			get { return Property("sizeConstraint").Value<QLayout.SizeConstraint>(); }
			set { SetProperty("sizeConstraint", QVariant.FromValue<QLayout.SizeConstraint>(value)); }
		}
		public QLayout(QWidget parent) : this((Type) null) {
			CreateProxy();
			NewQLayout(parent);
		}
		[SmokeMethod("QLayout", "(QWidget*)", "#")]
		private void NewQLayout(QWidget parent) {
			ProxyQLayout().NewQLayout(parent);
		}
		public QLayout() : this((Type) null) {
			CreateProxy();
			NewQLayout();
		}
		[SmokeMethod("QLayout", "()", "")]
		private void NewQLayout() {
			ProxyQLayout().NewQLayout();
		}
		[SmokeMethod("setAlignment", "(QWidget*, Qt::Alignment)", "#$")]
		public bool SetAlignment(QWidget w, int alignment) {
			return ProxyQLayout().SetAlignment(w,alignment);
		}
		[SmokeMethod("setAlignment", "(QLayout*, Qt::Alignment)", "#$")]
		public bool SetAlignment(QLayout l, int alignment) {
			return ProxyQLayout().SetAlignment(l,alignment);
		}
		[SmokeMethod("setAlignment", "(Qt::Alignment)", "$")]
		public void SetAlignment(int alignment) {
			ProxyQLayout().SetAlignment(alignment);
		}
		[SmokeMethod("setMenuBar", "(QWidget*)", "#")]
		public void SetMenuBar(QWidget w) {
			ProxyQLayout().SetMenuBar(w);
		}
		[SmokeMethod("menuBar", "() const", "")]
		public QWidget MenuBar() {
			return ProxyQLayout().MenuBar();
		}
		[SmokeMethod("parentWidget", "() const", "")]
		public QWidget ParentWidget() {
			return ProxyQLayout().ParentWidget();
		}
		[SmokeMethod("invalidate", "()", "")]
		public virtual void Invalidate() {
			ProxyQLayout().Invalidate();
		}
		[SmokeMethod("geometry", "() const", "")]
		public virtual QRect Geometry() {
			return ProxyQLayout().Geometry();
		}
		[SmokeMethod("activate", "()", "")]
		public bool Activate() {
			return ProxyQLayout().Activate();
		}
		[SmokeMethod("update", "()", "")]
		public void Update() {
			ProxyQLayout().Update();
		}
		[SmokeMethod("addWidget", "(QWidget*)", "#")]
		public void AddWidget(QWidget w) {
			ProxyQLayout().AddWidget(w);
		}
		[SmokeMethod("addItem", "(QLayoutItem*)", "#")]
		public abstract void AddItem(IQLayoutItem arg1);
		[SmokeMethod("removeWidget", "(QWidget*)", "#")]
		public void RemoveWidget(QWidget w) {
			ProxyQLayout().RemoveWidget(w);
		}
		[SmokeMethod("removeItem", "(QLayoutItem*)", "#")]
		public void RemoveItem(IQLayoutItem arg1) {
			ProxyQLayout().RemoveItem(arg1);
		}
		[SmokeMethod("expandingDirections", "() const", "")]
		public virtual int ExpandingDirections() {
			return ProxyQLayout().ExpandingDirections();
		}
		[SmokeMethod("minimumSize", "() const", "")]
		public virtual QSize MinimumSize() {
			return ProxyQLayout().MinimumSize();
		}
		[SmokeMethod("maximumSize", "() const", "")]
		public virtual QSize MaximumSize() {
			return ProxyQLayout().MaximumSize();
		}
		[SmokeMethod("setGeometry", "(const QRect&)", "#")]
		public abstract void SetGeometry(QRect arg1);
		[SmokeMethod("itemAt", "(int) const", "$")]
		public abstract IQLayoutItem ItemAt(int index);
		[SmokeMethod("takeAt", "(int)", "$")]
		public abstract IQLayoutItem TakeAt(int index);
		[SmokeMethod("indexOf", "(QWidget*) const", "#")]
		public virtual int IndexOf(QWidget arg1) {
			return ProxyQLayout().IndexOf(arg1);
		}
		[SmokeMethod("count", "() const", "")]
		public abstract int Count();
		[SmokeMethod("isEmpty", "() const", "")]
		public virtual bool IsEmpty() {
			return ProxyQLayout().IsEmpty();
		}
		[SmokeMethod("totalHeightForWidth", "(int) const", "$")]
		public int TotalHeightForWidth(int w) {
			return ProxyQLayout().TotalHeightForWidth(w);
		}
		[SmokeMethod("totalMinimumSize", "() const", "")]
		public QSize TotalMinimumSize() {
			return ProxyQLayout().TotalMinimumSize();
		}
		[SmokeMethod("totalMaximumSize", "() const", "")]
		public QSize TotalMaximumSize() {
			return ProxyQLayout().TotalMaximumSize();
		}
		[SmokeMethod("totalSizeHint", "() const", "")]
		public QSize TotalSizeHint() {
			return ProxyQLayout().TotalSizeHint();
		}
		[SmokeMethod("layout", "()", "")]
		public virtual QLayout Layout() {
			return ProxyQLayout().Layout();
		}
		[SmokeMethod("setEnabled", "(bool)", "$")]
		public void SetEnabled(bool arg1) {
			ProxyQLayout().SetEnabled(arg1);
		}
		[SmokeMethod("isEnabled", "() const", "")]
		public bool IsEnabled() {
			return ProxyQLayout().IsEnabled();
		}
		[SmokeMethod("widgetEvent", "(QEvent*)", "#")]
		protected void WidgetEvent(QEvent arg1) {
			ProxyQLayout().WidgetEvent(arg1);
		}
		[SmokeMethod("childEvent", "(QChildEvent*)", "#")]
		protected override void ChildEvent(QChildEvent e) {
			ProxyQLayout().ChildEvent(e);
		}
		[SmokeMethod("addChildLayout", "(QLayout*)", "#")]
		protected void AddChildLayout(QLayout l) {
			ProxyQLayout().AddChildLayout(l);
		}
		[SmokeMethod("addChildWidget", "(QWidget*)", "#")]
		protected void AddChildWidget(QWidget w) {
			ProxyQLayout().AddChildWidget(w);
		}
		[SmokeMethod("alignmentRect", "(const QRect&) const", "#")]
		protected QRect AlignmentRect(QRect arg1) {
			return ProxyQLayout().AlignmentRect(arg1);
		}
		[SmokeMethod("sizeHint", "() const", "")]
		public abstract QSize SizeHint();
		[SmokeMethod("hasHeightForWidth", "() const", "")]
		public virtual bool HasHeightForWidth() {
			return ProxyQLayout().HasHeightForWidth();
		}
		[SmokeMethod("heightForWidth", "(int) const", "$")]
		public virtual int HeightForWidth(int arg1) {
			return ProxyQLayout().HeightForWidth(arg1);
		}
		[SmokeMethod("minimumHeightForWidth", "(int) const", "$")]
		public virtual int MinimumHeightForWidth(int arg1) {
			return ProxyQLayout().MinimumHeightForWidth(arg1);
		}
		[SmokeMethod("widget", "()", "")]
		public virtual QWidget Widget() {
			return ProxyQLayout().Widget();
		}
		[SmokeMethod("spacerItem", "()", "")]
		public virtual QSpacerItem SpacerItem() {
			return ProxyQLayout().SpacerItem();
		}
		[SmokeMethod("alignment", "() const", "")]
		public int Alignment() {
			return ProxyQLayout().Alignment();
		}
		public static string Tr(string s, string c) {
			return StaticQLayout().Tr(s,c);
		}
		public static string Tr(string s) {
			return StaticQLayout().Tr(s);
		}
		public static QSize ClosestAcceptableSize(QWidget w, QSize s) {
			return StaticQLayout().ClosestAcceptableSize(w,s);
		}
		protected new IQLayoutSignals Emit {
			get { return (IQLayoutSignals) Q_EMIT; }
		}
	}

	public interface IQLayoutSignals : IQObjectSignals {
	}
}
