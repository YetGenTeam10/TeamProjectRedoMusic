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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=91.151.83.102;Port=5432;Database=!RedoMusicDbTeam10;User Id=ahmetkokteam;Password=obXRMG*U6rJ4R0cbHszpgEuFd;";

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
