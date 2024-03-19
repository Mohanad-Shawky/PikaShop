using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Entities.ContextEntities.Core;

namespace PikaShop.Data.Context.ContextEntities.Identity
{      
    public class CustomerEntity : ApplicationUserEntity
    {
        public virtual CartEntity? Cart { get; set; }
        public int? CartId { get; set; }

        public int Id { get; set; }
        public virtual ICollection<AddressEntity>? Addresses { get; set; }
    }
}
