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

namespace com {
    namespace trolltech {

        public class chat : QDBusAbstractInterface {
            public static string StaticInterfaceName() { return "com.trolltech.chat"; }
    
            public chat(string service, string path, QDBusConnection connection)
                : this(service, path, connection, (QObject) null) {}

            public chat(string service, string path, QDBusConnection connection, QObject parent)
                : base(service, path, chat.StaticInterfaceName(), connection, parent)
            {
            }
    
            protected new IchatSignals Emit {
                get {
                    return (IchatSignals) Q_EMIT;
                }
            }
        }
    }
}

public interface IchatSignals : IQDBusAbstractInterfaceSignals {
    [Q_SIGNAL]
    void Message(string nickname, string text);

    [Q_SIGNAL]
    void Action(string nickname, string text);
}
