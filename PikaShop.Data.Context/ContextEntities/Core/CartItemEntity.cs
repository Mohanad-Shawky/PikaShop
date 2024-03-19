using PikaShop.Data.Context.Contracts;
using PikaShop.Data.Contracts;
using PikaShop.Data.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
 
using PikaShop.Data.Context.ContextEntities.Identity;
 


namespace PikaShop.Data.Context.ContextEntities.Core
{
    public class CartItemEntity  
    {

     
        public int ProductId { get; set; }

       
        public int CartId { get; set; }

        // Navigation properties
        public virtual ProductEntity Product { get; set; }

        public virtual CartEntity Cart { get; set; }

    }
}
