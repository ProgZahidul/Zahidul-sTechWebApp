using Microsoft.EntityFrameworkCore;
using Zahidul_s_Tech_Emporium.DAL;
using Zahidul_s_Tech_Emporium.Models;
using Zahidul_s_Tech_Emporium.Repository.IRepository;

namespace Zahidul_s_Tech_Emporium.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
            
        }

        public async Task UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = await _db.OrderHeaders.FirstOrDefaultAsync(u => u.Id == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public async Task UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            var orderFromDb = await _db.OrderHeaders.FirstOrDefaultAsync(u => u.Id == id);
            if (!string.IsNullOrEmpty(sessionId))
            {
                orderFromDb.SessionId = sessionId;
            }
            if (!string.IsNullOrEmpty(paymentIntentId))
            {
                orderFromDb.PayemntIntentId = paymentIntentId;
                orderFromDb.PaymentDate = DateTime.Now;
            }

        }
    }
}
