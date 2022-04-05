using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DbConnection
    {
        public static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["DBContext"];
                //return EncryptAndDecrypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["DBContext"], true);
            }
        }

        public static string ConnectionStringLocal
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["DBContextLocal"];
                //return EncryptAndDecrypt.Decrypt(System.Configuration.ConfigurationManager.AppSettings["DBContext"], true);
            }
        }

    }
}
