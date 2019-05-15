using System;
using System.Collections.Generic;
using System.Text;
using BLL.Db;
using BOL;
using BOL.Models;

namespace UserTrackingService
{
    public class FakeRepository
    {
        private AllDb db;

        public  FakeRepository(CyberTrainingContext context)
        {
            db = new AllDb(context);
        }

        internal void SetRandomUserSettings()
        {
            foreach (var kill in db.KillDb.GetAll())
            {
                Random r = new Random();
                kill.GameForDay = r.Next(1, 10);
                kill.AllGames += kill.GameForDay;
                kill.BotKills += r.Next(1, 20);
                kill.IsUserInGame = r.Next(1, 2) > 1;
                db.KillDb.Update(kill);
            }
        }

        public void SetDataForUser(int userId)
        {
            Kill kill = new Kill {UserId = userId, BotKills = 0, GameForDay = 0, AllGames = 0, IsUserInGame = false};
            db.KillDb.Insert(kill);
        }
        
    }
}
