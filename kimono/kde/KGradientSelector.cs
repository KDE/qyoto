//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {
    using System;
    using Qyoto;
    /// <remarks>
    ///  The KGradientSelector widget allows the user to choose
    ///  from a one-dimensional range of colors which is given as a
    ///  gradient between two colors provided by the programmer.
    ///  \image html kgradientselector.png "KDE Gradient Selector Widget"
    /// </remarks>        <short>    The KGradientSelector widget allows the user to choose  from a one-dimensional range of colors which is given as a  gradient between two colors provided by the programmer.</short>
    [SmokeClass("KGradientSelector")]
    public class KGradientSelector : KSelector, IDisposable {
        protected KGradientSelector(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(KGradientSelector), this);
        }
        [Q_PROPERTY("QColor", "firstColor")]
        public QColor FirstColor {
            get { return (QColor) interceptor.Invoke("firstColor", "firstColor()", typeof(QColor)); }
            set { interceptor.Invoke("setFirstColor#", "setFirstColor(QColor)", typeof(void), typeof(QColor), value); }
        }
        [Q_PROPERTY("QColor", "secondColor")]
        public QColor SecondColor {
            get { return (QColor) interceptor.Invoke("secondColor", "secondColor()", typeof(QColor)); }
            set { interceptor.Invoke("setSecondColor#", "setSecondColor(QColor)", typeof(void), typeof(QColor), value); }
        }
        [Q_PROPERTY("QString", "firstText")]
        public string FirstText {
            get { return (string) interceptor.Invoke("firstText", "firstText()", typeof(string)); }
            set { interceptor.Invoke("setFirstText$", "setFirstText(QString)", typeof(void), typeof(string), value); }
        }
        [Q_PROPERTY("QString", "secondText")]
        public string SecondText {
            get { return (string) interceptor.Invoke("secondText", "secondText()", typeof(string)); }
            set { interceptor.Invoke("setSecondText$", "setSecondText(QString)", typeof(void), typeof(string), value); }
        }
        /// <remarks>
        ///  Constructs a horizontal color selector which
        ///  contains a gradient between white and black.
        ///    </remarks>        <short>    Constructs a horizontal color selector which  contains a gradient between white and black.</short>
        public KGradientSelector(QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KGradientSelector#", "KGradientSelector(QWidget*)", typeof(void), typeof(QWidget), parent);
        }
        public KGradientSelector() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KGradientSelector", "KGradientSelector()", typeof(void));
        }
        /// <remarks>
        ///  Constructs a colors selector with orientation o which
        ///  contains a gradient between white and black.
        ///    </remarks>        <short>    Constructs a colors selector with orientation o which  contains a gradient between white and black.</short>
        public KGradientSelector(Qt.Orientation o, QWidget parent) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KGradientSelector$#", "KGradientSelector(Qt::Orientation, QWidget*)", typeof(void), typeof(Qt.Orientation), o, typeof(QWidget), parent);
        }
        public KGradientSelector(Qt.Orientation o) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KGradientSelector$", "KGradientSelector(Qt::Orientation)", typeof(void), typeof(Qt.Orientation), o);
        }
        /// <remarks>
        ///  Sets the two colors which span the gradient.
        ///    </remarks>        <short>    Sets the two colors which span the gradient.</short>
        public void SetColors(QColor col1, QColor col2) {
            interceptor.Invoke("setColors##", "setColors(const QColor&, const QColor&)", typeof(void), typeof(QColor), col1, typeof(QColor), col2);
        }
        public void SetText(string t1, string t2) {
            interceptor.Invoke("setText$$", "setText(const QString&, const QString&)", typeof(void), typeof(string), t1, typeof(string), t2);
        }
        [SmokeMethod("drawContents(QPainter*)")]
        protected override void DrawContents(QPainter arg1) {
            interceptor.Invoke("drawContents#", "drawContents(QPainter*)", typeof(void), typeof(QPainter), arg1);
        }
        [SmokeMethod("minimumSize() const")]
        protected new virtual QSize MinimumSize() {
            return (QSize) interceptor.Invoke("minimumSize", "minimumSize() const", typeof(QSize));
        }
        ~KGradientSelector() {
            interceptor.Invoke("~KGradientSelector", "~KGradientSelector()", typeof(void));
        }
        public new void Dispose() {
            interceptor.Invoke("~KGradientSelector", "~KGradientSelector()", typeof(void));
        }
        protected new IKGradientSelectorSignals Emit {
            get { return (IKGradientSelectorSignals) Q_EMIT; }
        }
    }

    public interface IKGradientSelectorSignals : IKSelectorSignals {
    }
}
