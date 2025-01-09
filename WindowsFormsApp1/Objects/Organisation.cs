using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objects
{
    internal class Organisation
    {
        private int _id;
        private string _name;
        private string _creationDate;
        private string _description;
        private int _permissionLevel;

        public Organisation(int id, string name, string creationDate, string description, int permission)
        {
            _id = id;
            _name = name;
            _creationDate = creationDate;
            _description = description;
            _permissionLevel = permission;
        }

        public int Id { get { return _id; } set { this._id = value; } }
        public string Name { get { return _name; } set { this._name = value; } }
        public string CreationDate { get { return _creationDate; } set { this._creationDate = value; } }
        public string Description { get { return _description; } set { this._description = value; } }
        public int PermissionLevel { get { return _permissionLevel; } set { this._permissionLevel = value; } }


        public override string ToString()
        {
            return Name;
        }

    }
}
