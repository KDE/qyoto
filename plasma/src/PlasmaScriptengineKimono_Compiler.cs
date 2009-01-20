/*
 *   Copyright 2008 by Arno Rehn <arno@arnorehn.de>
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
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Reflection;

    using Qyoto;

    public class Compiler {
        
        QFileInfo program;
        string mainscript;
        
        static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        
        public Compiler(QFileInfo filename) {
            program = filename;
            mainscript = program.AbsoluteFilePath();
        }
        
        public string GetSourceHash() {
            StringBuilder hash = new StringBuilder();
            QFileInfo info = new QFileInfo();
            foreach (string file in GetSources()) {
                info.SetFile(program.AbsoluteDir(), file);
                Stream stream = new FileStream(info.AbsoluteFilePath(), FileMode.Open, FileAccess.Read);
                byte[] bytes = md5.ComputeHash(stream);
                stream.Close();
                hash.Append(Convert.ToBase64String(bytes));
            }
            return hash.ToString();
        }
        
        public string GetPreviousSourceHash() {
            if (!File.Exists(mainscript + ".hash"))
                return string.Empty;
            StreamReader reader = new StreamReader(mainscript + ".hash");
            string str = reader.ReadToEnd();
            reader.Close();
            return str;
        }
        
        public void WriteHash() {
            StreamWriter writer = new StreamWriter(mainscript + ".hash");
            writer.Write(GetSourceHash());
            writer.Close();
        }
        
        public bool SourceChanged {
            get { return (GetPreviousSourceHash() != GetSourceHash()); }
        }

        private Match GetMetaMatch() {
            StreamReader reader = new StreamReader(mainscript);
            string line = reader.ReadLine().Trim();
            while (line == "" && !reader.EndOfStream)
                line = reader.ReadLine().Trim();
            reader.Close();
            if (line.StartsWith("//") || line.StartsWith("/*") || line.StartsWith("#") || line.StartsWith("'")) {
                Match match = Regex.Match(line, @"(#|//|/\*|') *(.*):(.*) (.*):(.*) (.*):(.*)");
                if (match == Match.Empty)
                    match = Regex.Match(line, @"(#|//|/\*|') *(.*):(.*) (.*):(.*)");
                if (match == Match.Empty)
                    match = Regex.Match(line, @"(#|//|/\*|') *(.*):(.*)");
                return match;
            }
            return Match.Empty;
        }

        public string GetLanguage() {
            return GetLanguage(GetMetaMatch());
        }

        public string GetLanguage(Match match) {
            if (match != Match.Empty) {
                for (int i = 1; i < match.Groups.Count; i++) {
                    if (match.Groups[i].ToString() == "language")
                        return match.Groups[++i].ToString();
                }
            }
            return "csharp";
        }

        public List<string> GetSources(Match match) {
            List<string> sources = new List<string>();
            if (match != Match.Empty) {
                for (int i = 1; i < match.Groups.Count; i++) {
                    if (match.Groups[i].ToString() == "sources")
                        sources.AddRange(match.Groups[++i].ToString().Split(','));
                }
            }
            if (!sources.Contains(program.FileName())) sources.Add(program.FileName());
            return sources;
        }

        public List<string> GetSources() {
            return GetSources(GetMetaMatch());
        }

        public List<string> GetReferences(Match match) {
            List<string> refs = new List<string>();
            if (match != Match.Empty) {
                for (int i = 1; i < match.Groups.Count; i++) {
                    if (match.Groups[i].ToString() == "references")
                        refs.AddRange(match.Groups[++i].ToString().Split(','));
                }
            }
            return refs;
        }

        public List<string> GetReferences() {
            return GetReferences(GetMetaMatch());
        }

        public CodeDomProvider GetCodeDomProvider(string lang) {
            if (lang == "csharp") {
                return new Microsoft.CSharp.CSharpCodeProvider();
            } else if (lang == "vb") {  // this has still problems with references
                return new Microsoft.VisualBasic.VBCodeProvider();
            } else if (lang == "boo") {
                Assembly a = Assembly.LoadWithPartialName("Boo.Lang.CodeDom");
                return (CodeDomProvider) Activator.CreateInstance(a.GetType("Boo.Lang.CodeDom.BooCodeProvider"));
            } else if (lang == "nemerle") {
                Assembly a = Assembly.LoadWithPartialName("Nemerle.Compiler");
                return (CodeDomProvider) Activator.CreateInstance(a.GetType("Nemerle.Compiler.NemerleCodeProvider"));
            }
            return null;
        }

        public Assembly GetAssembly() {
            if (File.Exists(mainscript + ".dll") && !SourceChanged)
                return Assembly.LoadFile(mainscript + ".dll");
            
            Console.WriteLine("Source changed, recompiling");
            
            Match match = GetMetaMatch();
            List<string> sources = GetSources(match);
            List<string> refs = GetReferences(match);
            string lang = GetLanguage(match);
            
            // add commonly used references
            if (!sources.Contains(program.FileName())) sources.Add(program.FileName());
            if (!refs.Contains("qt-dotnet")) refs.Add("qt-dotnet");
            if (!refs.Contains("kde-dotnet")) refs.Add("kde-dotnet");
            if (!refs.Contains("plasma-dll")) refs.Add("plasma-dll");
            
            // relative paths -> absolute paths
            QFileInfo info = new QFileInfo();
            for (int i = 0; i < sources.Count; i++) {
                info.SetFile(program.AbsoluteDir(), sources[i]);
                sources[i] = info.AbsoluteFilePath();
            }
            
            CodeDomProvider provider = GetCodeDomProvider(lang);
            CompilerParameters param = new CompilerParameters();
            param.GenerateExecutable = false;
            param.GenerateInMemory = false;
            param.OutputAssembly = mainscript + ".dll";
            param.ReferencedAssemblies.AddRange(refs.ToArray());
            param.CompilerOptions = String.Empty;
            CompilerResults result = provider.CompileAssemblyFromFile(param, sources.ToArray());
            bool error = false;
            foreach (CompilerError err in result.Errors) {
                if (err.IsWarning == false) error = true;
                Console.WriteLine(err);
            } 
            if (!error) {
                Console.WriteLine("Compilation successful!");
                WriteHash();
            } else {
                throw new Exception("An error occurred during compilation");
                return null;
            }
            return Assembly.LoadFile(mainscript + ".dll");
        }
    }
}

// kate: space-indent on; indent-width 4; replace-tabs on; mixed-indent off;
