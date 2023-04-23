namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class s_Store_Info
    {
        public int ID { get; set; }

        [StringLength(500)]
        public string StoreName { get; set; }

        [StringLength(500)]
        public string Banner { get; set; }

        [StringLength(200)]
        public string Slogan { get; set; }

        [StringLength(500)]
        public string Video { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Logo { get; set; }

        [StringLength(500)]
        public string Favicon { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(500)]
        public string GoogleMap { get; set; }

        public string Description { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(15)]
        public string Zalo { get; set; }

        [StringLength(100)]
        public string Facebook { get; set; }

        [StringLength(50)]
        public string Instagram { get; set; }

        [StringLength(50)]
        public string Tiktok { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? EditedDate { get; set; }
    }
}
