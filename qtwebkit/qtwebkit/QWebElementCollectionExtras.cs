namespace Qyoto {
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public partial class QWebElementCollection : Object, IDisposable, IEnumerable<QWebElement> {
        IEnumerator<QWebElement> IEnumerable<QWebElement>.GetEnumerator() {
            for (int i = 0; i < Count(); i++) {
                yield return At(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            for (int i = 0; i < Count(); i++) {
                yield return At(i);
            }
        }
    }
}
