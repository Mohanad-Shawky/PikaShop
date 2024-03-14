using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PikaShop.Data.Context.ContextEntities.Identity
{
    public class ApplicationUserEntity : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ApplicationUserEntity()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
        }
    }
}
