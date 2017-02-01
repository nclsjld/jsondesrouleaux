using System;
using System.Data.Entity;
using Database;
using Classes;

namespace MotorsportAcademy.Database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class FullDb : DbContext
    {
        public DbSet<Role> dbsetrole { get; set; }
        //public dbset<bill> dbsetbill { get; set; }
        //public dbset<car> dbsetcar { get; set; }
        //public dbset<carbrand> dbsetcarbrand { get; set; }
        //public dbset<centre> dbsetcentre { get; set; }
        //public dbset<circuit> dbsetcircuit { get; set; }
        //public dbset<city> dbsetcity { get; set; }
        //public dbset<country> dbsetcountry { get; set; }
        //public dbset<customer> dbsetcustomer { get; set; }
        //public dbset<employee> dbsetemployee { get; set; }
        //public dbset<franchise> dbsetfranchise { get; set; }
        //public dbset<provider> dbsetprovider { get; set; }
        //public dbset<region> dbsetregion { get; set; }
        //public dbset<reservation> dbsetreservation { get; set; }

        public FullDb(DataConnectionResource dataConnectionResource)
            : base(EnumString.GetStringValue(dataConnectionResource))
        {
            this.Database.CreateIfNotExists();
        }
    }
}
