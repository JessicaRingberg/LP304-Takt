using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Mapper;
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


            orderDetails.ArticleId = articleId;
            orderDetails.OrderId = orderId;

            await _context.OrderDetails.AddAsync(orderDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEntity(int id)
        {
            var orderDetails = await _context.OrderDetails
               .FirstOrDefaultAsync(o => o.Id == id);
            if (orderDetails is null)
            {
                return;
            }
            _context.OrderDetails.Remove(orderDetails);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<OrderDetails>> GetEntities()
        {
            return await _context.OrderDetails
                .Include(o => o.Article)
                .ToListAsync();
        }

        public async Task<OrderDetails?> GetEntity(int id)
        {
            return await _context.OrderDetails
                .Include(o => o.Article)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateEntity(OrderDetails orderDetails, int orderDetailsId)
        {
            var orderDetailsToUpdate = await _context.OrderDetails
                .FindAsync(orderDetailsId);
            if(orderDetailsToUpdate is null)
            {
                return;
            }
            orderDetailsToUpdate.Quantity = orderDetails.Quantity;
            orderDetailsToUpdate.Article = orderDetails.Article;
            await _context.SaveChangesAsync(); 
        }
    }
}
