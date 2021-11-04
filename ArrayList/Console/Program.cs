using Lists;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList al = new ArrayList();

            al.Add(10);
            al.Add(20);
            al.Add(30);
            al.Add(40);
            al.Add(50);
            al.Add(60);
            al.Add(80);
            al.Add(110);
            al.Add(90);
            al.Add(100);
            al.WriteToConsole();

            Console.WriteLine(al.GetIndexOfFirstMatch(90));

            al.Reverse();
            al.WriteToConsole();
        }
    }
}
