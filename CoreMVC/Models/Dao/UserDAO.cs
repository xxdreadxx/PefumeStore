using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
    public class UserDAO
    {
        StoreDbContext db = new StoreDbContext();
        public byte Login(string username, string password)
        {
            d_Login_Info item = db.d_Login_Info.FirstOrDefault(x => x.Username == username && x.Password == password);
            if(item == null)
			{
                //0: username hoặc password không đúng
                return 0;
            }
			else
			{
                return (byte)item.Status;
			}
        }
    }
}
