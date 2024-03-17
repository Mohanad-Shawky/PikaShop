using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PikaShop.Data.Entities.ContextEntities.Core;

namespace PikaShop.Data.Context.EntityConfigurations.Core
{
    public class AddressEntityConfiguration : IEntityTypeConfiguration<AddressEntity>
    {
        public virtual void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            // Mapping
            builder.ToTable("Address");
            builder.HasKey(nameof(AddressEntity.ID))
                .HasName("PK_AddressID");

            // Data
            builder.Property<string>(nameof(AddressEntity.State)).HasMaxLength(50);
            builder.Property<string>(nameof(AddressEntity.Region)).HasMaxLength(50);
            builder.Property<string>(nameof(AddressEntity.Street)).HasMaxLength(50);
            builder.Property<string>(nameof(AddressEntity.BuildingNumber)).HasMaxLength(10);
            builder.Property<string>(nameof(AddressEntity.FloorNumber)).HasMaxLength(10);
            builder.Property<string>(nameof(AddressEntity.AppartmentNumber)).HasMaxLength(10);

            // Other Configuration
        }
    }
}

