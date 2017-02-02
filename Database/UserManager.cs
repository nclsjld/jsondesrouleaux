using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
   
        public class UserManager : MySQLManager<User>
        {
            public UserManager() : base(DataConnectionResource.LOCALMYSQL)
            {
            }

            public User GetByLogin(string login, string password)
            {
                User user;
            Console.WriteLine(login + password);
                try
                {
                    user = DbSetT
                        .Where(x => x.Login == login)
                        .Where(x => x.Password == password)
                        .First();
                    // Entry(user).Collection(x => x.Roles).Load();
                }
                catch (Exception)
                {
                    user = new User();
                }

                return user;
            }
        }
    
}
