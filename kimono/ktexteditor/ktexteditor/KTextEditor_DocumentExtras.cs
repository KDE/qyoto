namespace KTextEditor {
    using Kimono;
    using System;
    using Qyoto;
    using System.Collections.Generic;

    public partial class Document : KParts.ReadWritePart, IDisposable {
        protected override bool SaveFile() {
            return false;
        }
        protected override bool OpenFile() {
            return false;
        }
    }
}
