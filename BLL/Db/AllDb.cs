using System;
using System.Collections.Generic;
using System.Text;
using BOL;

namespace BLL.Db
{
    public class AllDb
    {
        public GameDb GameDb { get; set; }

        public GenreDb GenreDb { get; set; }

        public RoleDb RoleDb { get; set; }

        public TeamDb TeamDb { get; set; }

        public UserDb UserDb { get; set; }

        public ConditionDb ConditionDb { get; set; }

        public AllDb(CyberTrainingContext context)
        {
            GameDb = new GameDb(context);
            GenreDb = new GenreDb(context);
            RoleDb = new RoleDb(context);
            TeamDb = new TeamDb(context);
            UserDb = new UserDb(context);
            ConditionDb = new ConditionDb(context);
        }
    }
}
