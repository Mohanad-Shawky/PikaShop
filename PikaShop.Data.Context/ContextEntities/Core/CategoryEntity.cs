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
    public class CategoryEntity:Category, IEntityCreatedAt, IEntitySoftDelete
    {

        public int? DepartmentId { get; set; }
        public virtual DepartmentEntity? Department { get; set; }
        public virtual ICollection<ProductEntity>? Products { get; set; }
        public virtual ICollection<CategorySpecsEntity>? CategorySpecs { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        

    }
}
