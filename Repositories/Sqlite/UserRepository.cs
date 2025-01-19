using JricaStudioWebAPI.Data;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using JricaStudioWebAPI.Models.Dtos;
using JricaStudioWebAPI.Extentions;
using JricaStudioWebAPI.Models.Dtos.Admin;
using JricaStudioWebAPI.Models.Dtos;
using JricaStudioWebAPI.Services.Contracts;

namespace JricaStudioWebAPI.Repositories.SqLite
{
    public class UserRepository : IUserRepository
    {
        private readonly JaysLashesDbContext _jaysLashesDbContext;
        private readonly IStringEncryptionService _encryptionService;

        public UserRepository(JaysLashesDbContext jaysLashesDbContext, IStringEncryptionService encryptionService)
        {
            _jaysLashesDbContext = jaysLashesDbContext;
            _encryptionService = encryptionService;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {

            try
            {
                var users = _jaysLashesDbContext.Users.AsEnumerable();

                var decryptedUsers = new List<User>();

                foreach (var user in users)
                {
                    decryptedUsers.Add(await DecryptUser(user));
                }

                return decryptedUsers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetUsersAdmin()
        {

            try
            {
                var users = _jaysLashesDbContext.Users.Include(u => u.Appointments).ThenInclude(a => a.AppointmentProducts).ThenInclude(ap => ap.Product).Include(a => a.Appointments).ThenInclude(a => a.AppointmentServices).ThenInclude(a => a.Service).AsNoTracking().AsEnumerable();


                var decryptedUsers = new List<User>();

                foreach (var user in users)
                {
                    decryptedUsers.Add(await DecryptUser(user));
                }

                return decryptedUsers;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> CreateNew(UserToAddDto userAddDto)
        {
            userAddDto.FirstName = await _encryptionService.EncryptString(userAddDto.FirstName);
            userAddDto.LastName = await _encryptionService.EncryptString(userAddDto.LastName);

            var user = await _jaysLashesDbContext.Users.SingleOrDefaultAsync(u => u.Id == userAddDto.Id);

            if (user != null)
            {
                throw new Exception("User already Exists.");
            }

            var result = await _jaysLashesDbContext.Users.AddAsync(userAddDto.ConvertToEntity());

            await _jaysLashesDbContext.SaveChangesAsync();

            var userDecrypted = await DecryptUser(result.Entity);

            return userDecrypted;
        }

        public async Task<User> CreateNew(UserAdminAddDto userDto)
        {
            userDto.Email = userDto.Email.ToLower();

            var users = _jaysLashesDbContext.Users.Where(u => u.Email != null).AsNoTracking().AsEnumerable();

            var DecryptedUsers = await DecryptUsers(users);

            var user = DecryptedUsers.SingleOrDefault(u => u.Email.Equals(userDto.Email));

            if (user != null)
            {
                throw new Exception("This Email is taken.");
            }

            userDto.FirstName = await _encryptionService.EncryptString(userDto.FirstName);
            userDto.LastName = await _encryptionService.EncryptString(userDto.LastName);
            userDto.Phone = await _encryptionService.EncryptString(userDto.Phone);
            userDto.Email = await _encryptionService.EncryptString(userDto.Email);

            var result = await _jaysLashesDbContext.Users.AddAsync(userDto.ConvertToEntity());

            if (result == null)
            {
                return null;
            }

            await _jaysLashesDbContext.SaveChangesAsync();
            var decryptedUser = await DecryptUser(result.Entity);

            return decryptedUser;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await _jaysLashesDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                user = await DecryptUser(user);
            }
            return user;
        }

        public async Task<User> UpdateUser(UpdateUserDto userUpdateDto)
        {
            userUpdateDto.Email = userUpdateDto.Email.ToLower();

            userUpdateDto.FirstName = await _encryptionService.EncryptString(userUpdateDto.FirstName);
            userUpdateDto.LastName = await _encryptionService.EncryptString(userUpdateDto.LastName);
            userUpdateDto.Phone = await _encryptionService.EncryptString(userUpdateDto.Phone);
            userUpdateDto.Email = await _encryptionService.EncryptString(userUpdateDto.Email);


            var user = await _jaysLashesDbContext.Users.SingleOrDefaultAsync(u => u.Id == userUpdateDto.Id);

            if (user == null)
            {
                return null;
            }

            var conflictingUserEmail = await _jaysLashesDbContext.Users.SingleOrDefaultAsync(u => u.Id != userUpdateDto.Id && u.Email == userUpdateDto.Email);
            if (conflictingUserEmail != null)
            {
                throw new InvalidOperationException("This Email is already taken.");
            }
            user.FirstName = userUpdateDto.FirstName;
            user.LastName = userUpdateDto.LastName;
            user.Phone = userUpdateDto.Phone;
            user.Email = userUpdateDto.Email;
            user.DOB = userUpdateDto.DOB;
            user.HasSensitiveSkin = userUpdateDto.HasSensitiveSkin;
            user.HasHadEyeProblems4Weeks = userUpdateDto.HasHadEyeProblems4Weeks;
            user.WearsContanctLenses = userUpdateDto.WearsContanctLenses;
            user.HasAllergies = userUpdateDto.HasAllergies;

            await _jaysLashesDbContext.SaveChangesAsync();

            user = await DecryptUser(user);

            return user;
        }



        public Task<User> UpdateUserName(Guid id, UpdateUserNameDto updateUserNameDto)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUserWaiver(Guid id, bool IsAccepted)
        {
            var user = await _jaysLashesDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            user.IsWaiverAcknowledged = IsAccepted;

            await _jaysLashesDbContext.SaveChangesAsync();

            user = await DecryptUser(user);

            return user;
        }

        public async Task<User> SignIn(UserSignInDto dto)
        {
            var users = _jaysLashesDbContext.Users.Where(u => u.Email != null).AsNoTracking().AsEnumerable();

            var decryptedUsers = await DecryptUsers(users);

            dto.Email = dto.Email.ToLower();

            var user = decryptedUsers.SingleOrDefault(u => u.Email == dto.Email);

            return user;
        }

        private async Task<IEnumerable<User>> DecryptUsers(IEnumerable<User> users)
        {
            var decryptedusers = new List<User>();
            foreach (var user in users)
            {
                decryptedusers.Add(await DecryptUser(user));
            }
            return decryptedusers;
        }


        private async Task<User> DecryptUser(User user)
        {
            user.FirstName = await _encryptionService.DecryptString(user.FirstName);
            user.LastName = await _encryptionService.DecryptString(user.LastName);

            if (user.Email != null)
            {
                user.Email = await _encryptionService.DecryptString(user.Email);

            }
            else
            {
                user.Email = string.Empty;
            }
            if (user.Phone != null)
            {
                user.Phone = await _encryptionService.DecryptString(user.Phone);
            }
            else
            {
                user.Phone = string.Empty;
            }

            return user;
        }

        public async Task<User> DeleteTemporaryUser(Guid id)
        {
            var user = await _jaysLashesDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                if (user.Email == null && user.Phone == null)
                {
                    _jaysLashesDbContext.Users.Remove(user);
                    await _jaysLashesDbContext.SaveChangesAsync();
                }
                else
                {
                    return default;
                }
            }
            user = await DecryptUser(user);
            return user;
        }

        public async Task<User> DeleteUser(Guid id)
        {

            try
            {
                var user = await _jaysLashesDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    return default;
                }

                var result = _jaysLashesDbContext.Users.Remove(user);

                await _jaysLashesDbContext.SaveChangesAsync();

                var decryptedUser = await DecryptUser(result.Entity);

                return decryptedUser;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<User> UpdateUserById(Guid id, UpdateUserDto dto)
        {
            try
            {
                var user = await _jaysLashesDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    return default;
                }

                var decryptedUser = await DecryptUser(user);
                if (!dto.Email.Equals(decryptedUser.Email))
                {
                    var users = _jaysLashesDbContext.Users.AsNoTracking().AsEnumerable();
                    var decryptedUsers = await DecryptUsers(users);
                    if (decryptedUsers.Any(u => u.Email == dto.Email))
                    {
                        throw new AggregateException("Email is taken");
                    }
                }

                user.FirstName = await _encryptionService.EncryptString(dto.FirstName);
                user.LastName = await _encryptionService.EncryptString(dto.LastName);
                user.Email = await _encryptionService.EncryptString(dto.Email);
                user.Phone = await _encryptionService.EncryptString(dto.Phone);
                user.IsWaiverAcknowledged = dto.IsWaiverAcknowledged;
                user.HasHadEyeProblems4Weeks = dto.HasHadEyeProblems4Weeks;
                user.WearsContanctLenses = dto.WearsContanctLenses;
                user.HasAllergies = dto.HasAllergies;
                user.DOB = dto.DOB;

                var result = _jaysLashesDbContext.Users.Update(user);

                await _jaysLashesDbContext.SaveChangesAsync();

                return await DecryptUser(result.Entity);

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> SearchUsers(UserFilterDto filter)
        {
            try
            {
                if (string.IsNullOrEmpty(filter.SearchText))
                {
                    return default;
                }

                filter.SearchText = filter.SearchText.ToLower();

                var encryptedUsers = _jaysLashesDbContext.Users.Include(u => u.Appointments)
                    .ThenInclude(a => a.AppointmentProducts)
                    .ThenInclude(ap => ap.Product)
                    .Include(a => a.Appointments)
                    .ThenInclude(a => a.AppointmentServices)
                    .ThenInclude(a => a.Service)
                    .AsNoTracking()
                    .AsEnumerable();

                var decryptedUsers = await DecryptUsers(encryptedUsers);



                var filteredUsers = decryptedUsers.Where(u =>
                u.FirstName.Contains( filter.SearchText, StringComparison.CurrentCultureIgnoreCase ) || u.FirstName.ToLower().Equals(filter.SearchText)
                || u.LastName.Contains( filter.SearchText, StringComparison.CurrentCultureIgnoreCase ) || u.LastName.ToLower().Equals(filter.SearchText)
                || u.Phone.Contains( filter.SearchText, StringComparison.CurrentCultureIgnoreCase ) || u.Phone.ToLower().Equals(filter.SearchText)
                || u.Email.Contains( filter.SearchText, StringComparison.CurrentCultureIgnoreCase ) || u.Email.ToLower().Equals(filter.SearchText)
                ).AsEnumerable();

                return filteredUsers;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
