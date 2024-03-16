﻿using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.UnitsOfWork;
using PikaShop.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Services.Core
{
    public class CategoryServices : ICategoryServices
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public CategoryServices(IUnitOfWork _uow)
        {
            UnitOfWork = _uow;
        }

        
    }


}
