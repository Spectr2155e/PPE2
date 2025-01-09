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
        private int _id;
        private string _mail;
        private string _password;
        private int _organisation;
        private string _lastConnection;
        private string _creationDate;
        private int _keyToChangePassword;


        public User(string mail, string password, int organisation)
        {
            _mail = mail;
            _password = password;
            _organisation = organisation;
        }

        public User(int id, string mail, string password, int organisation, string lastConnection, string creationDate)
        {
            _id = id;
            _mail = mail;
            _password = password;
            _organisation = organisation;
            _lastConnection = lastConnection;
            _creationDate = creationDate;
        }

        public string Mail { get { return _mail; } set { this._mail = value; } }
        public string Password { get { return _password; } set { this._password = value; } }
        public int Organisation { get { return _organisation; } set { this._organisation = value; } }
        public string LastConnection { get { return _lastConnection; } set { this._lastConnection = value; } }
        public string CreationDate { get { return _creationDate; } set { this._creationDate = value; } }
        public int Id { get { return _id; } set { this._id = value; } }
        public int keyToChangePassword { get { return _keyToChangePassword; } set { this._keyToChangePassword = value; } }

        public override string ToString()
        {
            int index = Mail.LastIndexOf("@");
            if(index > 0)
            {
                string str = Mail.Substring(0, index);
                return str;
            } else
            {
                return "";
            }
        }

    }
}
