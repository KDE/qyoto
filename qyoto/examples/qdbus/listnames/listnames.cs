/****************************************************************************
 **
 ** Copyright (C) 1992-2006 Trolltech ASA. All rights reserved.
 **
 ** This file is part of the example classes of the Qt Toolkit.
 **
 ** This file may be used under the terms of the GNU General Public
 ** License version 2.0 as published by the Free Software Foundation
 ** and appearing in the file LICENSE.GPL included in the packaging of
 ** this file.  Please review the following information to ensure GNU
 ** General Public Licensing requirements will be met:
 ** http://www.trolltech.com/products/qt/opensource.html
 **
 ** If you are unsure which license is appropriate for your use, please
 ** review the following information:
 ** http://www.trolltech.com/products/qt/licensing.html or contact the
 ** sales department at sales@trolltech.com.
 **
 ** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
 ** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
 **
 ****************************************************************************/

/* Converted to C#/Qyoto by Richard Dale */

using Qyoto;
using System;
using System.Collections.Generic;

class ListNames {

    public static void Method1() {
        Console.WriteLine("Method 1:");

        QDBusReply<List<string>> reply = QDBusConnection.SessionBus().Interface().RegisteredServiceNames();
        if (!reply.IsValid()) {
            Console.WriteLine("Error:{0}", reply.Error().Message());
            return;
        }
        foreach (string name in reply.Value())
            Console.WriteLine(name);
    }

    public static void Method2() {
        Console.WriteLine("Method 2:");

        QDBusConnection bus = QDBusConnection.SessionBus();
        QDBusInterface dbus_iface = new QDBusInterface("org.freedesktop.DBus", "/org/freedesktop/DBus",
                                "org.freedesktop.DBus", bus);
        foreach (string name in dbus_iface.Call("ListNames").Arguments()[0].Value<List<string>>()) {
            Console.WriteLine(name);
        }
    }

    public static void Method3() {
        Console.WriteLine("Method 3:");
        foreach (string name in QDBusConnection.SessionBus().Interface().RegisteredServiceNames().Value())
            Console.WriteLine(name);
    }

    public static int Main(string[] args) {
        new QCoreApplication(args);

        if (!QDBusConnection.SessionBus().IsConnected()) {
            Console.WriteLine("Cannot connect to the D-BUS session bus.\n" +
                "To start it, run:\n" +
                "\teval `dbus-launch --auto-syntax`\n");
            return 1;
        }

        Method1();
        Method2();
        Method3();

        return 0;
    }
}

