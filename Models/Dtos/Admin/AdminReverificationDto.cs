using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JricaStudioWebApi.Models.Dtos.Admin
{
    public class AdminReverificationDto
    {
        public Guid AdminId { get; set; }
        public Guid Adminkey { get; set; }
    }
}
