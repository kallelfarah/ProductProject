namespace WebApplication1.Core
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        Task CompleteAsync();
    }
}
