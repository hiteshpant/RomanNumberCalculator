using NUnit.Framework;
using RomanParser.Core;
using System;

namespace RomanNumberParser.Core.Test
{
    [TestFixture]
    public class RomanValueValidatorTest
    {
        [Test]
        public void ValidRomanInputtest()
        {
            //Arrange
            string input = "LXXIV";
            var validator = new RomanValueValidator();

            //Act
            var result = validator.IsValid(input);

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void ValidMaxRomanInputtest()
        {
            //Arrange
            string input = "MMMCMXCIX";
            var validator = new RomanValueValidator();

            //Act
            var result = validator.IsValid(input);

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void InValidMaxRomanInputTest1()
        {
            //Arrange
            string input = "MMMMMXCIX";
            var validator = new RomanValueValidator();


            // Act and Assert
            Assert.Throws(typeof(InValidRomanValueException), () => validator.IsValid(input));
        }

        [Test]
        public void InValidMaxRomanInputTest2()
        {
            //Arrange
            string input = "IIIIVI";
            var validator = new RomanValueValidator();
                       

            // Act and Assert
            Assert.Throws(typeof(InValidRomanValueException), () => validator.IsValid(input));
        }

        [Test]
        public void InValidMaxRomanInputTest3()
        {
            //Arrange
            string input = "CMCMCMCMCMCMCMC";
            var validator = new RomanValueValidator();


            // Act and Assert
            Assert.Throws(typeof(InValidRomanValueException), () => validator.IsValid(input));
        }


        [Test]
        public void InValidMaxRomanInputTest4()
        {
            //Arrange
            string input = "XIVIII";
            var validator = new RomanValueValidator();


            // Act and Assert
            Assert.Throws(typeof(InValidRomanValueException), () => validator.IsValid(input));
        }

        [Test]
        public void SpecialCharRomanInputTest()
        {
            //Arrange
            string input = "X12Q123-IVIII";
            var validator = new RomanValueValidator();


            // Act and Assert
            Assert.Throws(typeof(InValidRomanValueException), () => validator.IsValid(input));
        }


        [Test]
        public void XIVRomanInputTest()
        {
            //Arrange
            string input = "XIV";
            var validator = new RomanValueValidator();

            var result = validator.IsValid(input);
            // Act and Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void EmptyRomanInputTest()
        {
            //Arrange
            string input= string.Empty;
            var validator = new RomanValueValidator();


            // Act and Assert
            Assert.Throws(typeof(ArgumentNullException), () => validator.IsValid(input));
        }
    }
}
