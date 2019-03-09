using NameSorter.Models;
using NameSorter.Rules;
using System.Collections.Generic;
using Xunit;

namespace NameSorterTest
{
    public class SortingServiceByLastNameUnitTest
    {
        ISortingRule _iSortingRule = new LastNameSortingRule();

        [Fact]
        public void LastNameSortingRuleTest()
        {
            //Arrange
            List<Name> listOfNames = new List<Name>();
            listOfNames.Add(new Name
            {
                firstName = "Janet", lastName = "Parsons"
            });
            listOfNames.Add(new Name
            {
                firstName = "Vaughn", lastName = "Lewis"
            });
            listOfNames.Add(new Name
            {
                firstName = "Adonis Julius", lastName = "Archer"
            });
            listOfNames.Add(new Name
            {
                firstName = "Shelby Nathan", lastName = "Yoder"
            });

            List<Name> actResult = new List<Name>();
            actResult.Add(new Name
            {
                firstName = "Adonis Julius", lastName = "Archer"
            });
            actResult.Add(new Name
            {
                firstName = "Vaughn", lastName = "Lewis"
            });
            actResult.Add(new Name
            {
                firstName = "Janet", lastName = "Parsons"
            });
            actResult.Add(new Name
            {
                firstName = "Shelby Nathan", lastName = "Yoder"
            });
           

            //Act
            List<Name> outputResult = _iSortingRule.SortNameList(listOfNames);

            //Assert
            Assert.Equal(outputResult, actResult);
        }

    }
}
