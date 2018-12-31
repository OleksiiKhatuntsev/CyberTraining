using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BOL.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [DisplayName("Genre")]
        public string GenreName { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
