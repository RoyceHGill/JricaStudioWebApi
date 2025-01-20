using JricaStudioWebAPI.Models.Dtos.Admin;
using JricaStudioWebAPI.Models.Dtos;
using JricaStudioWebAPI.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JricaStudioWebAPI.Models.Dtos.Admin
{
    public class AppointmentAdminToAddDto
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid UserId { get; set; }
        public bool HasHadEyelashExtentions { get; set; }
        public bool IsSampleSetComplete { get; set; }
        public bool IsDepositPaid { get; set; }
        public DateTime? SampleSetCompleted { get; set; }
        public List<AppointmentServiceAdminAddDto> ServicesToAdd { get; set; }
        public List<AppointmentProductAdminAddDto> ProductsToAdd { get; set; }
    }
}
