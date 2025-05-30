using interview_tallertechnologies.Domain.Entities;

namespace interview_tallertechnologies.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
