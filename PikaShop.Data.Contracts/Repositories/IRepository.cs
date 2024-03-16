using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Contracts.Repositories
{

    public interface IRepository<TEntity,Ttype> where TEntity : class

   
    {
        


        IQueryable<TEntity> GetAll();

        int Create(TEntity entity);

        TEntity GetById(Ttype id);
        int Update(Ttype id,TEntity other);
       
        int Delete(Ttype id);
       


    }
}
