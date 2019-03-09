using NameSorter.Models;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Rules
{
    class FirstNameSortingRule : ISortingRule
    {
        public bool IsMatch(string rule)
        {
            return rule.Equals("FirstName");
        }

        public List<Name> SortNameList(List<Name> listOfNames)
        {
            IEnumerable<Name> sortedListOfNames = from person in listOfNames
                                                  orderby person.firstName
                                                  select person;
            return sortedListOfNames.ToList();
        }
    }
}
