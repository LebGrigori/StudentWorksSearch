using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StudentWorksSearch.Repo;

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

                db.Users.Add(new Users
                {
                    Login = _username,
                    Password = _password,
                    Name = Name,
                    Registration = DateTime.Now,
                    University = Uni,
                    E_mail = Mail
                    
                });
                db.SaveChanges();
                result = true;
            }
            else
                result = false;
        }

        public void GetUserData()
        {
            var query =
                      from USER in db.Users
                      where USER.Login == _username
                      select new { USER.Login, USER.E_mail, USER.Registration, USER.Name, USER.University };

            foreach (var user in query)
            {
                Repository.User = new UserData(user.Login, user.E_mail, user.Name, user.Registration, user.University);
            }
        }

        public void UpdUserData(string Mail, string Name, string Uni, string Fac)
        {
            var query =
                      from USER in db.Users
                      where USER.Login == Repository.User.Login
                      select USER;

            foreach (Users user in query)
            {
                user.E_mail = Mail;
                user.Name = Name;
                user.University = Uni;
            }

            db.SaveChanges();
            GetUserData();
        }

    }
}
