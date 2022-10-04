using System;
using System.Collections.Generic;

namespace OneLookAPI.Models
{
    public partial class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public int UserId { get; set; }
    }
}
