using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCProjekt.Models;

namespace MVCProjekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MVCProjekt.Models.Client>? Client { get; set; }
        public DbSet<MVCProjekt.Models.Insurance>? Insurance { get; set; }
        public DbSet<MVCProjekt.Models.Comment>? Comment { get; set; }
    }
}