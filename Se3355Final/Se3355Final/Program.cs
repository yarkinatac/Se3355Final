using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Se33555Final.Interfaces;
using Se33555Final.Repository;
using Se3355Final.Data;
using Se3355Final.Data;
using Se3355Final.Models;
using Se3355Final.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// ... (Diğer servis yapılandırmalarınız)

// Google ile kimlik doğrulama için gerekli yapılandırmalar
builder.Services.AddAuthentication(options =>
    {
        // Varsayılan kimlik doğrulama şemasını belirleyin
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Kullanıcı giriş yapmadıysa buraya yönlendir
    })
    .AddGoogle(googleOptions =>
    {
        // Bu bilgileri Google Cloud Platform'dan aldığınız bilgiler ile değiştirin
        googleOptions.ClientId = "232155239256-4d5asmr7cee7mdl4omnpmq2efch45if4.apps.googleusercontent.com";
        googleOptions.ClientSecret = "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";
        // Eğer başka bir callback path kullanmak istiyorsanız, burada belirtebilirsiniz
        // googleOptions.CallbackPath = "/signin-google";
    });






builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    Seed.SeedData(app);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Login}/{id?}");
});


app.Run();