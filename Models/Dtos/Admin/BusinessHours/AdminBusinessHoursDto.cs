
using JricaStudioWebAPI.Models.Dtos.BusinessHours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JricaStudioWebAPI.Models.Dtos.Admin.BusinessHours
{
    public class AdminBusinessHoursDto : BusinessHoursDto, IBusinessHoursDto
    {
        public Guid Id { get; set; }
    }
}
