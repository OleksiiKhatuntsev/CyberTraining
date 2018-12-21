using System;
using System.Collections.Generic;
using System.Text;

namespace BOL.Models
{
    public class Role
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
