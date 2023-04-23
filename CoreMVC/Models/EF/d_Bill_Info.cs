namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class d_Bill_Info
    {
        public long ID { get; set; }

        public long? ID_Bill { get; set; }

        public long? ID_PSP { get; set; }

        public int? Amount { get; set; }

        public int? Price { get; set; }

        public int? Total { get; set; }
    }
}
