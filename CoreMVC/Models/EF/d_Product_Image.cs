namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class d_Product_Image
    {
        public long ID { get; set; }

        public long? ID_Product { get; set; }

        public string Image { get; set; }

        public bool? IsKey { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? EditedDate { get; set; }

        public int? EditedBy { get; set; }
    }
}
