namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class s_Permission_Group
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string GroupName { get; set; }

        public string List_ID_Permission { get; set; }

        public int? ID_SalaryTable { get; set; }

        public byte? Status { get; set; }
    }

	public class PermissionGroup : s_Permission_Group
	{
        public string SalaryTableName { get; set; }
		public byte? SalaryType { get; set; }

		public int? SalaryPerTime { get; set; }
		public List<s_Permission> lstPermission { get; set; }

	}
}
