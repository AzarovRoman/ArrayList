using Lists;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();

            al.Add(1);
            al.Add(2);
            al.Add(3);
            al.Add(4);
            al.Add(5);
            al.Add(6);
            Console.WriteLine(al);

            ArrayList al2 = new ArrayList();
            al2.Add(11);
            al2.Add(12);
            al2.Add(13);
            al2.Add(14);
            al2.Add(15);

            al.AddArrayListByIndex(al2, 3);
            Console.WriteLine(al);
        }
    }
}
