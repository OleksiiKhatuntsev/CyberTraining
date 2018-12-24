using System;
using System.Collections.Generic;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using DAL.Implementation;

namespace BLL.Db
{
    public class TeamDb
    {
        private readonly ITeamRepository db;

        public TeamDb(CyberTrainingContext context)
        {
            db = new TeamRepository(context);
        }

        public void Insert(Team team)
        {
            db.Insert(team);
        }

        public Team GetById(int id)
        {
            return db.GetById(id);
        }

        public IEnumerable<Team> GetAll()
        {
            return db.GetAll();
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public void Update(Team team)
        {
            db.Update(team);
        }
    }
}
