using System;
using System.Collections.Generic;

namespace OneLookAPI.Models
{
    public partial class User
    {
        public User()
        {
            Projects = new HashSet<Project>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Project> Projects { get; set; }
    }
}
