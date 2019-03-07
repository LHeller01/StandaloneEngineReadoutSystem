using StandaloneEngineReadoutSystem.UwpApp.Models;
using System;
using System.Threading.Tasks;

namespace StandaloneEngineReadoutSystem.UwpApp.CarReaders
{
    class FakeCarReader : ICarReader
    {
        private Random rand;
        private int fuelLevel;


        public FakeCarReader()
        {
            rand = new Random();
            fuelLevel = rand.Next(50, 100);
        }

        public Task<int> RequestAirTemp()
        {
            var airtemp = 86;
            airtemp += rand.Next(-10, 10);
            return Task.FromResult(airtemp);
        }

        public Task<int> RequestFuelLevel()
        {         
            if (fuelLevel > 0)
            {
                fuelLevel -= rand.Next(1, 3); 
            }

            return Task.FromResult(fuelLevel);
        }
    }
}
