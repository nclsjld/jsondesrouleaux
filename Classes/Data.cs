using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    #region Data

    [Table("data")]
    public class Data
    {
        private int id;
        private String dataJson;
        private int idUser;

        [Column("idUser")]
        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; }
        }



        [Key]
        [Column("id")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column("dataJson")]
        public String DataJson
        {
            get { return dataJson; }
            set { dataJson = value; }
        }
        
    }
    #endregion
}
