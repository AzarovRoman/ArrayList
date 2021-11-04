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

            ArrayList al1 = new ArrayList();

            al1.Add(4);
            al1.Add(5);
            al1.Add(6);

            al.AddArrayListByIndex(al1, 1);
            al.WriteToConsole();
        }
    }
}
