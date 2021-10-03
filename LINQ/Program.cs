using System;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, " +
                "Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            string[] names = str.Split(", ");
            string[] indexes = new string[names.Length];

            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = (i + 1).ToString();
            }

            var indexesAndNames = indexes.Zip(names, (first, second) => first + ". " + second);
            foreach (var item in indexesAndNames)
            {
                Console.WriteLine(item);
            }

        }


    }
}
