using System;
using System.Collections.Generic;
using System.Text;
using BOL;
using BOL.Models;
using DAL.Abstract;
using DAL.Implementation;

namespace BLL.Db
{
    public class RoleDb
    {
        private readonly IRoleRepository db;

        public RoleDb(CyberTrainingContext context)
        {
            db = new RoleRepository(context);
        }

        public void Insert(Role role)
        {
            db.Insert(role);
        }

        public Role GetById(int id)
        {
            return db.GetById(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return db.GetAll();
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public void Update(Role role)
        {
            db.Update(role);
        }
    }
}
