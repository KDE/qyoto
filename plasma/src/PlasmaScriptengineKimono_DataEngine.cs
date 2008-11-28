/*
 *   Copyright 2008 by Richard Dale <richard.j.dale@gmail.com>
 *   Copyright 2008, Arno Rehn <arno@arnorehn.de>
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

namespace PlasmaScriptengineKimono {

    using System;
    using System.IO;
    using System.Text;
    using System.Reflection;
    using System.Collections.Generic;

    using Qyoto;
    using Kimono;
    using Plasma;

    public class DataEngine : Plasma.DataEngineScript {
        private PlasmaScripting.DataEngine dataEngine;
        private Assembly dataEngineAssembly;
        private Type dataEngineType;

        public DataEngine(QObject parent, List<QVariant> args) : base(parent) {}

        public override bool Init() {
            QFileInfo program = new QFileInfo(MainScript());

            dataEngineAssembly = Assembly.LoadFile(program.AbsoluteFilePath());
            
            // the newly loaded assembly might contain reference other bindings that need to be initialized
            foreach (AssemblyName an in dataEngineAssembly.GetReferencedAssemblies()) {
                // if the binding has already been initialized (e.g. in SmokeInvocation.InitRuntime()), continue.
                Assembly a = null;
                try {
                    a = Assembly.Load(an);
                } catch (FileNotFoundException e) {
                    a = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(dataEngineAssembly.Location), an.Name + ".dll"));
                }
                if (SmokeInvocation.InitializedAssemblies.Contains(a)) continue;
                AssemblySmokeInitializer attr = (AssemblySmokeInitializer) Attribute.GetCustomAttribute(a, typeof(AssemblySmokeInitializer));
                if (attr != null) attr.CallInitSmoke();
                SmokeInvocation.InitializedAssemblies.Add(a);
            }
            
            string typeName = Camelize(Package().Metadata().PluginName()) + ".";  // namespace
            typeName += Camelize(program.CompleteBaseName());
            dataEngineType = dataEngineAssembly.GetType(typeName);
            if (dataEngineType == null) {
                foreach (Type t in dataEngineAssembly.GetTypes()) {
                    for (Type tmp = t.BaseType; tmp != null; tmp = tmp.BaseType) {
                        if (tmp == typeof(PlasmaScripting.DataEngine)) {
                            dataEngineType = t;
                            break;
                        }
                    }
                    if (dataEngineType != null) break;
                }
            }

            dataEngine = (PlasmaScripting.DataEngine) Activator.CreateInstance(dataEngineType, new object[] { this });
            dataEngine.Init();
            return true;
        }

        public virtual List<string> Sources() {
            return dataEngine.Sources();
        }

        public virtual bool SourceRequestEvent(string name) {
            return dataEngine.SourceRequestEvent(name);
        }

        public virtual bool UpdateSourceEvent(string source) {
            return dataEngine.UpdateSourceEvent(source);
        }

        private string Camelize(string str) {
            StringBuilder ret = new StringBuilder(str.Substring(0, 1).ToUpper());
            for (int i = 1; i < str.Length; i++) {
                if (str[i] == '_' || str[i] == '-') {
                    i++;
                    if (i < str.Length)
                        ret.Append(str.Substring(i, 1).ToUpper());
                } else {
                    ret.Append(str[i]);
                }
            }
            return ret.ToString();
        }
    }
}
