using System;
using System.Collections.Generic;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using DAL.Implementation;

namespace BLL.Db
{
    public class ParentsControlDb
    {
        private readonly IParentsControlRepository db;

        public ParentsControlDb(CyberTrainingContext context)
        {
            db = new ParentsControlRepository(context);
        }

        public void Insert(ParentsControl parentsControl)
        {
            db.Insert(parentsControl);
        }

        public ParentsControl GetById(int id)
        {
            return db.GetById(id);
        }

        public IEnumerable<ParentsControl> GetAll()
        {
            return db.GetAll();
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public void Update(ParentsControl parentsControl)
        {
            db.Update(parentsControl);
        }
    }
}
