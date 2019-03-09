using NameSorter.Services;
using Xunit;

namespace NameSorterTest
{
    public class DataValidationServiceUnitTests
    {
        private DataValidationService _dataValidation = new DataValidationService();

        [Fact]
        public void ValidateNameLineItemForLettersOnly()
        {
            //Arrange
            string nameLineItem = "Sweta Shah 123";
            bool actResult = false;

            //Act
            bool outputResult = _dataValidation.IsValid(nameLineItem);

            //Assert
            Assert.Equal(outputResult, actResult);
        }

        [Fact]
        public void ValidateNameLineItemForLessThanTwoWords()
        {
            //Arrange
            string nameLineItem = "Sweta";
            bool actResult = false;

            //Act
            bool outputResult = _dataValidation.IsValid(nameLineItem);

            //Assert
            Assert.Equal(outputResult, actResult);
        }

        [Fact]
        public void ValidateNameLineItemForExtraSpaces()
        {
            //Arrange
            string nameLineItem = "Sweta      ";
            bool actResult = false;

            //Act
            bool outputResult = _dataValidation.IsValid(nameLineItem);

            //Assert
            Assert.Equal(outputResult, actResult);
        }

        [Fact]
        public void ValidateNameLineItemForMoreThanFourWords()
        {
            //Arrange
            string nameLineItem = "Sweta Anant Maheshbhai Shantilal Shah";
            bool actResult = false;

            //Act
            bool outputResult = _dataValidation.IsValid(nameLineItem);

            //Assert
            Assert.Equal(outputResult, actResult);
        }

        [Fact]
        public void ValidateNameLineItemForValidFormat()
        {
            //Arrange
            string nameLineItem = "Sweta Anant Maheshbhai Shah";
            bool actResult = true;

            //Act
            bool outputResult = _dataValidation.IsValid(nameLineItem);

            //Assert
            Assert.Equal(outputResult, actResult);
        }
    }
}
