using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss
{
    public class User
    {
        private string id;
        private string name;
        private string password;
        private string role;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public User(string name, string password, string role, string id)
        {
            this.name = name;
            this.password = password;
            this.role = role;
            this.id = id;
        }
    }
}
