using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
            var names = new string[] { "Petrov","Ivanov" };
            Parallel.ForEach(names, Task12);// для 3 задания(таблица)
            foreach(var e in Task2())
                Console.WriteLine(e);
            Console.ReadKey();
        }

        public static void Task12(string secondName)
        {

            if (Directory.Exists(main + "//" + secondName))// беру все файлы и в нем все папки
            {
                var files = Directory.GetFiles(main + "//" + secondName);
                int i = 0;// удачные задания
                foreach (var file in files)
                {
                    string input = File.ReadAllText(file);
                    var list = input.Split(';').ToList();
                    var type = Type.GetType("INFATEST." + list[0].Trim());
                    ConstructorInfo constructor = type.GetConstructor(new Type[] { });
                    var param = list[2].Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                    object[] mas = param.Select(x => (object)x).ToArray();
                    var magicClass = constructor.Invoke(new object[] { });
                    var var = (double)type.GetMethod(list[1].Trim()).Invoke(magicClass, mas);
                    if ((list[1].Trim() == "Calculate" && var == ansForEx1) ||
                        (list[1].Trim() == "Divide" && var == ansForEx2))
                        i++;
                }
                Console.WriteLine(secondName +" "+ i);
            }
        } 

        public static int[] Task2()
        {// читаю текст в файлах 
            var link = new Uri(@"https://jsonplaceholder.typicode.com/comments");
            var client = new WebClient();
            var formatOfText = client.DownloadStringTaskAsync(link);
            var comments = JsonConvert.DeserializeObject<List<Comments>>(formatOfText.Result);
            var result = comments.Where(x => Convert.ToInt32(x.Id) % 2 == 0)
                // проверяю на нужные компоненты
                .Select(x => x.Body.Where(y=>char.IsLetter(y)).Count()).ToArray();
            return result;
        }
    }
}