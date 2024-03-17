using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Context.ContextEntities.Identity
{
    public class ApplicationUserRoleEntity : IdentityRole<int>
    {
        public ApplicationUserRoleEntity() : base()
        {

        }

        public ApplicationUserRoleEntity(string rolename) : base(rolename)
        {

        }

    }
}
