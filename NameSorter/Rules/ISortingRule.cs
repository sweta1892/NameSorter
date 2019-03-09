using NameSorter.Models;
using System.Collections.Generic;

namespace NameSorter.Rules
{
    interface ISortingRule
    {
        bool IsMatch(string rule);
        List<Name> SortNameList(List<Name> listOfNames);
    }
}
