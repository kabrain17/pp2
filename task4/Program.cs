using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = Convert.ToInt32(Console.ReadLine());  //Размер массива

            int[] a = new int[n];           //Создали массив
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());           //В консоли вводим элементы массива
            }
            Console.WriteLine("Array: ");
            Console.WriteLine(n);
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Duplicates:");

            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " " + a[i] + " ");         //Дублировали
            }


        }
    }
}