using interview_tallertechnologies.Data.Context;
using interview_tallertechnologies.Domain.Interfaces;

namespace interview_tallertechnologies.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly SqlDbContext _context;
        public RepositoryBase(SqlDbContext context)
        {
            _context = context;
        }
    }
}
