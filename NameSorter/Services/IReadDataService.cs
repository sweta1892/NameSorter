using NameSorter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    interface IReadDataService
    {
        List<Name> ReadData(string DataSource);
    }
}
