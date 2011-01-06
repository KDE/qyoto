namespace KTextEditor {
    using Kimono;
    using System;
    using Qyoto;
    using System.Collections.Generic;

    public partial class CodeCompletionModel : QAbstractItemModel, IDisposable {
        public override QVariant Data(QModelIndex index, int role) {
            return null;
        }
    }
}
