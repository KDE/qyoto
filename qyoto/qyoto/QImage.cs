//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	public class QImage : QPaintDevice, IDisposable {
 		protected QImage(Type dummy) : base((Type) null) {}
		interface IQImageProxy {
			bool op_equals(QImage lhs, QImage arg1);
			QMatrix TrueMatrix(QMatrix arg1, int w, int h);
			QImage FromData(char[] data, int size, string format);
			QImage FromData(char[] data, int size);
			QImage FromData(QByteArray data, string format);
			QImage FromData(QByteArray data);
		}

		protected void CreateQImageProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QImage), this);
			_interceptor = (QImage) realProxy.GetTransparentProxy();
		}
		private QImage ProxyQImage() {
			return (QImage) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QImage() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQImageProxy), null);
			_staticInterceptor = (IQImageProxy) realProxy.GetTransparentProxy();
		}
		private static IQImageProxy StaticQImage() {
			return (IQImageProxy) _staticInterceptor;
		}

		enum InvertMode {
			InvertRgb = 0,
			InvertRgba = 1,
		}
		enum E_Format {
			Format_Invalid = 0,
			Format_Mono = 1,
			Format_MonoLSB = 2,
			Format_Indexed8 = 3,
			Format_RGB32 = 4,
			Format_ARGB32 = 5,
			Format_ARGB32_Premultiplied = 6,
		}
		public QImage() : this((Type) null) {
			CreateQImageProxy();
			NewQImage();
		}
		private void NewQImage() {
			ProxyQImage().NewQImage();
		}
		public QImage(QSize size, int format) : this((Type) null) {
			CreateQImageProxy();
			NewQImage(size,format);
		}
		private void NewQImage(QSize size, int format) {
			ProxyQImage().NewQImage(size,format);
		}
		public QImage(int width, int height, int format) : this((Type) null) {
			CreateQImageProxy();
			NewQImage(width,height,format);
		}
		private void NewQImage(int width, int height, int format) {
			ProxyQImage().NewQImage(width,height,format);
		}
		public QImage(char[] data, int width, int height, int format) : this((Type) null) {
			CreateQImageProxy();
			NewQImage(data,width,height,format);
		}
		private void NewQImage(char[] data, int width, int height, int format) {
			ProxyQImage().NewQImage(data,width,height,format);
		}
		// QImage* QImage(const char** arg1); >>>> NOT CONVERTED
		public QImage(string fileName, string format) : this((Type) null) {
			CreateQImageProxy();
			NewQImage(fileName,format);
		}
		private void NewQImage(string fileName, string format) {
			ProxyQImage().NewQImage(fileName,format);
		}
		public QImage(string fileName) : this((Type) null) {
			CreateQImageProxy();
			NewQImage(fileName);
		}
		private void NewQImage(string fileName) {
			ProxyQImage().NewQImage(fileName);
		}
		public QImage(QImage arg1) : this((Type) null) {
			CreateQImageProxy();
			NewQImage(arg1);
		}
		private void NewQImage(QImage arg1) {
			ProxyQImage().NewQImage(arg1);
		}
		public bool IsNull() {
			return ProxyQImage().IsNull();
		}
		public new int DevType() {
			return ProxyQImage().DevType();
		}
		public static bool operator==(QImage lhs, QImage arg1) {
			return StaticQImage().op_equals(lhs,arg1);
		}
		public static bool operator!=(QImage lhs, QImage arg1) {
			return !StaticQImage().op_equals(lhs,arg1);
		}
		public override bool Equals(object o) {
			if (!(o is QImage)) { return false; }
			return this == (QImage) o;
		}
		public override int GetHashCode() {
			return ProxyQImage().GetHashCode();
		}
		//  operator QVariant(); >>>> NOT CONVERTED
		public void Detach() {
			ProxyQImage().Detach();
		}
		public bool IsDetached() {
			return ProxyQImage().IsDetached();
		}
		public QImage Copy(QRect rect) {
			return ProxyQImage().Copy(rect);
		}
		public QImage Copy() {
			return ProxyQImage().Copy();
		}
		public QImage Copy(int x, int y, int w, int h) {
			return ProxyQImage().Copy(x,y,w,h);
		}
		public int Format() {
			return ProxyQImage().Format();
		}
		public QImage ConvertToFormat(int f, int flags) {
			return ProxyQImage().ConvertToFormat(f,flags);
		}
		public QImage ConvertToFormat(int f) {
			return ProxyQImage().ConvertToFormat(f);
		}
		// QImage convertToFormat(QImage::Format arg1,const QVector<QRgb>& arg2,Qt::ImageConversionFlags arg3); >>>> NOT CONVERTED
		// QImage convertToFormat(QImage::Format arg1,const QVector<QRgb>& arg2); >>>> NOT CONVERTED
		public new int Width() {
			return ProxyQImage().Width();
		}
		public new int Height() {
			return ProxyQImage().Height();
		}
		public QSize Size() {
			return ProxyQImage().Size();
		}
		public QRect Rect() {
			return ProxyQImage().Rect();
		}
		public new int Depth() {
			return ProxyQImage().Depth();
		}
		public new int NumColors() {
			return ProxyQImage().NumColors();
		}
		public uint Color(int i) {
			return ProxyQImage().Color(i);
		}
		public void SetColor(int i, uint c) {
			ProxyQImage().SetColor(i,c);
		}
		public void SetNumColors(int arg1) {
			ProxyQImage().SetNumColors(arg1);
		}
		public bool AllGray() {
			return ProxyQImage().AllGray();
		}
		public bool IsGrayscale() {
			return ProxyQImage().IsGrayscale();
		}
		public byte[] Bits() {
			return ProxyQImage().Bits();
		}
		public int NumBytes() {
			return ProxyQImage().NumBytes();
		}
		public byte[] ScanLine(int arg1) {
			return ProxyQImage().ScanLine(arg1);
		}
		public int BytesPerLine() {
			return ProxyQImage().BytesPerLine();
		}
		public bool Valid(int x, int y) {
			return ProxyQImage().Valid(x,y);
		}
		public int PixelIndex(int x, int y) {
			return ProxyQImage().PixelIndex(x,y);
		}
		public uint Pixel(int x, int y) {
			return ProxyQImage().Pixel(x,y);
		}
		public void SetPixel(int x, int y, uint index_or_rgb) {
			ProxyQImage().SetPixel(x,y,index_or_rgb);
		}
		// QVector<QRgb> colorTable(); >>>> NOT CONVERTED
		// void setColorTable(const QVector<QRgb> arg1); >>>> NOT CONVERTED
		public void Fill(uint pixel) {
			ProxyQImage().Fill(pixel);
		}
		public bool HasAlphaChannel() {
			return ProxyQImage().HasAlphaChannel();
		}
		public void SetAlphaChannel(QImage alphaChannel) {
			ProxyQImage().SetAlphaChannel(alphaChannel);
		}
		public QImage AlphaChannel() {
			return ProxyQImage().AlphaChannel();
		}
		public QImage CreateAlphaMask(int flags) {
			return ProxyQImage().CreateAlphaMask(flags);
		}
		public QImage CreateAlphaMask() {
			return ProxyQImage().CreateAlphaMask();
		}
		public QImage CreateHeuristicMask(bool clipTight) {
			return ProxyQImage().CreateHeuristicMask(clipTight);
		}
		public QImage CreateHeuristicMask() {
			return ProxyQImage().CreateHeuristicMask();
		}
		public QImage Scaled(int w, int h, int aspectMode, int mode) {
			return ProxyQImage().Scaled(w,h,aspectMode,mode);
		}
		public QImage Scaled(int w, int h, int aspectMode) {
			return ProxyQImage().Scaled(w,h,aspectMode);
		}
		public QImage Scaled(int w, int h) {
			return ProxyQImage().Scaled(w,h);
		}
		public QImage Scaled(QSize s, int aspectMode, int mode) {
			return ProxyQImage().Scaled(s,aspectMode,mode);
		}
		public QImage Scaled(QSize s, int aspectMode) {
			return ProxyQImage().Scaled(s,aspectMode);
		}
		public QImage Scaled(QSize s) {
			return ProxyQImage().Scaled(s);
		}
		public QImage ScaledToWidth(int w, int mode) {
			return ProxyQImage().ScaledToWidth(w,mode);
		}
		public QImage ScaledToWidth(int w) {
			return ProxyQImage().ScaledToWidth(w);
		}
		public QImage ScaledToHeight(int h, int mode) {
			return ProxyQImage().ScaledToHeight(h,mode);
		}
		public QImage ScaledToHeight(int h) {
			return ProxyQImage().ScaledToHeight(h);
		}
		public QImage Transformed(QMatrix matrix, int mode) {
			return ProxyQImage().Transformed(matrix,mode);
		}
		public QImage Transformed(QMatrix matrix) {
			return ProxyQImage().Transformed(matrix);
		}
		public QImage Mirrored(bool horizontally, bool vertically) {
			return ProxyQImage().Mirrored(horizontally,vertically);
		}
		public QImage Mirrored(bool horizontally) {
			return ProxyQImage().Mirrored(horizontally);
		}
		public QImage Mirrored() {
			return ProxyQImage().Mirrored();
		}
		public QImage RgbSwapped() {
			return ProxyQImage().RgbSwapped();
		}
		public void InvertPixels(int arg1) {
			ProxyQImage().InvertPixels(arg1);
		}
		public void InvertPixels() {
			ProxyQImage().InvertPixels();
		}
		public bool Load(string fileName, string format) {
			return ProxyQImage().Load(fileName,format);
		}
		public bool Load(string fileName) {
			return ProxyQImage().Load(fileName);
		}
		public bool LoadFromData(char[] buf, int len, string format) {
			return ProxyQImage().LoadFromData(buf,len,format);
		}
		public bool LoadFromData(char[] buf, int len) {
			return ProxyQImage().LoadFromData(buf,len);
		}
		public bool LoadFromData(QByteArray data, string aformat) {
			return ProxyQImage().LoadFromData(data,aformat);
		}
		public bool LoadFromData(QByteArray data) {
			return ProxyQImage().LoadFromData(data);
		}
		public bool Save(string fileName, string format, int quality) {
			return ProxyQImage().Save(fileName,format,quality);
		}
		public bool Save(string fileName, string format) {
			return ProxyQImage().Save(fileName,format);
		}
		public bool Save(IQIODevice device, string format, int quality) {
			return ProxyQImage().Save(device,format,quality);
		}
		public bool Save(IQIODevice device, string format) {
			return ProxyQImage().Save(device,format);
		}
		public int SerialNumber() {
			return ProxyQImage().SerialNumber();
		}
		public new QPaintEngine PaintEngine() {
			return ProxyQImage().PaintEngine();
		}
		public int DotsPerMeterX() {
			return ProxyQImage().DotsPerMeterX();
		}
		public int DotsPerMeterY() {
			return ProxyQImage().DotsPerMeterY();
		}
		public void SetDotsPerMeterX(int arg1) {
			ProxyQImage().SetDotsPerMeterX(arg1);
		}
		public void SetDotsPerMeterY(int arg1) {
			ProxyQImage().SetDotsPerMeterY(arg1);
		}
		public QPoint Offset() {
			return ProxyQImage().Offset();
		}
		public void SetOffset(QPoint arg1) {
			ProxyQImage().SetOffset(arg1);
		}
		// QList<QImageTextKeyLang> textList(); >>>> NOT CONVERTED
		public ArrayList TextLanguages() {
			return ProxyQImage().TextLanguages();
		}
		public ArrayList TextKeys() {
			return ProxyQImage().TextKeys();
		}
		public string Text(string key, string lang) {
			return ProxyQImage().Text(key,lang);
		}
		public string Text(string key) {
			return ProxyQImage().Text(key);
		}
		// QString text(const QImageTextKeyLang& arg1); >>>> NOT CONVERTED
		public void SetText(string key, string lang, string arg3) {
			ProxyQImage().SetText(key,lang,arg3);
		}
		public static QMatrix TrueMatrix(QMatrix arg1, int w, int h) {
			return StaticQImage().TrueMatrix(arg1,w,h);
		}
		public static QImage FromData(char[] data, int size, string format) {
			return StaticQImage().FromData(data,size,format);
		}
		public static QImage FromData(char[] data, int size) {
			return StaticQImage().FromData(data,size);
		}
		public static QImage FromData(QByteArray data, string format) {
			return StaticQImage().FromData(data,format);
		}
		public static QImage FromData(QByteArray data) {
			return StaticQImage().FromData(data);
		}
		protected new virtual int Metric(IQPaintDevice metric) {
			return ProxyQImage().Metric(metric);
		}
		~QImage() {
			ProxyQImage().Dispose();
		}
		public void Dispose() {
			ProxyQImage().Dispose();
		}
	}
}