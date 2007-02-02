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

namespace com {
    namespace trolltech {
        namespace Examples {
            public class CarInterface : QDBusAbstractInterface
                public static StaticInterfaceName()
                { return "com.trolltech.Examples.CarInterface"; }
    
                CarInterface(string service, string path, QDBusConnection connection, QObject parent)
                    : base(service, path, StaticInterfaceName(), connection, parent)
                {
                }
    
                [Q_SLOT]
                QDBusReply<void> accelerate()
                {
                    List<QVariant> argumentList = new List<QVariant>;
                    return callWithArgumentList(QDBus.CallMode.Block, "accelerate", argumentList);
                }
            
                [Q_SLOT]
                QDBusReply<void> decelerate()
                {
                    List<QVariant> argumentList = new List<QVariant>;
                    return callWithArgumentList(QDBus.CallMode.Block, "decelerate", argumentList);
                }
            
                [Q_SLOT]
                QDBusReply<void> turnLeft()
                {
                    List<QVariant> argumentList = new List<QVariant>;
                    return callWithArgumentList(QDBus.CallMode.Block, "turnLeft", argumentList);
                }
            
                [Q_SLOT]
                QDBusReply<void> turnRight()
                {
                    List<QVariant> argumentList = new List<QVariant>;
                    return callWithArgumentList(QDBus.CallMode.Block, "turnRight", argumentList);
                }
    
        [Q_SIGNAL] // SIGNALS
        void crashed();
            }
        }
    }    
}
