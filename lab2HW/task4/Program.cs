using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1способ
            //  string path = @"C:\Users\Багдан\Desktop\test\tttttt\ddd\trtr.txt";
            //  string path2 = @"C:\Users\Багдан\Desktop\test\wwww\drrrrfr.txt";
            //  File.Copy(path, path2 ,true);     //1способом мы просто из txt файла в txt файл , скопировали то что было в path в pfth2

            //   если true, как в случае выше, файл при копировании перезаписывается.
            //   Если же в качестве последнего параметра передать значение false, то если такой файл уже существует,
            //   приложение выдаст ошибку.

            //  File.Delete(path);                //И после того как скопировали мы удаляем path

            //  2способ
            //      string path = @"C:\Users\Багдан\Desktop\test\tttttt\ddd\trtr.txt";
            //      string path2 = @"C:\Users\Багдан\Desktop\test\wwww\skrskr\dddr.txt";

            //   if (File.Exists(path2))
            //Проверяем есть ли существующий файл , типо , Метод Move нельзя использовать для перезаписи существующего файла.
            //Exists(file): определяет, существует ли файл
            //  {
            //      File.Delete(path2);     //Если есть ,то удаляем.
            //      File.Move(path, path2);    //После файл с path перемещяем в path2
            //      //Move: перемещает файл в новое место

            //  }

            //3способ

            string aaa = "Hello!";

            string path2 = @"C:\Users\777\Desktop\vkak\Output.txt";
            StreamWriter file = new StreamWriter(@"C:\Users\777\Desktop\vkak\akak\4ch\Test.txt");
            file.Write(aaa);
            file.Close();
            string path = @"C:\Users\777\Desktop\vkak\akak\4ch\Test.txt";
            if (File.Exists(path2))
            //Проверяем есть ли существующий файл , типо , Метод Move нельзя использовать для перезаписи существующего файла.
            //Exists(file): определяет, существует ли файл
            {
                File.Delete(path2);     //Если есть ,то удаляем.
                File.Move(path, path2);    //После файл с path перемещяем в path2
                                           //Move: перемещает файл в новое место

            }







        }
    }
}