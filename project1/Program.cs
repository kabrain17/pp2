using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            int x  = 0;
            bool status = false;        //status=можно представить что сейчас каждый член массива держит свой status(false)
                                      // и если он не prime то его status станет true , и мы выведем те члены массива
                                      //у которых status false
            for (int i = 0; i < n; i++)
            {
                status = false;
                if (a[i] <= 1) continue;    //если член массива меньше или равен еденице  то их не расматриваем, пропускаем
                else
                    for (int j = 2; j < a[i]; j++)
                        if (a[i] % j == 0) status = true;     //если член массива не prime то тут он станет true
                if (!status) x++;                    //считаем сколько у нас prime-ов
            }

            Console.WriteLine("Количество праймов" + x);
            Console.WriteLine("Те самые праймы: ");
            for (int i = 0; i < n; i++)
            {
                status = false;
                if (a[i] <= 1) continue;
                else
                    for (int j = 2; j < a[i]; j++)
                        if (a[i] % j == 0) status = true;
                if (!status) Console.Write(a[i] + " ");     //выводим все prime цифры
            }
            Console.ReadKey();
        }
    }
}



     
