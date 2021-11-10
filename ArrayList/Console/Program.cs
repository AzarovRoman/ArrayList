using Lists;
using System;
using LinkList;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList a = new LinkedList(new int[] { 1, 2, 3, 4, 5});
            Console.WriteLine(a.GetLength());
        }
    }
}
