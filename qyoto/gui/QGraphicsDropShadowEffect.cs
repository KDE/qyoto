//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    /// <remarks> See <see cref="IQGraphicsDropShadowEffectSignals"></see> for signals emitted by QGraphicsDropShadowEffect
    /// </remarks>
    [SmokeClass("QGraphicsDropShadowEffect")]
    public class QGraphicsDropShadowEffect : QGraphicsEffect, IDisposable {
        protected QGraphicsDropShadowEffect(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QGraphicsDropShadowEffect), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QGraphicsDropShadowEffect() {
            staticInterceptor = new SmokeInvocation(typeof(QGraphicsDropShadowEffect), null);
        }
        [Q_PROPERTY("QPointF", "offset")]
        public QPointF Offset {
            get { return (QPointF) interceptor.Invoke("offset", "offset()", typeof(QPointF)); }
            set { interceptor.Invoke("setOffset#", "setOffset(QPointF)", typeof(void), typeof(QPointF), value); }
        }
        [Q_PROPERTY("qreal", "xOffset")]
        public double XOffset {
            get { return (double) interceptor.Invoke("xOffset", "xOffset()", typeof(double)); }
            set { interceptor.Invoke("setXOffset$", "setXOffset(qreal)", typeof(void), typeof(double), value); }
        }
        [Q_PROPERTY("qreal", "yOffset")]
        public double YOffset {
            get { return (double) interceptor.Invoke("yOffset", "yOffset()", typeof(double)); }
            set { interceptor.Invoke("setYOffset$", "setYOffset(qreal)", typeof(void), typeof(double), value); }
        }
        [Q_PROPERTY("qreal", "blurRadius")]
        public double BlurRadius {
            get { return (double) interceptor.Invoke("blurRadius", "blurRadius()", typeof(double)); }
            set { interceptor.Invoke("setBlurRadius$", "setBlurRadius(qreal)", typeof(void), typeof(double), value); }
        }
        [Q_PROPERTY("QColor", "color")]
        public QColor Color {
            get { return (QColor) interceptor.Invoke("color", "color()", typeof(QColor)); }
            set { interceptor.Invoke("setColor#", "setColor(QColor)", typeof(void), typeof(QColor), value); }
        }
        public QGraphicsDropShadowEffect(QObject parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QGraphicsDropShadowEffect#", "QGraphicsDropShadowEffect(QObject*)", typeof(void), typeof(QObject), parent);
        }
        public QGraphicsDropShadowEffect() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QGraphicsDropShadowEffect", "QGraphicsDropShadowEffect()", typeof(void));
        }
        [SmokeMethod("boundingRectFor(const QRectF&) const")]
        public override QRectF BoundingRectFor(QRectF rect) {
            return (QRectF) interceptor.Invoke("boundingRectFor#", "boundingRectFor(const QRectF&) const", typeof(QRectF), typeof(QRectF), rect);
        }
        [Q_SLOT("void setOffset(QPointF)")]
        public void SetOffset(QPointF ofs) {
            interceptor.Invoke("setOffset#", "setOffset(const QPointF&)", typeof(void), typeof(QPointF), ofs);
        }
        [Q_SLOT("void setOffset(qreal, qreal)")]
        public void SetOffset(double dx, double dy) {
            interceptor.Invoke("setOffset$$", "setOffset(qreal, qreal)", typeof(void), typeof(double), dx, typeof(double), dy);
        }
        [Q_SLOT("void setOffset(qreal)")]
        public void SetOffset(double d) {
            interceptor.Invoke("setOffset$", "setOffset(qreal)", typeof(void), typeof(double), d);
        }
        [Q_SLOT("void setXOffset(qreal)")]
        public void SetXOffset(double dx) {
            interceptor.Invoke("setXOffset$", "setXOffset(qreal)", typeof(void), typeof(double), dx);
        }
        [Q_SLOT("void setYOffset(qreal)")]
        public void SetYOffset(double dy) {
            interceptor.Invoke("setYOffset$", "setYOffset(qreal)", typeof(void), typeof(double), dy);
        }
        [Q_SLOT("void setBlurRadius(qreal)")]
        public void SetBlurRadius(double blurRadius) {
            interceptor.Invoke("setBlurRadius$", "setBlurRadius(qreal)", typeof(void), typeof(double), blurRadius);
        }
        [Q_SLOT("void setColor(QColor)")]
        public void SetColor(QColor color) {
            interceptor.Invoke("setColor#", "setColor(const QColor&)", typeof(void), typeof(QColor), color);
        }
        [SmokeMethod("draw(QPainter*)")]
        protected override void Draw(QPainter painter) {
            interceptor.Invoke("draw#", "draw(QPainter*)", typeof(void), typeof(QPainter), painter);
        }
        ~QGraphicsDropShadowEffect() {
            interceptor.Invoke("~QGraphicsDropShadowEffect", "~QGraphicsDropShadowEffect()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~QGraphicsDropShadowEffect", "~QGraphicsDropShadowEffect()", typeof(void));
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        protected new IQGraphicsDropShadowEffectSignals Emit {
            get { return (IQGraphicsDropShadowEffectSignals) Q_EMIT; }
        }
    }

    public interface IQGraphicsDropShadowEffectSignals : IQGraphicsEffectSignals {
        [Q_SIGNAL("void offsetChanged(QPointF)")]
        void OffsetChanged(QPointF offset);
        [Q_SIGNAL("void blurRadiusChanged(qreal)")]
        void BlurRadiusChanged(double blurRadius);
        [Q_SIGNAL("void colorChanged(QColor)")]
        void ColorChanged(QColor color);
    }
}
