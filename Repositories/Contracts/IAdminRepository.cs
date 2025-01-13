
using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Entities;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IAdminRepository
    {
        /// <summary>
        /// Get the Administrator detail from user name provided
        /// </summary>
        /// <param name="username">User's Email</param>
        /// <returns>Admin Details </returns>
        Task<Admin> GetAdminUser(string username);
        /// <summary>
        /// Get Administrator details for provided ID.
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns>Administrator's details</returns>
        Task<Admin> GetAdminUser(Guid adminId);
        /// <summary>
        /// Update the Administrator's password with the provided details. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<Admin> UpdatePassword(Guid id, UserCredentialsUpdateDto dto);
        Task<Admin> UpdatePassword(Guid key, ResetPasswordDto dto);
        Task<Admin> UpdateAdmin(Guid id, UpdateAdminDto admin);
        Task<bool> ValidateAdminKey(Guid key);
        Task<Admin> InitiatePasswordReset(string email);
    }
}
