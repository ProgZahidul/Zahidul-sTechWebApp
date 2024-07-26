using Zahidul_s_Tech_Emporium.Models;

namespace Zahidul_s_Tech_Emporium.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        Task UpdateAsync(OrderHeader obj);
        Task UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        Task UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
    }
}
