using JricaStudioWebApi.Entities.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// An Administrator of the Application and database. 
    /// </summary>
    public class Admin : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Guid AdminKey { get; set; }
        public Guid ResetKey { get; set; }
        public DateTime ResetKeySent { get; set; }
        public DateTime? Updated { get; set; }

    }
}
