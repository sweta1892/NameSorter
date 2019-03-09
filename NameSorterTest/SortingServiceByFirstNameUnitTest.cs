using NameSorter.Models;
using NameSorter.Rules;
using System.Collections.Generic;
using Xunit;

namespace NameSorterTest
{
    public class SortingServiceByFirstNameUnitTest
    {

        ISortingRule _iSortingRule = new FirstNameSortingRule();

        [Fact]
        public void FirstNameSortingRuleTest()
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
                firstName = "Janet", lastName = "Parsons"
            });
            actResult.Add(new Name
            {
                firstName = "Shelby Nathan", lastName = "Yoder"
            });
            actResult.Add(new Name
            {
                firstName = "Vaughn", lastName = "Lewis"
            });

            //Act
            List<Name> outputResult = _iSortingRule.SortNameList(listOfNames);

            //Assert
            Assert.Equal(outputResult, actResult);
        }
        

    }
}
