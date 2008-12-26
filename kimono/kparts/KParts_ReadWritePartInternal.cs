namespace KParts {
	using System;

	internal class ReadWritePartInternal : ReadWritePart {
		protected ReadWritePartInternal(Type dummy) : base ((Type) null) {}
		protected override bool OpenFile() { return false; }
		protected override bool SaveFile() { return false; }
	}
}
