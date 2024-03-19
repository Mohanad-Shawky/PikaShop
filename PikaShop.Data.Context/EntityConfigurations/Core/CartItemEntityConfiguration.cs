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
    public class CartItemEntityConfiguration : IEntityTypeConfiguration<CartItemEntity>
    {
        public virtual void Configure(EntityTypeBuilder<CartItemEntity> builder)
        {


            // Mapping
            builder.ToTable("CartItem");
            builder.HasKey(nameof(CartItemEntity.ProductId), nameof(CartItemEntity.CartId)).HasName("PK_CartItemId");
            builder.HasOne<ProductEntity>(c => c.Product).WithMany().HasForeignKey(c => c.ProductId);
            builder.HasOne<CartEntity>(c => c.Cart).WithMany(cart=>cart.CartItems).HasForeignKey(c => c.CartId);






            // Other Configuration
        }
    }
}
