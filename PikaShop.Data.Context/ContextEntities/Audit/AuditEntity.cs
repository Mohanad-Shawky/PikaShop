using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PikaShop.Data.Context.Contracts.Audit;

namespace PikaShop.Data.Context.ContextEntities.Audit
{
    public class AuditEntity : IAuditEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
        public string ModifiedBy { get; set; }

        public AuditEntity()
        {
            ModifiedBy = string.Empty;
            DateCreated = DateTime.Now;
        }
    }
}
