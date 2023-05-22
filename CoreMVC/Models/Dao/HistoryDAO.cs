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
		public List<s_History> getlstData(DateTime fromDate, DateTime toDate, int IDUser, string Action, string Controller)
		{
			List<s_History> lstData = new List<s_History>();
			lstData = db.s_History.Where(x => x.CreatedDate >= fromDate && x.CreatedDate <= toDate).OrderByDescending(x => x.ID).ToList();
			if(IDUser != 0)
			{
				lstData = lstData.Where(x => x.ID_User == IDUser).OrderByDescending(x => x.ID).ToList();
			}
			if (Action != "")
			{
				lstData = lstData.Where(x => x.Action == Action).OrderByDescending(x => x.ID).ToList();
			}
			if (Controller != "")
			{
				lstData = lstData.Where(x => x.Controller == Controller).OrderByDescending(x => x.ID).ToList();
			}
			return lstData;
		}
	}
}