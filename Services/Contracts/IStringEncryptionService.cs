namespace JricaStudioWebApi.Services.Contracts
{
    /// <summary>
    /// Responsible for encrypting string.
    /// </summary>
    public interface IStringEncryptionService
    {
        /// <summary>
        /// Encrypts a string to a string.
        /// </summary>
        /// <param name="data">The string to be encrypted.</param>
        /// <returns>A string representation of the string that is encrypted.</returns>
        Task<string> EncryptString(string data);

        /// <summary>
        /// Decrypts a string that has be encrypted by this class.
        /// </summary>
        /// <param name="encryptedString">A string representation of a string that has been encrypted by this class previously.</param>
        /// <returns>A human readable string of the encrypted string.</returns>
        Task<string> DecryptString(string encryptedString);
    }
}
