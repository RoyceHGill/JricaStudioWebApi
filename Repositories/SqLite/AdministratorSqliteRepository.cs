using JricaStudioSharedLibrary.Dtos.Admin;
using JricaStudioWebAPI.Data;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace JricaStudioWebAPI.Repositories.SqLite
{
    /// <inheritdoc cref="IAdministratorRepository"/>
    public class AdministratorSqLiteRepository : IAdministratorRepository
    {
        private readonly JaysLashesDbContext _dbContext;
        public AdministratorSqLiteRepository(JaysLashesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Admin> GetAdministratorUser(string userName)
        {
            return await _dbContext.Admins.SingleOrDefaultAsync(a => a.Username.Equals(userName));
        }

        public async Task<Admin> GetAdministratorUser(Guid Id)
        {
            return await _dbContext.Admins.SingleOrDefaultAsync(a => a.Id == Id);
        }
        public async Task<Admin> InitiatePasswordReset(string email)
        {
            var admin = _dbContext.Admins.SingleOrDefault(s => s.Username.Equals(email));

            if (admin == null)
            {
                return default;
            }

            admin.ResetKey = Guid.NewGuid();
            admin.ResetKeySent = DateTime.UtcNow;

            var result = _dbContext.Admins.Update(admin);

            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }
        
        public async Task<Admin> UpdatePassword(Guid key, ResetPasswordDto updatePassword)
        {
            var admin = await _dbContext.Admins.SingleOrDefaultAsync(a => a.ResetKey == key);

            if (admin != null && admin.ResetKeySent > DateTime.UtcNow.AddHours(-1))
            {
                admin.Password = BCrypt.Net.BCrypt.HashPassword(updatePassword.NewPassword);
                admin.ResetKeySent = DateTime.MinValue;
                admin.Updated = DateTime.UtcNow;

                var result = _dbContext.Admins.Update(admin);

                _dbContext.SaveChanges();

                return result.Entity;
            }

            return default;
        }

        public async Task<Admin> UpdatePassword(Guid id, UserCredentialsUpdateDto userCredentials)
        {
            try
            {
                var admin = await _dbContext.Admins.SingleOrDefaultAsync(a => a.Id == id);


                if (admin == null || !BCrypt.Net.BCrypt.Verify(userCredentials.OldPassword, admin.Password))
                {
                    return default;
                }
                admin.Updated = DateTime.UtcNow;
                admin.Password = BCrypt.Net.BCrypt.HashPassword(userCredentials.NewPassword);

                var result = _dbContext.Admins.Update(admin);

                _dbContext.SaveChanges();

                return result.Entity;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<bool> ValidateAdministratorKey(Guid key)
        {
            return _dbContext.Admins.Any(a => a.AdminKey == key);
        }
    }
}
