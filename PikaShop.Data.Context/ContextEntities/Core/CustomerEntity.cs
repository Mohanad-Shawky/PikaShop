using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Entities.ContextEntities.Core
{
    /// <summary>
    /// The Entities mapped by the context
    /// </summary>
    public class CustomerEntity : ApplicationUserEntity
    {
        public virtual ICollection<AddressEntity>? Addresses { get; set; }
    }
}
