namespace CourseworkForDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contract")]
    public partial class Contract
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfContract { get; set; }

        public int LengthOfContract { get; set; }

        public bool StateContract { get; set; }

        [Column(TypeName = "date")]
        public DateTime ContractTerminationDate { get; set; }

        public virtual Writer Writer { get; set; }
    }
}
