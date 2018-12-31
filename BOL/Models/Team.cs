﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BOL.Models
{
    public class Team
    {
        public int TeamId { get; set; }

        [Required]
        [DisplayName("Name")]
        public string TeamName { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public virtual ICollection<User> Users {get;set;}
    }
}
