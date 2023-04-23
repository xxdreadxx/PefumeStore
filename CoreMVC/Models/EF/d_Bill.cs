namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class d_Bill
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        public DateTime? TimeBuy { get; set; }

        public int? Total { get; set; }

        public int? Discount { get; set; }

        public int? TotalAll { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
