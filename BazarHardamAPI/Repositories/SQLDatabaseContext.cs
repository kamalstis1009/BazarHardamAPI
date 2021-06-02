using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazarHardamAPI.Repositories
{
    public class SQLDatabaseContext
    {
        //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 for github
        private static SQLDatabaseContext _instance;

        private SQLDatabaseContext()
        {
            GetDatabaseInstance();
        }
        public static SQLDatabaseContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SQLDatabaseContext();
                }
                return _instance;
            }
        }

        public BazarHardamEntities GetDatabaseInstance()
        {
            return new BazarHardamEntities();
        }
    }
}