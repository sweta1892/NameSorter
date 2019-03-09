using NameSorter.Models;
using System.Collections.Generic;

namespace NameSorter.Services
{
    interface IWriteDataService
    {
        void WriteData(string DataSource, List<Name> listOfNames);
    }
}
