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

        public async Task<Queue?> GetEntity(int id)
        {
            return await _context.Queue
               .Include(q => q.Orders)
               .FirstOrDefaultAsync(q => q.Id == id);
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
