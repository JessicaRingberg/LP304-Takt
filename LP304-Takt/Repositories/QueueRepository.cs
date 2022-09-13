using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class QueueRepository : IQueueRepository
    {
        //private readonly DataContext _context;

        //public QueueRepository(DataContext context)
        //{
        //    _context = context;
        //}
        public Task Add(Queue queue, int id)
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

        public Task<ICollection<Queue>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Task<Queue?> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Queue entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
