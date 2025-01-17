namespace JricaStudioWebApi.Services.Contracts
{
    /// <summary>
    /// A service provided that Encrypts arrays of bytes.
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Encrypts a Byte Array
        /// </summary>
        /// <param name="array">A collection of bytes</param>
        /// <returns>The Encrypted Byte Array</returns>
        Task<byte[]> EncryptByteArray(byte[] array);

        /// <summary>
        /// Takes an array of bytes previously encrypted by the this class and decrypts it.
        /// </summary>
        /// <param name="encryptedFileData">An array of byte encrypted by this class.</param>
        /// <returns>The Decrypted Array of bytes.</returns>
        Task<byte[]> DecryptByteArray(byte[] encryptedFileData);


    }
}
