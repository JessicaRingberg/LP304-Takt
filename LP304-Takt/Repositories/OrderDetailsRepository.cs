using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly DataContext _context;

        public OrderDetailsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> Add(OrderDetails orderDetails, int orderId, int articleId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            var article = await _context.Article.FindAsync(articleId);
            var found = await _context.OrderDetails.FirstOrDefaultAsync(c => c.ArticleId == orderDetails.ArticleId);
            if (found is not null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"This order detail already contains this article: {orderDetails.Article}!"
                };
            }

            else if (order is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Order details must be tied to an order"
                };
            }

            else if (article is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Order details must contain valid articles"
                };
            }
            else
            orderDetails.ArticleId = articleId;
            orderDetails.OrderId = orderId;
            await _context.OrderDetails.AddAsync(orderDetails);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Order detail added"
            };
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int id)
        {
            var orderDetails = await _context.OrderDetails
               .FirstOrDefaultAsync(o => o.Id == id);
            if (orderDetails is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Order detail with id {id} was not found"
                };
            }
            _context.OrderDetails.Remove(orderDetails);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Order detail with id {id} deleted from the order"
            };
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

        public async Task<ServiceResponse<int>> UpdateEntity(OrderDetails orderDetails, int orderDetailsId)
        {
            var orderDetailsToUpdate = await _context.OrderDetails
                .FindAsync(orderDetailsId);
            if(orderDetailsToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Order detail with id {orderDetailsId} was not found"
                };
            }
            orderDetailsToUpdate.Quantity = orderDetails.Quantity;
            orderDetailsToUpdate.Article = orderDetails.Article;
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Order detail with id {orderDetailsId} was updated to the order"
            };
        }
    }
}
