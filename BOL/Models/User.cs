using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BOL.Models
{
    public class User
    {
        public int UserId { get; set; }

        [DisplayName("NickName")]
        [Required(ErrorMessage = "Enter username!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Email!")]
        [EmailAddress(ErrorMessage = "Enter valid Email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
