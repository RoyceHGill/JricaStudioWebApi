using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JricaStudioWebAPI.Models.Dtos
{
    public class ContactFormResult
    {
        public bool IsSuccessful { get; set; }
        public string Email { get; set; }
    }
}
