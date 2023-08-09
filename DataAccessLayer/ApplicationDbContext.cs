using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Models;

namespace DataAccessLayer
{

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<OHDDbContext>
    {
        public OHDDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OHDDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=OHD;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

            return new OHDDbContext(optionsBuilder.Options);
        }
    }
}