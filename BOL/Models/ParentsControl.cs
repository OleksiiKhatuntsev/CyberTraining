using System;
using System.Collections.Generic;
using System.Text;

namespace BOL.Models
{
    public class ParentsControl
    {
        public int ParentsControlId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int KillId { get; set; }

        public Kill Kill { get; set; }
    }
}
