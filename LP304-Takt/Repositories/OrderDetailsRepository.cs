using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly DataContext _context;

        public OrderDetailsRepository(DataContext context)
        {
            _context = context;
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<OrderDetails>> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetails?> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(OrderDetails entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}
