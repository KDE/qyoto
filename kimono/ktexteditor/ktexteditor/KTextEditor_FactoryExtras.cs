namespace KTextEditor {
    using Kimono;
    using System;
    using Qyoto;
    using System.Collections.Generic;

    public partial class Factory : KParts.Factory, IDisposable {
        protected override KParts.Part CreatePartObject(QWidget parentWidget, QObject parent, string classname, List<string> args) {
            return null;
        }
    }
}
