using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salon.Models;

namespace Salon.Data
{
    public class SalonContext : DbContext
    {
        public SalonContext (DbContextOptions<SalonContext> options)
            : base(options)
        {
        }

        public DbSet<Salon.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Salon.Models.Orar> Orar { get; set; }

        public DbSet<Salon.Models.Profesionist> Profesionist { get; set; }

        public DbSet<Salon.Models.Categorie> Categorie { get; set; }

        public DbSet<Salon.Models.Client> Client { get; set; }
    }
}
