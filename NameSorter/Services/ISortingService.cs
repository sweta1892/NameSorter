using NameSorter.Models;
using System.Collections.Generic;

namespace NameSorter.Services
{
    interface ISortingService
    {
        List<Name> SortNameList(List<Name> listOfNames);
    }
}
