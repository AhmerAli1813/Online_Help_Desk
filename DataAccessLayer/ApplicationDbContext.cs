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
            optionsBuilder.UseSqlServer("Server=DESKTOP-3OKF36U\\MSSQLSERVER01; Database=OHD; Integrated Security=true; MultipleActiveResultSets=true; Trusted_Connection=True");

            return new OHDDbContext(optionsBuilder.Options);
        }
    }
}