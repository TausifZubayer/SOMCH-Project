﻿using System;
using System.Collections.Generic;

namespace SOMCH_Project_V3.Models
{
    public partial class Databasechangelog
    {
        public string Id { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Filename { get; set; } = null!;
        public DateTime Dateexecuted { get; set; }
        public int Orderexecuted { get; set; }
        public string Exectype { get; set; } = null!;
        public string? Md5sum { get; set; }
        public string? Description { get; set; }
        public string? Comments { get; set; }
        public string? Tag { get; set; }
        public string? Liquibase { get; set; }
        public string? Contexts { get; set; }
        public string? Labels { get; set; }
    }
}
