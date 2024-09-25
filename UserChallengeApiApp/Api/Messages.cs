namespace UserChallengeApiApp.Api
{
    // record - иммутабельный ссылочный тип C#
    public record StringMessage(string Message);
    public record LoginMessage(string Login);
    public record ErrorMessage(string Type, string Message);
}
