using Doorang.Bussiness.Service.Abstracts;
using Doorang.Bussiness.Service.Concretes;
using Doorang.Core.Models;
using Doorang.Core.RepositoryAbstracts;
using Doorang.Data.DAL;
using Doorang.Data.RepositoyConcretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer("Server=WIN-0F0TGHD6FSA\\SQLEXPRESS;Database=Doorang;Trusted_Connection=true;Integrated Security=true; TrustServerCertificate=true;Encrypt=false");

});
builder.Services.AddIdentity<User, IdentityRole>(opt =>
{

    opt.Password.RequiredLength = 8;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
    opt.User.RequireUniqueEmail = true;
    opt.Lockout.MaxFailedAccessAttempts = 5;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IExplorerService, ExplorerService>();
builder.Services.AddScoped<IExplorerRepository, ExplorerRepository>();


var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
