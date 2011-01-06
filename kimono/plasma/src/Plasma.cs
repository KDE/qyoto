namespace Plasma {
    using Qyoto;
    using System;
    using System.Runtime.InteropServices;

    public class InitPlasma {
        [DllImport("libplasma-sharp", CharSet=CharSet.Ansi)]
        static extern void Init_plasma();
        
        public static void InitSmoke() {
            Init_plasma();
        }
    }
}
