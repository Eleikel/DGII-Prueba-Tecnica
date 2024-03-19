using DGII.Core.Domain.Entities;
using DGII.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Contribuyente> Contribuyente { get; set; }
        public DbSet<ComprobanteFiscal> ComprobanteFiscal { get; set; }

    }
}
