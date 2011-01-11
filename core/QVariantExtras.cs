namespace Qyoto {

    using System;
    using System.Collections;
    using System.Collections.Generic; 
    using System.Text;
    using System.Runtime.InteropServices;

    public partial class QVariant : Object, IDisposable {

        [DllImport("qyoto", CharSet=CharSet.Ansi)]
        static extern IntPtr QVariantValue(string typeName, IntPtr variant);

        [DllImport("qyoto", CharSet=CharSet.Ansi)]
        static extern IntPtr QVariantFromValue(int type, IntPtr value);

        public T Value<T>() {
            object value = Value(typeof(T));
            if (value == null) {
                return default(T);
            }
            return (T) value;
        }

        public object Value(Type valueType) {
            if (valueType == typeof(bool)) {
                return ToBool();
            } else if (valueType == typeof(double)) {
                return ToDouble();
            } else if (valueType == typeof(QBitArray)) {
                return ToBitArray();
            } else if (valueType == typeof(QByteArray)) {
                return ToByteArray();
            } else if (valueType == typeof(char)) {
                return ToChar();
            } else if (valueType == typeof(QDate)) {
                return ToDate();
            } else if (valueType == typeof(QDateTime)) {
                return ToDateTime();
            } else if (valueType == typeof(int)) {
                return ToInt();
            } else if (valueType == typeof(QLine)) {
                return ToLine();
            } else if (valueType == typeof(QLineF)) {
                return ToLineF();
            } else if (valueType == typeof(QLocale)) {
                return ToLocale();
            } else if (valueType == typeof(QPoint)) {
                return ToPoint();
            } else if (valueType == typeof(QPointF)) {
                return ToPointF();
            } else if (valueType == typeof(QRect)) {
                return ToRect();
            } else if (valueType == typeof(QRectF)) {
                return ToRectF();
            } else if (valueType == typeof(QRegExp)) {
                return ToRegExp();
            } else if (valueType == typeof(QSize)) {
                return ToSize();
            } else if (valueType == typeof(QSizeF)) {
                return ToSizeF();
            } else if (valueType == typeof(string)) {
                return ToString();
            } else if (valueType == typeof(List<string>)) {
                return ToStringList();
            } else if (valueType == typeof(List<QVariant>)) {
                return ToList();
            } else if (valueType == typeof(Dictionary<string, QVariant>)) {
                object o = ToMap();
                if (o == null)
                    o = ToHash();
                return o;
            } else if (valueType == typeof(QTime)) {
                return ToTime();
            } else if (valueType == typeof(uint)) {
                return ToUInt();
            } else if (valueType == typeof(QUrl)) {
                return ToUrl();
            } else if (valueType == typeof(QVariant)) {
                return this;
            } else if (valueType.IsEnum) {
                return ToInt();
            } else {
                string typeName;
                if (SmokeMarshallers.IsSmokeClass(valueType))
                    typeName = SmokeMarshallers.SmokeClassName(valueType);
                else
                    typeName = valueType.ToString();
                TypeOf type = NameToType(typeName);
                if (type > TypeOf.LastCoreType) {
                    IntPtr instancePtr = QVariantValue(typeName, (IntPtr) GCHandle.Alloc(this));
                    return ((GCHandle) instancePtr).Target;
                } else if (type == TypeOf.Invalid) {
                    Console.WriteLine("QVariant.Value(): invalid type", valueType);
                }

                return null;
            }
        }

        static public QVariant FromValue<T>(T value) {
            return FromValue(value, typeof(T));
        }

        static public QVariant FromValue(object value, Type valueType) {
            if (valueType == typeof(bool)) {
                return new QVariant((bool) value);
            } else if (valueType == typeof(double)) {
                return new QVariant((double) value);
            } else if (valueType == typeof(QBitArray)) {
                return new QVariant((QBitArray) value);
            } else if (valueType == typeof(QByteArray)) {
                return new QVariant((QByteArray) value);
            } else if (valueType == typeof(char)) {
                return new QVariant(new QChar((char) value));
            } else if (valueType == typeof(QDate)) {
                return new QVariant((QDate) value);
            } else if (valueType == typeof(QDateTime)) {
                return new QVariant((QDateTime) value);
            } else if (valueType == typeof(int)) {
                return new QVariant((int) value);
            } else if (valueType == typeof(QLine)) {
                return new QVariant((QLine) value);
            } else if (valueType == typeof(QLineF)) {
                return new QVariant((QLineF) value);
            } else if (valueType == typeof(QLocale)) {
                return new QVariant((QLocale) value);
            } else if (valueType == typeof(QPoint)) {
                return new QVariant((QPoint) value);
            } else if (valueType == typeof(QPointF)) {
                return new QVariant((QPointF) value);
            } else if (valueType == typeof(QRect)) {
                return new QVariant((QRect) value);
            } else if (valueType == typeof(QRectF)) {
                return new QVariant((QRectF) value);
            } else if (valueType == typeof(QRegExp)) {
                return new QVariant((QRegExp) value);
            } else if (valueType == typeof(QSize)) {
                return new QVariant((QSize) value);
            } else if (valueType == typeof(QSizeF)) {
                return new QVariant((QSizeF) value);
            } else if (valueType == typeof(string)) {
                return new QVariant((string) value);
            } else if (valueType == typeof(List<string>)) {
                return new QVariant((List<string>) value);
            } else if (valueType == typeof(List<QVariant>)) {
                return new QVariant((List<QVariant>) value);
            } else if (valueType == typeof(Dictionary<string, QVariant>)) {
                return new QVariant((Dictionary<string, QVariant>) value);
            } else if (valueType == typeof(QTime)) {
                return new QVariant((QTime) value);
            } else if (valueType == typeof(uint)) {
                return new QVariant((uint) value);
            } else if (valueType == typeof(QUrl)) {
                return new QVariant((QUrl) value);
            } else if (valueType == typeof(QVariant)) {
                return new QVariant((QVariant) value);
            } else if (valueType.IsEnum) {
                return new QVariant((int) value);
            } else {
                string typeName;
                if (SmokeMarshallers.IsSmokeClass(valueType))
                    typeName = SmokeMarshallers.SmokeClassName(valueType);
                else
                    typeName = valueType.ToString();
                TypeOf type = NameToType(typeName);
                if (type == TypeOf.Invalid) {
                    throw new Exception(string.Format("Type {0} not registered!", valueType.ToString()));
                } else if (type > TypeOf.LastCoreType) {
                    IntPtr valueHandle = IntPtr.Zero;
                    if (value != null) {
                        valueHandle = (IntPtr) GCHandle.Alloc(value);
                    }
                    GCHandle handle = (GCHandle) QVariantFromValue(QMetaType.type(typeName), valueHandle);
                    QVariant v = (QVariant) handle.Target;
                    handle.SynchronizedFree();
                    return v;
                }

                return new QVariant();
            }
        }

        public static implicit operator QVariant(int arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(uint arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(long arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(ulong arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(bool arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(double arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(string arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(QBitArray arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(QByteArray arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(QBitmap arg) {
            return QVariant.FromValue<QBitmap>(arg);
        }
        public static implicit operator QVariant(QBrush arg) {
            return QVariant.FromValue<QBrush>(arg);
        }
        public static implicit operator QVariant(QColor arg) {
            return QVariant.FromValue<QColor>(arg);
        }
        public static implicit operator QVariant(QCursor arg) {
            return QVariant.FromValue<QCursor>(arg);
        }
        public static implicit operator QVariant(QDate arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(QFont arg) {
            return QVariant.FromValue<QFont>(arg);
        }
        public static implicit operator QVariant(QIcon arg) {
            return QVariant.FromValue<QIcon>(arg);
        }
        public static implicit operator QVariant(QImage arg) {
            return QVariant.FromValue<QImage>(arg);
        }
        public static implicit operator QVariant(QKeySequence arg) {
            return QVariant.FromValue<QKeySequence>(arg);
        }
        public static implicit operator QVariant(QMatrix arg) {
            return QVariant.FromValue<QMatrix>(arg);
        }
        public static implicit operator QVariant(QPalette arg) {
            return QVariant.FromValue<QPalette>(arg);
        }
        public static implicit operator QVariant(QPen arg) {
            return QVariant.FromValue<QPen>(arg);
        }
        public static implicit operator QVariant(QPixmap arg) {
            return QVariant.FromValue<QPixmap>(arg);
        }
        public static implicit operator QVariant(QPolygon arg) {
            return QVariant.FromValue<QPolygon>(arg);
        }
        public static implicit operator QVariant(QRegion arg) {
            return QVariant.FromValue<QRegion>(arg);
        }
        public static implicit operator QVariant(QSizePolicy arg) {
            return QVariant.FromValue<QSizePolicy>(arg);
        }
        public static implicit operator QVariant(QTextFormat arg) {
            return QVariant.FromValue<QTextFormat>(arg);
        }
        public static implicit operator QVariant(QTextLength arg) {
            return QVariant.FromValue<QTextLength>(arg);
        }
        public static implicit operator QVariant(QTime arg) {
            return new QVariant(arg);
        }
        public static implicit operator QVariant(QTransform arg) {
            return QVariant.FromValue<QTransform>(arg);
        }
        public static implicit operator int(QVariant arg) {
            return arg.ToInt();
        }
        public static implicit operator uint(QVariant arg) {
            return arg.ToUInt();
        }
        public static implicit operator long(QVariant arg) {
            return arg.ToLongLong();
        }
        public static implicit operator ulong(QVariant arg) {
            return arg.ToULongLong();
        }
        public static implicit operator bool(QVariant arg) {
            return arg.ToBool();
        }
        public static implicit operator double(QVariant arg) {
            return arg.ToDouble();
        }
        public static implicit operator string(QVariant arg) {
            return arg.ToString();
        }
        public static implicit operator QBitArray(QVariant arg) {
            return arg.ToBitArray();
        }
        public static implicit operator QByteArray(QVariant arg) {
            return arg.ToByteArray();
        }
        public static implicit operator QBrush(QVariant arg) {
            return arg.Value<QBrush>();
        }
        public static implicit operator QColor(QVariant arg) {
            return arg.Value<QColor>();
        }
        public static implicit operator QCursor(QVariant arg) {
            return arg.Value<QCursor>();
        }
        public static implicit operator QFont(QVariant arg) {
            return arg.Value<QFont>();
        }
        public static implicit operator QIcon(QVariant arg) {
            return arg.Value<QIcon>();
        }
        public static implicit operator QImage(QVariant arg) {
            return arg.Value<QImage>();
        }
        public static implicit operator QKeySequence(QVariant arg) {
            return arg.Value<QKeySequence>();
        }
        public static implicit operator QMatrix(QVariant arg) {
            return arg.Value<QMatrix>();
        }
        public static implicit operator QPalette(QVariant arg) {
            return arg.Value<QPalette>();
        }
        public static implicit operator QPen(QVariant arg) {
            return arg.Value<QPen>();
        }
        public static implicit operator QPixmap(QVariant arg) {
            return arg.Value<QPixmap>();
        }
        public static implicit operator QPolygon(QVariant arg) {
            return arg.Value<QPolygon>();
        }
        public static implicit operator QRegion(QVariant arg) {
            return arg.Value<QRegion>();
        }
        public static implicit operator QSizePolicy(QVariant arg) {
            return arg.Value<QSizePolicy>();
        }
        public static implicit operator QTextFormat(QVariant arg) {
            return arg.Value<QTextFormat>();
        }
        public static implicit operator QTextLength(QVariant arg) {
            return arg.Value<QTextLength>();
        }
        public static implicit operator QTransform(QVariant arg) {
            return arg.Value<QTransform>();
        }
    }
}

// kate: space-indent on; indent-width 4; replace-tabs on; mixed-indent off;
