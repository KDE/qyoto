namespace Kimono {
	using System;
	using System.Collections.Generic;
	using Qyoto;

	public partial class KPluginFactory : QObject, IDisposable {
		public T Create<T>() where T: class {
			return Create<T>((QObject) null);
		}

		public T Create<T>(QObject parent) where T: class {
			return Create<T>(parent, new List<QVariant>());
		}

		public T Create<T>(QObject parent, List<QVariant> args) where T: class {
			return Create<T>(parent.IsWidgetType()? (QWidget) parent : null, parent, string.Empty, args);
		}

		public T Create<T>(string keyword) where T: class {
			return Create<T>(keyword, (QObject) null);
		}

		public T Create<T>(string keyword, QObject parent) where T: class {
			return Create<T>(keyword, parent, new List<QVariant>());
		}

		public T Create<T>(string keyword, QObject parent, List<QVariant> args) where T: class {
			return Create<T>(parent.IsWidgetType()? (QWidget) parent : null, parent, keyword, args);
		}

		public T Create<T>(QWidget parentWidget, QObject parent) where T: class{
			return Create<T>(parentWidget, parent, string.Empty, new List<QVariant>());
		}

		public T Create<T>(QWidget parentWidget, QObject parent, string keyword) where T: class{
			return Create<T>(parentWidget, parent, keyword, new List<QVariant>());
		}

		public T Create<T>(QWidget parentWidget, QObject parent, string keyword, List<QVariant> args) where T: class {
			Type type = typeof(T);
			
			if (!SmokeMarshallers.IsSmokeClass(type))
				throw new Exception("The generic type must be included in the bindings");
			
			QObject o = Create(SmokeMarshallers.SmokeClassName(type), parentWidget, parent, args, keyword);
			T t = qobject_cast<T>(o);
			if (t == null) o.Dispose();
			return t;
		}
	}
}
