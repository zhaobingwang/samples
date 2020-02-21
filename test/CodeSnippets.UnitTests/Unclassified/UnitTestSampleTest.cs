using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CodeSnippets.UnClassified;

namespace CodeSnippets.UnitTests.Unclassified
{
    public class UnitTestSampleTest
    {
        [Fact]
        public void IsStringLong_ReturnTrue_WithExpectedParameters()
        {
            // Arrange
            string val = "1234567";

            // Act
            var actual = UnitTestSample.IsStringLong(val);

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void IsStringLong_ReturnTrue_WithNullParameters()
        {
            // Arrange
            string val = null;

            // Act
            var actual = UnitTestSample.IsStringLong(val);

            // Assert
            Assert.False(actual);
        }

        // 'val.Length>6' threw an exception of type 'System.NullReferenceException'
    }
}

