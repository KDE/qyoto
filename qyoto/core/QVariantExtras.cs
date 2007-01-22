namespace Qyoto {

	using System;
	using System.Collections;
	using System.Collections.Generic; 
	using System.Text;

	public partial class QVariant : MarshalByRefObject, IDisposable {

		public T Value<T>() {
			if (typeof(T) == typeof(bool)) {
				return (T) (object) ToBool();
			} else if (typeof(T) == typeof(double)) {
				return (T) (object) ToDouble();
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
			} else {
				return (T) (object) default(T);
			}
		}

		static public QVariant FromValue<T>(object value) {
			if (typeof(T) == typeof(bool)) {
				return new QVariant((bool) value);
			} else if (typeof(T) == typeof(double)) {
				return new QVariant((double) value);
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
			} else {
				return new QVariant();
			}
		}
	}
}