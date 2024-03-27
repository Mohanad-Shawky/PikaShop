
using Microsoft.EntityFrameworkCore;
using PikaShop.Data.Context;
using PikaShop.Data.Context.ContextEntities.Core;
using PikaShop.Data.Contracts.Repositories;

namespace PikaShop.Data.Persistence.Repositories
{
	public class OrderRepository(ApplicationDbContext _context) : Repository<OrderEntity, int>(_context), IOrderRepository
	{
        public override OrderEntity? GetById(int id)
        {
            return _context.Orders.Include(oritem => oritem.Items).ThenInclude(pr => pr.Product).FirstOrDefault(or => or.ID == id);
        }
    }
}
