using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_task
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * На вхід є стрічка  "Davis, Clyne, Fonte, Hooiveld, Shaw,
             * Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert" 
             * Кожному гравцеві надайте номер, починаючи з 1, щоб вийшла 
             * стрічка подібна : "1. Davis, 2. Clyne, 3. Fonte" ...
             */

            string str = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, " +
                "Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            string[] names = str.Split(", ");
            string[] indexes = new string[names.Length];

            var s = names.Select(s => s);
            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = (i + 1).ToString();
            }

            var indexesAndNames = indexes.Zip(names, (first, second) => first + ". " + second);
            foreach (var item in indexesAndNames)
            {
                Console.WriteLine(item);
            }

            /*
             * Візьміть стрічку "Jason Puncheon, 26/06/1986; Jos Hooiveld, 
             * 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; 
             * Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988" і перетворіть 
             * її на IEnumerable гравців в порядку віку (і ще бажано вивести вік)
             */
            string strTask2 = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; " +
                        "Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; " +
                        "Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";
            string[] playersStr = strTask2.Split("; ");
            var player = playersStr.Select((s) => new
            {
                Name = s.Split(", ")[0], //Ім'я та прізвище
                Date = new DateTime
                (int.Parse(s.Split(", ")[1].Split('/')[2]), //Рік
                 int.Parse(s.Split(", ")[1].Split('/')[1]), //Місяць
                 int.Parse(s.Split(", ")[1].Split('/')[0])) //День
            });
            var orderedPlayers = player.OrderBy(p => p.Date);

            foreach (var item in orderedPlayers)
            {
                Console.WriteLine(item.Name + " " + item.Date);
            }


            /*
             * Візьміть стрічку "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27", 
             * яка відображає довжину пісень в хвилинах і секунда і обрахуйте загальну 
             * довжину всіх пісень.
             */
            string strTask3 = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            string[] minutesAndSeconds = strTask3.Split(',');
            var collection = minutesAndSeconds.Select((string s) => TimeSpan.Parse("0:" + s));
            var sum = collection.Aggregate((x, y) => x + y);
            Console.WriteLine(sum);
        }


    }
}
