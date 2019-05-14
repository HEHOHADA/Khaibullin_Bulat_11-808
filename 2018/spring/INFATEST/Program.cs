using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace INFATEST
{
    class Program
    {
        const string main = "C: \\Users\\Тест\\source\\repos\\INFATEST\\INFATEST\\Student";
        static void Main(string[] args)
        {
            if (Directory.Exists(main))
            {
                foreach (var e in Directory.EnumerateFiles(main))
                    Console.WriteLine(e);
            }
            Console.ReadKey();
            if (Directory.Exists(main + "//Invanov"))
            {
                string input = File.ReadAllText(main + "//Invanov//ex1.txt");
                var list = input.Split(';').ToList();
                var type = typeof(Student);
                var ob = Activator.CreateInstance(type);


                ConstructorInfo constructor = type.GetConstructor(new Type[] { });
                var param = list[2].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                object[] mas = new object[2];
                for (int i = 0; i < 2; i++)
                    mas[i] = param[i];
                var magicClass = constructor.Invoke(new object[] { });
                var e = type.GetMethod(list[1].Trim());
                var var = (int)type.GetMethod(list[1].Trim()).Invoke(magicClass, mas);
                //var variant = (int)type.InvokeMember(list[1].Trim(), BindingFlags.InvokeMethod, null, f, new object[] { param });
                Console.WriteLine(var);
            }
            Console.ReadKey();
        }

        public double Task2(string a)
        {

            string input = File.ReadAllText(main + a + "//ex1.txt");
            var list = input.Split(';').ToList();
            var type = typeof(Student);
            var ob = Activator.CreateInstance(type);
            ConstructorInfo constructor = type.GetConstructor(new Type[] { });
            var param = list[2].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            object[] mas = new object[2];
            for (int i = 0; i < 2; i++)
                mas[i] = param[i];
            var magicClass = constructor.Invoke(new object[] { });
            var e = type.GetMethod(list[1].Trim());
            var var = (int)type.GetMethod(list[1].Trim()).Invoke(magicClass, mas);
            //var variant = (int)type.InvokeMember(list[1].Trim(), BindingFlags.InvokeMethod, null, f, new object[] { param });
            Console.WriteLine(var);
            return var;

        }
    }
}
