using LavaMenu.Application.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Domain.Mapping
{
    public class ProductCateguryMap : IEntityTypeConfiguration<ProductCategury>
    {
        public void Configure(EntityTypeBuilder<ProductCategury> builder)
        {
            builder.ToTable("categury");

            builder.HasKey(p => p.CateguryId);

            builder.HasIndex(p => p.CateguryName).IsUnique();

            builder.Property(p => p.CateguryName)
                   .HasMaxLength(100)
                   .IsRequired();


        }
    }
}
