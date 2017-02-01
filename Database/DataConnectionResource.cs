using System;

namespace Database
{
    public enum DataConnectionResource
    {
        [StringValue("Server=127.0.0.1;Port=3306;Database=jsondesrouleaux;Uid=root;Pwd=''")]
        LOCALMYSQL = 1,
        //[StringValue("http://localhost:54299/api/")]
        //LOCALAPI = 2
    }
}
