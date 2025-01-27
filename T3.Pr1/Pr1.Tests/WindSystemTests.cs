using T3.Pr1;
using Xunit;

namespace Pr1.Tests
{
    public class WindSystemTests
    {
        [Fact]
        public void ConfigurateParameters_ShouldSetValidWindSpeed()
        {
            // Arrange
            var system = new WindSystem();
            var validWindSpeed = 10;

            // Act
            system.SetWindSpeed(validWindSpeed);

            // Assert
            Assert.Equal(validWindSpeed, system.GetWindSpeed());
        }

        [Fact]
        public void ConfigurateParameters_ShouldNotAcceptInvalidWindSpeed()
        {
            // Arrange
            var system = new WindSystem();

            // Act
            system.SetWindSpeed(-5);

            // Assert
            Assert.True(system.GetWindSpeed() >= 0);
        }

        [Fact]
        public void CalculateEnergy_ShouldReturnExpectedEnergy()
        {
            // Arrange
            var system = new WindSystem();
            var windSpeed = 5;
            system.SetWindSpeed(windSpeed);

            // Act
            var energy = system.CalculateEnergy();

            // Assert
            var expectedEnergy = Math.Pow(windSpeed, 3) * 0.2;
            Assert.Equal(expectedEnergy, energy, 2);
        }
    }
}
