﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PikaShop.Data.Context.ContextEntities.Identity;

namespace PikaShop.Data.Context.EntityConfigurations.Identity
{
    public class SuperAdminEntityConfiguration : IEntityTypeConfiguration<SuperAdminEntity>
    {
        public virtual void Configure(EntityTypeBuilder<SuperAdminEntity> builder)
        {
            // Mapping

            // Data

            // Other Configuration
        }
    }
}
