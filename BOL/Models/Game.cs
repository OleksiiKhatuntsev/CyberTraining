using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BOL.Models
{
    public class Game
    {
        public int GameId { get; set; }

        [DisplayName("Game")]
        public string GameName { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
