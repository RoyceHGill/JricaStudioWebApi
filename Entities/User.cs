using JricaStudioWebApi.Entities.Helpers;
using JricaStudioWebApi.Services;
using JricaStudioWebApi.Services.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace JricaStudioWebApi.Entities
{
    /// <summary>
    /// This Represents a user of the Application.
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The users email address.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The users Phone number.
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// The users Date of Birth.
        /// </summary>
        public DateOnly DOB { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// Indicates if the user wears contact lenses
        /// </summary>
        public bool WearsContanctLenses { get; set; } = false;

        /// <summary>
        /// Indicates if the user Has had eye problems in the past 4 weeks.
        /// </summary>
        public bool HasHadEyeProblems4Weeks { get; set; } = false;

        /// <summary>
        /// Indicates if the user has allergies to products used.
        /// </summary>
        public bool HasAllergies { get; set; } = false;

        /// <summary>
        /// Indicates if the user has sensitive skin.
        /// </summary>
        public bool HasSensitiveSkin { get; set; } = false;

        /// <summary>
        /// Indicates if the user has acknowledged the waiver.
        /// </summary>
        public bool IsWaiverAcknowledged { get; set; } = false;

        /// <summary>
        /// The appointments the user has made.
        /// </summary>
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
