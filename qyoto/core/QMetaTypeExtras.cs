/*
 *   Copyright 2009 by Arno Rehn <arno@arnorehn.de>
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU Library General Public License as
 *   published by the Free Software Foundation; either version 2, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details
 *
 *   You should have received a copy of the GNU Library General Public
 *   License along with this program; if not, write to the
 *   Free Software Foundation, Inc.,
 *   51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

namespace Qyoto {

    using System;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public partial class QMetaType : Object, IDisposable {
        public delegate void Destructor(IntPtr obj);
        public delegate IntPtr Constructor(IntPtr copy);

        [DllImport("qyoto", CharSet=CharSet.Ansi)]
        static extern void DestroyObject(string name, IntPtr ptr);

        [DllImport("qyoto", CharSet=CharSet.Ansi)]
        static extern IntPtr CreateObject(string name, IntPtr other);

        [DllImport("qyoto", CharSet=CharSet.Ansi)]
        static extern int QMetaTypeRegisterType(string name, Destructor dtor, Constructor ctor);

        public static int RegisterType<T>() {
            string className;
            Destructor dtorHandler;
            Constructor ctorHandler;
            if (SmokeMarshallers.IsSmokeClass(typeof(T))) {
                className = SmokeMarshallers.SmokeClassName(typeof(T));
                dtorHandler = delegate(IntPtr obj) { DestroyObject(className, obj); };
                ctorHandler = delegate(IntPtr copy) { return CreateObject(className, copy); };
            } else {
                className = typeof(T).ToString();
                dtorHandler = delegate(IntPtr obj) { ((GCHandle) obj).Free(); };
                ctorHandler = delegate(IntPtr copy) {
                    if (copy != IntPtr.Zero) {
                        object o = (T) ((GCHandle) copy).Target;  // create a copy if this is a valuetype

                        ICloneable cloneable = o as ICloneable;
                        if (cloneable != null) {
                            o = cloneable.Clone();
                        }
                        return (IntPtr) GCHandle.Alloc(o);
                    }
                    return (IntPtr) GCHandle.Alloc(default(T));
                };
            }
            GCHandle.Alloc(className); // prevent collection
            GCHandle.Alloc(dtorHandler);
            GCHandle.Alloc(ctorHandler);
            return QMetaTypeRegisterType(className, dtorHandler, ctorHandler);
        }
    }
}

// kate: space-indent on; indent-width 4; replace-tabs on; mixed-indent off;