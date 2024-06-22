using Microsoft.EntityFrameworkCore;
using Zahidul_s_Tech_Emporium.DAL;
using Zahidul_s_Tech_Emporium.Models;
using Zahidul_s_Tech_Emporium.Repository.IRepository;

namespace Zahidul_s_Tech_Emporium.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task UpdateAsync(Product obj)
        {
            var objFormDb =await _db.Products.FirstOrDefaultAsync(u => u.Id == obj.Id);

            if (objFormDb != null)
            {
                objFormDb.Title = obj.Title;
                objFormDb.Description = obj.Description;
                objFormDb.Brand = obj.Brand;
                objFormDb.ListPrice = obj.ListPrice;
                objFormDb.Price = obj.Price;
                objFormDb.Price50 = obj.Price50;
                objFormDb.Price100 = obj.Price100;
                objFormDb.CategoryId = obj.CategoryId;

                if (obj.ImageUrl != null)
                {
                    objFormDb.ImageUrl = obj.ImageUrl;
                }
            }
            
          
        }
    }
}
