/***************************************************************************
                          QyotoMetaData.cs  -  description
                             -------------------
    begin                : Wed Jun 16 2004
    copyright            : (C) 2004-2007 by Richard Dale, Arno Rehn
    email                : richard.j.dale@gmail.com
 ***************************************************************************/

/***************************************************************************
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU Lesser General Public License as        *
 *   published by the Free Software Foundation; either version 2 of the    *
 *   License, or (at your option) any later version.                       *
 *                                                                         *
 ***************************************************************************/

namespace Qyoto {
	using System;
	using System.Reflection;
	using System.Collections.Generic;
	using System.Text;
	using System.Text.RegularExpressions;
	
	class QyotoMetaData {
		byte[] stringdata;
		uint[] data;
		private delegate uint Handler(string str);
		Handler handler;
	
		// from qt-copy/src/tools/moc/generator.cpp
		enum MethodFlags {
			AccessPrivate = 0x00,
			AccessProtected = 0x01,
			AccessPublic = 0x02,
			MethodMethod = 0x00,
			MethodSignal = 0x04,
			MethodSlot = 0x08,
			MethodCompatibility = 0x10,
			MethodCloned = 0x20,
			MethodScriptable = 0x40
		}
		
		// from qt-copy/src/tools/moc/generator.cpp
		enum PropertyFlags  {
			Invalid = 0x00000000,
			Readable = 0x00000001,
			Writable = 0x00000002,
			Resettable = 0x00000004,
			EnumOrFlag = 0x00000008,
			StdCppSet = 0x00000100,
			//     Override = 0x00000200,
			Designable = 0x00001000,
			ResolveDesignable = 0x00002000,
			Scriptable = 0x00004000,
			ResolveScriptable = 0x00008000,
			Stored = 0x00010000,
			ResolveStored = 0x00020000,
			Editable = 0x00040000,
			ResolveEditable = 0x00080000,
			User = 0x00100000,
			ResolveUser = 0x00200000
		}
		
		void AddProperty(List<uint> array, string name, string type, PropertyFlags flags) {
			array.Add(handler(name));
			array.Add(handler(type));
			array.Add((uint)flags);
		}
		
		void AddClassInfo(List<uint> array, string key, string value) {
			array.Add(handler(key));
			array.Add(handler(value));
		}
		
		void AddMethod(List<uint> array, string method, string type, MethodFlags flags) {
			array.Add(handler(method));                            // signature
			array.Add(handler(Regex.Replace(method, "[^,]", ""))); // parameters
			array.Add(handler(type));				// type
			array.Add(handler(""));                                // tag
			array.Add((uint)flags);                                 // flags
		}
		
		byte[] ComputeStringData(List<string> array) {
			List<byte> result = new List<byte>();
			foreach(string x in array) {
				result.AddRange(Encoding.ASCII.GetBytes(x));
				result.Add(0);
			}
			return result.ToArray();
		}
	
		public QyotoMetaData(string className, ICollection<Qyoto.CPPMethod> signals,
							ICollection<Qyoto.CPPMethod> slots,
							Dictionary<string, string> classinfos,
							ICollection<Qyoto.CPPProperty> properties) {
			Dictionary<string, uint> hash = new Dictionary<string, uint>();
			uint offset = 0;
			List<string> stringdata_tmp = new List<string>();
			handler = delegate(string str) {
				uint res;
				if (!hash.TryGetValue(str, out res)) {
					hash.Add(str, offset);
					stringdata_tmp.Add(str);
					res = offset;
					offset += (uint)str.Length + 1;
				}
				return res;
			};
			
			uint classinfoCount = (uint) classinfos.Count;
			uint classinfoOffset = (uint) (classinfoCount > 0 ? 10 : 0);
			
			uint methodCount = (uint) (signals.Count + slots.Count);
			uint methodOffset = (uint) (methodCount > 0 ? (10 + (2 * classinfoCount)) : 0);
			
			uint propertyCount = (uint) properties.Count;
			uint propertyOffset = (uint) (propertyCount > 0 ? (10 + (2 * classinfoCount) + (5 * methodCount)) : 0);
			
			List<uint> tmp = new List<uint>()
			{
				1,					// revision
				handler(className),			// classname
				classinfoCount, classinfoOffset,	// classinfo
				methodCount, methodOffset,		// methods
				propertyCount, propertyOffset,		// properties
				0, 0
			};
			
			foreach (KeyValuePair<string, string> p in classinfos)
				AddClassInfo(tmp, p.Key, p.Value);
			
			foreach (Qyoto.CPPMethod entry in signals) {
				MethodFlags flags = MethodFlags.MethodSignal | MethodFlags.AccessProtected;
				
				if (entry.scriptable)
					flags = MethodFlags.MethodScriptable | MethodFlags.MethodSignal | MethodFlags.AccessPublic;
				
				AddMethod(tmp,
					entry.signature,						// signature
					entry.type,							// return type, "" for void
					flags);
			}
			
			foreach (Qyoto.CPPMethod entry in slots) {
				MethodFlags flags = MethodFlags.MethodSlot | MethodFlags.AccessPublic;
				
				if (entry.scriptable)
					flags |= MethodFlags.MethodScriptable;
				
				AddMethod(tmp,
					entry.signature,						// signature
					entry.type,							// return type, "" for void
					MethodFlags.MethodSlot | MethodFlags.AccessPublic);
			}
			
			foreach (Qyoto.CPPProperty entry in properties) {
				PropertyFlags flags = PropertyFlags.StdCppSet | PropertyFlags.ResolveEditable | PropertyFlags.Stored;
				
				if (entry.pi.CanRead && entry.pi.CanWrite) {
					flags |= PropertyFlags.Readable | PropertyFlags.Writable;
				} else if (entry.pi.CanRead) {
					flags |= PropertyFlags.Readable;
				} else if (entry.pi.CanWrite) {
					flags |= PropertyFlags.Writable;
				}
				
				if (entry.scriptable)
					flags = flags | PropertyFlags.Scriptable;
					
				AddProperty(tmp,
					entry.name,
					entry.type,
					flags);
			}
			
			tmp.Add(0);
			
			stringdata = ComputeStringData(stringdata_tmp);
			data = tmp.ToArray();
		}
	
		public byte[] StringData {
			get { return stringdata; }
		}
		
		public uint[] Data {
			get { return data; }
		}
	}
}
