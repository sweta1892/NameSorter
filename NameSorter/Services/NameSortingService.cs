using NameSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using NameSorter.Rules;

namespace NameSorter.Services
{
    class NameSortingService : ISortingService
    {
        private readonly List<ISortingRule> _sortingRules;
        private string _sortBy;

        public NameSortingService(string sortBy)
        {
            this._sortBy = sortBy;
            _sortingRules = new List<ISortingRule>();
            _sortingRules.Add(new FirstNameSortingRule());
            _sortingRules.Add(new LastNameSortingRule());
            _sortingRules.Add(new LastNameThenFirstNameSortingRule());
        }

        public List<Name> SortNameList(List<Name> listOfNames)
        {
            List<Name> sortedListOfNames = new List<Name>();
            try
            {
                sortedListOfNames =_sortingRules.First(r => r.IsMatch(_sortBy)).SortNameList(listOfNames);
            }
            catch(InvalidOperationException execption)
            {
                Console.WriteLine(execption.Message);
            }
            return sortedListOfNames;
        }
    }
}
