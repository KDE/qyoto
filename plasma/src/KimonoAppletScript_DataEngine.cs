namespace KimonoAppletScript {
	using Plasma;
	using System;
	using Kimono;
	using Qyoto;
	using System.Collections.Generic;

	public class DataEngine : Plasma.DataEngineScript {
		private PlasmaScripting.DataEngine dataEngine;

		public DataEngine(QObject parent, List<QVariant> args) : base(parent) {
		}

		public virtual bool Init() {
			QFileInfo program = new QFileInfo(MainScript());
		}

		public virtual bool SourceRequestEvent(string name) {
			dataEngine.SourceRequestEvent(name);
		}

		public virtual bool UpdateSourceEvent(string source) {
			dataEngine.UpdateSourceEvent(source);
		}
	}
}
