using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Contracts.Repositories;

namespace PikaShop.Data.Persistence.Repositories
{
    public class Repository<TEntity, TKey>(ApplicationDbContext _context)
        : IRepository<TEntity, TKey>
        where TEntity : class
    {
        protected ApplicationDbContext context = _context;

        protected DbSet<TEntity> entities = _context.Set<TEntity>();

        #region Create
        public virtual void Create(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual void CreateRange(IEnumerable<TEntity> _entities)
        {
            entities.AddRange(_entities);
        }
        #endregion

        #region Read
        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return entities.Where(predicate);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return entities;
        }

        public virtual TEntity? GetById(TKey id)
        {
            return entities.Find(id);
        }
        #endregion

        #region Delete
        public virtual void Delete(TEntity entity)
        {
            entities.Remove(entity);
        }

        public virtual void DeleteById(TKey id)
        {
            var target = GetById(id);
            if (target != null)
            {
                entities.Remove(target);
            }
        }

        public virtual void DeleteRange(IEnumerable<TEntity> _entities)
        {
            entities.RemoveRange(_entities);
        }
        #endregion
    }
}
