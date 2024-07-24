using Zahidul_s_Tech_Emporium.Models;

namespace Zahidul_s_Tech_Emporium.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        Task UpdateAsync(OrderHeader obj);
    }
}
