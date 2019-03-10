using System;
using System.Collections.Generic;

namespace NameSorter.Models
{
    class PrintNameList
    {
        public void PrintFullList(List<Name> ListOfNames)
        {
            foreach (Name name in ListOfNames)
            {
                Console.WriteLine(name.ToString());
            }
        }
    }
}
