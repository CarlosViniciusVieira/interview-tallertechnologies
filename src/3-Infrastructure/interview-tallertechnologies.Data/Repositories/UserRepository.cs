using interview_tallertechnologies.Data.Context;
using interview_tallertechnologies.Domain.Entities;
using interview_tallertechnologies.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace interview_tallertechnologies.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly SqlDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(
            SqlDbContext context,
            ILogger<UserRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            _logger.LogInformation($"[UserRepository].GetByUsernameAsync started for username: {username}");

            try
            {
                var user = await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Username == username);

                _logger.LogInformation($"[UserRepository].GetByUsernameAsync completed for username: {username}");
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[UserRepository] Error in GetByUsernameAsync for username: {username}");
                throw;
            }
        }
    }
}
