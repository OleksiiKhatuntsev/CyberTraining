using System;
using System.Collections.Generic;
using System.Text;
using BLL.Db;
using BOL;
using BOL.Models;

namespace UserTrackingService
{
    internal class FakeRepository
    {
        private AllDb db;

        internal  FakeRepository(CyberTrainingContext context)
        {
            db = new AllDb(context);
        }

        internal void UpdateUserSettings()
        {
            foreach (var kill in db.KillDb.GetAll())
            {
                Random r = new Random();
                kill.GameForDay = r.Next(1, 10);
                kill.AllGames += kill.GameForDay;
                kill.BotKills += r.Next(1, 20);
                kill.IsUserInGame = r.Next(1, 3) > 1;
                db.KillDb.Update(kill);
            }
        }

        internal void SetDataForUser(int userId)
        {
            Kill kill = new Kill {UserId = userId, BotKills = 0, GameForDay = 0, AllGames = 0, IsUserInGame = false};
            db.KillDb.Insert(kill);
        }
    }
}
