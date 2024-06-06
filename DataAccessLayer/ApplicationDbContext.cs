using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OHD.DataAccessLayer
{

	public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<OHDDbContext>
	{
		public OHDDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<OHDDbContext>();
			optionsBuilder.UseSqlServer("Data Source=ABDULSHAKOOR-W4\\MSSQLSERVER01;Initial Catalog=OHD;Persist Security Info=True;User ID=sa;Password=out2sol;Encrypt=False;Trust Server Certificate=True");

			return new OHDDbContext(optionsBuilder.Options);
		}
	}
}