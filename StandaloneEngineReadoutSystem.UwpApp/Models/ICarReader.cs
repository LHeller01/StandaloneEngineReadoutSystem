using System.Threading.Tasks;

namespace StandaloneEngineReadoutSystem.UwpApp.Models
{
    interface ICarReader
    {
        Task<int> RequestAirTemp();
        Task<int> RequestFuelLevel();  
    }
}
