using NSubstitute;
using NUnit.Framework;
using RomanParser.Core;
using System.Collections.Generic;

namespace RomanNumberParser.Core.Test
{
    [TestFixture]
    public class RomanExpressionParserTester
    {

        [Test]
        public void RomanInputAsSixParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "VI";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);

            //Assert
            Assert.That(result, Is.EqualTo("6"));
        }

        [Test]
        public void RomanInputAs1ParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "I";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);

            //Assert
            Assert.That(result, Is.EqualTo("1"));
        }

        [Test]
        public void RomanInputAsFiveParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "V";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);

            //Assert
            Assert.That(result, Is.EqualTo("5"));
        }

        [Test]
        public void RomanInputAsTenParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "X";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);
            //Assert
            Assert.That(result, Is.EqualTo("10"));
        }

        [Test]
        public void RomanInputAsFiftyParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "L";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);
            //Assert
            Assert.That(result, Is.EqualTo("50"));
        }


        [Test]
        public void RomanInputAsHundredParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "C";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);
            //Assert
            Assert.That(result, Is.EqualTo("100"));
        }


        [Test]
        public void RomanInputAsFiveHundredParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "D";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);
            //Assert
            Assert.That(result, Is.EqualTo("500"));
        }


        [Test]
        public void RomanInputAsThousandParseTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "M";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);
            //Assert
            Assert.That(result, Is.EqualTo("1000"));
        }

        [Test]
        public void MaxRomanInputTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "MMMCMXCIX";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);
            //Assert
            Assert.That(result, Is.EqualTo("3999"));
        }


        [Test]
        public void RomanInputFourtyEightTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "XLVIII";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);
            //Assert
            Assert.That(result, Is.EqualTo("48"));
        }

            [Test]
        public void RomanSevenTwoSixTest()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var input = "DCCXXVI";
            valueValidator.IsValid(input).Returns(true);

            // Act 
            var parser = new RomanExpressionParser(new List<IValueValidator>() { valueValidator });
            var result = parser.Interpret(input);
            valueValidator.Received().IsValid(input);
            //Assert
            Assert.That(result, Is.EqualTo("726"));
        }
    }
}
