//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    using System.Collections.Generic;
    [SmokeClass("QPen")]
    public partial class QPen : Object, IDisposable {
        protected SmokeInvocation interceptor = null;
        private IntPtr smokeObject;
        protected QPen(Type dummy) {}
        protected void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QPen), this);
        }
        private static SmokeInvocation staticInterceptor = null;
        static QPen() {
            staticInterceptor = new SmokeInvocation(typeof(QPen), null);
        }
        //  operator QVariant(); >>>> NOT CONVERTED
        // QPen::DataPtr*& data_ptr(); >>>> NOT CONVERTED
        public QPen() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QPen", "QPen()", typeof(void));
        }
        public QPen(Qt.PenStyle arg1) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QPen$", "QPen(Qt::PenStyle)", typeof(void), typeof(Qt.PenStyle), arg1);
        }
        public QPen(QColor color) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QPen#", "QPen(const QColor&)", typeof(void), typeof(QColor), color);
        }
        public QPen(QBrush brush, double width, Qt.PenStyle s, Qt.PenCapStyle c, Qt.PenJoinStyle j) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QPen#$$$$", "QPen(const QBrush&, qreal, Qt::PenStyle, Qt::PenCapStyle, Qt::PenJoinStyle)", typeof(void), typeof(QBrush), brush, typeof(double), width, typeof(Qt.PenStyle), s, typeof(Qt.PenCapStyle), c, typeof(Qt.PenJoinStyle), j);
        }
        public QPen(QBrush brush, double width, Qt.PenStyle s, Qt.PenCapStyle c) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QPen#$$$", "QPen(const QBrush&, qreal, Qt::PenStyle, Qt::PenCapStyle)", typeof(void), typeof(QBrush), brush, typeof(double), width, typeof(Qt.PenStyle), s, typeof(Qt.PenCapStyle), c);
        }
        public QPen(QBrush brush, double width, Qt.PenStyle s) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QPen#$$", "QPen(const QBrush&, qreal, Qt::PenStyle)", typeof(void), typeof(QBrush), brush, typeof(double), width, typeof(Qt.PenStyle), s);
        }
        public QPen(QBrush brush, double width) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QPen#$", "QPen(const QBrush&, qreal)", typeof(void), typeof(QBrush), brush, typeof(double), width);
        }
        public QPen(QPen pen) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QPen#", "QPen(const QPen&)", typeof(void), typeof(QPen), pen);
        }
        public Qt.PenStyle Style() {
            return (Qt.PenStyle) interceptor.Invoke("style", "style() const", typeof(Qt.PenStyle));
        }
        public void SetStyle(Qt.PenStyle arg1) {
            interceptor.Invoke("setStyle$", "setStyle(Qt::PenStyle)", typeof(void), typeof(Qt.PenStyle), arg1);
        }
        public List<double> DashPattern() {
            return (List<double>) interceptor.Invoke("dashPattern", "dashPattern() const", typeof(List<double>));
        }
        public void SetDashPattern(List<double> pattern) {
            interceptor.Invoke("setDashPattern?", "setDashPattern(const QVector<qreal>&)", typeof(void), typeof(List<double>), pattern);
        }
        public double DashOffset() {
            return (double) interceptor.Invoke("dashOffset", "dashOffset() const", typeof(double));
        }
        public void SetDashOffset(double doffset) {
            interceptor.Invoke("setDashOffset$", "setDashOffset(qreal)", typeof(void), typeof(double), doffset);
        }
        public double MiterLimit() {
            return (double) interceptor.Invoke("miterLimit", "miterLimit() const", typeof(double));
        }
        public void SetMiterLimit(double limit) {
            interceptor.Invoke("setMiterLimit$", "setMiterLimit(qreal)", typeof(void), typeof(double), limit);
        }
        public double WidthF() {
            return (double) interceptor.Invoke("widthF", "widthF() const", typeof(double));
        }
        public void SetWidthF(double width) {
            interceptor.Invoke("setWidthF$", "setWidthF(qreal)", typeof(void), typeof(double), width);
        }
        public int Width() {
            return (int) interceptor.Invoke("width", "width() const", typeof(int));
        }
        public void SetWidth(int width) {
            interceptor.Invoke("setWidth$", "setWidth(int)", typeof(void), typeof(int), width);
        }
        public QColor Color() {
            return (QColor) interceptor.Invoke("color", "color() const", typeof(QColor));
        }
        public void SetColor(QColor color) {
            interceptor.Invoke("setColor#", "setColor(const QColor&)", typeof(void), typeof(QColor), color);
        }
        public QBrush Brush() {
            return (QBrush) interceptor.Invoke("brush", "brush() const", typeof(QBrush));
        }
        public void SetBrush(QBrush brush) {
            interceptor.Invoke("setBrush#", "setBrush(const QBrush&)", typeof(void), typeof(QBrush), brush);
        }
        public bool IsSolid() {
            return (bool) interceptor.Invoke("isSolid", "isSolid() const", typeof(bool));
        }
        public Qt.PenCapStyle CapStyle() {
            return (Qt.PenCapStyle) interceptor.Invoke("capStyle", "capStyle() const", typeof(Qt.PenCapStyle));
        }
        public void SetCapStyle(Qt.PenCapStyle pcs) {
            interceptor.Invoke("setCapStyle$", "setCapStyle(Qt::PenCapStyle)", typeof(void), typeof(Qt.PenCapStyle), pcs);
        }
        public Qt.PenJoinStyle JoinStyle() {
            return (Qt.PenJoinStyle) interceptor.Invoke("joinStyle", "joinStyle() const", typeof(Qt.PenJoinStyle));
        }
        public void SetJoinStyle(Qt.PenJoinStyle pcs) {
            interceptor.Invoke("setJoinStyle$", "setJoinStyle(Qt::PenJoinStyle)", typeof(void), typeof(Qt.PenJoinStyle), pcs);
        }
        public bool IsCosmetic() {
            return (bool) interceptor.Invoke("isCosmetic", "isCosmetic() const", typeof(bool));
        }
        public void SetCosmetic(bool cosmetic) {
            interceptor.Invoke("setCosmetic$", "setCosmetic(bool)", typeof(void), typeof(bool), cosmetic);
        }
        public override bool Equals(object o) {
            if (!(o is QPen)) { return false; }
            return this == (QPen) o;
        }
        public override int GetHashCode() {
            return interceptor.GetHashCode();
        }
        public bool IsDetached() {
            return (bool) interceptor.Invoke("isDetached", "isDetached()", typeof(bool));
        }
        ~QPen() {
            interceptor.Invoke("~QPen", "~QPen()", typeof(void));
        }
        public void Dispose() {
            interceptor.Invoke("~QPen", "~QPen()", typeof(void));
        }
        public static bool operator==(QPen lhs, QPen p) {
            return (bool) staticInterceptor.Invoke("operator==#", "operator==(const QPen&) const", typeof(bool), typeof(QPen), lhs, typeof(QPen), p);
        }
        public static bool operator!=(QPen lhs, QPen p) {
            return !(bool) staticInterceptor.Invoke("operator==#", "operator==(const QPen&) const", typeof(bool), typeof(QPen), lhs, typeof(QPen), p);
        }
    }
}
