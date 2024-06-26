using Zahidul_s_Tech_Emporium.Models;

namespace Zahidul_s_Tech_Emporium.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        Task UpdateAsync(ShoppingCart obj);
    }
}
