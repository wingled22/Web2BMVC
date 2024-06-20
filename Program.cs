using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web2BMVC.Entities;
using Web2BMVC.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryContext>(option => 
    option.UseSqlServer("Server=localhost;Database=Library;User ID=SA;Password=VeryStr0ngP@ssw0rd;TrustServerCertificate=true;")
);

// Configure IdentityContext
builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=localhost;Database=Library;User ID=SA;Password=VeryStr0ngP@ssw0rd;TrustServerCertificate=true;")));

builder.Services.AddIdentity<AppUser, AppRole>(
    options => {
        options.Password.RequiredLength = 4;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        // options.Lockout.MaxFailedAccessAttempts = 5;
        // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromDays(5);
    }
)
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
