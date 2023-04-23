namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class c_Smell_Group
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string SmellName { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? EditedDate { get; set; }

        public int? EditedBy { get; set; }
    }
}
