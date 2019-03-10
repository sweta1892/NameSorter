using NameSorter.Models;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Rules
{
    class LastNameThenGivenNameSortingRule : ISortingRule
    {
        public bool IsMatch(string rule)
        {
            return rule.Equals("LastNameThenGivenName");
        }

        public List<Name> SortNameList(List<Name> listOfNames)
        {
            IEnumerable<Name> sortedListOfNames = from person in listOfNames
                                                  orderby person.LastName, person.GivenName
                                                  select person;

            return sortedListOfNames.ToList();        
        }
    }
}
