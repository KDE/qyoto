/*
 *   Copyright 2008 by Richard Dale <richard.j.dale@gmail.com>
 *   Copyright 2008, Arno Rehn <arno@arnorehn.de>
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Library General Public License as
 *   published by the Free Software Foundation; either version 2, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details
 *
 *   You should have received a copy of the GNU Library General Public
 *   License along with this program; if not, write to the
 *   Free Software Foundation, Inc.,
 *   51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

namespace PlasmaScriptengineKimono {

    using System;
    using System.Text;
    using System.Reflection;
    using System.Collections.Generic;

    using Qyoto;
    using Kimono;
    using Plasma;

    public class Applet : Plasma.AppletScript {
        private PlasmaScripting.Applet applet;
        private Assembly appletAssembly;
        private Type appletType;
        private Dictionary<QEvent.TypeOf, MethodInfo> eventHandlers = new Dictionary<QEvent.TypeOf, MethodInfo>();

        public Applet(QObject parent, List<QVariant> args) : base(parent) {}

        public override bool Init() {
            Applet().Resize(200, 200);
            QFileInfo program = new QFileInfo(MainScript());

            appletAssembly = Assembly.LoadFile(program.AbsoluteFilePath());
            Console.WriteLine("Loading main script {0}", program.AbsoluteFilePath());
            string typeName = Camelize(Package().Metadata().PluginName()) + ".";  // namespace
            typeName += Camelize(program.CompleteBaseName());
            Console.WriteLine("GetType() for {0}", typeName);
            appletType = appletAssembly.GetType(typeName);

            applet = (PlasmaScripting.Applet) Activator.CreateInstance(appletType, new object[] { this });
            applet.Init();
            SetUpEventHandlers();
            return true;
        }

        public override void PaintInterface(QPainter painter, QStyleOptionGraphicsItem option, QRect contentsRect) {
            applet.PaintInterface(painter, option, contentsRect);
            return;
        }

        public override void ConstraintsEvent(uint constraints) {
            applet.ConstraintsEvent(constraints);
            return;
        }

        public override List<QAction> ContextualActions() {
            return applet.ContextualActions();
        }

        public override void ShowConfigurationInterface() {
            applet.ShowConfigurationInterface();
        }

        protected new virtual bool EventFilter(QObject o, QEvent e) {
            MethodInfo eventHandler;
            if (!eventHandlers.TryGetValue(e.type(), out eventHandler)) {
                return false;
            }

            Object[] args = new Object[1];
            args[0] = e;
            eventHandler.Invoke(applet, args);
            return true;
        }

        private void SetUpEventHandlers() {
            Type[] paramTypes = new Type[1];
            MethodInfo eventHandler = null;
            Assembly assembly = null;

            foreach(Assembly a in AppDomain.CurrentDomain.GetAssemblies()) {
                if (a.FullName.StartsWith("qt-dotnet"))
                    assembly = a;
            }
            if (assembly == null) {
                // shouldn't happen
                Console.WriteLine("Couldn't find qt-dotnet assembly!");
                return;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneContextMenuEvent");
            eventHandler = appletType.GetMethod("ContextMenuEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneContextMenu] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneDragDropEvent");
            eventHandler = appletType.GetMethod("DragEnterEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneDragEnter] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneDragDropEvent");
            eventHandler = appletType.GetMethod("DragLeaveEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneDragLeave] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneDragDropEvent");
            eventHandler = appletType.GetMethod("DragMoveEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneDragMove] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneDragDropEvent");
            eventHandler = appletType.GetMethod("DropEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneDrop] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QFocusEvent");
            eventHandler = appletType.GetMethod("FocusInEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.FocusIn] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QFocusEvent");
            eventHandler = appletType.GetMethod("FocusOutEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.FocusOut] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneHoverEvent");
            eventHandler = appletType.GetMethod("HoverEnterEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneHoverEnter] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneHoverEvent");
            eventHandler = appletType.GetMethod("HoverMoveEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneHoverMove] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneHoverEvent");
            eventHandler = appletType.GetMethod("HoverLeaveEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneHoverLeave] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QKeyEvent");
            eventHandler = appletType.GetMethod("KeyPressEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.KeyPress] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QKeyEvent");
            eventHandler = appletType.GetMethod("KeyReleaseEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.KeyRelease] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneMouseEvent");
            eventHandler = appletType.GetMethod("MousePressEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneMousePress] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneMouseEvent");
            eventHandler = appletType.GetMethod("MouseMoveEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneMouseMove] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneMouseEvent");
            eventHandler = appletType.GetMethod("MouseReleaseEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneMouseRelease] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneMouseEvent");
            eventHandler = appletType.GetMethod("MouseDoubleClickEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneMouseDoubleClick] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QGraphicsSceneWheelEvent");
            eventHandler = appletType.GetMethod("WheelEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.GraphicsSceneWheel] = eventHandler;
            }

            paramTypes[0] = assembly.GetType("Qyoto.QInputMethodEvent");
            eventHandler = appletType.GetMethod("InputMethodEvent", paramTypes);
            if (eventHandler != null) {
                eventHandlers[QEvent.TypeOf.InputMethod] = eventHandler;
            }

            if (eventHandlers.Count > 0) {
                Applet().InstallEventFilter(this);
            }
        }

        private string Camelize(string str) {
            StringBuilder ret = new StringBuilder(str.Substring(0, 1).ToUpper());
            for (int i = 1; i < str.Length; i++) {
                if (str[i] == '_' || str[i] == '-') {
                    i++;
                    if (i < str.Length)
                        ret.Append(str.Substring(i, 1).ToUpper());
                } else {
                    ret.Append(str[i]);
                }
            }
            return ret.ToString();
        }
    }
}
