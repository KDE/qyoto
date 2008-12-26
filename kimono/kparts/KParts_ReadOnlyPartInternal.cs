namespace KParts {
	using System;

	internal class ReadOnlyPartInternal : ReadOnlyPart {
		protected ReadOnlyPartInternal(Type dummy) : base ((Type) null) {}
		protected override bool OpenFile() { return false; }
	}
}
