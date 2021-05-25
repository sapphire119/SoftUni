using FDMC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDMC.Data
{
    public class CatDbContext : DbContext
    {
        public CatDbContext() { }

        public CatDbContext(DbContextOptions options) 
            : base(options) { }
        

        public DbSet<Cat> Cats { get; set; }
    }
}
