using Microsoft.AspNetCore.Mvc;
using Models;
using Models.EF;
using Models.Dao;
using System.Text;
using System.Security.Cryptography;

namespace CoreMVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		UserDAO userDAO = new UserDAO();
		public ActionResult Index()
		{

			return View();
		}

		public ActionResult Login()
		{
			return View();
		}

		//[HttpPost]
		public JsonResult DangNhap(string username, string password)
		{
			bool status = true;
			string mess = "";
			byte TrangThaiUser = userDAO.Login(username, password);
			if (TrangThaiUser == 0)
			{
				status = false;
				mess = "Tài khoàn đăng nhập hoặc mật khẩu khong đúng, vui lòng thử lại!";
			}
			else if (TrangThaiUser == 1)
			{
				mess = "Đăng nhập thành công!";
			}

			var data = new { status = status, mess = mess };

			var result = new JsonResult(data);
			result.StatusCode = 200;
			result.ContentType = "application/json";
			return result;
		}

		public static string MD5Hash(string input)
		{
			StringBuilder hash = new StringBuilder();
			MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
			byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

			for (int i = 0; i < bytes.Length; i++)
			{
				hash.Append(bytes[i].ToString("x2"));
			}
			return hash.ToString();
		}
	}
}
