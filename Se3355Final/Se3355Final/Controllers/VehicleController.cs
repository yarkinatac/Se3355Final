using Microsoft.AspNetCore.Mvc;
using Se33555Final.Interfaces;
using System.Threading.Tasks;

public class VehicleController : Controller
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleController(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IActionResult> Index(string make, string sortOrder, string transmission)
    {
        // Arama sonuçlarını alın
        var vehicles = await _vehicleRepository.GetVehicles(make, sortOrder, transmission);


        ViewBag.PriceSortParm = string.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
        

        switch (sortOrder)
        {
            case "price_desc":
                vehicles = vehicles.OrderByDescending(v => v.Price);
                break;
            case "price":
                vehicles = vehicles.OrderBy(v => v.Price);
                break;
            default:
                // Varsayılan olarak herhangi bir sıralama uygulanmayacak
                break;
        }

        return View(vehicles);
    }
}