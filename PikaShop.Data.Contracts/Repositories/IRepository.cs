﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Contracts.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        // Naming Convension
        // Select... => Get...
        // SelectBy{instance attribute} => GetBy{instance attribute}
        // SelectBy{Other instance attribute} => GetBy{Other instance attribute}
        // ex: SelectCategoryByDeparmentName => GetCategoryByDeparmentName
        // when implementing this interface :Get{EntityName}{target}
        // GetInclude(string relationship)
        // Update... => Update...
        // Delete... => Delete...
        // DeleteRange
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetById(int id);

        int Update(int id,TEntity other);
        int Update(TEntity target,TEntity other);

        int Delete(TEntity entity);
        int DeleteById(int id);

    }
}
