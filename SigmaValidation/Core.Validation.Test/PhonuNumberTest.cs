using System;
using Xunit;

namespace Core.Validation.Test
{
    public class PhonuNumberTest
    {
        [Fact]
        public void IsPhoneNumber_NumberOnly()
        {
            //Arrange
            string phoneNumber = "2222222222";
            //Act
            var result = phoneNumber.IsPhoneNumber();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_AlphaNumeric()
        {
            //Arrange
            string phoneNumber = "2d22a22b22";
            //Act
            var result = phoneNumber.IsPhoneNumber();
            //Assert
            Assert.False(result.Result);
            Assert.True(!string.IsNullOrEmpty(result.Message));
        }

        [Fact]
        public void IsPhoneNumber_NumberWithHyphen()
        {
            //Arrange
            string phoneNumber = "222-222-2222";
            //Act
            var result = phoneNumber.IsPhoneNumber();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_NumberWithDoubleHyphen()
        {
            //Arrange
            string phoneNumber = "222-222--2222";
            //Act
            var result = phoneNumber.IsPhoneNumber();
            //Assert
            Assert.False(result.Result);
            Assert.True(!string.IsNullOrEmpty(result.Message));
        }

        [Fact]
        public void IsPhoneNumber_NumberWithBrackets()
        {
            //Arrange
            string phoneNumber = "(222)-222-2222";
            //Act
            var result = phoneNumber.IsPhoneNumber();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_NumberWithSpaces()
        {
            //Arrange
            string phoneNumber = "222 222 2222";
            //Act
            var result = phoneNumber.IsPhoneNumber();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_NumberWithDoubleSpaces()
        {
            //Arrange
            string phoneNumber = "222 222  2222";
            //Act
            var result = phoneNumber.IsPhoneNumber();
            //Assert
            Assert.False(result.Result);
            Assert.True(!string.IsNullOrEmpty(result.Message));
        }

        [Fact]
        public void IsPhoneNumber_NumberWithPlus()
        {
            //Arrange
            string phoneNumber = "+222 222 2222";
            //Act
            var result = phoneNumber.IsPhoneNumber();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_NumberWithCountryCode()
        {
            //Arrange
            string phoneNumber = "+97725522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("NP");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }
    }
}