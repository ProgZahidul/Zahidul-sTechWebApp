namespace Zahidul_s_Tech_Emporium.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        Task SaveAsync();
    }
}
