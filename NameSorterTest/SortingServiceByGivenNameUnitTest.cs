using NameSorter.Models;
using NameSorter.Rules;
using System.Collections.Generic;
using Xunit;

namespace NameSorterTest
{
    public class SortingServiceByGivenNameUnitTest
    {

        ISortingRule _iSortingRule = new GivenNameSortingRule();

        [Fact]
        public void GivenNameSortingRuleTest()
        {
            //Arrange
            List<Name> listOfNames = new List<Name>();
            listOfNames.Add(new Name
            {
                GivenName = "Janet", LastName = "Parsons"
            });
            listOfNames.Add(new Name
            {
                GivenName = "Vaughn", LastName = "Lewis"
            });
            listOfNames.Add(new Name
            {
                GivenName = "Adonis Julius", LastName = "Archer"
            });
            listOfNames.Add(new Name
            {
                GivenName = "Shelby Nathan", LastName = "Yoder"
            });

            List<Name> actResult = new List<Name>();
            actResult.Add(new Name
            {
                GivenName = "Adonis Julius", LastName = "Archer"
            });
            actResult.Add(new Name
            {
                GivenName = "Janet", LastName = "Parsons"
            });
            actResult.Add(new Name
            {
                GivenName = "Shelby Nathan", LastName = "Yoder"
            });
            actResult.Add(new Name
            {
                GivenName = "Vaughn", LastName = "Lewis"
            });

            //Act
            List<Name> outputResult = _iSortingRule.SortNameList(listOfNames);

            //Assert
            Assert.Equal(outputResult, actResult);
        }
        

    }
}
