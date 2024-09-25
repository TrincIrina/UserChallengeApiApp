namespace UserChallengeApiApp.Model
{
    // InvalidApiKeyException - ошибка невалидного api-ключа
    public class InvalidApiKeyException : ApplicationException
    {
        public InvalidApiKeyException() : base("api-key is invalid") { }
    }

    public class InvalidLoginException : ApplicationException
    {
        public InvalidLoginException(string login) : base($"'{login}' is invalid") { }
    }

    public class LoginTakenException : ApplicationException
    {
        public LoginTakenException(string login) : base($"'{login}' is taken") { }
    }
}
