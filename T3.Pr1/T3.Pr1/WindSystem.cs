using System;

namespace T3.Pr1
{
    public class WindSystem : AEnergySystem, IEnergyCalculus
    {
        private double windSpeed;

        public double GetWindSpeed() { return this.windSpeed; }

        public void SetWindSpeed(double windSpeed) { this.windSpeed = windSpeed; }

        public WindSystem()
        {
            Type = "Eòlic";
        }

        public override void ConfigurateParameters()
        {
            const string MsgIntroduceWindSpeed = "Introdueix la velocitat del vent (mínim 5 m/s): ";
            const string MsgWindSpeedError = "Error. La velocitat del vent ha de ser com a mínim de 5 m/s.";
            const int MinWindSpeed = 5;

            Console.WriteLine(MsgIntroduceWindSpeed);

            while (!double.TryParse(Console.ReadLine(), out windSpeed) || windSpeed < MinWindSpeed)
            {
                Console.WriteLine();
                Console.WriteLine(MsgWindSpeedError);
            }
            Console.WriteLine();
        }

        public override double CalculateEnergy()
        {
            GeneratedEnergy = Math.Pow(windSpeed, 3) * 0.2;

            return GeneratedEnergy;
        }
    }
}

