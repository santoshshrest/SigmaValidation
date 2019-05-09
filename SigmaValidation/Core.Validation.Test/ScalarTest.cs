using System;
using System.Collections.Generic;
using Xunit;

namespace Core.Validation.Test
{
    public class ScalarTest
    {
        [Fact]
        public void IsScalar_StringVariable()
        {
            //Arrange
            var variable = "test_data";
            //Act
            var result = variable.IsScalar();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
        }

        [Fact]
        public void IsScalar_IntVariable()
        {
            //Arrange
            var variable = 1;
            //Act
            var result = variable.IsScalar();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
        }

        [Fact]
        public void IsScalar_DoubleVariable()
        {
            //Arrange
            var variable = 1111111111111.444;
            //Act
            var result = variable.IsScalar();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
        }

        [Fact]
        public void IsScalr_BoolVariable()
        {
            //Arrange
            var variable = true;
            //Act
            var result = variable.IsScalar();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
        }

        [Fact]
        public void IsScalar_InvalidVariable()
        {
            //Arrange
            var variable = DateTime.UtcNow;
            //Act
            var result = variable.IsScalar();
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Provided data is not scalar: {variable}. Data Type: {variable.GetType().Name}", result.Message);
        }

        [Fact]
        public void IsScalar_ArrayValid()
        {
            //Arrange
            object[] variables = new object[] { "str1", 1, 1.1, true };
            //Act
            var result = variables.IsScalar();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
        }

        [Fact]
        public void IsScalar_ArrayInvalid()
        {
            //Arrange
            object[] variables = new object[] { "str1", 1, 1.1, DateTime.Now };
            //Act
            var result = variables.IsScalar();
            //Assert
            Assert.False(result.Result);
            Assert.Equal($"Provided data is not scalar: {variables[3]}. Data Type: {variables[3].GetType().Name}", result.Message);
        }

        [Fact]
        public void IsScalar_ListValid()
        {
            //Arrange
            IList<object> variables = new List<object> { "str1", 1, 1.1, true };
            //Act
            var result = variables.IsScalar();
            //Assert
            Assert.True(result.Result);
            Assert.Equal("Success", result.Message);
        }

        [Fact]
        public void IsScalr_ListInvalid()
        {
            //Arrange
            IList<object> variables = new List<object> { "str1", 1, 1.1, DateTime.Now };
            //Act
            var result = variables.IsScalar();
            //Assert
            Assert.True(result.Result);
            Assert.Equal($"Provided data is not scalar: {variables[3]}. Data Type: {variables[3].GetType().Name}", result.Message);
        }
    }
}