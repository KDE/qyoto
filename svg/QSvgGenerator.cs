//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {
    using System;
    [SmokeClass("QSvgGenerator")]
    public class QSvgGenerator : QPaintDevice, IDisposable {
        protected QSvgGenerator(Type dummy) : base((Type) null) {}
        protected new void CreateProxy() {
            interceptor = new SmokeInvocation(typeof(QSvgGenerator), this);
        }
        [Q_PROPERTY("QSize", "size")]
        public QSize Size {
            get { return (QSize) interceptor.Invoke("size", "size()", typeof(QSize)); }
            set { interceptor.Invoke("setSize#", "setSize(QSize)", typeof(void), typeof(QSize), value); }
        }
        [Q_PROPERTY("QRectF", "viewBox")]
        public QRectF ViewBox {
            get { return (QRectF) interceptor.Invoke("viewBoxF", "viewBoxF()", typeof(QRectF)); }
            set { interceptor.Invoke("setViewBox#", "setViewBox(QRectF)", typeof(void), typeof(QRectF), value); }
        }
        [Q_PROPERTY("QString", "title")]
        public string Title {
            get { return (string) interceptor.Invoke("title", "title()", typeof(string)); }
            set { interceptor.Invoke("setTitle$", "setTitle(QString)", typeof(void), typeof(string), value); }
        }
        [Q_PROPERTY("QString", "description")]
        public string Description {
            get { return (string) interceptor.Invoke("description", "description()", typeof(string)); }
            set { interceptor.Invoke("setDescription$", "setDescription(QString)", typeof(void), typeof(string), value); }
        }
        [Q_PROPERTY("QString", "fileName")]
        public string FileName {
            get { return (string) interceptor.Invoke("fileName", "fileName()", typeof(string)); }
            set { interceptor.Invoke("setFileName$", "setFileName(QString)", typeof(void), typeof(string), value); }
        }
        [Q_PROPERTY("QIODevice*", "outputDevice")]
        public QIODevice OutputDevice {
            get { return (QIODevice) interceptor.Invoke("outputDevice", "outputDevice()", typeof(QIODevice)); }
            set { interceptor.Invoke("setOutputDevice#", "setOutputDevice(QIODevice*)", typeof(void), typeof(QIODevice), value); }
        }
        [Q_PROPERTY("int", "resolution")]
        public int Resolution {
            get { return (int) interceptor.Invoke("resolution", "resolution()", typeof(int)); }
            set { interceptor.Invoke("setResolution$", "setResolution(int)", typeof(void), typeof(int), value); }
        }
        public QSvgGenerator() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("QSvgGenerator", "QSvgGenerator()", typeof(void));
        }
        [SmokeMethod("paintEngine() const")]
        public override QPaintEngine PaintEngine() {
            return (QPaintEngine) interceptor.Invoke("paintEngine", "paintEngine() const", typeof(QPaintEngine));
        }
        [SmokeMethod("metric(QPaintDevice::PaintDeviceMetric) const")]
        protected override int Metric(QPaintDevice.PaintDeviceMetric metric) {
            return (int) interceptor.Invoke("metric$", "metric(QPaintDevice::PaintDeviceMetric) const", typeof(int), typeof(QPaintDevice.PaintDeviceMetric), metric);
        }
        ~QSvgGenerator() {
            interceptor.Invoke("~QSvgGenerator", "~QSvgGenerator()", typeof(void));
        }
        public void Dispose() {
            interceptor.Invoke("~QSvgGenerator", "~QSvgGenerator()", typeof(void));
        }
    }
}
