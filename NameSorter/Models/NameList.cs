using System;
using System.Collections.Generic;

namespace NameSorter.Models
{
    class NameList
    {
        public List<Name> listOfNames { get ; set ; }

        public NameList()
        {
            listOfNames = new List<Name>();
        }

        public void PrintFullList()
        {
            foreach (Name name in listOfNames)
            {
                Console.WriteLine(name.ToString());
            }
        }
    }
}
