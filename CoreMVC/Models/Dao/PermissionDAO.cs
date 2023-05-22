using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
	public class PermissionDAO
	{
		StoreDbContext db = new StoreDbContext();
		HistoryDAO hisDao = new HistoryDAO();

		public PermissionGroup getPermissionByIDUser (int ID)
		{
			PermissionGroup result = new PermissionGroup();

			string sqlQuery = string.Empty;
			StringBuilder sb = new StringBuilder();
			sb.Append("select pg.*, st.Name as SalaryTableName, st.Type as SalaryType, st.SalaryPerTime as SalaryPerTime ");
			sb.Append("from s_Permission_Group pg left join c_SalaryTable st on st.ID = pg.ID_SalaryTable");
			sb.Append($"where pg.ID = {ID}");
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

		public PermissionGroup GetPermissionGroupByID(int ID)
		{
			PermissionGroup result = new PermissionGroup();
			string sqlQuery = string.Empty;
			StringBuilder sb = new StringBuilder();
			sb.Append("select pg.*, st.Name as SalaryTableName, st.Type as SalaryType, st.SalaryPerTime as SalaryPerTime ");
			sb.Append("from s_Permission_Group pg left join c_SalaryTable st on st.ID = pg.ID_SalaryTable");
			sb.Append($"where pg.Status <> 10 and pg.ID = {ID}");
			sqlQuery = sb.ToString();
			result = db.Database.SqlQuery<PermissionGroup>(sqlQuery).FirstOrDefault();
			if (result != null)
			{
				string sqlQuery1 = string.Empty;
				StringBuilder sb1 = new StringBuilder();
				sb1.Append("select * from s_Permission where ID in (" + result.List_ID_Permission + ")");
				sqlQuery1 = sb1.ToString();
				List<s_Permission> lstPermission = db.Database.SqlQuery<s_Permission>(sqlQuery1).ToList();
				result.lstPermission = lstPermission;
			}
			else
			{
				result.lstPermission = null;
			}
			return result; ;
		}

		public bool SaveData(s_Permission_Group item, ref string mess)
		{
			bool ActionStatus = true;
			if (item != null)
			{
				if(item.ID == 0)
				{
					db.s_Permission_Group.Add(item);
					db.SaveChanges();
				}
				else
				{
					var res=db.s_Permission_Group.FirstOrDefault(x=>x.ID == item.ID);
					if(res != null)
					{
						try
						{
							res.ID_SalaryTable = item.ID_SalaryTable;
							res.List_ID_Permission = item.List_ID_Permission;
							res.Status = item.Status;
							res.GroupName = item.GroupName;
							db.SaveChanges();
							mess = "Cập nhật thông tin nhóm quyền thành công";
							string content = "Cập nhật thông tin nhóm quyền " + item.GroupName + "";
							ActionStatus = hisDao.Create(0, content, "Update", "PermissionGroup");
						}
						catch (Exception ex)
						{
							mess = "Thao tác cập nhật thông tin nhóm quyền không thành công";
							ActionStatus = false;
						}
					}
					else
					{
						ActionStatus = false;
						mess = "Không tìm thấy nhóm quyền theo yêu cầu, vui lòng thử lại hoặc báo cáo với quản lý!";
					}
				}
			}
			return ActionStatus;
		}

		public bool ChangeStatus(int ID, byte Status, ref string mess) 
		{
			bool ActionStatus = true;
			var res = db.s_Permission_Group.FirstOrDefault(x => x.ID == ID);
			if (res != null)
			{
				try
				{
					res.Status = Status;
					db.SaveChanges();
					mess = "Cập nhật trạng thái nhóm quyền thành công";
					string content = "Cập nhật trạng thái nhóm quyền " + res.GroupName + " sang " + Status;
					ActionStatus = hisDao.Create(0, content, "ChangeStatus", "PermissionGroup");
				}
				catch (Exception ex)
				{
					mess = "Thao tác cập nhật trạng thái nhóm quyền không thành công";
					ActionStatus = false;
				}
			}
			else
			{
				ActionStatus = false;
				mess = "Không tìm thấy nhóm quyền theo yêu cầu, vui lòng thử lại hoặc báo cáo với quản lý!";
			}
			return ActionStatus;
		}
	}
}