using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Table("role")]
    public class Role
    {
        private int id;
        private String name;
        private ICollection<User> users;

        [Key]
        [Column("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("name")]
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        [Column("users")]
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
