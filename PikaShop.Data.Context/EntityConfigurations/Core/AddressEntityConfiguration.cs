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

            // Data

            // Other Configuration
        }
    }
}

