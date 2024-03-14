using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PikaShop.Data.Entities.ContextEntities.Core;

namespace PikaShop.Data.Context.ContextEntities.Identity
{
    public class CustomerEntity : ApplicationUserEntity
    {
        public virtual ICollection<AddressEntity>? Addresses { get; set; }
    }
}
