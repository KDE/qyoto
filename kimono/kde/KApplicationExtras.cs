namespace Kimono {
    using System;
    using Qyoto;

    public partial class KApplication : QApplication, IDisposable {
        /// <remarks>
        ///  This constructor is the one you should use.
        ///  It takes aboutData and command line arguments from KCmdLineArgs.
        /// <param> name="GUIenabled" Set to false to disable all GUI stuff.
        ///  Note that for a non-GUI daemon, you might want to use QCoreApplication
        ///  and a KComponentData instance instead. The main difference will be
        ///  that you'll have to register to DBus yourself, but there is no
        ///  point in a kdeui dependency in a non-GUI daemon.
        ///    </param></remarks>        <short>    This constructor is the one you should use.</short>
        public KApplication(bool GUIenabled) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KApplication$", "KApplication(bool)", typeof(void), typeof(bool), GUIenabled);
            qApp = this;
        }
        public KApplication() : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KApplication", "KApplication()", typeof(void));
            qApp = this;
        }
        /// <remarks>
        ///    </remarks>        <short>   </short>
        public KApplication(bool GUIenabled, KComponentData cData) : this((Type) null) {
            CreateProxy();
            interceptor.Invoke("KApplication$#", "KApplication(bool, const KComponentData&)", typeof(void), typeof(bool), GUIenabled, typeof(KComponentData), cData);
            qApp = this;
        }
    }
}
