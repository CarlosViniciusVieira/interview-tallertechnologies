using System.Linq.Expressions;

namespace interview_tallertechnologies.Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        //Here should be create base methods such as GetByIdAsync, AddAsync......

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
