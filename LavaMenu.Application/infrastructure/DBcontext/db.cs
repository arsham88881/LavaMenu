
using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LavaMenu.Application.infrastructure.DBcontext
{
    public class db : DbContext, Idb
    {
        public db(DbContextOptions options):base(options){ }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategury> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<User>(entity => entity.HasKey(u => u.UserId));
            modelBuilder.Entity<UserRole>(entity => entity.HasKey(u => u.RoleId));

            //////////////////////////////////////read from Mapping folder on Domain
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(db).Assembly);

        }

    }
}
