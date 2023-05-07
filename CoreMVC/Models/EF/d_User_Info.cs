namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class d_User_Info
    {
        public int ID { get; set; }

        public int ID_Username { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        public byte? Gender { get; set; }

        [StringLength(500)]
        public string Avatar { get; set; }

        public int? ID_PermissionGroup { get; set; }

        [StringLength(100)]
        public string PermanentAddress { get; set; }

        public int? ID_PA_AU_1 { get; set; }

        public int? ID_PA_AU_2 { get; set; }

        public int? ID_PA_AU_3 { get; set; }

        [StringLength(100)]
        public string TemporaryAddress { get; set; }

        public int? ID_TA_AU_1 { get; set; }

        public int? ID_TA_AU_2 { get; set; }

        public int? ID_TA_AU_3 { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        [StringLength(100)]
        public string Instagram { get; set; }

        [StringLength(100)]
        public string Twitter { get; set; }
        public string Tiktok { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? EditedDate { get; set; }
    }

    public class dUserInfo :d_User_Info
    {
		public string Username { get; set; }
        public string Password { get; set; }
        public string PA_AU1_Name { get; set; }
        public string PA_AU2_Name { get; set; }
        public string PA_AU3_Name { get; set; }
        public string TA_AU1_Name { get; set; }
        public string TA_AU2_Name { get; set; }
        public string TA_AU3_Name { get; set; }

	}
}
