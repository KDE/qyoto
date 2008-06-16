namespace Kimono {
	using System;
	using Qyoto;
	using System.Text;
	using System.Collections.Generic;

	public class KConfigSkeletonGenericItem : KConfigSkeletonItem {
		protected KConfigSkeletonGenericItem(Type dummy) : base((Type) null) {}

		public override void ReadConfig(KConfig arg1) {}
		public override void WriteConfig(KConfig arg1) {}
		public override void ReadDefault(KConfig arg1) {}
		public override void SetProperty(QVariant p) {}
		public override bool IsEqual(QVariant v) {
			return false;
		}
		public override QVariant Property() {
			return null;
		}
		public override void SetDefault() {}
		public override void SwapDefault() {}
	}
}