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
    option => {
        option.Password.RequireNonAlphanumeric = false;
        option.Password.RequireDigit = false ;
        option.Password.RequireLowercase = false;
        option.Password.RequireUppercase = false;
        option.Password.RequiredLength = 4;
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
