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
        public async Task<ServiceResponse<Order>> Add(Order order, int areaId)
        {
            var area = await _context.Areas
                .Include(a => a.Orders)
                .FirstOrDefaultAsync(a => a.Id == areaId);

            if (area is null)
            {
                return new ServiceResponse<Order>()
                {
                    Success = false,
                    Message = "Order must belong to an Area."
                };
                               
            }
            //var queue = await _context.Queue
            //    .Include(q => q.Orders)
            //    .FirstOrDefaultAsync(q => q.Id == areaId);
            //if(queue is null)
            //{
            //    return new ServiceResponse<Order>()
            //    {
            //        Success = false,
            //        Message = "Area is incomplete"
            //    };
            //}
            //foreach (var item in area.Orders)
            //{
            //    if (order.StartTime <= item.EndTime)
            //    {
            //        queue.Orders?.Add(order);
            //    }

            //}
            //if (order.StartTime <= DateTime.Now)
            //{
            //    queue.Orders?.Add(order);
            //}
            order.AreaId = area.Id;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Order>()
            {
                Data = order,
                Success = true,
                Message = "Order added"
            };

        }
    
        public async Task<ICollection<Order>> GetEntities()
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ToListAsync();
        }

        public async Task<Order?> GetEntity(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(a => a.Id == orderId);
        }

        public async Task<ICollection<Order>> GetOrdersByArea(int areaId)
        {
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.AreaId == areaId).ToListAsync();
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int orderId)
        {
            var order = await _context.Orders
                .FirstOrDefaultAsync(a => a.Id == orderId);
            if (order is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Order with id {orderId} was not found"
                };
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Order with id {orderId} deleted"
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

            var area = await _context.Areas
               .Include(a => a.Orders)
               .FirstOrDefaultAsync(a => a.Id == orderToUpdate.AreaId);
            if (area is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Order not bound to an area"
                };
            }
            var queue = await _context.Queue
                .Include(q => q.Orders)
                .FirstOrDefaultAsync(q => q.Id == orderToUpdate.AreaId);
    

            foreach (var item in area.Orders)
            {
                if (item.EndTime is null)
                {
                    continue;
                }
                else if (item.Equals(orderToUpdate))
                {
                    continue;
                }
                else if(item.EndTime >= orderToUpdate.StartTime)
                {
                    queue?.Orders?.Add(orderToUpdate);
                }
                else
                {
                    continue;
                }
            }
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
