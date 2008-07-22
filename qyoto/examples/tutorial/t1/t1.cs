using System;
using System.Collections.Generic;
using Qyoto;

public class T1 
{

public static void TestScriptEngine() {
   QScriptEngine engine = new QScriptEngine();
   engine.Evaluate("function fullName() { return this.firstName + ' ' + this.lastName; }");
   engine.Evaluate("somePerson = { firstName: 'John', lastName: 'Doe' }");

   QScriptValue global = engine.GlobalObject();
   QScriptValue fullName = global.Property("fullName");
   QScriptValue who = global.Property("somePerson");
   Console.WriteLine(fullName.Call(who).ToString()); // "John Doe"

   engine.Evaluate("function cube(x) { return x * x * x; }");
   QScriptValue cube = global.Property("cube");
   List<QScriptValue> args = new List<QScriptValue>();
   args.Add(new QScriptValue(engine, 3));
   Console.WriteLine(cube.Call(new QScriptValue(), args).ToNumber()); // 27
}

    public static int Main(String[] args) {
        QApplication app = new QApplication(args);
        QPushButton hello = new QPushButton("Hello world!");
        QLabel label = new QLabel(hello);
        hello.Resize(100, 30);        
        hello.Show();
        TestScriptEngine();
        return QApplication.Exec();
    }
}
