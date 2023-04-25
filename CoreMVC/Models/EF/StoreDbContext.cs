using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class StoreDbContext : DbContext
    {
        public StoreDbContext()
            : base("name=StoreDbContext")
        {
        }

        public virtual DbSet<c_Branch> c_Branch { get; set; }
        public virtual DbSet<c_Cource_Logistic> c_Cource_Logistic { get; set; }
        public virtual DbSet<c_News_Type> c_News_Type { get; set; }
        public virtual DbSet<c_SalaryTable> c_SalaryTable { get; set; }
        public virtual DbSet<c_Size> c_Size { get; set; }
        public virtual DbSet<c_Smell_Group> c_Smell_Group { get; set; }
        public virtual DbSet<c_Type_Perfume> c_Type_Perfume { get; set; }
        public virtual DbSet<d_AdministrativeUnit> d_AdministrativeUnit { get; set; }
        public virtual DbSet<d_Agency> d_Agency { get; set; }
        public virtual DbSet<d_Bill> d_Bill { get; set; }
        public virtual DbSet<d_Bill_Buy> d_Bill_Buy { get; set; }
        public virtual DbSet<d_Bill_Buy_Info> d_Bill_Buy_Info { get; set; }
        public virtual DbSet<d_Bill_Info> d_Bill_Info { get; set; }
        public virtual DbSet<d_Login_Info> d_Login_Info { get; set; }
        public virtual DbSet<d_News> d_News { get; set; }
        public virtual DbSet<d_Product> d_Product { get; set; }
        public virtual DbSet<d_Product_Image> d_Product_Image { get; set; }
        public virtual DbSet<d_Product_Size_Price> d_Product_Size_Price { get; set; }
        public virtual DbSet<d_User_Info> d_User_Info { get; set; }
        public virtual DbSet<d_Voucher> d_Voucher { get; set; }
        public virtual DbSet<s_History> s_History { get; set; }
        public virtual DbSet<s_Permission> s_Permission { get; set; }
        public virtual DbSet<s_Permission_Group> s_Permission_Group { get; set; }
        public virtual DbSet<s_Report> s_Report { get; set; }
        public virtual DbSet<s_Slide> s_Slide { get; set; }
        public virtual DbSet<s_Store_Info> s_Store_Info { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
