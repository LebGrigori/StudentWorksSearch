using System;
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

        public static String Hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

    }
}
