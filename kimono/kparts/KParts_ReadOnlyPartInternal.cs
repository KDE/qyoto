namespace KParts {
	using System;
	using Qyoto;

	[SmokeClass("KParts::ReadOnlyPart")]
	internal class ReadOnlyPartInternal : ReadOnlyPart {
		protected ReadOnlyPartInternal(Type dummy) : base ((Type) null) {}
		protected override bool OpenFile() { return false; }
	}
}
