using Lists;

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
            al.Add(70);

            al.WriteToConsole();
            al.Insert(3, 35);
            al.WriteToConsole();

            al.RemoveByIndex(3);

            al.WriteToConsole();

        }
    }
}
