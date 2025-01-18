using JricaStudioWebApi.Entities;
using JricaStudioSharedLibrary.Dtos;
using JricaStudioSharedLibrary.Dtos.Admin;
using JricaStudioSharedLibrary.Dtos;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IUserRepository
    {
        /// <summary>
        /// Authenticate the users identity against details on the database. 
        /// </summary>
        /// <param name="dto">The current users details.</param>
        /// <returns>The Authenticated user.</returns>
        Task<User> SignIn(UserSignInDto dto);

        /// <summary>
        /// Get the users details from the database.
        /// </summary>
        /// <param name="id">users Id</param>
        /// <returns>The users details that has the id provided.</returns>
        Task<User> GetUser(Guid id);

        /// <summary>
        /// Get all users of the website.
        /// </summary>
        /// <returns>Populate the user page of the Administrator pages.</returns>
        Task<IEnumerable<User>> GetUsers();

        /// <summary>
        /// Create a new user in the database.
        /// </summary>
        /// <param name="user">Users details.</param>
        /// <returns>The newly created user.</returns>
        Task<User> CreateNew(UserToAddDto user);
        /// <summary>
        /// Create a new user in the database.
        /// </summary>
        /// <param name="user">Users details.</param>
        /// <returns>The newly created user.</returns>
        Task<User> CreateNew(UserAdminAddDto user);

        /// <summary>
        /// Change the users user name. 
        /// </summary>
        /// <param name="id">The users ID</param>
        /// <param name="updateUserNameDto">The user's new details.</param>
        /// <returns>The updated user's details.</returns>
        Task<User> UpdateUserName(Guid id, UpdateUserNameDto updateUserNameDto);

        /// <summary>
        /// Change multiple user details at once.
        /// </summary>
        /// <param name="dto">New user details.</param>
        /// <returns>Updated user's details.</returns>
        Task<User> UpdateUser(UpdateUserDto dto);

        /// <summary>
        /// Change the user's waiver acceptance detail.
        /// </summary>
        /// <param name="id">The user Id</param>
        /// <param name="isAccepted">Is the waiver accepted?</param>
        /// <returns>The updated user's details.</returns>
        Task<User> UpdateUserWaiver(Guid id, bool isAccepted);

        /// <summary>
        /// Remove the User from the database.
        /// </summary>
        /// <param name="id">Unique identifier representing the user in the database.</param>
        /// <returns>The updated user's details. <see cref="User"></returns>
        Task<User> DeleteTemporaryUser(Guid id);


        /// <summary>
        /// Retrieves a collection of users for the administrator page.
        /// </summary>
        /// <returns>A collection of users.</returns>
        Task<IEnumerable<User>> GetUsersAdmin();

        /// <summary>
        /// Remove the user from the database.
        /// </summary>
        /// <param name="id">identifier of the user in the database.</param>
        /// <returns>The deleted User.</returns>
        Task<User> DeleteUser(Guid id);

        /// <summary>
        /// Change the user's details. 
        /// </summary>
        /// <param name="id">the user's identifier.</param>
        /// <param name="user">New users details</param>
        /// <returns>The updated user's details.</returns>
        Task<User> UpdateUserById(Guid id, UpdateUserDto user);

        /// <summary>
        /// Query the database for users that match the filter.
        /// </summary>
        /// <param name="filter">Collection of user details that are desired.</param>
        /// <returns>Returns users that match or partially match the filters details.</returns>
        Task<IEnumerable<User>> SearchUsers(UserFilterDto filter);
    }
}
