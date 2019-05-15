using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BOL.Models
{
    public class Kill
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        public int BotKills { get; set; }

        public int GameForDay { get; set; }

        public int AllGames { get; set; }

        public bool IsUserInGame { get; set; }
    }
}
