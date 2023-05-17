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

			string sqlQuery = string.Empty;
			StringBuilder sb = new StringBuilder();
			sb.Append("select pg.*, st.Name as SalaryTableName, st.Type as SalaryType, st.SalaryPerTime as SalaryPerTime ");
			sb.Append("from s_Permission_Group pg left join c_SalaryTable st on st.ID = pg.ID_SalaryTable");
			sb.Append($"where pg.ID = {id}");
			sqlQuery = sb.ToString();
			result = db.Database.SqlQuery<PermissionGroup>(sqlQuery).FirstOrDefault();
			if (result != null)
			{
				string sqlQuery1 = string.Empty;
				StringBuilder sb1 = new StringBuilder();
				sb1.Append("select * from s_Permission where ID in (" + result.List_ID_Permission + ")");
				sqlQuery1 = sb1.ToString();
				List<s_Permission> lstPermission= db.Database.SqlQuery<s_Permission>(sqlQuery1).ToList();
				result.lstPermission = lstPermission;
				return result;
			}
			else
			{
				return null;
			}
		}

		public List<PermissionGroup> getAllPermissionGroup()
		{
			List<PermissionGroup> lstData = new List<PermissionGroup>();
			string sqlQuery = string.Empty;
			StringBuilder sb = new StringBuilder();
			sb.Append("select pg.*, st.Name as SalaryTableName, st.Type as SalaryType, st.SalaryPerTime as SalaryPerTime ");
			sb.Append("from s_Permission_Group pg left join c_SalaryTable st on st.ID = pg.ID_SalaryTable");
			sb.Append($"where pg.Status <> 10");
			sqlQuery = sb.ToString();
			lstData = db.Database.SqlQuery<PermissionGroup>(sqlQuery).ToList();
			return lstData;
		}
	}
}
