using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module15
{
    internal class Program
    {
        //1. Получение списка методов класса Console и их вывод на экран:
        static void Esep1()
        {
            Type consoleType = typeof(Console);
            MethodInfo[] methods = consoleType.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }


        //2. Описание класса с несколькими свойствами, создание экземпляра, инициализация свойств,
        //и получение этих свойств с помощью рефлексии:
        public class MyClass
        {
            public int Property1 { get; set; }
            public string Property2 { get; set; }
        }
        static void Esep2()
        {
            MyClass myObject = new MyClass { Property1 = 10, Property2 = "Hello" };

            Type type = myObject.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                Console.WriteLine($"Property: {property.Name}, Value: {property.GetValue(myObject)}");
            }
        }
        //3. Использование рефлексии для вызова метода Substring класса String:
        static void Esep3()
        {
            string str = "Hello World";
            Type stringType = typeof(string);
            MethodInfo substringMethod = stringType.GetMethod("Substring", new[] { typeof(int), typeof(int) });
            object result = substringMethod.Invoke(str, new object[] { 0, 5 });

            Console.WriteLine(result); // Выведет "Hello"
        }
        //4. Получение списка конструкторов класса List<T>:
        static void Esep4()
        {
            Type listType = typeof(List<>);
            ConstructorInfo[] constructors = listType.GetConstructors();

            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor);
            }
        }
        static void Main(string[] args)
        {
            Esep1();
            Esep2();
            Esep3();
            Esep4();

        }
    }
}
