using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(CyberTrainingContext context) : base(context)
        { }

        public void Insert(Genre genre)
        {
            db.Entry(genre).State = EntityState.Added;
            db.SaveChanges();
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres.ToList();
        }

        public Genre GetById(int id)
        {
            return db.Genres.FirstOrDefault(x => x.GenreId == id);
        }

        public void Delete(int id)
        {
            Genre genre = GetById(id);
            db.Entry(genre).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(Genre genre)
        {
            db.Entry(genre).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
