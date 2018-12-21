using BOL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public interface IGameRepository
    {
        void Insert(Game game);
        IEnumerable<Game> GetAll();
        User GetById(int id);
        void Delete(int id);
        void Update(Game game);
    }
}
