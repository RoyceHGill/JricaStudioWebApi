﻿
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
        /// Update the Administrator's password with the provided details. Only to be used on Authorized Requests.
        /// </summary>
        /// <param name="id">Guid Representing Administrator in the database.</param>
        /// <param name="credentialsDto">Data Transfer Object Containing Old and new login information..</param>
        /// <returns>Returns Updated Administrator Details of affects Entity.</returns>
        Task<Admin> UpdatePassword(Guid id, UserCredentialsUpdateDto credentialsDto);
        /// <summary>
        /// Update the password of the administrator with the provided details, Only to be used in Authorized request in certain circumstances .
        /// </summary>
        /// <param name="resetKey">Password Reset Key Associated with the Administrator that is Reseting their password.</param>
        /// <param name="resetDto">Data Transfer object containing new password </param>
        /// <returns>Returns the updated Administrator details</returns>
        Task<Admin> UpdatePassword(Guid resetKey, ResetPasswordDto resetDto);
        /// <summary>
        /// Checks the Key provided is a valid key within the database.
        /// </summary>
        /// <param name="adminKey">Guid Administrator key for authorized access </param>
        /// <returns>Returns true if the key provided exists in the database.</returns>
        Task<bool> ValidateAdminKey(Guid adminKey);
        /// <summary>
        /// Begins the Password reset process, generating a new key for reseting a password. 
        /// </summary>
        /// <param name="email">the email associated with the administrator's account.</param>
        /// <returns>Administrators details with updated reset password key.</returns>
        Task<Admin> InitiatePasswordReset(string email);
    }
}
