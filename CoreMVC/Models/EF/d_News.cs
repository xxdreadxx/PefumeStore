namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class d_News
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(500)]
        public string Thumbnail { get; set; }

        public int? ID_NT { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public string Content { get; set; }

        public byte? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? EditedDate { get; set; }

        public int? EditedBy { get; set; }
    }
}
