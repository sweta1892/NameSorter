using NameSorter.Models;
using NameSorter.Rules;
using System.Collections.Generic;
using Xunit;

namespace NameSorterTest
{
    public class SortingServiceByLastNameThenGivenNameUnitTest
    {

        ISortingRule _iSortingRule = new LastNameThenGivenNameSortingRule();

        [Fact]
        public void LastNameThenGivenNameSortingRuleTest()
        {
            //Arrange
            List<Name> listOfNames = new List<Name>();
            listOfNames.Add(new Name
            {
                GivenName = "Sweta Anant", LastName = "Shah"
            });
            listOfNames.Add(new Name
            {
                GivenName = "Sweta", LastName = "Shah"
            });
            listOfNames.Add(new Name
            {
                GivenName = "Shriya Anant", LastName = "Shah"
            });
            listOfNames.Add(new Name
            {
                GivenName = "Param", LastName = "Shah"
            });

            List<Name> actResult = new List<Name>();
            actResult.Add(new Name
            {
                GivenName = "Param", LastName = "Shah"
            });
            actResult.Add(new Name
            {
                GivenName = "Shriya Anant", LastName = "Shah"
            });
            actResult.Add(new Name
            {
                GivenName = "Sweta", LastName = "Shah"
            });
            actResult.Add(new Name
            {
                GivenName = "Sweta Anant", LastName = "Shah"
            });

            //Act
            List<Name> outputResult = _iSortingRule.SortNameList(listOfNames);

            //Assert
            Assert.Equal(outputResult, actResult);
        }
        

    }
}
