namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class s_Slide
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string LinkImage { get; set; }

        [StringLength(500)]
        public string LinkContent { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? EditedDate { get; set; }

        public int? EditedBy { get; set; }
    }
}
