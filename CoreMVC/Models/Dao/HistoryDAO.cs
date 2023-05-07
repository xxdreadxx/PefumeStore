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
	public class HistoryDAO
	{
		StoreDbContext db = new StoreDbContext();

		public bool Create(int IDUser, string content, string action, string controller)
		{
			s_History hitem = new s_History();
			hitem.ID_User = IDUser;
			hitem.CreatedDate = DateTime.Now;
			hitem.Content = content;
			hitem.Action = action;
			hitem.Controller = controller;
			db.s_History.Add(hitem);
			return true;
		}
	}
}
