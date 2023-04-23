namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class d_Voucher
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public int? Price { get; set; }

        public byte? IsInfinite { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpriationDate { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? EditedDate { get; set; }

        public int? EditedBy { get; set; }
    }
}
