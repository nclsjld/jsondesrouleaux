using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Role
    {
        private int id;
        private String name;
        private ICollection<User> users;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public ICollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        public Role()
        {
            this.users = new HashSet<User>();
        }
    }
}
