namespace KimonoAppletScript {
	using Plasma;
	using System;
	using Kimono;
	using Qyoto;
	using System.Collections.Generic;

	public class Applet : Plasma.AppletScript {
		private PlasmaScripting.Applet applet;

		public AppletScript(QObject parent, List<QVariant> args) : base(parent) {
		}

		public virtual bool Init() {
			Applet().Resize(200, 200);
			QFileInfo program = new QFileInfo(MainScript());
		}

		public virtual void PaintInterface(QPainter painter, QStyleOptionGraphicsItem option, QRect contentsRect) {
			applet.PaintInterface(painter, option, contentsRect);
			return;
		}

		public virtual void ConstraintsEvent(uint constraints) {
			applet.ConstraintsEvent(constraints);
			return;
		}

		public virtual List<QAction> ContextualActions() {
			return applet.ContextualActions();
		}

		public virtual void ShowConfigurationInterface() {
		}

		protected new virtual bool EventFilter(QObject o, QEvent e) {
		}
	}
}
