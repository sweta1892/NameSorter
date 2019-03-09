using NameSorter.Models;
using NameSorter.Rules;
using System.Collections.Generic;
using Xunit;

namespace NameSorterTest
{
    public class SortingServiceByLastNameThenFirstNameUnitTest
    {

        ISortingRule _iSortingRule = new LastNameThenFirstNameSortingRule();

        [Fact]
        public void LastNameThenFirstNameSortingRuleTest()
        {
            //Arrange
            List<Name> listOfNames = new List<Name>();
            listOfNames.Add(new Name
            {
                firstName = "Sweta Anant", lastName = "Shah"
            });
            listOfNames.Add(new Name
            {
                firstName = "Sweta", lastName = "Shah"
            });
            listOfNames.Add(new Name
            {
                firstName = "Shriya Anant", lastName = "Shah"
            });
            listOfNames.Add(new Name
            {
                firstName = "Param", lastName = "Shah"
            });

            List<Name> actResult = new List<Name>();
            actResult.Add(new Name
            {
                firstName = "Param", lastName = "Shah"
            });
            actResult.Add(new Name
            {
                firstName = "Shriya Anant", lastName = "Shah"
            });
            actResult.Add(new Name
            {
                firstName = "Sweta", lastName = "Shah"
            });
            actResult.Add(new Name
            {
                firstName = "Sweta Anant", lastName = "Shah"
            });

            //Act
            List<Name> outputResult = _iSortingRule.SortNameList(listOfNames);

            //Assert
            Assert.Equal(outputResult, actResult);
        }
        

    }
}
