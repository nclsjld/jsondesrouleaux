using Classes;
using Database;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {

            List<User> listUsers = CallGetAllUsers();

            //On se connecte
            //Connexion();

            Console.WriteLine("Voici la liste des utilistateurs :\n");

            foreach (User item in listUsers)
            {
                Console.WriteLine(item.Id + "\t->\t" + item.Login);
            }


            Console.WriteLine("Entrez l'id d'un utilisateur :\n");
            String idSelected = Console.ReadLine();

            List<Data> datas = GetDataById(Int32.Parse(idSelected));

            foreach (Data item in datas)
            {
                Console.WriteLine(item.DataJson);
            }

            itemChoice(datas);

            Console.ReadLine();



        }

        // GET: User
        private static async Task<List<User>> GetAllUsers()
        {
            MySQLManager<User> manager;
            manager = new MySQLManager<User>(DataConnectionResource.LOCALMYSQL);
            return await manager.Get() as List<User>;
        }


        private static List<User> CallGetAllUsers()
        {
            var task = GetAllUsers();
            task.Wait();
            var result = task.Result;
            return result;
        }

        //Get data
        private static List<Data> GetDataById(Int32 userId)
        {
            DataManager dataManager = new DataManager();

            List<Data> dataById = dataManager.GetById(userId);

            return dataManager.GetById(userId);
        }

        private static void Connexion()
        {
            Console.WriteLine("Your login");
            String login = Console.ReadLine();

            Console.WriteLine("Your password");
            String password = Console.ReadLine();

            UserManager userManager = new UserManager();
            User user = userManager.GetByLogin(login, password);

            if (user.Id != 0)
            {
                Console.WriteLine("Vous êtes connecté en tant que " + user.Login);
            }
            else
            {
                Console.WriteLine("t'as pas de compte batard ou tu t'es trompé enculé");
                Connexion();
            }
        }
        private static void itemChoice(List<Data> datas)
        {
            Console.WriteLine("Entrez un type film ou music :\n");
            String typeSelected = Console.ReadLine();
            if (typeSelected == "music")
            {
                displayJsonByType(datas, 1);
            }
            else if (typeSelected == "film")
            {
                displayJsonByType(datas, 2);
            }
            else
            {
                itemChoice(datas);
            }

        }

        private static void displayJsonByType(List<Data> datas, Int16 typeJson)
        {

            string schemaJson;



            if (typeJson == 1)
            {
                schemaJson = @"{
                  'description': 'A person',
                  'type': 'object',
                  'properties':
                  {
                      'Artist': {'type':'string'},
                      'Id': {'type':'number'},
                      'Title': {'type':'string'},
                      'Album': {'type':'string'},
                      'Bitrate': {'type':'number'}
                    },
                    'additionalProperties': false
                  }
                }";

            }
            else
            {
                schemaJson = @"{
              'description': 'A person',
              'type': 'object',
              'properties':
                    {
                    'Id': {'type':'number'},
                    'Title': {'type':'string'},
                    'Writer': {'type':'string'},
                    'Actors': {'type':'string'},
                    'Date': {'type':'number'},
                    'Language': {'type':'string'},
                    'Type': {'type':'string'}
                }, 
               'additionalProperties': false
            }";
            }



            foreach (Data data in datas)
            {
                JsonSchema schema = JsonSchema.Parse(schemaJson);
                JObject displaydatas = JObject.Parse(@data.DataJson);
                bool valid = displaydatas.IsValid(schema);
             
                if (valid)
                {
                    Console.WriteLine(displaydatas);
                }
            }


        }




    }
}
