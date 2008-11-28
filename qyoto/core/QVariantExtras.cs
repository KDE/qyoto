namespace Qyoto {

    using System;
    using System.Collections;
    using System.Collections.Generic; 
    using System.Text;
    using System.Runtime.InteropServices;

    public partial class QVariant : Object, IDisposable {

        [DllImport("libqyoto", CharSet=CharSet.Ansi)]
        static extern IntPtr QVariantValue(string typeName, IntPtr variant);

        [DllImport("libqyoto", CharSet=CharSet.Ansi)]
        static extern IntPtr QVariantFromValue(int type, IntPtr value);

        public T Value<T>() {
            if (typeof(T) == typeof(bool)) {
                return (T) (object) ToBool();
            } else if (typeof(T) == typeof(double)) {
                return (T) (object) ToDouble();
            } else if (typeof(T) == typeof(QBitArray)) {
                return (T) (object) ToBitArray();
            } else if (typeof(T) == typeof(QByteArray)) {
                return (T) (object) ToByteArray();
            } else if (typeof(T) == typeof(char)) {
                return (T) (object) ToChar();
            } else if (typeof(T) == typeof(QDate)) {
                return (T) (object) ToDate();
            } else if (typeof(T) == typeof(QDateTime)) {
                return (T) (object) ToDateTime();
            } else if (typeof(T) == typeof(int)) {
                return (T) (object) ToInt();
            } else if (typeof(T) == typeof(QLine)) {
                return (T) (object) ToLine();
            } else if (typeof(T) == typeof(QLineF)) {
                return (T) (object) ToLineF();
            } else if (typeof(T) == typeof(QLocale)) {
                return (T) (object) ToLocale();
            } else if (typeof(T) == typeof(QPoint)) {
                return (T) (object) ToPoint();
            } else if (typeof(T) == typeof(QPointF)) {
                return (T) (object) ToPointF();
            } else if (typeof(T) == typeof(QRect)) {
                return (T) (object) ToRect();
            } else if (typeof(T) == typeof(QRectF)) {
                return (T) (object) ToRectF();
            } else if (typeof(T) == typeof(QRegExp)) {
                return (T) (object) ToRegExp();
            } else if (typeof(T) == typeof(QSize)) {
                return (T) (object) ToSize();
            } else if (typeof(T) == typeof(QSizeF)) {
                return (T) (object) ToSizeF();
            } else if (typeof(T) == typeof(string)) {
                return (T) (object) ToString();
            } else if (typeof(T) == typeof(List<string>)) {
                return (T) (object) ToStringList();
            } else if (typeof(T) == typeof(QTime)) {
                return (T) (object) ToTime();
            } else if (typeof(T) == typeof(uint)) {
                return (T) (object) ToUInt();
            } else if (typeof(T) == typeof(QUrl)) {
                return (T) (object) ToUrl();
            } else if (typeof(T) == typeof(QVariant)) {
                return (T) (object) this;
            } else if (typeof(T).IsEnum) {
                return (T) (object) ToInt();
            } else {
                string typeName = typeof(T).ToString().Replace("Qyoto.", "");
                if (NameToType(typeName) > TypeOf.LastCoreType) {
                    IntPtr instancePtr = QVariantValue(typeName, (IntPtr) GCHandle.Alloc(this));
                    return (T) ((GCHandle) instancePtr).Target;
                }

                return (T) (object) default(T);
            }
        }

        static public QVariant FromValue<T>(object value) {
            if (typeof(T) == typeof(bool)) {
                return new QVariant((bool) value);
            } else if (typeof(T) == typeof(double)) {
                return new QVariant((double) value);
            } else if (typeof(T) == typeof(QBitArray)) {
                return new QVariant((QBitArray) value);
            } else if (typeof(T) == typeof(QByteArray)) {
                return new QVariant((QByteArray) value);
            } else if (typeof(T) == typeof(char)) {
                return new QVariant((char) value);
            } else if (typeof(T) == typeof(QDate)) {
                return new QVariant((QDate) value);
            } else if (typeof(T) == typeof(QDateTime)) {
                return new QVariant((QDateTime) value);
            } else if (typeof(T) == typeof(int)) {
                return new QVariant((int) value);
            } else if (typeof(T) == typeof(QLine)) {
                return new QVariant((QLine) value);
            } else if (typeof(T) == typeof(QLineF)) {
                return new QVariant((QLineF) value);
            } else if (typeof(T) == typeof(QLocale)) {
                return new QVariant((QLocale) value);
            } else if (typeof(T) == typeof(QPoint)) {
                return new QVariant((QPoint) value);
            } else if (typeof(T) == typeof(QPointF)) {
                return new QVariant((QPointF) value);
            } else if (typeof(T) == typeof(QRect)) {
                return new QVariant((QRect) value);
            } else if (typeof(T) == typeof(QRectF)) {
                return new QVariant((QRectF) value);
            } else if (typeof(T) == typeof(QRegExp)) {
                return new QVariant((QRegExp) value);
            } else if (typeof(T) == typeof(QSize)) {
                return new QVariant((QSize) value);
            } else if (typeof(T) == typeof(QSizeF)) {
                return new QVariant((QSizeF) value);
            } else if (typeof(T) == typeof(string)) {
                return new QVariant((string) value);
            } else if (typeof(T) == typeof(List<string>)) {
                return new QVariant((List<string>) value);
            } else if (typeof(T) == typeof(QTime)) {
                return new QVariant((QTime) value);
            } else if (typeof(T) == typeof(uint)) {
                return new QVariant((uint) value);
            } else if (typeof(T) == typeof(QUrl)) {
                return new QVariant((QUrl) value);
            } else if (typeof(T) == typeof(QVariant)) {
                return new QVariant((QVariant) value);
            } else if (typeof(T).IsEnum) {
                return new QVariant((int) value);
            } else {
                string typeName = typeof(T).ToString().Replace("Qyoto.", "");
                if (NameToType(typeName) > TypeOf.LastCoreType) {
                    IntPtr instancePtr =  QVariantFromValue((int) NameToType(typeName), (IntPtr) GCHandle.Alloc(value));
                    return (QVariant) ((GCHandle) instancePtr).Target;
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
