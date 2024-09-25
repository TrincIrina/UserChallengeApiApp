namespace UserChallengeApiApp.Crypto
{
    // Encoder - интерфейс кодирования строк
    public interface IEncoder
    {
        // Encode - закодировать строку data
        string Encode(string data);
    }
}
