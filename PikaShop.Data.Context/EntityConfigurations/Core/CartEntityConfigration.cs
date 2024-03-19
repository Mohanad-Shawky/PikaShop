using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PikaShop.Data.Entities.Core;
using PikaShop.Data.Context.ContextEntities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PikaShop.Data.Context.ContextEntities.Core;
using System;
using System.Reflection.Emit;
using Stripe;
using PikaShop.Data.Context.ContextEntities.Identity;

namespace PikaShop.Data.Context.EntityConfigurations.Core
{
    public class CartEntityConfiguration : IEntityTypeConfiguration<CartEntity>
    {
        public virtual void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            // Mapping
            builder.ToTable("Carts");
            builder.HasKey(nameof(CartEntity.Id)).HasName("PK_CartId");
            builder.HasOne<CustomerEntity>(c => c.Customer)  // Specify the navigation property in the Cart entity
                  .WithOne(p => p.Cart)   // Specify the navigation property in the Customer entity
                  .HasForeignKey<CartEntity>(c => c.Id)  // Specify the foreign key property in the Cart entity //Id of cart == id of customer
                  .HasPrincipalKey<CustomerEntity>(p => p.Id);  // Specify the principal key property in the Customer entity





            // Data
            builder.Property<double>(nameof(CartEntity.Total));
            builder.Property<DateTime>(nameof(CartEntity.CreatedAt));
            builder.Property<DateTime?>(nameof(CartEntity.UpdatedAt));
            builder.Property<int>(nameof(CartEntity.Quantity));
            builder.Property<int>(nameof(CartEntity.Id)).ValueGeneratedNever();//id of cart it is not identity



            // Other Configuration
        }
    }
}
