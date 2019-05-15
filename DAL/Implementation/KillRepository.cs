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
    public class KillRepository : BaseRepository, IKillRepository
    {
        public KillRepository(CyberTrainingContext context) : base(context)
        { }
        public void Insert(Kill kill)
        {
            db.Entry(kill).State = EntityState.Added;
            db.SaveChanges();
        }

        public IEnumerable<Kill> GetAll()
        {
            return db.Kills.ToList();
        }

        public Kill GetById(int id)
        {
            return db.Kills.FirstOrDefault(x => x.UserId == id);
        }

        public void Delete(int id)
        {
            Kill kill = GetById(id);
            db.Entry(kill).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(Kill kill)
        {
            db.Entry(kill).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
