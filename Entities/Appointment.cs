using JricaStudioWebAPI.Entities.Helpers;
using JricaStudioWebAPI.Models.enums;
using NuGet.Packaging.Signing;

namespace JricaStudioWebAPI.Entities
{
    public class Appointment : BaseModel
    {
        public Guid UserId { get; set; }
        public DateTime? StartTime { get; set; } = null;
        public DateTime? EndTime { get; set; }
        public User User { get; set; }
        public bool HasHadEyelashExtentions { get; set; } = false;
        public bool IsSampleSetComplete { get; set; } = false;
        public bool IsDepositPaid { get; set; } = false;
        public DateTime? SampleSetCompleted { get; set; }
        public ICollection<AppointmentProduct>? AppointmentProducts { get; set; }
        public ICollection<AppointmentService>? AppointmentServices { get; set; }
        public AppointmentStatus Status { get; set; } = AppointmentStatus.NotFinalized;
    }
}
