using Lists;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4};

            ArrayList al = new ArrayList(array);
            Console.WriteLine(al);
        }
    }
}
