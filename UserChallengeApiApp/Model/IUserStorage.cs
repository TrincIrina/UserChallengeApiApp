namespace UserChallengeApiApp.Model
{
    // IUserStorage - интерфейс для хранения данных о пользователях
    public interface IUserStorage
    {
        // GetByApiKeyAsync - получение информации о пользователе по строке api-ключа
        // вход: строка api-key
        // выход: информация о пользователе из хранилища или null если такой записи нет
        Task<UserInfo?> GetByApiKeyAsync(string apiKey);

        // AddUserAsync - добавление нового пользователя
        // вход: объект информации о пользователе и сгенерированный apiKey
        // выход: -
        Task AddUserAsync(UserInfo userInfo, string apiKey);

        // GetByLoginAsync - получение информации о пользователе по строке логина
        // вход: строка логина
        // выход: информация о пользователе из хранилища или null если такой записи нет
        Task<UserInfo?> GetByLoginAsync(string login); 
    }
}
