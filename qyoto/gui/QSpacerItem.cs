//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QSpacerItem")]
	public class QSpacerItem : QLayoutItem, IDisposable {
 		protected QSpacerItem(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QSpacerItem), this);
		}
		public QSpacerItem(int w, int h, QSizePolicy.Policy hData, QSizePolicy.Policy vData) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QSpacerItem$$$$", "QSpacerItem(int, int, QSizePolicy::Policy, QSizePolicy::Policy)", typeof(void), typeof(int), w, typeof(int), h, typeof(QSizePolicy.Policy), hData, typeof(QSizePolicy.Policy), vData);
		}
		public QSpacerItem(int w, int h, QSizePolicy.Policy hData) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QSpacerItem$$$", "QSpacerItem(int, int, QSizePolicy::Policy)", typeof(void), typeof(int), w, typeof(int), h, typeof(QSizePolicy.Policy), hData);
		}
		public QSpacerItem(int w, int h) : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QSpacerItem$$", "QSpacerItem(int, int)", typeof(void), typeof(int), w, typeof(int), h);
		}
		public void ChangeSize(int w, int h, QSizePolicy.Policy hData, QSizePolicy.Policy vData) {
			interceptor.Invoke("changeSize$$$$", "changeSize(int, int, QSizePolicy::Policy, QSizePolicy::Policy)", typeof(void), typeof(int), w, typeof(int), h, typeof(QSizePolicy.Policy), hData, typeof(QSizePolicy.Policy), vData);
		}
		public void ChangeSize(int w, int h, QSizePolicy.Policy hData) {
			interceptor.Invoke("changeSize$$$", "changeSize(int, int, QSizePolicy::Policy)", typeof(void), typeof(int), w, typeof(int), h, typeof(QSizePolicy.Policy), hData);
		}
		public void ChangeSize(int w, int h) {
			interceptor.Invoke("changeSize$$", "changeSize(int, int)", typeof(void), typeof(int), w, typeof(int), h);
		}
		[SmokeMethod("sizeHint() const")]
		public override QSize SizeHint() {
			return (QSize) interceptor.Invoke("sizeHint", "sizeHint() const", typeof(QSize));
		}
		[SmokeMethod("minimumSize() const")]
		public override QSize MinimumSize() {
			return (QSize) interceptor.Invoke("minimumSize", "minimumSize() const", typeof(QSize));
		}
		[SmokeMethod("maximumSize() const")]
		public override QSize MaximumSize() {
			return (QSize) interceptor.Invoke("maximumSize", "maximumSize() const", typeof(QSize));
		}
		[SmokeMethod("expandingDirections() const")]
		public override uint ExpandingDirections() {
			return (uint) interceptor.Invoke("expandingDirections", "expandingDirections() const", typeof(uint));
		}
		[SmokeMethod("isEmpty() const")]
		public override bool IsEmpty() {
			return (bool) interceptor.Invoke("isEmpty", "isEmpty() const", typeof(bool));
		}
		[SmokeMethod("setGeometry(const QRect&)")]
		public override void SetGeometry(QRect arg1) {
			interceptor.Invoke("setGeometry#", "setGeometry(const QRect&)", typeof(void), typeof(QRect), arg1);
		}
		[SmokeMethod("geometry() const")]
		public override QRect Geometry() {
			return (QRect) interceptor.Invoke("geometry", "geometry() const", typeof(QRect));
		}
		[SmokeMethod("spacerItem()")]
		public override QSpacerItem SpacerItem() {
			return (QSpacerItem) interceptor.Invoke("spacerItem", "spacerItem()", typeof(QSpacerItem));
		}
		~QSpacerItem() {
			interceptor.Invoke("~QSpacerItem", "~QSpacerItem()", typeof(void));
		}
		public void Dispose() {
			interceptor.Invoke("~QSpacerItem", "~QSpacerItem()", typeof(void));
		}
	}
}
