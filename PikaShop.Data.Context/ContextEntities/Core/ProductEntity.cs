﻿using PikaShop.Data.Context.Contracts;
using PikaShop.Data.Contracts;
using PikaShop.Data.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Context.ContextEntities.Core
{
    public class ProductEntity:Product,IEntityCreatedAt,IEntitySoftDelete
    {
        public int? CategoryId { get; set; }
        public CategoryEntity? Category { get; set; }
        public DateTime CreatedAt { get; set ; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
