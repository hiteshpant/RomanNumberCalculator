using NSubstitute;
using NUnit.Framework;
using RomanParser.Core;
using RomanParser.Core.Contract;

namespace RomanNumberParser.Core.Test
{
	[TestFixture]
    public class RomanSumCalulateTester
    {


        [Test]
        public void TestSumWithTwoAndThree()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var expression = Substitute.For<IExpression>();

            var input1 = "II";
            var input2 = "III";
            valueValidator.IsValid(input1).Returns(true);
            valueValidator.IsValid(input2).Returns(true);
            expression.Interpret(input1).Returns("2");
            expression.Interpret(input2).Returns("3");

            // Act 
            var calculator = new RomanSumCalculator(expression);
            var result =calculator.GetSum(input1, input2);


            //Assert
            Assert.That(result, Is.EqualTo("V"));
        }


        [Test]
        public void TestSumWithComplexInput()
        {
            //Arrange
            var valueValidator = Substitute.For<IValueValidator>();
            var expression = Substitute.For<IExpression>();

            var input1 = "DCCXXVI";
            var input2 = "XLVIII";
            valueValidator.IsValid(input1).Returns(true);
            valueValidator.IsValid(input2).Returns(true);
            expression.Interpret(input1).Returns("726");
            expression.Interpret(input2).Returns("48");

            // Act 
            var calculator = new RomanSumCalculator(expression);
            var result = calculator.GetSum(input1, input2);


            //Assert
            Assert.That(result, Is.EqualTo("DCCLXXIV"));
        }


        //[Test]
        //public void TestSumWithTwoAndThree()
        //{
        //    //Arrange
        //    var valueValidator = Substitute.For<IValueValidator>();
        //    var expression = Substitute.For<IExpression>();

        //    var input1 = "II";
        //    var input2 = "III";
        //    valueValidator.IsValid(input1).Returns(true);
        //    valueValidator.IsValid(input2).Returns(true);
        //    expression.Interpret(input1).Returns("2");
        //    expression.Interpret(input2).Returns("3");

        //    // Act 
        //    var calculator = new RomanSumCalculator(expression);
        //    var result = calculator.GetSum(input1, input2);


        //    //Assert
        //    Assert.That(result, Is.EqualTo("V"));
        //}

    }
}