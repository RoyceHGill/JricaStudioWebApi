
using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Entities;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IAdminRepository
    {
        Task<Admin> GetAdminUser(string username);
        Task<Admin> GetAdminUser(Guid id);
        Task<IEnumerable<Admin>> GetAdminUsers();
        Task<Admin> UpdatePassword(Guid id, UserCredentialsUpdateDto dto);
        Task<Admin> UpdatePassword(Guid key, ResetPasswordDto dto);
        Task<Admin> UpdateAdmin(Guid id, UpdateAdminDto admin);
        Task<bool> ValidateAdminKey(Guid key);
        Task<Admin> InitiatePasswordReset(string email);
    }
}
