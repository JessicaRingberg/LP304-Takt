using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Add(Order order, int stationId)
        {
            var station = await _context.Stations.FindAsync(stationId);

            if (station != null)
            {
                order.StationId = stationId;
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Order>> GetEntities()
        {
            return await _context.Orders
                .Include(o => o.Alarms)
                .Include(o => o.Events)
                .ToListAsync();
        }

        public async Task<Order?> GetEntity(int id)
        {
            return await _context.Orders
                .Include(o => o.Alarms)
                .Include(o => o.Events)
                .FirstOrDefaultAsync(a => a.Id == id);
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

        public async Task UpdateEntity(Order order, int orderId)
        {
            var orderToUpdate = await _context.Orders
                .FindAsync(orderId);
            if (orderToUpdate is null)
            {
                return;
            }

            MapOrder(orderToUpdate, order);

            await _context.SaveChangesAsync();
        }

        private static Order MapOrder(Order newOrder, Order oldOrder)
        {
            newOrder.Quantity = oldOrder.Quantity;
            return newOrder;
        }
    }
}
