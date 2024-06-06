using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OHD.DataAccessLayer.EntityModel;

namespace OHD.DataAccessLayer
{
	public class OHDDbContext : IdentityDbContext<ApplicationUser>
	{
		public OHDDbContext(DbContextOptions options) : base(options)
		{
		}
		// public DbSet<Roles> Roles { get; set; }
		public DbSet<Facility> Facilities { get; set; }
		//public DbSet<Register> Registers { get; set; }
		public DbSet<Requests> Requests { get; set; }
	}
}
