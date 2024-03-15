using Microsoft.EntityFrameworkCore;
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
    public class DepartmentRepository : Repository<DepartmentEntity, int>, IDepartmentRepository
    {

        public DepartmentRepository(ApplicationDbContext _context) : base(_context) { }


        public override IQueryable<DepartmentEntity> GetAll()
        {
            return context.Departments.Where(d=>d.IsDeleted==false);
        }

        public void UpdateById(int id, DepartmentEntity other)
        {
            DepartmentEntity? oldDep = GetById(id);
            if(oldDep != null)
            {
               oldDep.Description = other.Description;
               oldDep.Name = other.Name;
            }
        }
        public void Update(DepartmentEntity entity, DepartmentEntity other)
        {
            UpdateById(entity.Id, other);
        }

        public void SoftDeleteById(int id)
        {
            DepartmentEntity? oldDep = GetById(id);
            if (oldDep != null && !oldDep.IsDeleted)
            {
                oldDep.IsDeleted = true;
                oldDep.DeletedAt = DateTime.Now;
            }
        }
        public void SoftDelete(DepartmentEntity entity)
        {
            SoftDeleteById(entity.Id);
        }
    }
}
