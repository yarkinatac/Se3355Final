using Microsoft.EntityFrameworkCore;
using Se33555Final.Interfaces;
using Se3355Final.Data;
using Se3355Final.Models;

namespace Se33555Final.Repository;

public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext _context;

    public VehicleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Car>> GetAll()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetVehicles(string make, string sortOrder, string transmission)
    {
        // Arama kriterlerine göre sorgu oluşturma
        IQueryable<Car> query = _context.Cars;

        // Markaya göre filtreleme
        if (!string.IsNullOrEmpty(make))
        {
            query = query.Where(v => v.Make == make);
        }

        // Şanzımana göre filtreleme
        if (!string.IsNullOrEmpty(transmission))
        {
            query = query.Where(v => v.Transmission == transmission);
        }

        // Fiyata göre sıralama
        switch (sortOrder)
        {
            case "price_desc":
                query = query.OrderByDescending(v => v.Price);
                break;
            case "price":
                query = query.OrderBy(v => v.Price);
                break;
            default:
                // Varsayılan olarak herhangi bir sıralama uygulanmayacak
                break;
        }

        return await query.ToListAsync();
    }
}