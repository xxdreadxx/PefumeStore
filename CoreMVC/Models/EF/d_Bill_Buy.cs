namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class d_Bill_Buy
    {
        public int ID { get; set; }

        public int? ID_SL { get; set; }

        public DateTime? TimeBuy { get; set; }

        public int? Total { get; set; }

        public int? Discount { get; set; }

        public int? TotalAll { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? EditedDate { get; set; }

        public int? EditedBy { get; set; }
    }
}
