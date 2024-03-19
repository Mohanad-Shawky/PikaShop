using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PikaShop.Data.Context.ContextEntities.Identity;
using PikaShop.Data.Context.Contracts;
using PikaShop.Data.Contracts;
using PikaShop.Data.Entities.Core;
 
 
 
namespace PikaShop.Data.Context.ContextEntities.Core
{
    public class CartEntity:Cart, IEntitySoftDelete,  IEntityCreatedAt 
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
     
        public double Total { get; set; }
 
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Quantity { get; set; }

   



        public CartEntity()
        {
            Total = 0;

            CreatedAt = DateTime.Now;
            Quantity = 0;
        }



        public virtual CustomerEntity? Customer { get; set; }

     
        public virtual ICollection<CartItemEntity>? CartItems { get; set; }

        // Soft delete properties
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
