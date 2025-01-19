using JricaStudioWebAPI.Services.Contracts;
using System.Buffers.Text;
using System.Text;

namespace JricaStudioWebAPI.Services
{
    public class StringEncryptionService : IStringEncryptionService
    {
        private readonly IEncryptionService _encryptionService;

        public StringEncryptionService(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        public async Task<string> DecryptString(string encryptedString)
        {

            byte[] bytes = Convert.FromBase64String(encryptedString);

            bytes = await _encryptionService.DecryptByteArray(bytes);


            return Encoding.UTF8.GetString(bytes);

        }

        public async Task<string> EncryptString(string data)
        {

            byte[] bytes = Encoding.UTF8.GetBytes(data);

            bytes = await _encryptionService.EncryptByteArray(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}
