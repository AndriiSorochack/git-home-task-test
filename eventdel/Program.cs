using System;

namespace EventsDelegates
{
    //Консольна програма має дозволяти користувачеві вводити безмежну кількість стрічок.
    //Стрічку в якій є хоча б одна цифра повинен опрацьовувати клас з назвою 
    //AlphaNumericCollector, в іншому випадку клас StringCollector.Згадані вище 
    //класи повинні зберігати стрічки в списку(накопичувати їх). Взаємодію між 
    //вводом даних і згаданими класами слід реалізувати через події/делегати.
    //Зони відповідальності класів старайтеся зробити максимально подібно, як в JokeGenerator
    class Program
    {
        
        static void Main(string[] args)
        {
            string stringFromConsole;
            ConsoleInputHendeler_DelegateOnly hendeler = new ConsoleInputHendeler_DelegateOnly();
            AlphaNumericCollector alphaNumeric = new AlphaNumericCollector();
            StringCollector stringCollector = new StringCollector();


            Console.WriteLine("Введіть стрічку");
            Console.WriteLine("Пуста стрічка - кінець програми\n");


            hendeler.AddToDelegate(Hendeler_PassToCollector);
            while (true) 
            {
                stringFromConsole = Console.ReadLine();

                if(hendeler.ContainsNumber(stringFromConsole))
                {
                    hendeler.InvokeDelegate(alphaNumeric, stringFromConsole);
                }
                else
                {
                    if (stringFromConsole == "")
                        break;

                    hendeler.InvokeDelegate(stringCollector, stringFromConsole);
                }
            } 
        }

        private static void Hendeler_PassToCollector(ICollector collector, string str)
        {
            collector?.AddToCollection(str);
        }

        //class ConsoleInputHendeler
        //{
        //    public delegate void Collector(ICollector collector, string str);
        //    public  event Collector PassToCollector;
        //    public void InvokeEvent(ICollector collector, string str)
        //    {
        //        PassToCollector?.Invoke(collector, str);
        //    }
        //    public bool ContainsNumber(string str)
        //    {
        //        string[] strArray = str.Split(" ");
        //        foreach (string s in strArray)
        //        {
        //            if (int.TryParse(s, out int res))
        //            {
        //                return true;
        //            }
        //        }

        //        return false;
        //    }
        //}

        class ConsoleInputHendeler_DelegateOnly
        {
            public delegate void Collector(ICollector collector, string str);
            private Collector collectorDelegate;

            public void AddToDelegate(Collector function)
            {
                collectorDelegate = function;
            }
            public void InvokeDelegate(ICollector collector, string str)
            {
                collectorDelegate?.Invoke(collector, str);
            }
            public bool ContainsNumber(string str)
            {
                string[] strArray = str.Split(" ");
                foreach (string s in strArray)
                {
                    if (int.TryParse(s, out int res))
                    {
                        return true;
                    }
                }

                return false;
            }
        }


    }
}
