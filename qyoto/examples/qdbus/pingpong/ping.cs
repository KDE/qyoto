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

class Ping 
{
    static private string SERVICE_NAME = "com.trolltech.QtDBus.PingExample";

    public static int Main(string[] args) {
        new QCoreApplication(args);

        if (!QDBusConnection.SessionBus().IsConnected()) {
            Console.WriteLine("Cannot connect to the D-BUS session bus.\n" +
                "To start it, run:\n" +
                "\teval `dbus-launch --auto-syntax`\n");
            return 1;
        }

        QDBusInterface iface = new QDBusInterface(SERVICE_NAME, "/", "", QDBusConnection.SessionBus());
        if (iface.IsValid()) {
            QDBusReply<string> reply = new QDBusReply<string>(iface.Call("Ping", new QVariant(args.Length > 0 ? args[0] : "")));
            if (reply.IsValid()) {
                Console.WriteLine("Reply was: {0}", reply.Value());
                Qyoto.Qyoto.DeleteQApp();
                return 0;
            }

            Console.WriteLine("Call failed: {0}\n", reply.Error().Message());
            Qyoto.Qyoto.DeleteQApp();
            return 1;
        }

        Console.WriteLine(QDBusConnection.SessionBus().LastError().Message());
        Qyoto.Qyoto.DeleteQApp();
        return 1;
    }
}

