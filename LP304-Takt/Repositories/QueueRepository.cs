using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LP304_Takt.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        private readonly DataContext _context;

        public QueueRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Queue>> GetAllQueues()
        {
            return await _context.Queue
                .Include(q => q.Orders)
                .ToListAsync();
        }

        public async Task<Queue?> GetOneQueue(int queueId)
        {
            return await _context.Queue
               .Include(q => q.Orders)
               .FirstOrDefaultAsync(q => q.Id == queueId);
        }
        public async Task<Area?> GetQueueFromArea(int areaId)
        {
            return await _context.Areas
               .Include(a => a.Queue)
               .FirstOrDefaultAsync(a => a.Id == areaId);
        }

        public async Task<ServiceResponse<int>> DeleteOrderFromQueue(int queueId, int orderId)
        {
            var queueToUpdate = await _context.Queue
                .Include(q => q.Orders)
                .FirstOrDefaultAsync(q => q.Id == queueId);
            if (queueToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Queue with id {queueId} was not found"
                };
            }

            foreach (var order in queueToUpdate.Orders.Where(order => order.Id.Equals(orderId)))
            {
                queueToUpdate.Orders.Remove(order);
            }

            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Queue with id {queueId} updated"
            };

        }

    }
}
