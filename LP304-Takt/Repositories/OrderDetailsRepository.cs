using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LP304_Takt.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly DataContext _context;

        public OrderDetailsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(OrderDetails orderDetails, int orderId, int articleId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            var article = await _context.Article.FindAsync(articleId);

            if (order is null)
            {
                return;
            }

            if (article is null)
            {
                return;
            }

            orderDetails.Article = article;
            orderDetails.Order = order;
            await _context.OrderDetails.AddAsync(orderDetails);
            await _context.SaveChangesAsync();
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<OrderDetails>> GetEntities()
        {
            return await _context.OrderDetails
                .Include(o => o.Article)
                .Include(o => o.Order)
                .ToListAsync();
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
