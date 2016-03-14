using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                var query =
                      from UNI in db.University
                      select UNI.Short_name;

                List<string> UNIList = new List<string>();
                return UNIList = query.Select(a => a).ToList();
            }
            catch
            {
                throw;
            }
        }

        public void GetFac()
        {

        }

    }
}
