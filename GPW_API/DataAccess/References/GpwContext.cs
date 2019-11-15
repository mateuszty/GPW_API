using GPW_API.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPW_API.DataAccess.References
{
    public class GpwContext : DbContext
    {

        public GpwContext()
        {

        }

        public GpwContext(DbContextOptions<GpwContext> options)
            : base (options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<GpwCompany> gpwCompanies { get; set; }

    }
}
