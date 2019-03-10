using NameSorter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NameSorter.Services
{
    interface IValidateService
    {
        bool IsValid(string nameLineItem);
    }
}
