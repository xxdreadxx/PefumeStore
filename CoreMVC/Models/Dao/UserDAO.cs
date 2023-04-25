using System;
using System.Collections.Generic;
using System.Linq;
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
            //d_Login_Info item=db.FirstOrDefault()
            return 0;
        }
    }
}
