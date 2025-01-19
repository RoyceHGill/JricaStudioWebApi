using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JricaStudioWebAPI.Models.Dtos
{
    public class AppointmentServiceUpdateQuantityDto
    {
        public Guid AppointmentServiceId { get; set; }
        public int Quantiy { get; set; }
    }
}
