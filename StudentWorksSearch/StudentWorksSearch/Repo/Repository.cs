using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentWorksSearch.Repo;

namespace StudentWorksSearch
{
    class Repository
    {
        private static UserData user;
        public static UserData User
        {
            get { return user; }
            set { user = value; }
        }

        private static bool edit; //false - регистрация, true - редактирование
        public static bool Edit
        {
            get { return edit; }
            set { edit = value; }
        }
    }
}
