using Zahidul_s_Tech_Emporium.Models;

namespace Zahidul_s_Tech_Emporium.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task UpdateAsync(Category obj);
    }
}
