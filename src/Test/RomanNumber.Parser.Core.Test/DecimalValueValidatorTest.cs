using NUnit.Framework;
using RomanParser.Core;
using System.IO;

namespace RomanNumberParser.Core.Test
{
    [TestFixture]
    public class DecimalValueValidatorTest
    {

        [Test]
        public void ValidDecimalInputtest()
        {
            //Arrange
            string input = "123";
            var validator = new DecimalValueValidator();

            //Act
            var result = validator.IsValid(input);

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void ValidMaxDecimalInputtest()
        {
            //Arrange
            string input = "9999999999999999999909999999999999999999999999";
            var validator = new DecimalValueValidator();


            // Act and Assert
            Assert.Throws(typeof(InvalidDataException), () => validator.IsValid(input));

        }


        [Test]
        public void ValidMaxDecimalValueInputtest()
        {
            //Arrange
            string input = int.MaxValue.ToString();
            input += 1;
            var validator = new DecimalValueValidator();


            // Act and Assert
            Assert.Throws(typeof(InvalidDataException), () => validator.IsValid(input));

        }

        [Test]
        public void InValidMaxAlphaNumericDceimalInputTest1()
        {
            //Arrange
            string input = "999999sdsds9999999999999999999999999";
            var validator = new DecimalValueValidator();


            // Act and Assert
            Assert.Throws(typeof(InvalidDataException), () => validator.IsValid(input));
        }

    }
}
