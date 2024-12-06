using JricaStudioWebApi.Entities.Helpers;
using JricaStudioWebApi.Services;
using JricaStudioWebApi.Services.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace JricaStudioWebApi.Entities
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateOnly DOB { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public bool WearsContanctLenses { get; set; } = false;
        public bool HasHadEyeProblems4Weeks { get; set; } = false;
        public bool HasAllergies { get; set; } = false;
        public bool HasSensitiveSkin { get; set; } = false;
        public bool IsWaiverAcknowledged { get; set; } = false;
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
