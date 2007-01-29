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
 ** Translated to C#/Qyoto by Richard Dale
 **
 ****************************************************************************/

using Qyoto;
using System;
using System.Collections.Generic;

class Ping : QObject
{
    static private string SERVICE_NAME = "com.trolltech.QtDBus.PingExample";

    public QDBusInterface iface;

    [Q_SLOT]
    public void Start(string name, string oldValue, string newValue)
    {
        if (name != SERVICE_NAME || newValue == "")
            return;

        // find our remote
        iface = new QDBusInterface(SERVICE_NAME, "/", "com.trolltech.QtDBus.ComplexPong.Pong",
                               QDBusConnection.SessionBus(), this);
        if (!iface.IsValid()) {
            Console.Error.WriteLine(QDBusConnection.SessionBus().LastError().Message());
            QCoreApplication.Quit();
        }

        Connect(iface, SIGNAL("aboutToQuit()"), QCoreApplication.Instance(), SLOT("quit()"));

        while (true) {
            Console.WriteLine("Ask your question: ");

            string line = Console.ReadLine().Trim();

            if (line == "") {
                iface.Call("quit");
                return;
            } else if (line == "value") {
                QVariant reply = iface.Property("value");
                if (!reply.IsNull())
                    Console.WriteLine("value = {0}", reply.ToString());
            } else if (line.StartsWith("value=")) {
                iface.SetProperty("value", new QVariant(line.Substring(6)));            
            } else {
               QDBusReply<QVariant> reply = new QDBusReply<QVariant>(iface.Call("query", new QVariant(line)));
                if (reply.IsValid())
                    Console.WriteLine("Reply was: {0}", reply.Value().ToString());
            }

            if (iface.LastError().IsValid())
                Console.Error.WriteLine("Call failed: {0}", iface.LastError().Message());    
        }
    }

    public static int Main(string[] args) {
        new QCoreApplication(args);

        if (!QDBusConnection.SessionBus().IsConnected()) {
            Console.Error.WriteLine("Cannot connect to the D-BUS session bus.\n" +
                "To start it, run:\n" +
                "\teval `dbus-launch --auto-syntax`\n");
            return 1;
        }

        Ping ping = new Ping();
        ping.Connect(QDBusConnection.SessionBus().Interface(),
                     SIGNAL("serviceOwnerChanged(QString,QString,QString)"),
                     SLOT("Start(QString,QString,QString)"));

        QProcess pong = new QProcess();
        pong.Start("mono ./complexpong.exe");

        return QCoreApplication.Exec();
    }
}

