using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Partial;
using PikaShop.Data.Contracts.Repositories;
using PikaShop.Data.Entities.Core;




namespace PikaShop.Data.Persistence.Repositories
{
   
         public class CartRepository : Repository<CartEntity, int>, ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void SoftDelete(CartEntity entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CartEntity entity, CartEntity other)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int key, CartEntity other)
        {
            throw new NotImplementedException();
        }
    }
}