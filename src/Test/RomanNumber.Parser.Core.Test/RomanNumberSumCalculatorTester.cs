using NSubstitute;
using NUnit.Framework;
using RomanParser.Core;
using RomanParser.Core.Parser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RomanNumberParser.Core.Test
{
    [TestFixture]
    public class RomanNumberSumCalculatorTester
    {
        [Test]
        public async Task TestSumWithTwoAndThree()
        {

            var valueValidator = Substitute.For<IValueValidator>();

            //Arrange 
            var input1 = "II";
            var input2 = "CXL";
            var romanValueValidator = new RomanValueValidator();
            romanValueValidator.IsValid(input1);
            romanValueValidator.IsValid(input2);
            var calculator = new RomanNumberSumCalculator(new List<IValueValidator?>() { romanValueValidator });

            //ACT
            var result = await calculator.CalculateSum(input1, input2);

            //Assert
            Assert.That(result, Is.EqualTo("CXLII"));
        }

        [Test]
        public async Task TestSumWithSubtractiveCase()
        {           

            //Arrange 
            var input1 = "CXXIV";
            var input2 = "CXL";
            var romanValueValidator = new RomanValueValidator();
            romanValueValidator.IsValid(input1);
            romanValueValidator.IsValid(input2);
            var calculator = new RomanNumberSumCalculator(new List<IValueValidator?>() { romanValueValidator });

            //Act
            var result = await calculator.CalculateSum(input1, input2);

            //Assert
            Assert.That(result, Is.EqualTo("CCLXIV"));
        }

        [Test]
        public async Task TestSumWithAdditiveNotation()
        {
            var valueValidator = Substitute.For<IValueValidator>();

            //Arrange
            var input1 = "II";
            var input2 = "III";
            var romanValueValidator = new RomanValueValidator();
            romanValueValidator.IsValid(input1);
            romanValueValidator.IsValid(input2);
            var calculator = new RomanNumberSumCalculator(new List<IValueValidator?>() { romanValueValidator });
            //Act
            var result = await calculator.CalculateSum(input1, input2);

            //Assert
            Assert.That(result, Is.EqualTo("V"));
        }

        [Test]
        public async Task TestSumWithAdditiveAndSubtractive()
        {
            //Arrange
            var input1 = "CCCLXIX";
            var input2 = "DCCCXLV";
            var romanValueValidator = new RomanValueValidator();
            romanValueValidator.IsValid(input1);
            romanValueValidator.IsValid(input2);
            var calculator = new RomanNumberSumCalculator(new List<IValueValidator?>() { romanValueValidator });
            
            //Act
            var result = await calculator.CalculateSum(input1, input2);

            //Assert
            Assert.That(result, Is.EqualTo("MCCXIV"));
        }

        [Test]
        public async Task TestMax()
        {

            //Arrange
            var input1 = "MMMCMXCVIII";
            var input2 = "I";
            var romanValueValidator = new RomanValueValidator();
            romanValueValidator.IsValid(input1);
            romanValueValidator.IsValid(input2);
            var calculator = new RomanNumberSumCalculator(new List<IValueValidator?>() { romanValueValidator });

            //Act
            var result = await calculator.CalculateSum(input1,input2);

            //Assert
            Assert.That(result, Is.EqualTo("MMMCMXCIX"));
        }

        [Test]
        public async Task TestSumWithComplexInput()
        {

            //Arrange
            var input1 = "DCCXXVI";
            var input2 = "XLVIII";
            var romanValueValidator = new RomanValueValidator();
            romanValueValidator.IsValid(input1);
            romanValueValidator.IsValid(input2);
            var calculator = new RomanNumberSumCalculator(new List<IValueValidator?>() { romanValueValidator });
            //Act
            var result = await calculator.CalculateSum(input1, input2);

            //Assert
            Assert.That(result, Is.EqualTo("DCCLXXIV"));
        }

        [Test]
        public async Task TestExceptionWithInvalidInputInput()
        {
            //Arrange
            var input1 = "DCCXXVIMMMM";
            var input2 = "XLVIIIXXXXXX";
           
            var romanValueValidator = new RomanValueValidator();
            var calculator = new RomanNumberSumCalculator(new List<IValueValidator?>() { romanValueValidator });

            //Act
            Assert.That(async () => await calculator.CalculateSum(input1, input2), Throws.InstanceOf<InValidRomanValueException>());
        }


    }
}
