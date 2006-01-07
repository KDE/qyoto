//Auto-generated by ../../kalyptus/kalyptus. DO NOT EDIT.
namespace Qt {

	using System;
	using System.Collections;
	using System.Text;

	public class QVariant : MarshalByRefObject, IDisposable {
		protected Object _interceptor = null;
 
		private IntPtr _smokeObject;
 		protected QVariant(Type dummy) {}
		interface IQVariantProxy {
			bool op_equals(QVariant lhs, QVariant v);
			string TypeToName(int type);
			int NameToType(string name);
		}

		protected void CreateQVariantProxy() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(QVariant), this);
			_interceptor = (QVariant) realProxy.GetTransparentProxy();
		}
		private QVariant ProxyQVariant() {
			return (QVariant) _interceptor;
		}
		private static Object _staticInterceptor = null;
		static QVariant() {
			SmokeInvocation realProxy = new SmokeInvocation(typeof(IQVariantProxy), null);
			_staticInterceptor = (IQVariantProxy) realProxy.GetTransparentProxy();
		}
		private static IQVariantProxy StaticQVariant() {
			return (IQVariantProxy) _staticInterceptor;
		}

		enum E_Type : uint {
			Invalid = 0,
			Bool = 1,
			Int = 2,
			UInt = 3,
			LongLong = 4,
			ULongLong = 5,
			Double = 6,
			Char = 7,
			Map = 8,
			List = 9,
			String = 10,
			StringList = 11,
			ByteArray = 12,
			BitArray = 13,
			Date = 14,
			Time = 15,
			DateTime = 16,
			Url = 17,
			Locale = 18,
			Rect = 19,
			RectF = 20,
			Size = 21,
			SizeF = 22,
			Line = 23,
			LineF = 24,
			Point = 25,
			PointF = 26,
			Font = 64,
			Pixmap = 65,
			Brush = 66,
			Color = 67,
			Palette = 68,
			Icon = 69,
			Image = 70,
			Polygon = 71,
			Region = 72,
			Bitmap = 73,
			Cursor = 74,
			SizePolicy = 75,
			KeySequence = 76,
			Pen = 77,
			TextLength = 78,
			TextFormat = 79,
			UserType = 127,
			LastType = 0xffffffff,
		}
		public QVariant() : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant();
		}
		private void NewQVariant() {
			ProxyQVariant().NewQVariant();
		}
		public QVariant(int type) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(type);
		}
		private void NewQVariant(int type) {
			ProxyQVariant().NewQVariant(type);
		}
		// QVariant* QVariant(int arg1,const void* arg2); >>>> NOT CONVERTED
		public QVariant(QVariant other) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(other);
		}
		private void NewQVariant(QVariant other) {
			ProxyQVariant().NewQVariant(other);
		}
		public QVariant(QDataStream s) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(s);
		}
		private void NewQVariant(QDataStream s) {
			ProxyQVariant().NewQVariant(s);
		}
		public QVariant(uint ui) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(ui);
		}
		private void NewQVariant(uint ui) {
			ProxyQVariant().NewQVariant(ui);
		}
		// QVariant* QVariant(qlonglong arg1); >>>> NOT CONVERTED
		// QVariant* QVariant(qulonglong arg1); >>>> NOT CONVERTED
		public QVariant(bool b) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(b);
		}
		private void NewQVariant(bool b) {
			ProxyQVariant().NewQVariant(b);
		}
		public QVariant(double d) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(d);
		}
		private void NewQVariant(double d) {
			ProxyQVariant().NewQVariant(d);
		}
		public QVariant(string str) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(str);
		}
		private void NewQVariant(string str) {
			ProxyQVariant().NewQVariant(str);
		}
		public QVariant(QByteArray bytearray) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(bytearray);
		}
		private void NewQVariant(QByteArray bytearray) {
			ProxyQVariant().NewQVariant(bytearray);
		}
		// QVariant* QVariant(const QBitArray& arg1); >>>> NOT CONVERTED
		// QVariant* QVariant(const QLatin1String& arg1); >>>> NOT CONVERTED
		public QVariant(string[] stringlist) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(stringlist);
		}
		private void NewQVariant(string[] stringlist) {
			ProxyQVariant().NewQVariant(stringlist);
		}
		public QVariant(char qchar) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(qchar);
		}
		private void NewQVariant(char qchar) {
			ProxyQVariant().NewQVariant(qchar);
		}
		public QVariant(DateTime date) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(date);
		}
		private void NewQVariant(DateTime date) {
			ProxyQVariant().NewQVariant(date);
		}
		// QVariant* QVariant(const QList<QVariant>& arg1); >>>> NOT CONVERTED
		// QVariant* QVariant(const QMap<QString, QVariant>& arg1); >>>> NOT CONVERTED
		public QVariant(QSize size) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(size);
		}
		private void NewQVariant(QSize size) {
			ProxyQVariant().NewQVariant(size);
		}
		public QVariant(QSizeF size) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(size);
		}
		private void NewQVariant(QSizeF size) {
			ProxyQVariant().NewQVariant(size);
		}
		public QVariant(QPoint pt) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(pt);
		}
		private void NewQVariant(QPoint pt) {
			ProxyQVariant().NewQVariant(pt);
		}
		public QVariant(QPointF pt) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(pt);
		}
		private void NewQVariant(QPointF pt) {
			ProxyQVariant().NewQVariant(pt);
		}
		public QVariant(QLine line) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(line);
		}
		private void NewQVariant(QLine line) {
			ProxyQVariant().NewQVariant(line);
		}
		public QVariant(QLineF line) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(line);
		}
		private void NewQVariant(QLineF line) {
			ProxyQVariant().NewQVariant(line);
		}
		public QVariant(QRect rect) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(rect);
		}
		private void NewQVariant(QRect rect) {
			ProxyQVariant().NewQVariant(rect);
		}
		public QVariant(QRectF rect) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(rect);
		}
		private void NewQVariant(QRectF rect) {
			ProxyQVariant().NewQVariant(rect);
		}
		public QVariant(IQUrl url) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(url);
		}
		private void NewQVariant(IQUrl url) {
			ProxyQVariant().NewQVariant(url);
		}
		public QVariant(QLocale locale) : this((Type) null) {
			CreateQVariantProxy();
			NewQVariant(locale);
		}
		private void NewQVariant(QLocale locale) {
			ProxyQVariant().NewQVariant(locale);
		}
		public int UserType() {
			return ProxyQVariant().UserType();
		}
		public string TypeName() {
			return ProxyQVariant().TypeName();
		}
		public bool CanConvert(int t) {
			return ProxyQVariant().CanConvert(t);
		}
		public bool Convert(int t) {
			return ProxyQVariant().Convert(t);
		}
		public bool IsValid() {
			return ProxyQVariant().IsValid();
		}
		public bool IsNull() {
			return ProxyQVariant().IsNull();
		}
		public void Clear() {
			ProxyQVariant().Clear();
		}
		public void Detach() {
			ProxyQVariant().Detach();
		}
		public bool IsDetached() {
			return ProxyQVariant().IsDetached();
		}
		public int ToInt(out bool ok) {
			return ProxyQVariant().ToInt(out ok);
		}
		public int ToInt() {
			return ProxyQVariant().ToInt();
		}
		public uint ToUInt(out bool ok) {
			return ProxyQVariant().ToUInt(out ok);
		}
		public uint ToUInt() {
			return ProxyQVariant().ToUInt();
		}
		// qlonglong toLongLong(bool* arg1); >>>> NOT CONVERTED
		// qlonglong toLongLong(); >>>> NOT CONVERTED
		// qulonglong toULongLong(bool* arg1); >>>> NOT CONVERTED
		// qulonglong toULongLong(); >>>> NOT CONVERTED
		public bool ToBool() {
			return ProxyQVariant().ToBool();
		}
		public double ToDouble(out bool ok) {
			return ProxyQVariant().ToDouble(out ok);
		}
		public double ToDouble() {
			return ProxyQVariant().ToDouble();
		}
		public QByteArray ToByteArray() {
			return ProxyQVariant().ToByteArray();
		}
		// QBitArray toBitArray(); >>>> NOT CONVERTED
		public new string ToString() {
			return ProxyQVariant().ToString();
		}
		public ArrayList ToStringList() {
			return ProxyQVariant().ToStringList();
		}
		public char ToChar() {
			return ProxyQVariant().ToChar();
		}
		public DateTime ToDate() {
			return ProxyQVariant().ToDate();
		}
		public DateTime ToTime() {
			return ProxyQVariant().ToTime();
		}
		public DateTime ToDateTime() {
			return ProxyQVariant().ToDateTime();
		}
		// QList<QVariant> toList(); >>>> NOT CONVERTED
		// QMap<QString, QVariant> toMap(); >>>> NOT CONVERTED
		public QPoint ToPoint() {
			return ProxyQVariant().ToPoint();
		}
		public QPointF ToPointF() {
			return ProxyQVariant().ToPointF();
		}
		public QRect ToRect() {
			return ProxyQVariant().ToRect();
		}
		public QSize ToSize() {
			return ProxyQVariant().ToSize();
		}
		public QSizeF ToSizeF() {
			return ProxyQVariant().ToSizeF();
		}
		public QLine ToLine() {
			return ProxyQVariant().ToLine();
		}
		public QLineF ToLineF() {
			return ProxyQVariant().ToLineF();
		}
		public QRectF ToRectF() {
			return ProxyQVariant().ToRectF();
		}
		public IQUrl ToUrl() {
			return ProxyQVariant().ToUrl();
		}
		public QLocale ToLocale() {
			return ProxyQVariant().ToLocale();
		}
		public void Load(QDataStream ds) {
			ProxyQVariant().Load(ds);
		}
		public void Save(QDataStream ds) {
			ProxyQVariant().Save(ds);
		}
		// void* data(); >>>> NOT CONVERTED
		// const void* constData(); >>>> NOT CONVERTED
		// const void* data(); >>>> NOT CONVERTED
		public static bool operator==(QVariant lhs, QVariant v) {
			return StaticQVariant().op_equals(lhs,v);
		}
		public static bool operator!=(QVariant lhs, QVariant v) {
			return !StaticQVariant().op_equals(lhs,v);
		}
		public override bool Equals(object o) {
			if (!(o is QVariant)) { return false; }
			return this == (QVariant) o;
		}
		public override int GetHashCode() {
			return ProxyQVariant().GetHashCode();
		}
		public static string TypeToName(int type) {
			return StaticQVariant().TypeToName(type);
		}
		public static int NameToType(string name) {
			return StaticQVariant().NameToType(name);
		}
		// void create(int arg1,const void* arg2); >>>> NOT CONVERTED
		protected bool Cmp(QVariant other) {
			return ProxyQVariant().Cmp(other);
		}
		~QVariant() {
			ProxyQVariant().Dispose();
		}
		public void Dispose() {
			ProxyQVariant().Dispose();
		}
	}
}