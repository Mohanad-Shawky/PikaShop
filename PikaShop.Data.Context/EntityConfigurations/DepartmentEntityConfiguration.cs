using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PikaShop.Data.Context.ContextEntities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Context.EntityConfigurations
{
    public class DepartmentEntityConfiguration : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(d => d.Id);
            builder.HasMany(d => d.Categories).WithOne(c=>c.Department).HasForeignKey(c => c.DepartmentId).HasPrincipalKey(d=>d.Id);
            builder.Property(d=>d.Name).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(d=>d.Description).HasColumnType("nvarchar(200)").IsRequired();
        }
    }
}
