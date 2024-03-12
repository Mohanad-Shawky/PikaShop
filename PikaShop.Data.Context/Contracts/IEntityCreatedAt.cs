using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Context.Contracts
{
    internal interface IEntityCreatedAt
    {
        public DateTime CreatedAt { get; set; }
    }
}
