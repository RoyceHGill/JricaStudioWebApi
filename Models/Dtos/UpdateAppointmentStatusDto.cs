﻿using JricaStudioWebAPI.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JricaStudioWebAPI.Models.Dtos
{
    public class UpdateAppointmentStatusDto
    {
        public AppointmentStatus Status { get; set; }
    }
}
