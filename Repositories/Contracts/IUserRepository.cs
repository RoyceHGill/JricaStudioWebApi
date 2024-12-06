using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Models.Dtos;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<User> SignIn(UserSignInDto dto);
        Task<User> GetUser(Guid id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> CreateNew(UserToAddDto user);
        Task<User> CreateNew(UserAdminAddDto user);

        Task<User> UpdateUserName(Guid id, UpdateUserNameDto updateUserNameDto);
        Task<User> UpdateUser(UpdateUserDto dto);
        Task<User> UpdateUserWaiver(Guid id, bool IsAccepted);
        Task<User> DeleteTemporaryUser(Guid id);
        Task<IEnumerable<User>> GetUsersAdmin();
        Task<User> DeleteUser(Guid id);
        Task<User> UpdateUserById(Guid id, UpdateUserDto user);
        Task<IEnumerable<User>> SearchUsers(UserFilterDto filter);
    }
}
