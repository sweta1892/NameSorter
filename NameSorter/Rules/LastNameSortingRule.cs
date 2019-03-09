using NameSorter.Models;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Rules
{
    class LastNameSortingRule : ISortingRule
    {
        public bool IsMatch(string rule)
        {
            return rule.Equals("LastName");
        }

        public List<Name> SortNameList(List<Name> listOfNames)
        {
            IEnumerable<Name> sortedListOfNames = from person in listOfNames
                                                  orderby person.lastName
                                                  select person;
            return sortedListOfNames.ToList();
        }
    }
}
