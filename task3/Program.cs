using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            n = Convert.ToInt32(Console.ReadLine());
            int[] a = new int[n]; // создаем массив
            for (int i = 0; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write("[*]");
                Console.WriteLine();
            }
        }
    }
}
