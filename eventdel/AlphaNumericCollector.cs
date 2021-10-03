using System;
using System.Collections.Generic;
using System.Text;

namespace EventsDelegates
{
    class AlphaNumericCollector : ICollector
    {
        private List<string> listOfStrings = new List<string>();

        public void AddToCollection(string str)
        {
            listOfStrings.Add(str);
        }
    }
}
