namespace UserChallengeApiApp.Model
{
    // UserInfo - класс с информацией о пользователе
    public class UserInfo
    {
        public string Login { get; set; } = "";
        public DateTime RegisteredAt { get; set; }

        // свойства проверки валидности пользователя
        public bool IsLoginValid { 
            get
            {
                return !string.IsNullOrEmpty(Login);
            }
        }

        public UserInfo() { }

        public override string ToString()
        {
            return Login;
        }
    }
}
