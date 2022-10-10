using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        private readonly DataContext _context;

        public QueueRepository(DataContext context)
        {
            _context = context;
        }

        public Task<ServiceResponse<int>> Add(Queue queue, int id)
        {
            throw new NotImplementedException();
            //var order = await _context.Orders.FindAsync(id);
            //if(order is null)
            //{
            //    return;
            //}
            //queue.OrderId = id;
            //_context.Queue.Add(queue);
            //await _context.SaveChangesAsync();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Queue>> GetEntities()
        {
            return await _context.Queue
                .Include(q => q.Orders)
                .ToListAsync();
        }

        public Task<Queue?> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEntity(Queue entity, int areaId)
        {
            var queue = await _context.Queue.FindAsync(areaId);

           
        }
        public Task UpdateQueue(int orderId, int areaId)
        {
            throw new NotImplementedException();
            ////if (area.Orders.Any(o => o.Takt.Equals(order.Takt)))
            ////{
            ////    area.Queue?.Orders?.Add(order);

            ////    await _context.SaveChangesAsync();
            ////}
            //return new ServiceResponse<int>()
            //{
            //    Success = true,
            //    Message = "Order added"
            //};
        }

    }
}
