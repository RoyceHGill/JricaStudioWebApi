﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JricaStudioWebAPI.Models.Dtos.Admin
{
    public class UserCredentialsUpdateDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public Guid AdminId { get; set; }
    }
}
