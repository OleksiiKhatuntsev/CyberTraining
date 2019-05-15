using System;
using System.Collections.Generic;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using DAL.Implementation;

namespace BLL.Db
{
    public class KillDb
    {
        private readonly IKillRepository db;

        public KillDb(CyberTrainingContext context)
        {
            db = new KillRepository(context);
        }

        public void Insert(Kill kill)
        {
            db.Insert(kill);
        }

        public Kill GetById(int id)
        {
            return db.GetById(id);
        }

        public IEnumerable<Kill> GetAll()
        {
            return db.GetAll();
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public void Update(Kill kill)
        {
            db.Update(kill);
        }
    }
}
