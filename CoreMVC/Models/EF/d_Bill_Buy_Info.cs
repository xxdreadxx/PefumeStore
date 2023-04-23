namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class d_Bill_Buy_Info
    {
        public long ID { get; set; }

        public int? ID_Bill { get; set; }

        public long? ID_PS { get; set; }

        public int? Amount { get; set; }

        public int? Price { get; set; }

        public int? Total { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? EditedDate { get; set; }

        public int? EditedBy { get; set; }
    }
}
