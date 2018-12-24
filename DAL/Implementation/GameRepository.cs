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
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(CyberTrainingContext context) : base(context)
        { }

        public void Insert(Game game)
        {
            db.Entry(game).State = EntityState.Added;
            db.SaveChanges();
        }

        public IEnumerable<Game> GetAll()
        {
            return db.Games.ToList();
        }

        public Game GetById(int id)
        {
            return db.Games.FirstOrDefault(x => x.GameId == id);
        }

        public void Delete(int id)
        {
            Game game = this.GetById(id);
            db.Entry(game).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
