using interview_tallertechnologies.Data.Context;
using interview_tallertechnologies.Data.Repositories;
using interview_tallertechnologies.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace interview_tallertechnologies.Data.UnitOfwork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlDbContext _context;
        private IDbContextTransaction _transaction;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(SqlDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepositoryBase<T> Repository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
                return (IRepositoryBase<T>)_repositories[typeof(T)];

            var repository = new RepositoryBase<T>(_context);
            _repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task<int> CommitAsync()
            => await _context.SaveChangesAsync();

        public async Task BeginTransactionAsync()
            => _transaction = await _context.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync()
            => await _transaction.CommitAsync();

        public async Task RollbackAsync()
            => await _transaction?.RollbackAsync();

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}

