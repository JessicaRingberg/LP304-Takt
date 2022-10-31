using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
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
        public async Task<ServiceResponse<int>> Add(Order order, int areaId)
        {
            var area = await _context.Areas
                .Include(a => a.Orders)
                .FirstOrDefaultAsync(a => a.Id == areaId);

            if (area is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = "Order must belong to an Area."
                };
                               
            }
            var queue = await _context.Queue
                .Include(q => q.Orders)
                .FirstOrDefaultAsync(q => q.Id == areaId);
            if(queue is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = "Area is incomplete"
                };
            }
            foreach (var item in area.Orders)
            {
                if (order.StartTime <= item.EndTime)
                {
                    queue.Orders?.Add(order);
                }

            }
           
            order.AreaId = area.Id;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = "Order added"
            };

        }
    
        public async Task<ICollection<Order>> GetEntities()
        {
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Article)
                .Include(o => o.Alarms)
                .ThenInclude(a => a.AlarmType)
                .Include(o => o.Events)
                .ThenInclude(e => e.EventStatus)
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
                .ThenInclude(a => a.AlarmType)
                .Include(o => o.Events)
                .ThenInclude(e => e.EventStatus)
                .FirstOrDefaultAsync(a => a.Id == id);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(a => a.Id == id);
            if (order is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Order with id {id} was not found"
                };
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Order with id {id} deleted"
            };
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Order order, int orderId)
        {
            var orderToUpdate = await _context.Orders.FindAsync(orderId);
            if(orderToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Order with id {orderId} was not found"
                };
            }

            MapOrder(orderToUpdate, order);

            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Order with id {orderId} updated"
            };
        }

        private static Order MapOrder(Order newOrder, Order oldOrder)
        {
            newOrder.ChangeSecSet = oldOrder.ChangeSecSet;
            newOrder.ChangeSetDec = oldOrder.ChangeSetDec;
            newOrder.Backlog = oldOrder.Backlog;
            newOrder.LastPartProd = oldOrder.LastPartProd;
            newOrder.PartsProd = oldOrder.PartsProd;
            newOrder.StartTime = oldOrder.StartTime;
            newOrder.Takt = oldOrder.Takt;
            newOrder.EndTime = oldOrder.EndTime;
            newOrder.RunSecSet = oldOrder.RunSecSet;
            newOrder.RunSetDec = oldOrder.RunSetDec;
            newOrder.TaktSet = oldOrder.TaktSet;
            return newOrder;
        }

    }
}
