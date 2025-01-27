using System;
namespace T3.Pr1
{
    public class Program
    {

        public const string MsgOptionError = "Error. Selecciona una opció vàlida.";
        public const string Spacer = "\n";

        
        public static void Main()
        {
            const string MsgIntroduceMaxCapacity = "Introdueix la capacitat màxima de simulacions: ";
            const string MsgSelectOption = "Selecciona una opció:\n1. Iniciar Simulació.\n2. Veure informe de simulacions.\n3. Sortir.";
            const string MsgCapacityError = "Error. La capacitat ha de ser un número enter.";
            const string MsgEnd = "Sortint del programa... ";
            const string MsgInitiateSimulationError = "Error. No es poden afegir més simulacions. ";

            int capacity = 0;
            int option = 0;
            int count = 0;

            // Seleccionar capacitat màxima de simulacions
            Console.WriteLine(MsgIntroduceMaxCapacity);
            while (!int.TryParse(Console.ReadLine(), out capacity) || capacity <= 0)
            {
                Console.WriteLine();
                Console.WriteLine(MsgCapacityError);
            }
            Console.WriteLine(Spacer);

            AEnergySystem[] simulations = new AEnergySystem[capacity];

            while (count <= capacity)
            {
                // Seleccionar opció
                Console.WriteLine(MsgSelectOption);
                while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine(MsgOptionError);
                }
                Console.WriteLine(Spacer);

                switch (option)
                {
                    case 1:
                        if (count >= capacity)
                        {
                            Console.WriteLine(MsgInitiateSimulationError);
                            Console.WriteLine();
                        }
                        else
                        {
                            OptionOne(count, capacity, simulations);
                            count++;
                        }
                        break;

                    case 2:
                        OptionTwo(capacity, simulations);
                        break;

                    case 3:
                        Console.WriteLine(MsgEnd);
                        Console.WriteLine();
                        count = capacity + 1;
                        break;

                    default:
                        Console.WriteLine(MsgOptionError);
                        Console.WriteLine();
                        break;
                }
            }
        }

        // Iniciar simulació
        public static void OptionOne(int count, int capacity, AEnergySystem[] simulations)
        {
            const string MsgSimulationNumber = "Simulació #{0}.";
            const string MsgEnergySystemOption = "Escull un tipus de sistema d'energia:\n1. Energia Solar.\n2. Energia Eòlica.\n3. Energia Hidroelèctrica.";
            const string MsgResult = "Simulació completada. Energia generada: {0} kWh.";

            int energySystemOption = 0;


            // Seleccionar sistema d'energia
            Console.WriteLine(MsgSimulationNumber, count + 1);
            Console.WriteLine(MsgEnergySystemOption);
            while (!int.TryParse(Console.ReadLine(), out energySystemOption) || energySystemOption < 1 || energySystemOption > 3)
            {
                Console.WriteLine();
                Console.WriteLine(MsgOptionError);
            }
            Console.WriteLine(Spacer);

            switch (energySystemOption)
            {
                case 1:
                    AEnergySystem solarSystem = new SolarSystem();

                    // Configurar paràmetres
                    solarSystem.ConfigurateParameters();

                    // Mostrar informe
                    Console.WriteLine(MsgResult, solarSystem.CalculateEnergy());
                    Console.WriteLine(Spacer);

                    simulations[count] = solarSystem;
                    break;

                case 2:
                    AEnergySystem windSystem = new WindSystem();

                    // Configurar paràmetres
                    windSystem.ConfigurateParameters();

                    // Mostrar informe
                    Console.WriteLine(MsgResult, windSystem.CalculateEnergy());
                    Console.WriteLine(Spacer);

                    simulations[count] = windSystem;
                    break;

                case 3:
                    AEnergySystem hidraulicSystem = new HidraulicSystem();

                    // Configurar paràmetres
                    hidraulicSystem.ConfigurateParameters();

                    // Mostrar informe
                    Console.WriteLine(MsgResult, hidraulicSystem.CalculateEnergy());
                    Console.WriteLine(Spacer);

                    simulations[count] = hidraulicSystem;
                    break;

                default:
                    Console.WriteLine(MsgOptionError);
                    Console.WriteLine();
                    break;
            }
        }

        // Mostrar simulacions guardades fins al moment
        public static void OptionTwo(int capacity, AEnergySystem[] simulations)
        {
            const string MsgSimulationInfo = "Informe de la simulació #{0}:\n   Tipus de sistema: {1}\n   Data: {2}\n   Càlcul energètic: {3}kWh";

            int simulationCounter = 0;

            foreach (AEnergySystem simulation in simulations)
            {
                if (simulation != null)
                {
                    Console.WriteLine(MsgSimulationInfo, simulationCounter + 1, simulation.Type, simulation.SimulationDate, simulation.CalculateEnergy());
                    Console.WriteLine();
                    simulationCounter++;
                }
            }
            Console.WriteLine();
        }
    }
}
