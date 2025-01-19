using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JricaStudioWebAPI.Models.Dtos.Admin
{
    public class ServiceFilterDto
    {
        public string SearchString { get; set; } = "";
        public Guid CategoryId { get; set; }

    }
}
