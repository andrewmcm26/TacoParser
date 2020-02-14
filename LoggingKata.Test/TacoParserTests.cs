using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638,-84.677017,Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        

        [Theory]
        [InlineData("34.073638,-84.677017,Taco Bell Acwort...", 34.073638, -84.677017, "Taco Bell Acwort...")]
        public void ShouldParse(string str, double expectedLong, double expectedLat, string expectedName)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(str);

            
            //Asert
            Assert.Equal(actual.Location.Longitude, expectedLong);
            Assert.Equal(actual.Location.Latitude, expectedLat);
            Assert.Equal(actual.Name, expectedName);

        }


        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(str);

            //Assert
            Assert.Null(actual);
            
        }
    }
}
