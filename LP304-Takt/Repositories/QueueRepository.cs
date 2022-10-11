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

        public Task<ServiceResponse<int>> DeleteEntity(int id)
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

        public Task<ServiceResponse<int>> UpdateEntity(Queue entity, int areaId)
        {
            throw new NotImplementedException();


        }
        public Task<ServiceResponse<int>> UpdateQueue(Queue queue, int areaId)
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
