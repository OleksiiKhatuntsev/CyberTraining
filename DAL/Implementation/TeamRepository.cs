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
    public class TeamRepository : BaseRepository, ITeamRepository
    {
        public TeamRepository(CyberTrainingContext context) : base(context)
        { }

        public void Insert(Team team)
        {
            db.Entry(team).State = EntityState.Added;
            db.SaveChanges();
        }

        public IEnumerable<Team> GetAll()
        {
            return db.Teams.ToList();
        }

        public Team GetById(int id)
        {
            return db.Teams.FirstOrDefault(x => x.TeamId == id);
        }

        public void Delete(int id)
        {
            Team team = GetById(id);
            db.Entry(team).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
