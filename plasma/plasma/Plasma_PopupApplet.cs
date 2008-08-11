//Auto-generated by kalyptus. DO NOT EDIT.
namespace Plasma {
    using Plasma;
    using System;
    using Kimono;
    using Qyoto;
    using System.Collections.Generic;
    [SmokeClass("Plasma::PopupApplet")]
    public class PopupApplet : Plasma.Applet, IDisposable {
        protected PopupApplet(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(PopupApplet), this);
        }
        public PopupApplet(QObject parent, List<QVariant> args) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("PopupApplet#?", "PopupApplet(QObject*, const QList<QVariant>&)", typeof(void), typeof(QObject), parent, typeof(List<QVariant>), args);
        }
        public void SetIcon(QIcon icon) {
            interceptor.Invoke("setIcon#", "setIcon(const QIcon&)", typeof(void), typeof(QIcon), icon);
        }
        public void SetIcon(string iconName) {
            interceptor.Invoke("setIcon$", "setIcon(const QString&)", typeof(void), typeof(string), iconName);
        }
        public new QIcon Icon() {
            return (QIcon) interceptor.Invoke("icon", "icon() const", typeof(QIcon));
        }
        [SmokeMethod("widget()")]
        public virtual QWidget Widget() {
            return (QWidget) interceptor.Invoke("widget", "widget()", typeof(QWidget));
        }
        [SmokeMethod("graphicsWidget()")]
        public virtual QGraphicsWidget GraphicsWidget() {
            return (QGraphicsWidget) interceptor.Invoke("graphicsWidget", "graphicsWidget()", typeof(QGraphicsWidget));
        }
        public void ShowPopup(uint displayTime) {
            interceptor.Invoke("showPopup$", "showPopup(uint)", typeof(void), typeof(uint), displayTime);
        }
        public void ShowPopup() {
            interceptor.Invoke("showPopup", "showPopup()", typeof(void));
        }
        public void HidePopup() {
            interceptor.Invoke("hidePopup", "hidePopup()", typeof(void));
        }
        [SmokeMethod("constraintsEvent(Plasma::Constraints)")]
        protected override void ConstraintsEvent(uint constraints) {
            interceptor.Invoke("constraintsEvent$", "constraintsEvent(Plasma::Constraints)", typeof(void), typeof(uint), constraints);
        }
        ~PopupApplet() {
            interceptor.Invoke("~PopupApplet", "~PopupApplet()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~PopupApplet", "~PopupApplet()", typeof(void));
        }
        protected new IPopupAppletSignals Emit {
            get { return (IPopupAppletSignals) Q_EMIT; }
        }
    }

    public interface IPopupAppletSignals : Plasma.IAppletSignals {
    }
}