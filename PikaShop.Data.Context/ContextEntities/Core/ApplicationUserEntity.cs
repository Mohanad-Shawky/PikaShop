using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PikaShop.Data.Entities.ContextEntities.Core
{
    public class ApplicationUserEntity : IdentityUser<int>
    {
        public ApplicationUserEntity() : base() { }

        public ApplicationUserEntity(string userName) : base(userName) { }


    }
}
