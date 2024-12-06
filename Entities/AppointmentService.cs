using JricaStudioWebApi.Entities.Helpers;

namespace JricaStudioWebApi.Entities
{
    public class AppointmentService : BaseModel
    {

        public Guid AppointmentId { get; set; }

        public Guid ServiceId { get; set; }

        public Appointment Appointment { get; set; }

        public Service Service { get; set; }

    }
}
