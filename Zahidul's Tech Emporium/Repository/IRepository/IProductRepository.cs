﻿using Zahidul_s_Tech_Emporium.Models;

namespace Zahidul_s_Tech_Emporium.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
    
        Task UpdateAsync(Product obj);
    }
}
