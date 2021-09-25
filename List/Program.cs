using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int> { 1, 2, 3, 4, 5, 6, 34, 12 };
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
        }
    }
}
