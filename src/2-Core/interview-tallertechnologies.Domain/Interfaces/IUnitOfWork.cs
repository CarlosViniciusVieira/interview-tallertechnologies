namespace interview_tallertechnologies.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<T> Repository<T>() where T : class;
        Task<int> CommitAsync();
        Task CommitTransactionAsync();
        Task BeginTransactionAsync();
        Task RollbackAsync();
    }

}
