namespace JricaStudioWebAPI.Services.Contracts
{
    public interface IEncryptionService
    {
        Task<byte[]> EncryptByteArray(byte[] array);

        Task<byte[]> DecryptByteArray(byte[] encryptedFileData);


    }
}
