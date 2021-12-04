namespace DataBase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public int ID { get; set; }

        [StringLength(75)]
        public string CLIENTE_NAME { get; set; }

        public int? FIRST_COURSE { get; set; }

        public int? MAIN_COURSE { get; set; }

        public int? DESSERTS { get; set; }

        public int? DRINKS { get; set; }

        public int? STATES { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CREATE_DATE { get; set; }

        public decimal? SUB_TOTAL { get; set; }

        public decimal? ITBIS { get; set; }

        public decimal? TOTAL { get; set; }

        public virtual Desserts Desserts1 { get; set; }

        public virtual Drinks Drinks1 { get; set; }

        public virtual FirstCourses FirstCourses { get; set; }

        public virtual MainCourses MainCourses { get; set; }

        public virtual States States1 { get; set; }
    }
}
