using NameSorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using NameSorter.Rules;
using NLog;

namespace NameSorter.Services
{
    class NameSortingService : ISortingService
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        private readonly List<ISortingRule> _sortingRules;
        private string _sortBy;

        public NameSortingService(string sortBy)
        {
            this._sortBy = sortBy;
            _sortingRules = new List<ISortingRule>();
            _sortingRules.Add(new GivenNameSortingRule());
            _sortingRules.Add(new LastNameSortingRule());
            _sortingRules.Add(new LastNameThenGivenNameSortingRule());
        }

        public List<Name> SortNameList(List<Name> listOfNames)
        {
            List<Name> sortedListOfNames = new List<Name>();
            try
            {
                sortedListOfNames =_sortingRules.First(r => r.IsMatch(_sortBy)).SortNameList(listOfNames);
            }
            catch(InvalidOperationException e)
            {
                log.Error(e.Message);
            }
            return sortedListOfNames;
        }
    }
}
