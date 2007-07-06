//Auto-generated by kalyptus. DO NOT EDIT.
namespace Kimono {

	using System;
	using Qyoto;
	using System.Collections.Generic;

	/// <remarks>
	///  The KLibLoader allows you to load libraries dynamically at runtime.
	///  Dependent libraries are loaded automatically.
	///  KLibLoader follows the singleton pattern. You can not create multiple
	///  instances. Use self() to get a pointer to the loader.
	/// </remarks>		<author> Torben Weis <weis@kde.org>
	///  </author>
	/// 		<short>    The KLibLoader allows you to load libraries dynamically at runtime.</short>
	/// 		<see> KLibrary</see>

	[SmokeClass("KLibLoader")]
	public class KLibLoader : QObject {
 		protected KLibLoader(Type dummy) : base((Type) null) {}
		protected new void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(KLibLoader), this);
		}
		private static SmokeInvocation staticInterceptor = null;
		static KLibLoader() {
			staticInterceptor = new SmokeInvocation(typeof(KLibLoader), null);
		}
		/// <remarks>
		///  This enum type defines the possible error cases that can happen
		///  when loading a component.
		///  <ul>
		///   <li><code>ErrNoLibrary</code> - the specified library could not be
		///       loaded. Use KLibLoader.LastErrorMessage for details.</li>
		///   <li><code>ErrNoFactory</code> - the library does not export a factory
		///       for creating components</li>
		///   <li><code>ErrNoComponent</code> - the factory does not support creating
		///       components of the specified type</li>
		///   <li><code>ErrServiceProvidesNoLibrary</code> - the specified service
		///       provides no shared library (when using KService)</li>
		///   <li><code>ErrNoServiceFound</code> - no service implementing the
		///       given servicetype and fullfilling the given constraint expression
		///       can be found (when using KServiceTypeTrader).</li>
		///  </ul>
		///      </remarks>		<short>    This enum type defines the possible error cases that can happen  when loading a component.</short>
		public enum ComponentLoadingError {
			ErrNoLibrary = 1,
			ErrNoFactory = 2,
			ErrNoComponent = 3,
			ErrServiceProvidesNoLibrary = 4,
			ErrNoServiceFound = 5,
		}
		// KLibFactory* factory(const QString& arg1,QLibrary::LoadHints arg2); >>>> NOT CONVERTED
		// KLibrary* library(const QString& arg1,QLibrary::LoadHints arg2); >>>> NOT CONVERTED
		// KLibrary* library(const QString& arg1); >>>> NOT CONVERTED
		// template <typename T>  T* createInstance(const QString& arg1,QObject* arg2,const QStringList& arg3,int* arg4); >>>> NOT CONVERTED
		// template <typename T>  T* createInstance(const QString& arg1,QObject* arg2,const QStringList& arg3); >>>> NOT CONVERTED
		// template <typename T>  T* createInstance(const QString& arg1,QObject* arg2); >>>> NOT CONVERTED
		// template <typename T>  T* createInstance(const QString& arg1); >>>> NOT CONVERTED
		/// <remarks>
		///  Loads and initializes a library. Loading a library multiple times is
		///  handled gracefully.
		///  This is a convenience function that returns the factory immediately
		/// <param> name="libname" This is the library name without extension. Usually that is something like
		///                  "libkspread". The function will then search for a file named
		///                  "libkspread.la" in the KDE library paths.
		///                  The .la files are created by libtool and contain
		///                  important information especially about the libraries dependencies
		///                  on other shared libs. Loading a "libfoo.so" could not solve the
		///                  dependencies problem.
		/// </param>                 You can, however, give a library name ending in ".so"
		///                  (or whatever is used on your platform), and the library
		///                  will be loaded without resolving dependencies. Use with caution.
		/// </remarks>		<return> the KLibFactory, or 0 if the library does not exist or it does
		///          not have a factory
		/// </return>
		/// 		<short>    Loads and initializes a library.</short>
		/// 		<see> library</see>
		public KLibFactory Factory(string libname) {
			return (KLibFactory) interceptor.Invoke("factory$", "factory(const QString&)", typeof(KLibFactory), typeof(string), libname);
		}
		/// <remarks>
		///  Loads and initializes a library. Loading a library multiple times is
		///  handled gracefully.
		/// <param> name="libname" This is the library name without extension. Usually that is something like
		///                  "libkspread". The function will then search for a file named
		///                  "libkspread.la" in the KDE library paths.
		///                  The .la files are created by libtool and contain
		///                  important information especially about the libraries dependencies
		///                  on other shared libs. Loading a "libfoo.so" could not solve the
		///                  dependencies problem.
		/// </param>                 You can, however, give a library name ending in ".so"
		///                  (or whatever is used on your platform), and the library
		///                  will be loaded without resolving dependencies. Use with caution.
		/// </remarks>		<return> KLibrary is invalid (0) when the library couldn't be dlopened. in such
		///  a case you can retrieve the error message by calling KLibLoader.LastErrorMessage()
		/// </return>
		/// 		<short>    Loads and initializes a library.</short>
		/// 		<see> factory</see>
		/// <remarks>
		///  Returns an error message that can be useful to debug the problem.
		///  Returns string() if the last call to library() was successful.
		///  You can call this function more than once. The error message is only
		///  reset by a new call to library().
		/// </remarks>		<return> the last error message, or string() if there was no error
		///      </return>
		/// 		<short>    Returns an error message that can be useful to debug the problem.</short>
		public string LastErrorMessage() {
			return (string) interceptor.Invoke("lastErrorMessage", "lastErrorMessage() const", typeof(string));
		}
		/// <remarks>
		///  Unloads the library with the given name.
		/// <param> name="libname" This is the library name without extension. Usually that is something like
		///                  "libkspread". The function will then search for a file named
		///                  "libkspread.la" in the KDE library paths.
		///                  The .la files are created by libtool and contain
		///                  important information especially about the libraries dependencies
		///                  on other shared libs. Loading a "libfoo.so" could not solve the
		///                  dependencies problem.
		/// </param>                 You can, however, give a library name ending in ".so"
		///                  (or whatever is used on your platform), and the library
		///                  will be loaded without resolving dependencies. Use with caution.
		///      </remarks>		<short>    Unloads the library with the given name.</short>
		public void UnloadLibrary(string libname) {
			interceptor.Invoke("unloadLibrary$", "unloadLibrary(const QString&)", typeof(void), typeof(string), libname);
		}
		/// <remarks>
		///  Returns a pointer to the factory. Use this function to get an instance
		///  of KLibLoader.
		/// </remarks>		<return> a pointer to the loader. If no loader exists until now
		///          then one is created.
		///      </return>
		/// 		<short>    Returns a pointer to the factory.</short>
		public static KLibLoader Self() {
			return (KLibLoader) staticInterceptor.Invoke("self", "self()", typeof(KLibLoader));
		}
		/// <remarks>
		///  Helper method which looks for a library in the standard paths
		///  ("module" and "lib" resources).
		///  Made public for code that doesn't use KLibLoader itself, but still
		///  wants to open modules.
		/// <param> name="libname" of the library. If it is not a path, the function searches in
		///                 the "module" and "lib" resources. If there is no extension,
		///                 ".la" will be appended.
		/// </param><param> name="cData" a KComponentData used to get the standard paths
		///      </param></remarks>		<short>    Helper method which looks for a library in the standard paths  ("module" and "lib" resources).</short>
		public static string FindLibrary(string libname, KComponentData cData) {
			return (string) staticInterceptor.Invoke("findLibrary$#", "findLibrary(const QString&, const KComponentData&)", typeof(string), typeof(string), libname, typeof(KComponentData), cData);
		}
		public static string FindLibrary(string libname) {
			return (string) staticInterceptor.Invoke("findLibrary$", "findLibrary(const QString&)", typeof(string), typeof(string), libname);
		}
		/// <remarks>
		///  Returns a translated error message for <code>componentLoadingError</code>
		/// <param> name="componentLoadingError" the error code, as returned in the "error"
		///  output parameter of createInstance.
		///      </param></remarks>		<short>    Returns a translated error message for <code>componentLoadingError</code> </short>
		public static string ErrorString(int componentLoadingError) {
			return (string) staticInterceptor.Invoke("errorString$", "errorString(int)", typeof(string), typeof(int), componentLoadingError);
		}
		/// <remarks>
		///  This template allows to load the specified library and ask the
		///  factory to create an instance of the given template type.
		/// <param> name="libraryName" The library to open
		/// </param><param> name="parent" The parent object (see QObject constructor)
		/// </param><param> name="args" A list of string arguments, passed to the factory and possibly
		///              to the component (see KLibFactory)
		/// </param></remarks>		<return> A pointer to the newly created object or a null pointer if the
		///          factory was unable to create an object of the given type.
		///      </return>
		/// 		<short>    This template allows to load the specified library and ask the  factory to create an instance of the given template type.</short>
		protected new IKLibLoaderSignals Emit {
			get { return (IKLibLoaderSignals) Q_EMIT; }
		}
	}

	public interface IKLibLoaderSignals : IQObjectSignals {
	}
}
