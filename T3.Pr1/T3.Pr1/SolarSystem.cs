using System;
namespace T3.Pr1
{
    public class SolarSystem : AEnergySystem, IEnergyCalculus
    {
        private double sunshineHours;

        public double GetSunshineHours() { return this.sunshineHours; }

        public void SetSunshineHours(double sunshineHours) { this.sunshineHours = sunshineHours; }

        public SolarSystem()
        {
            Type = "Solar";

        }

        public override void ConfigurateParameters()
        {
            const string MsgIntroduceSunshineHours = "Introdueix les hores de sol (superior a 1): ";
            const string MsgSunshineHoursError = "Error. Les hores de sol han de ser superiors de 1.";
            const int MinSunshineHours = 1;

            Console.WriteLine(MsgIntroduceSunshineHours);

            while (!double.TryParse(Console.ReadLine(), out sunshineHours) || sunshineHours <= MinSunshineHours)
            {
                Console.WriteLine();
                Console.WriteLine(MsgSunshineHoursError);
            }
            Console.WriteLine();
        }

        public override double CalculateEnergy()
        {
            GeneratedEnergy = sunshineHours * 1.5;

            return GeneratedEnergy;
        }
    }
}

