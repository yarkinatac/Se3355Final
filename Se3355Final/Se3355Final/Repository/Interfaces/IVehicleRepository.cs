using Se3355Final.Models;

namespace Se33555Final.Interfaces;

public interface IVehicleRepository
{
    Task<IEnumerable<Car>> GetAll();
    Task<IEnumerable<Car>> GetVehicles(string Make, string sortOrder, string transmission);
    
}