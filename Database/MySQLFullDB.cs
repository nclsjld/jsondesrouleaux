using Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        //public DbSet<Class1> DbSetClass1 { get; set; }
        //public DbSet<Class2> DbSetClass2 { get; set; }

        //public DbSet<ClassA> DbSetClassA { get; set; }
        //public DbSet<ClassB> DbSetClassB { get; set; }
        //public DbSet<ClassC> DbSetClassC { get; set; }
        //public DbSet<ClassD> DbSetClassD { get; set; }
        public DbSet<Data> DbSetData { get; set; }
        public DbSet<User> DbSetUser { get; set; }
        public DbSet<Role> DbSetRole { get; set; }

        public MySQLFullDB(DataConnectionResource dataConnectionResource)
            : base(EnumString.GetStringValue(dataConnectionResource))
        {
            if (dataConnectionResource == DataConnectionResource.LOCALMYSQL)
            {
                    InitLocalMySQL();
            }
        }

        public void InitLocalMySQL()
        {

            if (this.Database.CreateIfNotExists())
            {
                //Setup base datas to load
                /*for (int j = 0; j < 20; j++)
                {
                    Role r1 = new Role();

                    r1.Name = "Admin";
                    MySQLManager<Role> managerRole = new MySQLManager<Role>(DataConnectionResource.LOCALMYSQL);
                    managerRole.Insert(r1);

                    //EntityGenerator<Class2> generatorClass2 = new EntityGenerator<Class2>();
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    c1.Addresses.Add(generatorClass2.GenerateItem());
                    //}

                    //MySQLManager<Class1> managerClass1 = new MySQLManager<Class1>(DataConnectionResource.LOCALMYSQL);
                    //managerClass1.Insert(c1);


                    //ClassD d1 = new ClassD();
                    //EntityGenerator<ClassD> generatorClassD = new EntityGenerator<ClassD>();
                    //d1 = generatorClassD.GenerateItem();

                    //MySQLManager<ClassD> managerClassD = new MySQLManager<ClassD>(DataConnectionResource.LOCALMYSQL);
                    //managerClassD.Insert(d1);
                }*/
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Role>(s => s.Roles)
                .WithMany(c => c.Users)
                .Map(cs =>
                {
                    cs.MapLeftKey("User_UserId");
                    cs.MapRightKey("Role_RoleId");
                    cs.ToTable("roleusers");
                });
        }
    }
}