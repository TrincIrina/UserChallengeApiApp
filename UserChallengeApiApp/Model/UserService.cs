using UserChallengeApiApp.Crypto;

namespace UserChallengeApiApp.Model
{
    // UserService - сервис для работы с пользователями
    public class UserService
    {
        private readonly IUserStorage _userStorage;
        private readonly IEncoder _encoder;

        public UserService(IUserStorage userStorage, IEncoder encoder)
        {
            _userStorage = userStorage;
            _encoder = encoder;
        }

        // GetUserInfoAsync - получение информации о пользователе
        // вход: api-key пользователя
        // выход: объект информации о пользователе
        // исключения: InvalidApiKeyException
        public async Task<UserInfo> GetUserInfoAsync(string apiKey)
        {
            UserInfo? userInfo = await _userStorage.GetByApiKeyAsync(apiKey);
            if (userInfo == null)
            {
                throw new InvalidApiKeyException();
            }
            return userInfo;
        }

        // RegisterUserAsync - регистрация нового пользователя по логину
        // вход: login - уникальный непустой логин пользователя
        // выход: apiKey зарегистрированного пользователя
        // исключения: LoginTakenException, InvalidLoginException
        public async Task<string> RegisterUserAsync(string login)
        {
            // подготовить объект нового пользователя
            UserInfo userInfo = new UserInfo()
            {
                Login = login,
                RegisteredAt = DateTime.UtcNow,
            };
            // проверить валидность логина
            if (!userInfo.IsLoginValid)
            {
                throw new InvalidLoginException(login);
            }
            // проверить уникальность логина
            if (await _userStorage.GetByLoginAsync(login) != null)
            {
                throw new LoginTakenException(login);
            }
            // сгенерировать api-key 
            string apiKeySeed = $"{login}{userInfo.RegisteredAt}";
            string apiKey = _encoder.Encode(apiKeySeed);
            // добавить пользователя
            await _userStorage.AddUserAsync(userInfo, apiKey);
            // вернуть api-ключ
            return apiKey;
        }
    }
}
