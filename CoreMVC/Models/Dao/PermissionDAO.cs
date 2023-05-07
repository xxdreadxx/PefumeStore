using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
	public class PermissionDAO
	{
		StoreDbContext db = new StoreDbContext();

		public PermissionGroup getPermissionGroupByIDUser (int id)
		{
			PermissionGroup result = new PermissionGroup();



			return result;

		}
	}
}
