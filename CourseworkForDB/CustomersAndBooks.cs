namespace CourseworkForDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomersAndBooks
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string FirstLastName { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookCount { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "date")]
        public DateTime PrintDate { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CostPrice { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Fee { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
