namespace Kimono {
	using System;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	using Qyoto;

	public partial class KPluginFactory : QObject, IDisposable {
		[DllImport("kimono", CharSet=CharSet.Ansi)]
		static extern IntPtr KPluginFactory_Create(IntPtr self, string classname, IntPtr parentWidget, IntPtr parent, IntPtr[] args, int numArgs, string keyword);

		public T Create<T>() where T: class {
			return Create<T>((QObject) null);
		}

		public T Create<T>(QObject parent) where T: class {
			return Create<T>(parent, new List<QVariant>());
		}

		public T Create<T>(QObject parent, List<QVariant> args) where T: class {
			if (parent == null)
				return Create<T>(null, parent, string.Empty, args);
			else
				return Create<T>(parent.IsWidgetType()? (QWidget) parent : null, parent, string.Empty, args);
		}

		public T Create<T>(string keyword) where T: class {
			return Create<T>(keyword, (QObject) null);
		}

		public T Create<T>(string keyword, QObject parent) where T: class {
			return Create<T>(keyword, parent, new List<QVariant>());
		}

		public T Create<T>(string keyword, QObject parent, List<QVariant> args) where T: class {
			if (parent == null)
				return Create<T>(null, parent, keyword, args);
			else
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
			
			IntPtr[] array = new IntPtr[args.Count];
			for (int i = 0; i < args.Count; i++) {
				array[i] = (IntPtr) GCHandle.Alloc(args[i]);
			}
			
			IntPtr pw = IntPtr.Zero;
			if (parentWidget != null)
				pw = (IntPtr) GCHandle.Alloc(parentWidget);

			IntPtr p = IntPtr.Zero;
			if (parent != null)
				p = (IntPtr) GCHandle.Alloc(parent);

			IntPtr ret = KPluginFactory_Create((IntPtr) GCHandle.Alloc(this), SmokeMarshallers.SmokeClassName(type), pw, p,
			                                   array, array.Length, keyword);
			QObject o = (ret != IntPtr.Zero) ? (QObject) ((GCHandle) ret).Target : null;
			T t = qobject_cast<T>(o);
			if (t == null && o != null)
				o.Dispose();
			return t;
		}
	}
}
