using System;
using System.Collections.Generic;
using System.Text;
using BOL;

namespace DAL.Implementation
{
    public class BaseRepository
    {
        protected CyberTrainingContext db;

        public BaseRepository(CyberTrainingContext context)
        {
            db = context;
        }
    }
}
