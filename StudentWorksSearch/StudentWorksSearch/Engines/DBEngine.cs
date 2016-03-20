using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudentWorksSearch.Engines
{
    class DBEngine
    {
        SearchWorkEntities db = new SearchWorkEntities();

        public DBEngine()
        {
        }

        public List<string> GetUni()
        {
                var query =
                      from UNI in db.University
                      select UNI.Short_name;

                List<string> UNIList = new List<string>();
                return UNIList = query.Select(a => a).ToList();
        }

        public List<string> GetDis()
        {
            var query =
                      from DIS in db.Discipline
                      select DIS.Name;

            List<string> DISList = new List<string>();
            return DISList = query.Select(a => a).ToList();
        }

    }
}
