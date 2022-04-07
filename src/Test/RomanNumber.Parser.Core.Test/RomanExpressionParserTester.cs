using NSubstitute;
using NUnit.Framework;
using RomanParser.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RomanNumberParser.Core.Test
{
    [TestFixture]
    public class RomanExpressionParserTester
    {

        [Test]
        public async Task RomanInputAsSixParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "6";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();
            var result = await parser.Interpret(input);

            //Assert
            Assert.That(result, Is.EqualTo("VI"));
        }

        [Test]
        public async Task RomanInputAs1ParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "1";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();
            var result = await parser.Interpret(input);

            //Assert
            Assert.That(result, Is.EqualTo("I"));
        }

        [Test]
        public async Task RomanInputAsFiveParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "5";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();
            var result = await parser.Interpret(input);

            //Assert
            Assert.That(result, Is.EqualTo("V"));
        }

        [Test]
        public async Task RomanInputAsTenParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "10";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();
            var result = await parser.Interpret(input);
            //Assert
            Assert.That(result, Is.EqualTo("X"));
        }

        [Test]
        public async Task RomanInputAsFiftyParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "50";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();
            var result = await parser.Interpret(input);
            //Assert
            Assert.That(result, Is.EqualTo("L"));
        }


        [Test]
        public async Task RomanInputAsHundredParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "100";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();

            var result = await parser.Interpret(input);
            //Assert
            Assert.That(result, Is.EqualTo("C"));
        }


        [Test]
        public async Task RomanInputAsFiveHundredParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "500";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();
            var result = await parser.Interpret(input);
            //Assert
            Assert.That(result, Is.EqualTo("D"));
        }


        [Test]
        public async Task RomanInputAsThousandParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "1000";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();
            var result = await parser.Interpret(input);
            //Assert
            Assert.That(result, Is.EqualTo("M"));
        }

        [Test]
        public async Task MaxRomanInputTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "3999";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();
            var result = await parser.Interpret(input);
            //Assert
            Assert.That(result, Is.EqualTo("MMMCMXCIX"));
        }


        [Test]
        public async Task RomanInputFourtyEightTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "48";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();
            var result = await parser.Interpret(input);
            //Assert
            Assert.That(result, Is.EqualTo("XLVIII"));
        }

            [Test]
        public async Task RomanSevenTwoSixTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "726";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new DecimalToRomanInterpreter();

            var result = await parser.Interpret(input);

            //Assert
            Assert.That(result, Is.EqualTo("DCCXXVI"));
        }
    }
}
