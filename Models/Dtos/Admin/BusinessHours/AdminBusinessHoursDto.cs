
using JricaStudioWebApi.Models.Dtos.BusinessHours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JricaStudioWebApi.Models.Dtos.Admin.BusinessHours
{
    public class AdminBusinessHoursDto : BusinessHoursDto, IBusinessHoursDto
    {
        public Guid Id { get; set; }
    }
}
