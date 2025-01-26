using System;

namespace T3.Pr1
{
    public class HidraulicSystem : AEnergySystem, IEnergyCalculus
    {
        private double waterFlow;

        public double GetWaterFlow() { return this.waterFlow; }

        public void SetWaterFlow(double waterFlow) { this.waterFlow = waterFlow; }

        public HidraulicSystem()
        {
            Type = "Hidràulic";
        }

        public override void ConfigurateParameters()
        {
            const string MsgIntroduceWaterFlow = "Introdueix el cabal de l'aigua (mínim 20 m^3): ";
            const string MsgWaterFlowError = "Error. El cabal d'aigua ha de ser com a mínim 20 m^3.";
            const int MinWaterFlow = 20;

            Console.WriteLine(MsgIntroduceWaterFlow);

            while (!double.TryParse(Console.ReadLine(), out waterFlow) || waterFlow < MinWaterFlow)
            {
                Console.WriteLine();
                Console.WriteLine(MsgWaterFlowError);
            }
            Console.WriteLine();
        }

        public override double CalculateEnergy()
        {
            GeneratedEnergy = waterFlow * 9.8 * 9.8;

            return GeneratedEnergy;
        }
    }
}

