namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VW_Orders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(75)]
        public string CLIENTE_NAME { get; set; }

        [StringLength(75)]
        public string FirstCourses { get; set; }

        [StringLength(75)]
        public string MainCourses { get; set; }

        [StringLength(75)]
        public string Desserts { get; set; }

        [StringLength(75)]
        public string Drinks { get; set; }

        [StringLength(15)]
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATE_DATE { get; set; }

        public decimal? SUB_TOTAL { get; set; }

        public decimal? ITBIS { get; set; }

        public decimal? TOTAL { get; set; }
    }
}
