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

public class MouseMain : Qt {
    private static int MouseCount = 7;
    private static QGraphicsScene scene;
    
    public static int Main(string[] args) {
        Q_INIT_RESOURCE("mice");
        new QApplication(args);
    
        scene = new QGraphicsScene();
        scene.SetSceneRect(-300, -300, 600, 600);
        scene.itemIndexMethod = QGraphicsScene.ItemIndexMethod.NoIndex;
    
        for (int i = 0; i < MouseCount; ++i) {
            Mouse mouse = new Mouse();
            mouse.SetPos(Math.Sin((i * 6.28) / MouseCount) * 200,
                          Math.Cos((i * 6.28) / MouseCount) * 200);
            scene.AddItem(mouse);
        }
    
        QGraphicsView view = new QGraphicsView(scene);
        view.SetRenderHint(QPainter.RenderHint.Antialiasing);
        view.BackgroundBrush = new QBrush(new QPixmap(":/images/cheese.jpg"));
        view.CacheMode = (int) QGraphicsView.CacheModeFlag.CacheBackground;
        view.dragMode = QGraphicsView.DragMode.ScrollHandDrag;
        view.WindowTitle = QT_TRANSLATE_NOOP("QGraphicsView", "Colliding Mice");
        view.Resize(400, 300);
        view.Show();
    
        return QApplication.Exec();
    }
}
