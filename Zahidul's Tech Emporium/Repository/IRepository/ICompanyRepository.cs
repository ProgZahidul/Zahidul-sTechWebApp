using Zahidul_s_Tech_Emporium.Models;

namespace Zahidul_s_Tech_Emporium.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task UpdateAsync(Company obj);
    }
}
