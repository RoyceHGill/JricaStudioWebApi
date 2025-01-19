using JricaStudioWebAPI.Entities.Helpers;

namespace JricaStudioWebAPI.Entities
{
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

    }
}
