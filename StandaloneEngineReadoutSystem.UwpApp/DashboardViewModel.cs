using StandaloneEngineReadoutSystem.UwpApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandaloneEngineReadoutSystem.UwpApp
{
    class DashboardViewModel : INotifyPropertyChanged
    {
        ICarReader carReader;
        public DashboardViewModel(ICarReader carReader)
        {
            this.carReader = carReader;
        }
        private string fuelLevel;

        public string FuelLevel
        {
            get { return fuelLevel; }
            set { fuelLevel = value;
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("FuelLevel"));
            }

        }

        private string airTemp;

        public event PropertyChangedEventHandler PropertyChanged;

        public string AirTemp
        {
            get { return airTemp; }
            set { airTemp = value;
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs("AirTemp"));
            }
        }

        public async Task Start()
        {
            while (true)
            {
                var fuelLevel = await carReader.RequestFuelLevel();
                this.FuelLevel = fuelLevel.ToString();
                var airtemp = await carReader.RequestAirTemp();
                this.AirTemp = airtemp.ToString();
                await Task.Delay(5000);
            }
        }
    }
}
