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
        public void IsPhoneNumber_NP_CountryCode()
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
        public void IsPhoneNumber_NP_InvalidCountryCode()
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
        public void IsPhoneNumber_NP_AreaCode()
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
        public void IsPhoneNumber_NP_InvalidAreaCode()
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
        public void IsPhoneNumber_NP_InvalidNumber()
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
        public void IsPhoneNumber_NP_LongNumber()
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
        public void IsPhoneNumber_DK_CountryCode()
        {
            //Arrange
            string phoneNumber = "+4532522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("DK");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_DK_InvalidCountryCode()
        {
            //Arrange
            string phoneNumber = "+4632522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("DK");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_DK_AreaCode()
        {
            //Arrange
            string phoneNumber = "32522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("DK");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_DK_InvalidAreaCode()
        {
            //Arrange
            string phoneNumber = "11522866";
            //Act
            var result = phoneNumber.IsPhoneNumber("DK");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_US_CountryCode()
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
        public void IsPhoneNumber_US_InvalidCountryCode()
        {
            //Arrange
            string phoneNumber = "+22012224545";
            //Act
            var result = phoneNumber.IsPhoneNumber("US");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_US_AreaCode()
        {
            //Arrange
            string phoneNumber = "2012224545";
            //Act
            var result = phoneNumber.IsPhoneNumber("US");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_US_InvalidAreaCode()
        {
            //Arrange
            string phoneNumber = "1012224545";
            //Act
            var result = phoneNumber.IsPhoneNumber("US");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_IN_CountryCode()
        {
            //Arrange
            string phoneNumber = "+912234345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("IN");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_IN_InvalidCountryCode()
        {
            //Arrange
            string phoneNumber = "+922234345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("IN");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_IN_AreaCode()
        {
            //Arrange
            string phoneNumber = "2234345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("IN");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_IN_InvalidAreaCode()
        {
            //Arrange
            string phoneNumber = "1034345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("IN");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_CN_CountryCode()
        {
            //Arrange
            string phoneNumber = "+862234345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("CN");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_CN_InvalidCountryCode()
        {
            //Arrange
            string phoneNumber = "+872234345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("CN");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_CN_AreaCode()
        {
            //Arrange
            string phoneNumber = "2234345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("CN");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_CN_InvalidAreaCode()
        {
            //Arrange
            string phoneNumber = "2634345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("CN");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_UK_CountryCode()
        {
            //Arrange
            string phoneNumber = "+442034345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("UK");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_UK_InvalidCountryCode()
        {
            //Arrange
            string phoneNumber = "+452234345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("UK");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_UK_AreaCode()
        {
            //Arrange
            string phoneNumber = "2034345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("UK");
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
            Assert.Null(result.Exception);
        }

        [Fact]
        public void IsPhoneNumber_UK_InvalidAreaCode()
        {
            //Arrange
            string phoneNumber = "2234345678";
            //Act
            var result = phoneNumber.IsPhoneNumber("UK");
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Invalid phone number {phoneNumber}.", result.Message);
            Assert.Null(result.Exception);
        }
    }
}