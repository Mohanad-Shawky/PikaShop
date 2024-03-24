using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PikaShop.Data.Persistence.Repositories
{
    public class ReviewRepository(ApplicationDbContext _context) : Repository<ReviewEntity, int>(_context), IReviewRepository
    {
        public void SoftDelete(ReviewEntity entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ReviewEntity entity, ReviewEntity other)
        {
            throw new NotImplementedException();
        }

        public void Update(ReviewEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(int key, ReviewEntity other)
        {
            throw new NotImplementedException();
        }
    }
}
