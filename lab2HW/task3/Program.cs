using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void f(DirectoryInfo dir, int j)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;    //перекрашиваем текст который будет выводиться в консоль 
            string s = "";              //пока что пустой
            for (int i = 0; i < j; i++)
            {
                s += " ";              //сколько было отправлено в функию int столько раз добавляет пробел
            }
            Console.WriteLine(s + dir.Name);               //выводим пробел и название и какой фармат у файла
            FileSystemInfo[] x = dir.GetFileSystemInfos();
            //Возвращает массив строго типизированных объектов FileSystemInfo, представляющих все файлы и подкаталоги в том или ином каталоге.
            //узнаем инфу о папке т.е. внутри папки заходим в папку и получаем инфо что в нутри нее
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i].GetType() == typeof(DirectoryInfo))
                //с помощью ключевого слова typeof Чтобы управлять типом и получать всю информацию о нем
                {

                    DirectoryInfo dir2 = x[i] as DirectoryInfo;
                    //своими словами,находит файл , узнает инфо и записывает в dir2 , и опять вызывает функцию отправляя вместе с ней 
                    // определенное число (интеджер) , рекурсивно будет поворяться пока внутри одной папки не будет папок и файлов которые нужно показать

                    f(dir2, j + 5);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;    //если в нутри папки нет папки то все файлы перекрашиваем  в белый и выводим в консоль
                    Console.WriteLine(s + x[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(@"C:\Users\777\Desktop\vkak");     //Получаем информацию о библиетеке и записываем в dirinfo
            f(dirinfo, 0); //отправляем ее в функцию вместе с 0 
        }

    }
}