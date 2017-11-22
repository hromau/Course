namespace CourseworkForDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            Orders = new HashSet<Orders>();
        }

        [Required]
        [StringLength(50)]
        public string BookChiper { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int Printing { get; set; }

        [Column(TypeName = "date")]
        public DateTime PrintDate { get; set; }

        public int CostPrice { get; set; }

        public int SellingPrice { get; set; }

        public int Fee { get; set; }

        public int Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdOrders { get; set; }

        public virtual Writer Writer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
