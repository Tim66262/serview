using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using serview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serview
{
    public class ServiewDBContext : IdentityDbContext<User>
    {
        public DbSet<Serie> Series { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public ServiewDBContext(DbContextOptions<ServiewDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
