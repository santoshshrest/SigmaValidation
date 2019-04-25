using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Core.Validation.Test
{
    public class EmailTest
    {
        [Fact]
        public void Email_Valid()
        {
            //Arrange
            string email = "santosh@domain.com";
            //Act
            var operation = email.IsEmail();
            //Assert
            Assert.True(operation.Result);
            Assert.Equal("Success", operation.Message);
            Assert.Null(operation.Exception);
        }
    }
}