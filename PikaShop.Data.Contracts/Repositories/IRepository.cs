using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Contracts.Repositories
{
    public interface IRepository<TEntity,TType> where TEntity : class
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
        TEntity GetById(TType id);

        int Update(TType id,TEntity other);
        //int Update(TEntity target,TEntity other);
        int Delete(TType id);

    }
}
