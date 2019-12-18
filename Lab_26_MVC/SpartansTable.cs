namespace Lab_26_MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SpartansTable")]
    public partial class SpartansTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SPARTAID { get; set; }

        [StringLength(30)]
        public string TITLE { get; set; }

        [StringLength(50)]
        public string FIRSTNAME { get; set; }

        [StringLength(50)]
        public string LASTNAME { get; set; }

        [StringLength(50)]
        public string UNIVERSITY { get; set; }
    }
}
