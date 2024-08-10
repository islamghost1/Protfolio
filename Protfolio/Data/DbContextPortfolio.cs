using Microsoft.EntityFrameworkCore;
using Protfolio.Client.Models;
using Protfolio.Helpers;

namespace Protfolio.Data
{
    public class DbContextPortfolio : DbContext
    {
       

        public DbSet<Admins> Admins { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ProjectSteps> Project_steps { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SocialsLinks> Socials_links { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(AppSettings.connectionString, ServerVersion.AutoDetect(AppSettings.connectionString));
        }
    }
}
