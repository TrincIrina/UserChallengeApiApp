using UserChallengeApiApp.Model;

namespace UserChallengeApiApp.Rdb
{
    public class UserRepository : IUserStorage
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task AddUserAsync(UserInfo userInfo, string apiKey)
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo?> GetByApiKeyAsync(string apiKey)
        {
            throw new NotImplementedException();
        }

        public Task<UserInfo?> GetByLoginAsync(string login)
        {
            throw new NotImplementedException();
        }
    }
}
