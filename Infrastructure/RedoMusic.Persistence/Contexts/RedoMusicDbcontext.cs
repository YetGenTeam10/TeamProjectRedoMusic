using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RedoMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedoMusic.Persistence.Contexts
{
    public class RedoMusicDbcontext : DbContext
    {
        public DbSet<Instrument> Instruments { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql(Configurations.GetString("ConnectionStrings:PostgreSQL"));
        }
    }
}
