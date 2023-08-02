using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Role> Roles { get; set; }
        public  DbSet<Facility> Facilities { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Requests> Requests { get; set; }
        
     }
}