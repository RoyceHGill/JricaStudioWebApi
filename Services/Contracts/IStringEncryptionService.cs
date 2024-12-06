namespace JricaStudioWebApi.Services.Contracts
{
    public interface IStringEncryptionService
    {
        Task<string> EncryptString(string data);

        Task<string> DecryptString(string encryptedString);
    }
}
