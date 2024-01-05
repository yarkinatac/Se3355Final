using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Se3355Final.Data;
using Se3355Final.Models;

public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: /Account/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: /Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new User
            {
                Email = model.Email,
                Password = HashPassword(model.Password), 
                Name = model.Name,
                Country = model.Country,
                City = model.City
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "HomePage");
        }
        return View(model);
    }

    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    // GET: /Account/Login
    public IActionResult Login()
    {
        return View();
    }

// POST: /Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user != null && HashPassword(model.Password) == user.Password)
            {
                // TODO: Burada kullanıcı için bir oturum açın (örneğin, cookie tabanlı bir oturum)


                return RedirectToAction("Index", "HomePage");
            }
            else
            {
                ModelState.AddModelError("", "Email veya şifre hatalı.");
            }
        }


        return View(model);
    }
// POST: /Account/Logout
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {



        return RedirectToAction("Login", "Account");
    }

    public IActionResult GoogleLogin()
    {

        var authenticationProperties = new AuthenticationProperties
        {
            RedirectUri = Url.Action("GoogleResponse")
        };
        return Challenge(authenticationProperties, GoogleDefaults.AuthenticationScheme);
    }

    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        
        var claims = result.Principal.Identities.FirstOrDefault()?.Claims;

        var emailClaim = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email);
        var nameClaim = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Name);

        if (emailClaim != null)
        {

            var user = _context.Users.FirstOrDefault(u => u.Email == emailClaim.Value);

            if (user == null)
            {

                user = new User
                {
                    Email = emailClaim.Value,
                    Name = nameClaim?.Value,
                    Password = "Password123!",
                    City = "Varsayılan Şehir",
                    Country = "Varsayılan"

                };
                _context.Users.Add(user);
                _context.SaveChanges();
            }


            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),

            }, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true 
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        
            return RedirectToAction("Index", "HomePage");
        }

        return RedirectToAction(nameof(Login));
    }






}