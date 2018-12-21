using System;
using System.Collections.Generic;
using System.Text;

namespace BOL.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
