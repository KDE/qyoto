namespace Kimono {
    using System;
    using Qyoto;
    public partial class KUniqueApplication : KApplication, IDisposable {
        /// <remarks>
        ///  Constructor. Takes command line arguments from KCmdLineArgs
        /// <param> name="GUIenabled" Set to false to disable all GUI stuff. This implies
        ///  no styles either.
        /// </param><param> name="configUnique" If true, the uniqueness of the application will
        ///                  depend on the value of the "MultipleInstances"
        ///                  key in the "KDE" group of the application config file.
        ///    </param></remarks>        <short>    Constructor.</short>
        public KUniqueApplication(bool GUIenabled, bool configUnique) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KUniqueApplication$$", "KUniqueApplication(bool, bool)", typeof(void), typeof(bool), GUIenabled, typeof(bool), configUnique);
        }
        public KUniqueApplication(bool GUIenabled) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KUniqueApplication$", "KUniqueApplication(bool)", typeof(void), typeof(bool), GUIenabled);
        }
        public KUniqueApplication() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KUniqueApplication", "KUniqueApplication()", typeof(void));
        }
    }
}
