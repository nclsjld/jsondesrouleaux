using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Table("user")]
    public class User
    {
        private int id;
        private String firstname;
        private String lastname;
        private String login; // firstname + lastname
        private String password;
        private int idRole;
        private ICollection<Role> roles;


        [Key]
        [Column("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("firstname")]
        public String Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        [Column("lastname")]
        public String Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        [Column("login")]
        public String Login
        {
            get { return login; }
            set { login = firstname + lastname; }
        }

        [Column("password")]
        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        [Column("idRole")]
        public int IdRole
        {
            get { return idRole; }
            set { idRole = value; }
        }

        [Column("roles")]
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