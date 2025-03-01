
using JricaStudioWebAPI.Entities.Helpers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JricaStudioWebAPI.Entities
{
    public interface IAdmin : IBaseModel
    {
        Guid AdminKey { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string Phone { get; set; }
        Guid ResetKey { get; set; }
        DateTime ResetKeySent { get; set; }
        string Username { get; set; }
    }
}