﻿using Microsoft.EntityFrameworkCore;
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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext context = new();

        //public DepartmentRepository(ApplicationDbContext _context)
        //{
        //    context = _context;
        //}
        

        public IQueryable<DepartmentEntity> GetAll()
        {
            return context.Departments.Where(d=>d.IsDeleted==false).AsNoTracking();
        }

        public DepartmentEntity GetById(int id)
        {
            return context.Departments
                .FirstOrDefault(d => d.Id == id);
        }

        public int Update(int id, DepartmentEntity other)
        {
            DepartmentEntity oldDep=GetById(id);
            if(oldDep != null)
            {

               oldDep.Description = other.Description;
               oldDep.Name = other.Name;
            return context.SaveChanges();
            }
            return -1;
        }
        public int Delete(int id)
        {
            DepartmentEntity oldDep = GetById(id);
            if (oldDep == null || oldDep.IsDeleted == true) return -1;
              oldDep.IsDeleted = true;
            oldDep.DeletedAt = DateTime.Now;
            return context.SaveChanges();
        }

        public int Create(DepartmentEntity entity)
        {
            if (entity != null)
            {
                context.Add(entity);
                return context.SaveChanges();
            }
            return -1;
        }
    }
}
