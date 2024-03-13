﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PikaShop.Data.Context.ContextEntities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Context.EntityConfigurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c=>c.Id);
            builder.HasOne(c => c.Department).WithMany(d=>d.Categories).HasForeignKey(c => c.DepartmentId);
            builder.HasMany(c => c.Products).WithOne(p=>p.Category).HasForeignKey(p=>p.CategoryId).HasPrincipalKey(c=>c.Id);
            builder.Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(c => c.Description).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(c => c.CreatedAt).HasColumnType("Date");
            builder.Property(c => c.DeletedAt).HasColumnType("Date");
            builder.Property(c => c.IsDeleted).HasColumnType("bit");
        }
    }
}