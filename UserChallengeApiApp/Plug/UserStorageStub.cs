using UserChallengeApiApp.Model;

namespace UserChallengeApiApp.Plug
{
    public class UserStorageStub : IUserStorage
    {
        // ключ - api-key, значение - информация о пользователе
        private static Dictionary<string, UserInfo> usersData = new Dictionary<string, UserInfo>();

        public async Task AddUserAsync(UserInfo userInfo, string apiKey)
        {
            usersData[apiKey] = new UserInfo()
            {
                Login = userInfo.Login,
                RegisteredAt = userInfo.RegisteredAt,
            };
            await Task.FromResult(1);
        }

        public async Task<UserInfo?> GetByApiKeyAsync(string apiKey)
        {
            if (usersData.ContainsKey(apiKey))
            {
                return await Task.FromResult(usersData[apiKey]);
            }
            return await Task.FromResult<UserInfo?>(null);
        }

        public async Task<UserInfo?> GetByLoginAsync(string login)
        {
            KeyValuePair<string, UserInfo>? item = usersData.FirstOrDefault(p => p.Value.Login == login);
            if (item != null)
            {
                return await Task.FromResult<UserInfo?>(item.Value.Value);
            }
            return await Task.FromResult<UserInfo?>(null);
        }
    }
}
