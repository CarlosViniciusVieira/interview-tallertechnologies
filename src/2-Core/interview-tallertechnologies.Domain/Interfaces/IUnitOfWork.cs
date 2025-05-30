namespace interview_tallertechnologies.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public interface IUnitOfWork : IDisposable
        {
            IUserRepository Users { get; }
            Task<int> CommitAsync();
        }
    }
}
