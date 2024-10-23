using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objects
{
    internal class User
    {
        private string _mail;
        private string _password;
        private string _organisation;

        public User(string mail, string password, string organisation)
        {
            _mail = mail;
            _password = password;
            _organisation = organisation;
        }

        public string Mail { get { return _mail; } set { this._mail = value; } }
        public string Password { get { return _password; } set { this._organisation = value; } }
        public string Organisation { get { return _organisation; } set { this._organisation = value; } }

    }
}
