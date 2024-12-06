using JricaStudioWebApi.Services.Contracts;
using System.Dynamic;
using System.Security.Cryptography;
using System.Text;

namespace JricaStudioWebApi.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly string _encryptionKey;

        public EncryptionService(IConfiguration configuration)
        {
#if DEBUG
            _encryptionKey = configuration["CrypKey"];
#else
            _encryptionKey = Environment.GetEnvironmentVariable("CrypKey");
#endif
        }


        public async Task<byte[]> DecryptByteArray(byte[] encryptedData)
        {
            if (encryptedData == null || encryptedData.Length < 16)
            {
                throw new ArgumentException("Invalid encrypted data. Must be at least 16 bytes.");
            }

            using (AesManaged aesAlgorithm = new AesManaged())
            {
                aesAlgorithm.Key = Encoding.UTF8.GetBytes(_encryptionKey);
                if (aesAlgorithm.Key.Length != 16 && aesAlgorithm.Key.Length != 24 && aesAlgorithm.Key.Length != 32)
                {
                    throw new ArgumentException("Invalid key size. Key must be 128, 192, or 256 bits.");
                }

                byte[] IV = new byte[16];
                Array.Copy(encryptedData, 0, IV, 0, IV.Length);

                byte[] cipherText = new byte[encryptedData.Length - IV.Length];
                Array.Copy(encryptedData, IV.Length, cipherText, 0, cipherText.Length);

                ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, IV);

                using (MemoryStream memoryStream = new MemoryStream(cipherText))
                {
                    try
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (MemoryStream resultStream = new MemoryStream())
                            {
                                await cryptoStream.CopyToAsync(resultStream);
                                return resultStream.ToArray();
                            }
                        }
                    }
                    catch (CryptographicException ex)
                    {
                        throw new CryptographicException("Decryption failed: " + ex.Message, ex);
                    }
                }
            }
        }



        public async Task<byte[]> EncryptByteArray(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            using (AesManaged aesAlgorithm = new AesManaged())
            {
                aesAlgorithm.Key = Encoding.UTF8.GetBytes(_encryptionKey);
                if (aesAlgorithm.Key.Length != 16 && aesAlgorithm.Key.Length != 24 && aesAlgorithm.Key.Length != 32)
                {
                    throw new ArgumentException("Invalid key size. Key must be 128, 192, or 256 bits.");
                }

                aesAlgorithm.GenerateIV();
                ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV);

                using (MemoryStream memoryStreamEncrypt = new MemoryStream())
                {
                    memoryStreamEncrypt.Write(aesAlgorithm.IV, 0, aesAlgorithm.IV.Length);

                    try
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(memoryStreamEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            await csEncrypt.WriteAsync(data, 0, data.Length);
                            await csEncrypt.FlushFinalBlockAsync();
                        }
                    }
                    catch (CryptographicException ex)
                    {
                        throw new CryptographicException("Encryption failed: " + ex.Message, ex);
                    }

                    return memoryStreamEncrypt.ToArray();
                }
            }
        }
    }
}


