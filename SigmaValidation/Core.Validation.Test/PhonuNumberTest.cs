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
        public void IsPhoneNumber_NumberWithNPCountryCode()
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

        [Fact]
        public void IsPhoneNumber_NumberWithNPWrongCountryCode()
        {
            //Arrange
            string phoneNumber = "+97125522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("NP");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_NumberWithNPCountryCodeWrongAreaCode()
        {
            //Arrange
            string phoneNumber = "+977125522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("NP");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_WrongInitialNumberWithNPCountryCode()
        {
            //Arrange
            string phoneNumber = "+9779612040361";
            //Act
            var result = phoneNumber.IsPhoneNumber("NP");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_NumberWithNPAreaCode()
        {
            //Arrange
            string phoneNumber = "025522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("NP");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_InvalidNumberWithNPCountryCode()
        {
            //Arrange
            string phoneNumber = "+9709862022592";
            //Act
            var result = phoneNumber.IsPhoneNumber("NP");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_LongNumberWithNPCountryCode()
        {
            //Arrange
            string phoneNumber = "+97798620225921";
            //Act
            var result = phoneNumber.IsPhoneNumber("NP");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_NumberWithDKCountryCode()
        {
            //Arrange
            string phoneNumber = "+4525522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("DK");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_InvalidNumberWithDKCountryCode()
        {
            //Arrange
            string phoneNumber = "+4625522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("DK");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_NumberWithInvalidCountryCode()
        {
            //Arrange
            string phoneNumber = "+97725522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("DE");
            //Assert
            Assert.False(result.Result);
            Assert.Equal("Invalid country code DE.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_NumberWithUSCountryCode()
        {
            //Arrange
            string phoneNumber = "+12012224545";
            //Act
            var result = phoneNumber.IsPhoneNumber("US");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_InvalidNumberWithUSCountryCode()
        {
            //Arrange
            string phoneNumber = "+125522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("US");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }
    }
}