﻿using LP304_Takt.Interfaces.Repositories;
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
            var area = await _context.Areas.FindAsync(areaId);

            if (area is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = "Order must belong to an Area."
                };
                               
            }
            //if (area.Orders.Any(o => o.EndTime.Equals(order.StartTime)))
            //{
            //    area.Queue.
            //}
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
            return await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Article)
                .Include(o => o.Alarms)
                .Include(o => o.Events)
                .ToListAsync();
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

        public async Task UpdateEntity(Order order, int orderId)
        {
            var orderToUpdate = await _context.Orders.FindAsync(orderId);
            if(orderToUpdate is null)
            {
                return;
            }
            orderToUpdate.ChangeSecSet = order.ChangeSecSet;
            orderToUpdate.ChangeSetDec = order.ChangeSetDec;
            orderToUpdate.Backlog = order.Backlog;
            orderToUpdate.LastPartProd = order.LastPartProd;
            orderToUpdate.PartsProd = order.PartsProd;
            orderToUpdate.StartTime = order.StartTime;
            orderToUpdate.Takt = order.Takt;
            orderToUpdate.EndTime = order.EndTime;
            orderToUpdate.RunSecSet = order.RunSecSet;
            orderToUpdate.RunSetDec = order.RunSetDec;
            orderToUpdate.TaktSet = order.TaktSet;
            await _context.SaveChangesAsync();
        }

    }
}
