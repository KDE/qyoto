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

		public Applet(QObject parent, List<QVariant> args) : base(parent) {
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

		public virtual bool Init() {
			Applet().Resize(200, 200);
			QFileInfo program = new QFileInfo(MainScript());
			
			appletAssembly = Assembly.LoadFile(program.AbsoluteFilePath());
			
			string typeName = Camelize(Package().Metadata().PluginName()) + ".";  // namespace
			typeName += Camelize(program.CompleteBaseName());
			appletType = appletAssembly.GetType(typeName);
			
			applet = (PlasmaScripting.Applet) Activator.CreateInstance(appletType, new object[] { this });
			applet.Init();
			return true;
		}

		public virtual void PaintInterface(QPainter painter, QStyleOptionGraphicsItem option, QRect contentsRect) {
			applet.PaintInterface(painter, option, contentsRect);
			return;
		}

		/*protected virtual void ConstraintsEvent(uint constraints) {
			applet.ConstraintsEvent(constraints);
			return;
		}*/

		public virtual List<QAction> ContextualActions() {
			return applet.ContextualActions();
		}

		public virtual void ShowConfigurationInterface() {
		}

		protected new virtual bool EventFilter(QObject o, QEvent e) {
			return false;
		}
	}
}
