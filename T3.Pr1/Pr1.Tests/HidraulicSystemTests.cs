using T3.Pr1;
using Xunit;

namespace Pr1.Tests
{
    public class HidraulicSystemTests
    {
        [Fact]
        public void ConfigurateParameters_ShouldSetValidWaterFlow()
        {
            // Arrange
            var system = new HidraulicSystem();
            var validWaterFlow = 50;

            // Act
            system.SetWaterFlow(validWaterFlow);

            // Assert
            Assert.Equal(validWaterFlow, system.GetWaterFlow());
        }

        [Fact]
        public void CalculateEnergy_ShouldReturnExpectedEnergy()
        {
            // Arrange
            var system = new HidraulicSystem();
            system.SetWaterFlow(20);

            // Act
            var energy = system.CalculateEnergy();

            // Assert
            var expectedEnergy = 20 * 9.8 * 9.8;
            Assert.Equal(expectedEnergy, energy, 2);
        }
    }
}