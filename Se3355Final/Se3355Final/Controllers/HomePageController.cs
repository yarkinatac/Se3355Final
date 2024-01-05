using Microsoft.AspNetCore.Mvc;
using Se3355Final.Repository;
using Se3355Final.Models;


namespace Se3355Final.Controllers;

public class HomePageController : Controller
{
    private readonly IOfficeRepository _officeRepository;

    public HomePageController(IOfficeRepository officeRepository)
    {
        _officeRepository = officeRepository;
    }
    // GET
    public IActionResult Index()
    {
        List<Office> offices = _officeRepository.GetAllOffices();
        return View(offices);
    }

}