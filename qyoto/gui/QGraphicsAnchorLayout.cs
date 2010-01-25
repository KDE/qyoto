//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QGraphicsAnchorLayout")]
    public class QGraphicsAnchorLayout : QGraphicsLayout, IDisposable {
        protected QGraphicsAnchorLayout(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QGraphicsAnchorLayout), this);
        }
        public QGraphicsAnchorLayout(IQGraphicsLayoutItem parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QGraphicsAnchorLayout#", "QGraphicsAnchorLayout(QGraphicsLayoutItem*)", typeof(void), typeof(IQGraphicsLayoutItem), parent);
        }
        public QGraphicsAnchorLayout() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QGraphicsAnchorLayout", "QGraphicsAnchorLayout()", typeof(void));
        }
        public QGraphicsAnchor AddAnchor(IQGraphicsLayoutItem firstItem, Qt.AnchorPoint firstEdge, IQGraphicsLayoutItem secondItem, Qt.AnchorPoint secondEdge) {
            return (QGraphicsAnchor) interceptor.Invoke("addAnchor#$#$", "addAnchor(QGraphicsLayoutItem*, Qt::AnchorPoint, QGraphicsLayoutItem*, Qt::AnchorPoint)", typeof(QGraphicsAnchor), typeof(IQGraphicsLayoutItem), firstItem, typeof(Qt.AnchorPoint), firstEdge, typeof(IQGraphicsLayoutItem), secondItem, typeof(Qt.AnchorPoint), secondEdge);
        }
        public QGraphicsAnchor Anchor(IQGraphicsLayoutItem firstItem, Qt.AnchorPoint firstEdge, IQGraphicsLayoutItem secondItem, Qt.AnchorPoint secondEdge) {
            return (QGraphicsAnchor) interceptor.Invoke("anchor#$#$", "anchor(QGraphicsLayoutItem*, Qt::AnchorPoint, QGraphicsLayoutItem*, Qt::AnchorPoint)", typeof(QGraphicsAnchor), typeof(IQGraphicsLayoutItem), firstItem, typeof(Qt.AnchorPoint), firstEdge, typeof(IQGraphicsLayoutItem), secondItem, typeof(Qt.AnchorPoint), secondEdge);
        }
        public void AddCornerAnchors(IQGraphicsLayoutItem firstItem, Qt.Corner firstCorner, IQGraphicsLayoutItem secondItem, Qt.Corner secondCorner) {
            interceptor.Invoke("addCornerAnchors#$#$", "addCornerAnchors(QGraphicsLayoutItem*, Qt::Corner, QGraphicsLayoutItem*, Qt::Corner)", typeof(void), typeof(IQGraphicsLayoutItem), firstItem, typeof(Qt.Corner), firstCorner, typeof(IQGraphicsLayoutItem), secondItem, typeof(Qt.Corner), secondCorner);
        }
        public void AddAnchors(IQGraphicsLayoutItem firstItem, IQGraphicsLayoutItem secondItem, uint orientations) {
            interceptor.Invoke("addAnchors##$", "addAnchors(QGraphicsLayoutItem*, QGraphicsLayoutItem*, Qt::Orientations)", typeof(void), typeof(IQGraphicsLayoutItem), firstItem, typeof(IQGraphicsLayoutItem), secondItem, typeof(uint), orientations);
        }
        public void AddAnchors(IQGraphicsLayoutItem firstItem, IQGraphicsLayoutItem secondItem) {
            interceptor.Invoke("addAnchors##", "addAnchors(QGraphicsLayoutItem*, QGraphicsLayoutItem*)", typeof(void), typeof(IQGraphicsLayoutItem), firstItem, typeof(IQGraphicsLayoutItem), secondItem);
        }
        public void SetHorizontalSpacing(double spacing) {
            interceptor.Invoke("setHorizontalSpacing$", "setHorizontalSpacing(qreal)", typeof(void), typeof(double), spacing);
        }
        public void SetVerticalSpacing(double spacing) {
            interceptor.Invoke("setVerticalSpacing$", "setVerticalSpacing(qreal)", typeof(void), typeof(double), spacing);
        }
        public void SetSpacing(double spacing) {
            interceptor.Invoke("setSpacing$", "setSpacing(qreal)", typeof(void), typeof(double), spacing);
        }
        public double HorizontalSpacing() {
            return (double) interceptor.Invoke("horizontalSpacing", "horizontalSpacing() const", typeof(double));
        }
        public double VerticalSpacing() {
            return (double) interceptor.Invoke("verticalSpacing", "verticalSpacing() const", typeof(double));
        }
        [SmokeMethod("removeAt(int)")]
        public override void RemoveAt(int index) {
            interceptor.Invoke("removeAt$", "removeAt(int)", typeof(void), typeof(int), index);
        }
        [SmokeMethod("setGeometry(const QRectF&)")]
        public override void SetGeometry(QRectF rect) {
            interceptor.Invoke("setGeometry#", "setGeometry(const QRectF&)", typeof(void), typeof(QRectF), rect);
        }
        [SmokeMethod("count() const")]
        public override int Count() {
            return (int) interceptor.Invoke("count", "count() const", typeof(int));
        }
        [SmokeMethod("itemAt(int) const")]
        public override IQGraphicsLayoutItem ItemAt(int index) {
            return (IQGraphicsLayoutItem) interceptor.Invoke("itemAt$", "itemAt(int) const", typeof(IQGraphicsLayoutItem), typeof(int), index);
        }
        [SmokeMethod("invalidate()")]
        public override void Invalidate() {
            interceptor.Invoke("invalidate", "invalidate()", typeof(void));
        }
        [SmokeMethod("sizeHint(Qt::SizeHint, const QSizeF&) const")]
        public override QSizeF SizeHint(Qt.SizeHint which, QSizeF constraint) {
            return (QSizeF) interceptor.Invoke("sizeHint$#", "sizeHint(Qt::SizeHint, const QSizeF&) const", typeof(QSizeF), typeof(Qt.SizeHint), which, typeof(QSizeF), constraint);
        }
        [SmokeMethod("sizeHint(Qt::SizeHint) const")]
        protected virtual QSizeF SizeHint(Qt.SizeHint which) {
            return (QSizeF) interceptor.Invoke("sizeHint$", "sizeHint(Qt::SizeHint) const", typeof(QSizeF), typeof(Qt.SizeHint), which);
        }
        ~QGraphicsAnchorLayout() {
            interceptor.Invoke("~QGraphicsAnchorLayout", "~QGraphicsAnchorLayout()", typeof(void));
        }
        public void Dispose() {
            interceptor.Invoke("~QGraphicsAnchorLayout", "~QGraphicsAnchorLayout()", typeof(void));
        }
    }
}
