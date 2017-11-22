namespace CourseworkForDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Contract> Contract { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Writer> Writer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<BooksAndWriter> BooksAndWriter { get; set; }
        public virtual DbSet<CustomersAndBooks> CustomersAndBooks { get; set; }
        public virtual DbSet<WriterAndContract> WriterAndContract { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Books)
                .HasForeignKey(e => e.Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customers>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Writer>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Writer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Writer>()
                .HasOptional(e => e.Contract)
                .WithRequired(e => e.Writer)
                .WillCascadeOnDelete();
        }
    }
}
