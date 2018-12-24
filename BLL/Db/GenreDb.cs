using System;
using System.Collections.Generic;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using DAL.Implementation;

namespace BLL.Db
{
    public class GenreDb
    {
        private readonly IGenreRepository db;

        public GenreDb(CyberTrainingContext context)
        {
            db = new GenreRepository(context);
        }

        public void Insert(Genre genre)
        {
            db.Insert(genre);
        }

        public Genre GetById(int id)
        {
            return db.GetById(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.GetAll();
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public void Update(Genre genre)
        {
            db.Update(genre);
        }
    }
}
