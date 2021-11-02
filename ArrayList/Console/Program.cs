using Lists;

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
            al.Add(1);
            al.Add(2);
            al.Add(3);
            al.Add(4);
            al.Add(2);
            al.Add(3);
            al.Add(4);
            al.Add(5);

            al.WriteToConsole();

            al.AddToBeginning(2);
            al.Add(2);
            al.WriteToConsole();


        }
    }
}
