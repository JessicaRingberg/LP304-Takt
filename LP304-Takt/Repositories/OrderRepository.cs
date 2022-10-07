using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Services;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;

namespace LP304_Takt.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Order order, int areaId)
        {
            var area = await _context.Areas.FindAsync(areaId);

            if (area != null)
            {
                order.AreaId = area.Id;
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                //var area = await _context.Areas.FirstOrDefaultAsync(a => a.Stations.Equals(station));
                //if order start time is before or same time as end time && stationId equals station.Id
                if (await _context.Orders.AnyAsync(o => o.EndTime.Equals(order.StartTime)))
                {
                   await _context.SaveChangesAsync();
                }
            }
        }
    
        public async Task<ICollection<Order>> GetEntities()
        {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Article)
                .Include(o => o.Alarms)
                .Include(o => o.Events)
                .ToListAsync();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        }

        public async Task<Order?> GetEntity(int id)
        {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Article)
                .Include(o => o.Alarms)
                .Include(o => o.Events)
                .FirstOrDefaultAsync(a => a.Id == id);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        }

        public async Task DeleteEntity(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(a => a.Id == id);
            if (order is null)
            {
                return;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync(); 
        }

        public Task UpdateEntity(Order entity, int id)
        {
            throw new NotImplementedException();
        }

        //public async Task UpdateEntity(Order order, int orderId)
        //{
        //    var orderToUpdate = await _context.Orders
        //        .FindAsync(orderId);
        //    if (orderToUpdate is null)
        //    {
        //        return;
        //    }

        //    MapOrder(orderToUpdate, order);

        //    await _context.SaveChangesAsync();
        //}

        //private static Order MapOrder(Order newOrder, Order oldOrder)
        //{
        //    newOrder.Quantity = oldOrder.Quantity;
        //    return newOrder;
        //}
    }
}
