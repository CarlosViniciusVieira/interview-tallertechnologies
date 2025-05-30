using interview_tallertechnologies.Data.Context;
using interview_tallertechnologies.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace interview_tallertechnologies.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly SqlDbContext _context;
        public RepositoryBase(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().Where(predicate).ToListAsync();
    }
}
