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
 ** Translated to C#/Qyoto by Richard Dale
 **
 ****************************************************************************/

using Qyoto;
using System;
using System.Collections.Generic;

[Q_CLASSINFO("D-Bus Interface", "com.trolltech.QtDBus.ComplexPong.Pong")]
class Pong : QDBusAbstractAdaptor 
{
    public string m_value;

    static private string SERVICE_NAME = "com.trolltech.QtDBus.PingExample";

    Pong(QObject obj) : base(obj) { }

    [Q_PROPERTY]
    public string value {
        get {
            return m_value;
        }
        set {
            m_value = value;
        }
    }

    [Q_SLOT]
    public void quit()
    {
        QTimer.singleShot(0, QCoreApplication.Instance(), SLOT("quit()"));
    }

    [Q_SLOT]
    public QDBusVariant query(string query)
    {
        string q = query.ToLower();

        if (q == "hello")
            return new QDBusVariant("World");
//            return new QDBusVariant("World");
        if (q == "ping")
            return new QDBusVariant("Pong");
        if (q == "the answer to life, the universe and everything")
            return new QDBusVariant(42);
        if (q.IndexOf("unladen swallow") != -1) {
            if (q.IndexOf("european") != -1)
                return new QDBusVariant(11.0);
            return new QDBusVariant(new QByteArray("african or european?"));
        }

        return new QDBusVariant("Sorry, I don't know the answer");
    }

    public static int Main(string[] args) {
        QCoreApplication app = new QCoreApplication(args);

        QObject obj = new QObject();
        Pong pong = new Pong(obj);
        pong.Connect(app, SIGNAL("aboutToQuit()"), SIGNAL("aboutToQuit()"));
        pong.value = "initial value";
        QDBusConnection.SessionBus().RegisterObject("/", obj);

        if (!QDBusConnection.SessionBus().RegisterService(SERVICE_NAME)) {
            Console.Error.WriteLine(QDBusConnection.SessionBus().LastError().Message());
            return(1);
        }

        return QCoreApplication.Exec();
    }

    protected new IPongSignals Emit {
        get {
            return (IPongSignals) Q_EMIT;
        }
    }
}

interface IPongSignals : IQDBusAbstractAdaptorSignals {
    [Q_SIGNAL]
    void aboutToQuit();
}

