using BOL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface IGenreRepository
    {
        void Insert(Genre genre);
        IEnumerable<Genre> GetAll();
        User GetById(int id);
        void Delete(int id);
        void Update(Genre genre);
    }
}
