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
    public class CategorySpecsEntityConfiguration: IEntityTypeConfiguration<CategorySpecsEntity>
    {
        public void Configure(EntityTypeBuilder<CategorySpecsEntity> builder)
        {
            // Mapping
            builder.HasKey(cs => cs.Id);
            builder.ToTable("CategorySpecification");
            builder.HasOne(cs => cs.Category).WithMany(c => c.CategorySpecs).HasForeignKey(cs => cs.CategoryId);

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
