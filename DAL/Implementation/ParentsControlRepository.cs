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
    public class ParentsControlRepository : BaseRepository, IParentsControlRepository
    {
        public ParentsControlRepository(CyberTrainingContext context) : base(context)
        { }

        public void Insert(ParentsControl parentsControl)
        {
            db.Entry(parentsControl).State = EntityState.Added;
            db.SaveChanges();
        }

        public IEnumerable<ParentsControl> GetAll()
        {
            return db.ParentsControls
                .Include(user => user.User)
                .Include(kill => kill.Kill)
                .ToList();
        }

        public ParentsControl GetById(int id)
        {
            return db.ParentsControls.FirstOrDefault(x => x.ParentsControlId == id);
        }

        public void Delete(int id)
        {
            ParentsControl parentsControl = GetById(id);
            db.Entry(parentsControl).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public void Update(ParentsControl parentsControl)
        {
            db.Entry(parentsControl).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
