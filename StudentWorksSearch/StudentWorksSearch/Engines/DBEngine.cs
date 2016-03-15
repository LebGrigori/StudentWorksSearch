using System;
using System.Collections.Generic;
using System.Data;
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

        public void GetUserData(string username, out string UserData)
        {
            UserData = "";
            var query =
                      from USER in db.Users
                      where USER.Login == username
                      select new { USER.Login, USER.E_mail, USER.Registration, USER.Name, USER.University };

            foreach (var user in query)
            {
                UserData = user.ToString();
            }
            UserData = UserData.Trim('{', '}');
            UserData = UserData.Replace(",", "\n");
        }

    }
}
