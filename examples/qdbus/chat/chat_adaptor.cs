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
    
[Q_CLASSINFO("D-Bus Interface", "com.trolltech.chat")]
[Q_CLASSINFO("D-Bus Introspection", "" +
    "  <interface name=\"com.trolltech.chat\" >\n" +
    "    <signal name=\"message\" >\n" +
    "      <arg direction=\"out\" type=\"s\" name=\"nickname\" />\n" +
    "      <arg direction=\"out\" type=\"s\" name=\"text\" />\n" +
    "    </signal>\n" +
    "    <signal name=\"action\" >\n" +
    "      <arg direction=\"out\" type=\"s\" name=\"nickname\" />\n" +
    "      <arg direction=\"out\" type=\"s\" name=\"text\" />\n" +
    "    </signal>\n" +
    "  </interface>\n")]
public class ChatAdaptor : QDBusAbstractAdaptor {
    
    public ChatAdaptor(QObject parent) : base(parent)
    {
        SetAutoRelaySignals(true);
    }
    
    protected new IChatAdaptorSignals Emit {
        get {
            return (IChatAdaptorSignals) Q_EMIT;
        }
    }
}

public interface IChatAdaptorSignals : IQDBusAbstractAdaptorSignals {
    [Q_SIGNAL]
    void Message(string nickname, string text);

    [Q_SIGNAL]
    void Action(string nickname, string text);
}
