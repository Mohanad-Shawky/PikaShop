using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PikaShop.Data.Context.ContextEntities.Identity;
using PikaShop.Data.Entities.ContextEntities.Core;

namespace PikaShop.Data.Context.EntityConfigurations.Identity
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public virtual void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            // Mapping

            // Data
            builder.HasMany<AddressEntity>(nameof(CustomerEntity.Addresses))
                .WithOne(nameof(AddressEntity.Customer))
                .HasForeignKey(nameof(AddressEntity.CustomerID))
                .OnDelete(DeleteBehavior.Cascade);

            // Other Configuration
        }
    }
}
