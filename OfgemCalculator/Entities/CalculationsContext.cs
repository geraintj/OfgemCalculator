using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OfgemCalculator.Entities
{
    public class CalculationsContext : DbContext
    {
        public CalculationsContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Calculation> Calculations { get; set; }
    }
}
