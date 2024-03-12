using PikaShop.Data.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Context.ContextEntities.Core
{
    public class ProductEntity:Product
    {
        public int? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
    }
}
