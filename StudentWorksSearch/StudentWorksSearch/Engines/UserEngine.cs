using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudentWorksSearch
{
    class UserEngine
    {
        SearchWorkEntities db = new SearchWorkEntities();

        string _username;
        string _password;

        public UserEngine(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public bool LogInCheck()
        {
            try
            {
                var query =
                      from USER in db.Users
                      where USER.Login == _username
                      select USER.Password;

                List<string> USERPass = new List<string>();
                USERPass = query.Select(a => a).ToList();

                if (USERPass[0] == _password)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public void AddUser(string Mail, string Name, string Uni, string Fac, out bool result)
        {
            var query =
                      from USER in db.Users
                      select USER.Login;
            List<string> USERLogIn = new List<string>();
            USERLogIn = query.Select(a => a).ToList();

            if (!USERLogIn.Contains(_username))
            {
                if (Uni == "")
                {
                    Uni = null;
                }
                //Вставить после обновления БД(сделать Name NULLable)
                //if (Name == "")
                //{
                //    Name = null;
                //}
                if (Fac == "")
                {
                    Fac = null;
                }

                db.Users.Add(new Users
                {
                    Login = _username,
                    Password = _password,
                    Name = Name,
                    Registration = DateTime.Now,
                    University = Uni,
                    E_mail = Mail
                    //Здесь будет добавление факультета
                });
                db.SaveChanges();
                result = true;
            }
            else
                result = false;
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
