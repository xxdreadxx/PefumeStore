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
    public class UserDAO
    {
        StoreDbContext db = new StoreDbContext();
        HistoryDAO hisDao = new HistoryDAO();
        public byte Login(string username, string password)
        {
            d_Login_Info item = db.d_Login_Info.FirstOrDefault(x => x.Username == username && x.Password == password);
            if(item == null)
            {
                return 0;
            }
            else
            {
                return (byte)item.Status;
			}
        }

        public string changePassword(string username, string oldPass, string newPass, ref bool ActionStatus)
        {
			ActionStatus = true;
			string mess = "";
            List<d_Login_Info> lstitem = db.d_Login_Info.Where(x => x.Username == username && x.Status == 1).ToList();
            if(lstitem.Count > 0 )
            {
                lstitem=lstitem.Where(x=>x.Password==oldPass).ToList();
                if(lstitem.Count > 0 )
                {
                    if(lstitem.Count > 1 )
                    {
						ActionStatus = false;
						mess = "Tồn tại hơn 1 tài khoản trùng với thông tin bạn nhập, liên hệ admin để được giải quyết";
					}
                    else
                    {
						d_Login_Info item=db.d_Login_Info.FirstOrDefault(x=>x.Username == username && x.Password== oldPass && x.Status == 1);
                        item.Password = newPass;
                        db.SaveChanges();
						mess = "Cập nhật mật khẩu thành công!";
						string content = "Cập nhật mật khẩu username " + item.Username + " từ " + oldPass + " sang " + newPass;
						ActionStatus = hisDao.Create(item.ID, content, "Update", "UserInfo");
					}
                }
                else
                {
					ActionStatus = false;
					mess = "Mật khẩu nhập không chính xác, vui lòng thử lại";
				}
            }
            else
            {
				ActionStatus = false;
				mess = "Tên đăng nhập không tồn tại trong hệ thống hoặc đã bị vô hiệu hóa! Liên hệ admin để được giải quyết";
            }
			return mess;
        }

        public string changeStatus(int ID, byte status, ref bool ActionStatus)
        {
            string mess = "";
			d_Login_Info item = db.d_Login_Info.FirstOrDefault(x => x.ID == ID);
            if(item!=null)
            {
                item.Status = status;
                db.SaveChanges();
				mess = "Cập nhật trạng thái thành công!";
                string content = "Cập nhật trạng thái username " + item.Username + " sang " + status.ToString();
				ActionStatus = hisDao.Create(ID, content, "Update", "UserInfo");
			}
            else
            {
				ActionStatus = false;
				mess = "Không tìm thấy tài khoản, vui lòng thao tác lại hoặc báo cáo admin để được giải quyết!";
            }
            return mess;
        }

        public d_User_Info getData(int ID)
        {
            return db.d_User_Info.FirstOrDefault(x=>x.ID == ID);
        }
		public dUserInfo getDataUser(int ID)
		{
            dUserInfo result= new dUserInfo();
            string sqlQuery = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("select lg.Username, lg.Password, ui.ID, ui.ID_Username, ui.Name, ui.DateOfBirth, ui.Gender, ui.Avatar, ui.ID_PermissionGroup, ui.PermanentAddress, ui.ID_PA_AU_1, ui.ID_PA_AU_2, ui.ID_PA_AU_3, ui.TemporaryAddress, ui.ID_TA_AU_1, ui.ID_TA_AU_1, ui.ID_TA_AU_2, ui.ID_TA_AU_3, ui.Phone, ui.Email, ui.Facebook, ui.Instagram, ui.Twitter,ui.Tiktok, ui.CreatedDate, ui.EditedDate ");
            sb.Append("from d_Login_Info lg join d_User_Info ui on ui.ID_Username = lg.ID");
            sb.Append($"where lg.id = {ID}");
            sqlQuery = sb.ToString();
            result = db.Database.SqlQuery<dUserInfo>(sqlQuery).FirstOrDefault();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }
		}

		public List<dUserInfo> getAllDataUser(int page, int pageSize, ref int totalCount)
		{
			List<dUserInfo> result = new List<dUserInfo>();
			string sqlQuery = string.Empty;
			StringBuilder sb = new StringBuilder();
			sb.Append("select lg.Username, lg.Password, ui.ID, ui.ID_Username, ui.Name, ui.DateOfBirth, ui.Gender, ui.Avatar, ui.ID_PermissionGroup, " +
                "ui.PermanentAddress, ui.ID_PA_AU_1, ui.ID_PA_AU_2, ui.ID_PA_AU_3, ui.TemporaryAddress, ui.ID_TA_AU_1, ui.ID_TA_AU_1, ui.ID_TA_AU_2, ui.ID_TA_AU_3, " +
				"au1.Name as PA_AU1_Name, au2.Name as PA_AU2_Name, au3.Name as PA_AU3_Name, au4.Name as TA_AU1_Name, au5.Name as TA_AU2_Name, au6.Name as TA_AU3_Name, " +
                "ui.Phone, ui.Email, ui.Facebook, ui.Instagram, ui.Twitter,ui.Tiktok, ui.CreatedDate, ui.EditedDate ");
			sb.Append("from d_Login_Info lg join d_User_Info ui on ui.ID_Username = lg.ID " +
				"left join d_AdministrativeUnit au1 on au1.Level = 1 and au1.ID = ID_PA_AU_1 " +
                "left join d_AdministrativeUnit au2 on au1.Level = 2 and au2.ID = ID_PA_AU_2 " +
                "left join d_AdministrativeUnit au3 on au1.Level = 3 and au3.ID = ID_PA_AU_3 " +
                "left join d_AdministrativeUnit au4 on au1.Level = 1 and au4.ID = ID_TA_AU_1 " +
                "left join d_AdministrativeUnit au5 on au1.Level = 2 and au5.ID = ID_TA_AU_2 " +
                "left join d_AdministrativeUnit au6 on au1.Level = 3 and au6.ID = ID_TA_AU_3 ");
			sb.Append($"where lg.Status <> 10");
			sqlQuery = sb.ToString();
			result = db.Database.SqlQuery<dUserInfo>(sqlQuery).ToList();
			if (result != null)
			{
				return result;
			}
			else
			{
				return null;
			}
		}

		public string ChangeInfo(int ID, d_User_Info item, ref bool ActionStatus)
        {
            ActionStatus = true;

			string mess = "";
            d_User_Info result = db.d_User_Info.FirstOrDefault(x => x.ID == ID);
            if (result != null)
            {
                mess = "Cập nhật thông tin thành công";
                ActionStatus = hisDao.Create(result.ID_Username, "Cập nhật thông tin tài khoản", "Update", "UserInfo");
			}
            else
            {
                mess = "Không tồn tại bản ghi, vui lòng thử lại";
                ActionStatus = false;
			}
            return mess;
		}
	}
}
