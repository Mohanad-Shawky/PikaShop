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
    public class ProductSpecsEntityConfiguration: IEntityTypeConfiguration<ProductSpecsEntity>
    {
        public void Configure(EntityTypeBuilder<ProductSpecsEntity> builder)
        {
            // Mapping
            builder.HasKey(ps => ps.Id);
            builder.ToTable("ProductSpecification");
            builder.HasOne(ps => ps.Product).WithMany(p => p.ProductSpecs).HasForeignKey(ps => ps.ProductId);

            // Data
            builder.Property(ps => ps.Key).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(ps => ps.Value).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnType("Date");
            builder.Property(p => p.DeletedAt).HasColumnType("Date");
            builder.Property(p => p.IsDeleted).HasColumnType("bit");

            // Other Configuration

        }
    }
}
