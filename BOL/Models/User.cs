﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BOL.Models
{
    public class User
    {
        public int UserId { get; set; }

        [DisplayName("NickName")]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}