using LavaMenu.Application.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Interfaces
{
    public interface Idb
    {
        DbSet<Product> Products { get; set; }
        DbSet<ProductCategury> Categories { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserRole> Roles { get; set; }

        int SaveChanges(bool AccepAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
