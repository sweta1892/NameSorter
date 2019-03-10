using System;
using System.Text.RegularExpressions;

namespace NameSorter.Services
{
    class NameDataValidateService : IValidateService
    {
        public bool IsValid(string nameLineItem)
        {
             
        if (!Regex.IsMatch(nameLineItem, @"^[A-Za-z ]+$"))
            {
                return false;
            }

        if (nameLineItem.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length < 2 || 
            nameLineItem.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length > 4)
            {
                return false;
            }

            return true;
        }
    }
}

