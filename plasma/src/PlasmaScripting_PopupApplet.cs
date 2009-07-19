/*
 *   Copyright 2009 by Richard Dale <richard.j.dale@gmail.com>
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

namespace PlasmaScripting {
    using Plasma;
    using System;
    using Kimono;
    using QyotoQGraphicsWidget = Qyoto.QGraphicsWidget;
    using Qyoto;
    using System.Collections.Generic;
    using System.Reflection;
    /// <remarks>
    ///  Allows applets to automatically 'collapse' into an icon when put in an panel, and is a convenient
    ///  base class for any applet that wishes to use extenders.
    ///  Applets that subclass this class should implement either widget() or graphicsWidget() to return a
    ///  widget that will be displayed in the applet if the applet is in a Planar or MediaCenter form
    ///  factor. If the applet is put in a panel, an icon will be displayed instead, which shows the
    ///  widget in a popup when clicked.
    ///  If you use this class as a base class for your extender using applet, the extender will
    ///  automatically be used for the popup; reimplementing graphicsWidget() is unnecessary in this case.
    ///  </remarks>        <short>    Allows applets to automatically 'collapse' into an icon when put in an panel, and is a convenient  base class for any applet that wishes to use extenders.</short>
    public class PopupApplet : PlasmaScripting.Applet, IDisposable {
        protected Plasma.PopupApplet popupApplet;

        public Plasma.PopupApplet PlasmaPopupApplet {
            get { return popupApplet; }
        }

        public PopupApplet(AppletScript parent) : base(parent) {
            popupApplet = (Plasma.PopupApplet) parent.Applet();
        }

        /// <remarks>
        ///  @arg icon the icon that has to be displayed when the applet is in a panel.
        ///      </remarks>        <short>    @arg icon the icon that has to be displayed when the applet is in a panel.</short>
        public void SetPopupIcon(QIcon icon) {
            popupApplet.SetPopupIcon(icon);
        }

        /// <remarks>
        ///  @arg icon the icon that has to be displayed when the applet is in a panel.
        ///      </remarks>        <short>    @arg icon the icon that has to be displayed when the applet is in a panel.</short>
        public void SetPopupIcon(string iconName) {
            popupApplet.SetPopupIcon(iconName);
        }

        /// <remarks>
        /// </remarks>        <return> the icon that is displayed when the applet is in a panel.
        ///      </return>
        ///         <short>   </short>
        public QIcon PopupIcon() {
            return popupApplet.PopupIcon();
        }

        public QWidget Widget {
            get { return popupApplet.Widget(); }
            set { popupApplet.SetWidget(value); }
        }

        public QyotoQGraphicsWidget GraphicsWidget {
            get { return popupApplet.GraphicsWidget(); }
            set { popupApplet.SetGraphicsWidget(value); }
        }

        /// <remarks>
        /// </remarks>        <return> the placement of the popup relating to the icon
        ///      </return>
        ///         <short>   </short>
        public Plasma.PopupPlacement popupPlacement() {
            return popupApplet.popupPlacement();
        }

        /// <remarks>
        ///  Sets whether or not the dialog popup that gets created should be a "passive" popup
        ///  that does not steal focus from other windows or not. 
        ///  @arg passive true if the dialog should be treated as a passive popup
        ///      </remarks>        <short>    Sets whether or not the dialog popup that gets created should be a "passive" popup  that does not steal focus from other windows or not.</short>
        public void SetPassivePopup(bool passive) {
            popupApplet.SetPassivePopup(passive);
        }

        /// <remarks>
        /// </remarks>        <return> true if the dialog will be treated as a passive poup
        ///      </return>
        ///         <short>   </short>
        public bool IsPassivePopup() {
            return popupApplet.IsPassivePopup();
        }

        /// <remarks>
        /// </remarks>        <return> true if the applet is popped up
        ///      </return>
        ///         <short>   </short>
        public bool IsPopupShowing() {
            return popupApplet.IsPopupShowing();
        }

        /// <remarks>
        ///  Hides the popup.
        ///      </remarks>        <short>    Hides the popup.</short>
        [Q_SLOT("void hidePopup()")]
        public void HidePopup() {
            popupApplet.HidePopup();
        }

        /// <remarks>
        ///  Shows the dialog showing the widget if the applet is in a panel.
        ///  @arg displayTime the time in ms that the popup should be displayed, defaults to 0 which means
        ///  always (until the user closes it again, that is).
        ///      </remarks>        <short>    Shows the dialog showing the widget if the applet is in a panel.</short>
        [Q_SLOT("void showPopup(uint)")]
        public void ShowPopup(uint displayTime) {
            popupApplet.ShowPopup(displayTime);
        }

        [Q_SLOT("void showPopup()")]
        public void ShowPopup() {
            popupApplet.ShowPopup();
        }

        /// <remarks>
        ///  Toggles the popup.
        ///      </remarks>        <short>    Toggles the popup.</short>
        [Q_SLOT("void togglePopup()")]
        public void TogglePopup() {
            popupApplet.TogglePopup();
        }

        public new void Dispose() {
        }

        protected new IPopupAppletSignals Emit {
            get { return (IPopupAppletSignals) Q_EMIT; }
        }
        public static implicit operator Plasma.PopupApplet(PopupApplet arg) {
            return arg.PlasmaPopupApplet;
        }
        public static implicit operator QyotoQGraphicsWidget(PopupApplet arg) {
            return arg.PlasmaPopupApplet;
        }
    }

    public interface IPopupAppletSignals : PlasmaScripting.IAppletSignals {
    }
}
