using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace INFATEST
{
    public class Program
    {
        const string main = "C:\\Users\\bulat\\source\\repos\\INFATEST\\INFATEST\\Student";
        const double ansForEx1 = 2;
        const double ansForEx2 = 2.5;
        static void Main(string[] args)
        {
            if (Directory.Exists(main))
            {//читаю все файлы и вывожу
                foreach (var e in Directory.EnumerateFiles(main))
                    Console.WriteLine(e);
            }
            foreach (var e in Task12())// для 3 задания(таблица)
                Console.WriteLine(e.SecondName + " " + e.TrueAsks);
            Console.ReadKey();
        }

        public static List<Student> Task12()
        {
            var result = new List<Student>();
            if (Directory.Exists(main))// беру все файлы и в нем все папки
                foreach (var name in Directory.GetDirectories(main))
                {
                    var files = Directory.GetFiles(name);
                    var secondName = new DirectoryInfo(name).Name;
                    int i = 0;// удачные задания
                    foreach (var file in files)
                    {
                        string input = File.ReadAllText(file);
                        var list = input.Split(';').ToList();
                        var type = Type.GetType("INFATEST."+list[0].Trim());
                        ConstructorInfo constructor = type.GetConstructor(new Type[] { });
                        var param = list[2].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                        object[] mas = param.Select(x => (object)x).ToArray(); 
                        var magicClass = constructor.Invoke(new object[] { });
                        var var = (double)type.GetMethod(list[1].Trim()).Invoke(magicClass, mas);
                        if ((list[1].Trim() == "Calculate" && var == ansForEx1) || (list[1].Trim() == "Divide" && var == ansForEx2))
                            i++;
                    }
                    result.Add(new Student(i, secondName));
                }
            return result ;
        }

        //public void Task2()
        //{
        //    var link = @"https://jsonplaceholder.typicode.com/comments";
                       


        //}
        

    }

}