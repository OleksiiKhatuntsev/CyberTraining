using System;
using System.Collections.Generic;
using System.Text;
using BLL.Db;
using BOL;
using BOL.Models;

namespace ConditionsService
{

    // TODO Make some physical devices to track all of user conditions
    internal class FakeRepository
    {
        private AllDb db;

        internal FakeRepository(CyberTrainingContext context)
        {
            db = new AllDb(context);
        }

        internal void SetConditions()
        {
            foreach (var user in db.UserDb.GetAll())
            {
                Random r = new Random();
                db.ConditionDb.Insert(new Condition{DateTime = DateTime.Now, Pulse = r.Next(60, 120), RoomTemperature = r.Next(15,30), Temperature = r.Next(35, 37) + r.Next(1,10)/10, UserId = user.UserId, User = user});
            }
        }
    }
}
