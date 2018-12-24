using System;
using System.Collections.Generic;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using DAL.Implementation;

namespace BLL.Db
{
    public class GameDb
    {
        private readonly IGameRepository db;

        public GameDb(CyberTrainingContext context)
        {
            db = new GameRepository(context);
        }

        public void Insert(Game game)
        {
            db.Insert(game);
        }

        public Game GetById(int id)
        {
            return db.GetById(id);
        }

        public IEnumerable<Game> GetAll()
        {
            return db.GetAll();
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public void Update(Game game)
        {
            db.Update(game);
        }
    }
}
