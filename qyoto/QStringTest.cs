using System;
using Qt;
using System.Runtime.InteropServices;

class StringTest {
    [DllImport("libqyoto", CharSet=CharSet.Ansi)]
    static extern void Init_qyoto();

    public static void Main(String[] args) {
        Console.WriteLine("QStringTest");
    }
}
