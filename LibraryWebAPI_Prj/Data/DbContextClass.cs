using LibraryWebAPI_Prj.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI_Prj.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Books> Books { get; set; }

    }
}
