using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static bool IsPrime(int x)
        {
            if (x == 1) return false;        //если 1 то false
            if (x == 2) return true;          // если 2 то true

            bool flag = true;     //пока что flag true 

            for (int i = 2; i < x; ++i)
            {
                if (x % i == 0)     //если делителей несколько то flag false
                {
                    flag = false;
                    break;
                }
            }
            return flag;   // если flag true то выводи его и дальнейшем записываем в res
        }

        static bool IsPrimeString(string s)
        {
            return IsPrime(int.Parse(s));
            //после каждый строг разделенной с  ' '  делаем интеджером и вызываем ее в функцию для опознания prime или нет
        }

        static void Main(string[] args)
        {

            List<string> res = new List<string>();
            //объявляем иницилизацию строг , в каждую строку этого списка будет писаться string[] line

            FileStream fs = new FileStream(@"C:\Users\777\Desktop\vkak\kncd\input.txt", FileMode.Open, FileAccess.Read);
            //FileStream класс для чтения и записи, открывать и закрывать файлы
            StreamReader sr = new StreamReader(fs);
            //StreamReader прочитать текст из файла

            string line = sr.ReadLine();
            //читаем и присвеваем в line
            string[] nums = line.Split(' ');
            //split разделаем стринг на ' '

            foreach (var x in nums)    //пробегаемся как в форке по строге
            {
                if (IsPrimeString(x))    //вызываем в функцию по отдельности из сроги разделенную с ' '
                {
                    res.Add(x);   //присваеваем в res
                }
            }

            sr.Close();    //закрываем 
            fs.Close();



            FileStream fs2 = new FileStream(@"C:\Users\777\Desktop\vkak\Output.txt", FileMode.Create, FileAccess.Write);
            //FileStream класс для чтения и записи
            StreamWriter sw = new StreamWriter(fs2); //StreamWriter записать текст на файл

            foreach (var x in res)
            {
                sw.Write(x + " ");      //записываем в файл
                Console.Write(x + " ");  //выводим в консоли
            }

            sw.Close();     //закрываем
            fs2.Close();
        }
    }
}