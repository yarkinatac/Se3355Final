using Se3355Final.Data;
using Microsoft.EntityFrameworkCore;
using Se3355Final.Models;



namespace Se3355Final.Repository;

public class OfficeRepository : IOfficeRepository
{
    private readonly ApplicationDbContext _context;
    public OfficeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Office> GetAllOffices()
    {

        List<Office> offices = _context.Offices.ToList();
        return offices;
    }
}