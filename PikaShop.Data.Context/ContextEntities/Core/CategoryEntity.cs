using PikaShop.Data.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Context.ContextEntities.Core
{
    public class CategoryEntity:Category
    {

        public int? DepartmentId { get; set; }
        public virtual DepartmentEntity? Department { get; set; }
    }
}
