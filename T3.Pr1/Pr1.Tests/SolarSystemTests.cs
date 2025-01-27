using T3.Pr1;
using Xunit;

namespace Pr1.Tests
{
    public class SolarSystemTests
    {
        [Fact]
        public void ConfigurateParameters_ShouldSetValidSunshineHours()
        {
            // Arrange
            var system = new SolarSystem();
            var validSunshineHours = 10;

            // Act
            system.SetSunshineHours(validSunshineHours);

            // Assert
            Assert.Equal(validSunshineHours, system.GetSunshineHours());
        }

        [Fact]
        public void ConfigurateParameters_ShouldNotAcceptInvalidSunshineHours()
        {
            // Arrange
            var system = new SolarSystem();

            // Act
            system.SetSunshineHours(-1);

            // Assert
            Assert.True(system.GetSunshineHours() > 0);
        }

        [Fact]
        public void CalculateEnergy_ShouldReturnExpectedEnergy()
        {
            // Arrange
            var system = new SolarSystem();
            var sunshineHours = 8;
            system.SetSunshineHours(sunshineHours);

            // Act
            var energy = system.CalculateEnergy();

            // Assert
            var expectedEnergy = sunshineHours * 1.5;
            Assert.Equal(expectedEnergy, energy, 2);
        }
    }
}
