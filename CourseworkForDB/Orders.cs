namespace CourseworkForDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime OrderExecutionDate { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookCount { get; set; }

        public virtual Books Books { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
