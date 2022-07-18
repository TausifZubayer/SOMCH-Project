﻿using System;
using System.Collections.Generic;

namespace SOMCH_Project_V3.Models
{
    public partial class RegDoctorRoomLog
    {
        public string Id { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool Enabled { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Doctorroomstatusenumkey { get; set; }
    }
}
