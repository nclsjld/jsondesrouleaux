using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class User
    {
        private int id;
        private String firstname;
        private String lastname;
        private String login; // firstname + lastname
        private String password;
        private int idRole;
        private ICollection<Role> roles;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public String Login
        {
            get { return login; }
            set { login = firstname + lastname; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public int IdRole
        {
            get { return idRole; }
            set { idRole = value; }
        }

        public ICollection<Role> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public User()
        {
            this.roles = new HashSet<Role>();
        }
    }
}