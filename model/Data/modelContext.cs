#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using model.Models;

namespace model.Data
{
    public class modelContext : DbContext
    {
        public modelContext (DbContextOptions<modelContext> options)
            : base(options)
        {
        }

        public DbSet<model.Models.Endgame> Endgames { get; set; }
    }
}
