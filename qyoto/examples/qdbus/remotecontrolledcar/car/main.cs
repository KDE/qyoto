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

public class CarMain {
    public static int Main(string[] args) {
        new QApplication(args);
    
        QGraphicsScene scene = new QGraphicsScene();
        scene.SetSceneRect(-500, -500, 1000, 1000);
        scene.itemIndexMethod = QGraphicsScene.ItemIndexMethod.NoIndex;
    
        Car car = new Car();
        scene.AddItem(car);
    
        QGraphicsView view = new QGraphicsView(scene);
        view.SetRenderHint(QPainter.RenderHint.Antialiasing);
        view.BackgroundBrush = new QBrush(Qt.GlobalColor.darkGray);
        view.WindowTitle = "Qt DBus Controlled Car";
//        view.SetWindowTitle(QT_TRANSLATE_NOOP(QGraphicsView, "Qt DBus Controlled Car"));
        view.Resize(400, 300);
        view.Show();
    
        CarAdaptor adaptor = new CarAdaptor(car);
        QDBusConnection connection = QDBusConnection.SessionBus();
        connection.RegisterObject("/Car", adaptor);
        connection.RegisterService("com.trolltech.CarExample");
    
        return QApplication.Exec();
    }
}
