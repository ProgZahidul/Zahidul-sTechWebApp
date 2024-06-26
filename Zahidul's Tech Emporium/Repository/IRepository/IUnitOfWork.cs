namespace Zahidul_s_Tech_Emporium.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICompanyRepository Company { get; }
        Task SaveAsync();
    }
}
