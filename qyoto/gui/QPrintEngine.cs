//Auto-generated by kalyptus. DO NOT EDIT.
namespace Qyoto {

	using System;

	[SmokeClass("QPrintEngine")]
	public abstract class QPrintEngine : Object {
		protected SmokeInvocation interceptor = null;
		private IntPtr smokeObject;
		protected QPrintEngine(Type dummy) {}
		protected void CreateProxy() {
			interceptor = new SmokeInvocation(typeof(QPrintEngine), this);
		}
		public enum PrintEnginePropertyKey {
			PPK_CollateCopies = 0,
			PPK_ColorMode = 1,
			PPK_Creator = 2,
			PPK_DocumentName = 3,
			PPK_FullPage = 4,
			PPK_NumberOfCopies = 5,
			PPK_Orientation = 6,
			PPK_OutputFileName = 7,
			PPK_PageOrder = 8,
			PPK_PageRect = 9,
			PPK_PageSize = 10,
			PPK_PaperRect = 11,
			PPK_PaperSource = 12,
			PPK_PrinterName = 13,
			PPK_PrinterProgram = 14,
			PPK_Resolution = 15,
			PPK_SelectionOption = 16,
			PPK_SupportedResolutions = 17,
			PPK_WindowsPageSize = 18,
			PPK_FontEmbedding = 19,
			PPK_SuppressSystemPrintStatus = 20,
			PPK_Duplex = 21,
			PPK_PaperSources = 22,
			PPK_CustomPaperSize = 23,
			PPK_PageMargins = 24,
			PPK_PaperSize = PPK_PageSize,
			PPK_CustomBase = 0xff00,
		}
		[SmokeMethod("setProperty(QPrintEngine::PrintEnginePropertyKey, const QVariant&)")]
		public abstract void SetProperty(QPrintEngine.PrintEnginePropertyKey key, QVariant value);
		[SmokeMethod("property(QPrintEngine::PrintEnginePropertyKey) const")]
		public abstract QVariant Property(QPrintEngine.PrintEnginePropertyKey key);
		[SmokeMethod("newPage()")]
		public abstract bool NewPage();
		[SmokeMethod("abort()")]
		public abstract bool Abort();
		[SmokeMethod("metric(QPaintDevice::PaintDeviceMetric) const")]
		public abstract int Metric(IQPaintDevice arg1);
		[SmokeMethod("printerState() const")]
		public abstract QPrinter.PrinterState PrinterState();
		public QPrintEngine() : this((Type) null) {
			CreateProxy();
			interceptor.Invoke("QPrintEngine", "QPrintEngine()", typeof(void));
		}
	}
}
