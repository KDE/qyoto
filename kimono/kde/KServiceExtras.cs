namespace Kimono {
	using System;
	using System.Collections.Generic;
	using Qyoto;
	
	public partial class KService : KSycocaEntry, IDisposable {
		public T CreateInstance<T>() where T: class {
			return CreateInstance<T>(null);
		}

		public T CreateInstance<T>(QObject parent) where T: class {
			return CreateInstance<T>(parent, new List<QVariant>());
		}

		public T CreateInstance<T>(QObject parent, List<QVariant> args) where T: class {
			string error;
			return CreateInstance<T>(parent, args, out error);
		}

		public T CreateInstance<T>(QObject parent, List<QVariant> args, out string error) where T: class {
			return CreateInstance<T>(null, parent, args, out error);
		}
		
		public T CreateInstance<T>(QWidget parentWidget, QObject parent) where T: class {
			return CreateInstance<T>(parentWidget, parent, new List<QVariant>());
		}
		
		public T CreateInstance<T>(QWidget parentWidget, QObject parent, List<QVariant> args) where T: class {
			string error;
			return CreateInstance<T>(parentWidget, parent, args, out error);
		}
		
		public T CreateInstance<T>(QWidget parentWidget, QObject parent, List<QVariant> args, out string error) where T: class {
			KPluginLoader loader = new KPluginLoader(this);
			KPluginFactory factory = loader.Factory();
			if (factory != null) {
				T o = factory.Create<T>(parentWidget, parent, PluginKeyword(), args);
				if (o == null)
					error = string.Format("The service '{0}' does not provide an interface '{1}' with keyword '{2}'",
						Name(), typeof(T).ToString(), PluginKeyword());
				else
					error = null;
				return o;
			}
			error = loader.ErrorString();
			loader.Unload();
			return null;
		}
	}
}
