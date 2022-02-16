using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Bijuterii.Models;

namespace Proiect_Bijuterii.Data
{
    public class Proiect_BijuteriiContext : DbContext
    {
        public Proiect_BijuteriiContext (DbContextOptions<Proiect_BijuteriiContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Bijuterii.Models.Bijuterie> Bijuterie { get; set; }

        public DbSet<Proiect_Bijuterii.Models.Material> Material { get; set; }

        public DbSet<Proiect_Bijuterii.Models.Category> Category { get; set; }
    }
}
