using System;
using System.Collections.Generic;
using System.Text;
using NameSorter.Models;
using Xunit;

namespace NameSorterTest
{
    public class ModelUnitTests
    {
        private CreateNameObjects _createNameObjects = new CreateNameObjects();

        [Fact]
        public void CreateNameObjectFromStringShouldReturn()
        {
            //Arrange
            string line = "Sweta Anant Shah";
            Name actName = new Name
            {
                firstName = "Sweta Anant",
                lastName = "Shah"
            };

            //Act
            Name outputName = _createNameObjects.CreateNameObjectFromString(line);

            //Assert
            Assert.Equal(outputName, actName);
        }

    }
}
