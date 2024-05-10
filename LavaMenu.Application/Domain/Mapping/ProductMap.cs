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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");

            builder.HasKey(x => x.ProductId);

            builder.HasIndex(x => x.ProductTitle).IsUnique();

            builder.Property(x => x.ProductTitle)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.ProductDescription)
                .HasMaxLength(250)
                .IsRequired(false);


            /// one categury can relation with many product  (one to many relation)
            builder.HasOne(x => x.categury)
                .WithMany(x => x.products)
                .HasForeignKey(x => x.CateguryId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
