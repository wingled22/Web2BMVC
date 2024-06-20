using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web2BMVC.Identity
{
     public class IdentityContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Library;User ID=SA;Password=VeryStr0ngP@ssw0rd;TrustServerCertificate=true;");


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Additional configuration if needed
        }
    }


     public class AppUser : IdentityUser
    {
        public string FullName { get; set;} = null!;
    }

    public class AppRole : IdentityRole
    {
    }
}