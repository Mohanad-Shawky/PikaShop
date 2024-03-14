using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PikaShop.Data.Context.ContextEntities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Context.EntityConfigurations.Core
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public virtual void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            // Mapping
            builder.HasKey(p => p.Id);
            builder.ToTable("Products");
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);

            // Data
            builder.Property(p => p.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p => p.Price).HasColumnType("money").IsRequired();
            builder.Property(p => p.Specifications).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.UnitsInStock).HasColumnType("int").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnType("Date");
            builder.Property(p => p.DeletedAt).HasColumnType("Date");
            builder.Property(p => p.IsDeleted).HasColumnType("bit");

            // Other Configuration

        }
    }
}
