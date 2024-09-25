namespace UserChallengeApiApp.Rdb
{
    public class DbUser
    {
        public int Id { get; set; }
        public string Login { get; set; } = "";
        public string Key { get; set; } = "";
        public DateTime RegisteredAt { get; set; }

        public DbUser() { }
    }
}
