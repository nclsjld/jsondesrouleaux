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
            Int32 userId = Connexion();

            Console.WriteLine("Voici la liste des utilistateurs :\n");

            foreach (User item in listUsers)
            {
                Console.WriteLine(item.Id + "\t->\t" + item.Login);
            }

            Console.WriteLine("Entrez l'id d'un utilisateur :\n");
            String idSelected = Console.ReadLine();

            List<Data> datas = GetDataByIdUser(Int32.Parse(idSelected));

            foreach (Data item in datas)
            {
                Console.WriteLine(item.DataJson);
            }


            userMenu(datas, true, userId);
            Console.ReadLine();




        }

        private static void userMenu(List<Data> datas, Boolean exit, Int32 userId)
        {
            Console.Clear();

            while (exit)
            {
                Console.WriteLine("################################################");
                Console.WriteLine("Que souhaitez-vous faire ? :");
                Console.WriteLine("1 -> afficher et trier par type (music ou film):");
                Console.WriteLine("2 -> ajouter une valeur dans un Json :");
                Console.WriteLine("3 -> supprimer  une valeur dans un Json :");
                Console.WriteLine("4 -> modifier une valeur dans un Json :");
                Console.WriteLine("exit -> sortir du programme :");
                Console.WriteLine("################################################");

                String userMenuInput = Console.ReadLine();

                switch (userMenuInput)
                {
                    case "1":
                        itemChoice(datas);
                        break;
                    case "2":
                        addJson(datas, userId);
                        break;
                    case "3":
                        deleteJson(datas, userId);
                        break;
                    case "4":
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Apprend à écrire batard ! c'est pas comme si tu avais beaucoup le choix");
                        break;
                }
                Console.ReadLine();
                userMenu(datas, true, userId);
            }
        }

        private static async void deleteJson(List<Data> datas, int userId)
        {
            String dataJsonOutput = "";
            Data dataJsonElement = new Data();


            foreach (Data item in datas)
            {
                Console.WriteLine(item.Id + " -> " + item.DataJson);
            }

            Console.WriteLine("Selectionnez un Json à supprimer");
            String userInput = Console.ReadLine();

            Int32 intuserInput = Int32.Parse(userInput);
            /*
            Console.WriteLine("Entrez une clé");
            String keyInput = Console.ReadLine();

            List<Data> datasById = GetByDataId(intuserInput, userId);
            foreach (Data item in datasById)
            {

                dataJsonElement = item;

                dataJsonOutput = item.DataJson.Substring(0, item.DataJson.Length - 1);


            }

            dataJsonOutput += ", '" + keyInput + "': '" + valueInput + "' } ";
            dataJsonElement.DataJson = dataJsonOutput;
            //attention les datas arrivent avec amour <3
            MySQLManager<Data> managerData = new MySQLManager<Data>(DataConnectionResource.LOCALMYSQL);
            await managerData.Update(dataJsonElement);

            Console.WriteLine("Votre clé " + keyInput + " et votre valeur " + valueInput + " ont bien été ajoutées : \n" + dataJsonElement.DataJson);*/
            Console.WriteLine("Appuyez pour continuer");
        }

        //Get data by users
        private static List<Data> GetByDataId(Int32 dataId, Int32 userId)
        {
            DataManager dataManager = new DataManager();

            List<Data> dataById = dataManager.GetByDataId(dataId, userId);
            return dataById;
        }

        private static async void addJson(List<Data> datas, Int32 userId)
        {
            String dataJsonOutput = "";
            Data dataJsonElement = new Data();


            foreach (Data item in datas)
            {
                Console.WriteLine(item.Id + " -> " + item.DataJson);
            }

            Console.WriteLine("Selectionnez un Json");
            String userInput = Console.ReadLine();

            Int32 intuserInput = Int32.Parse(userInput);



            Console.WriteLine("Entrez une clé");
            String keyInput = Console.ReadLine();
            Console.WriteLine("Entrez une valeur");
            String valueInput = Console.ReadLine();

            List<Data> datasById = GetByDataId(intuserInput, userId);
            foreach (Data item in datasById)
            {
                
                dataJsonElement = item;

                dataJsonOutput = item.DataJson.Substring(0, item.DataJson.Length - 1);
               

            }

            dataJsonOutput += ", '" + keyInput + "': '" + valueInput + "' } ";
            dataJsonElement.DataJson = dataJsonOutput;
            //attention les datas arrivent avec amour <3
            MySQLManager<Data> managerData = new MySQLManager<Data>(DataConnectionResource.LOCALMYSQL);
            await managerData.Update(dataJsonElement);

            Console.WriteLine("Votre clé " + keyInput + " et votre valeur " + valueInput + " ont bien été ajoutées : \n" + dataJsonElement.DataJson);
            Console.WriteLine("Appuyez pour continuer");
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
        private static List<Data> GetDataByIdUser(Int32 userId)
        {
            DataManager dataManager = new DataManager();

            List<Data> dataById = dataManager.GetById(userId);

            return dataManager.GetById(userId);
        }

        private static Int32 Connexion()
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
                return user.Id;
            }
            else
            {
                Console.WriteLine("t'as pas de compte batard ou tu t'es trompé enculé");
                Connexion();
                return 0;
                
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
