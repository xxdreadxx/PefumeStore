namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class d_Product
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(100)]
        public string NameProduct { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        public byte? Gender { get; set; }

        public int? Year_Release { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [StringLength(200)]
        public string Style { get; set; }

        public int? ID_SG { get; set; }

        [StringLength(50)]
        public string Origin { get; set; }

        public int? ID_Branch { get; set; }

        public int? ID_Type { get; set; }

        public string Content { get; set; }

        public int? View { get; set; }

        public double? Rate { get; set; }

        public int? Quantity { get; set; }

        public int? Sell { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? EditedDate { get; set; }

        public int? EditedBy { get; set; }
    }
}
