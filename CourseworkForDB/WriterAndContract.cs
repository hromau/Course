namespace CourseworkForDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WriterAndContract")]
    public partial class WriterAndContract
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Patronymic { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Telephone { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "date")]
        public DateTime DateOfContract { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool StateContract { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "date")]
        public DateTime ContractTerminationDate { get; set; }
    }
}
