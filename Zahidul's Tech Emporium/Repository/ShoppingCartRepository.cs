using Zahidul_s_Tech_Emporium.DAL;
using Zahidul_s_Tech_Emporium.Models;
using Zahidul_s_Tech_Emporium.Repository.IRepository;

namespace Zahidul_s_Tech_Emporium.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(ShoppingCart obj)
        {
            _db.ShoppingCarts.Update(obj);
            
        }
    }
}
