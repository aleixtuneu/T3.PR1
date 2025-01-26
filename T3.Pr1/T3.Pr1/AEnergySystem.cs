using System;

namespace T3.Pr1
{
    public abstract class AEnergySystem : IEnergyCalculus
    {
        public string Type { get; set; }
        public DateTime SimulationDate { get; set; }
        protected double GeneratedEnergy { get; set; }

        public AEnergySystem()
        {
            SimulationDate = DateTime.Now;
        }

        public abstract void ConfigurateParameters();
        public abstract double CalculateEnergy();
    }
}

