//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    /// <remarks> See <see cref="IQGraphicsOpacityEffectSignals"></see> for signals emitted by QGraphicsOpacityEffect
    /// </remarks>
    [SmokeClass("QGraphicsOpacityEffect")]
    public class QGraphicsOpacityEffect : QGraphicsEffect, IDisposable {
        protected QGraphicsOpacityEffect(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QGraphicsOpacityEffect), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QGraphicsOpacityEffect() {
            staticInterceptor = new SmokeInvocation(typeof(QGraphicsOpacityEffect), null);
        }
        [Q_PROPERTY("qreal", "opacity")]
        public double Opacity {
            get { return (double) interceptor.Invoke("opacity", "opacity()", typeof(double)); }
            set { interceptor.Invoke("setOpacity$", "setOpacity(qreal)", typeof(void), typeof(double), value); }
        }
        [Q_PROPERTY("QBrush", "opacityMask")]
        public QBrush OpacityMask {
            get { return (QBrush) interceptor.Invoke("opacityMask", "opacityMask()", typeof(QBrush)); }
            set { interceptor.Invoke("setOpacityMask#", "setOpacityMask(QBrush)", typeof(void), typeof(QBrush), value); }
        }
        public QGraphicsOpacityEffect(QObject parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QGraphicsOpacityEffect#", "QGraphicsOpacityEffect(QObject*)", typeof(void), typeof(QObject), parent);
        }
        public QGraphicsOpacityEffect() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QGraphicsOpacityEffect", "QGraphicsOpacityEffect()", typeof(void));
        }
        [Q_SLOT("void setOpacity(qreal)")]
        public void SetOpacity(double opacity) {
            interceptor.Invoke("setOpacity$", "setOpacity(qreal)", typeof(void), typeof(double), opacity);
        }
        [Q_SLOT("void setOpacityMask(QBrush)")]
        public void SetOpacityMask(QBrush mask) {
            interceptor.Invoke("setOpacityMask#", "setOpacityMask(const QBrush&)", typeof(void), typeof(QBrush), mask);
        }
        [SmokeMethod("draw(QPainter*)")]
        protected override void Draw(QPainter painter) {
            interceptor.Invoke("draw#", "draw(QPainter*)", typeof(void), typeof(QPainter), painter);
        }
        ~QGraphicsOpacityEffect() {
            interceptor.Invoke("~QGraphicsOpacityEffect", "~QGraphicsOpacityEffect()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~QGraphicsOpacityEffect", "~QGraphicsOpacityEffect()", typeof(void));
        }
        public static new string Tr(string s, string c) {
            return (string) staticInterceptor.Invoke("tr$$", "tr(const char*, const char*)", typeof(string), typeof(string), s, typeof(string), c);
        }
        public static new string Tr(string s) {
            return (string) staticInterceptor.Invoke("tr$", "tr(const char*)", typeof(string), typeof(string), s);
        }
        protected new IQGraphicsOpacityEffectSignals Emit {
            get { return (IQGraphicsOpacityEffectSignals) Q_EMIT; }
        }
    }

    public interface IQGraphicsOpacityEffectSignals : IQGraphicsEffectSignals {
        [Q_SIGNAL("void opacityChanged(qreal)")]
        void OpacityChanged(double opacity);
        [Q_SIGNAL("void opacityMaskChanged(QBrush)")]
        void OpacityMaskChanged(QBrush mask);
    }
}
