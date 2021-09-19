using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reada_Backend.Models
{
    public class DbEFContext : DbContext
    {


        //public DbEFContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbEFContext(DbContextOptions options)
: base(options)
        {
        }
        public virtual DbSet<UserModel> User { get; set; }
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
