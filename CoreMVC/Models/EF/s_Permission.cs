namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class s_Permission
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string ShowName { get; set; }

        [StringLength(100)]
        public string ControllerName { get; set; }

        [StringLength(100)]
        public string ActionName { get; set; }

        public int? ID_Parent { get; set; }

        public int? LevelPermission { get; set; }

        public int? Location { get; set; }

        public byte? Status { get; set; }
    }
}
