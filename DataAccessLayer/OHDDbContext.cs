using Microsoft.EntityFrameworkCore;
using OHD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHD.DataAccessLayer
{
    public class OHDDbContext : DbContext
    {
        public OHDDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<Requests> Requests { get; set; }
    }
}
