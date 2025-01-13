using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Data;
using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace JricaStudioWebApi.Repositories.Sqlite
{
    public class AdminSqliteRepository : IAdminRepository
    {
        private readonly JaysLashesDbContext _dbContext;
        public AdminSqliteRepository(JaysLashesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Admin> GetAdminUser(string username)
        {
            return await _dbContext.Admins.SingleOrDefaultAsync(a => a.Username.Equals(username));
        }

        public async Task<Admin> GetAdminUser(Guid Id)
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

        

        public async Task<Admin> UpdatePassword(Guid key, ResetPasswordDto dto)
        {
            var admin = await _dbContext.Admins.SingleOrDefaultAsync(a => a.ResetKey == key);

            if (admin != null && admin.ResetKeySent > DateTime.UtcNow.AddHours(-1))
            {
                admin.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
                admin.ResetKeySent = DateTime.MinValue;
                admin.Updated = DateTime.UtcNow;

                var result = _dbContext.Admins.Update(admin);

                _dbContext.SaveChanges();

                return result.Entity;
            }

            return default;
        }

        public async Task<Admin> UpdateAdmin(Guid Id, UpdateAdminDto dto)
        {
            try
            {

                var admin = await GetAdminUser(Id);

                admin.FirstName = dto.FirstName;
                admin.LastName = dto.LastName;
                admin.Phone = dto.Phone;

                var result = _dbContext.Admins.Update(admin);
                _dbContext.SaveChanges();
                return result.Entity;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Admin> UpdatePassword(Guid id, UserCredentialsUpdateDto dto)
        {
            try
            {
                var admin = await _dbContext.Admins.SingleOrDefaultAsync(a => a.Id == id);


                if (admin == null || !BCrypt.Net.BCrypt.Verify(dto.OldPassword, admin.Password))
                {
                    return default;
                }
                admin.Updated = DateTime.UtcNow;
                admin.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

                var result = _dbContext.Admins.Update(admin);

                _dbContext.SaveChanges();

                return result.Entity;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public Task<Admin> UpdatePassword(Guid Id, string existingPassword, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateAdminKey(Guid key)
        {
            return _dbContext.Admins.Any(a => a.AdminKey == key);
        }
    }
}
