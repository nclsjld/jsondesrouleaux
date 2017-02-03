using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DataManager : MySQLManager<Data>
    {
        public DataManager() : base(DataConnectionResource.LOCALMYSQL)
        {
        }


        public List<Data> GetById(Int32 userId)
        {
            List<Data> datas;
            try
            {

                datas = DbSetT
                .Where(x => x.IdUser == userId).ToList();


            }
            catch (Exception)
            {
                datas = new List<Data>();
            }

            return datas;
        }

        public List<Data> GetByDataId(Int32 dataId, Int32 userId)
        {
            List<Data> datas;
            try
            {

                datas = DbSetT

                .Where(x => x.IdUser == userId)
                .Where(x => x.Id == dataId).ToList();

            }
            catch (Exception)
            {
                datas = new List<Data>();
            }

            return datas;
        }





    }
}
