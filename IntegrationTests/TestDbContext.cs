using System.Data.Entity;

namespace PeinearyDevelopment.Framework.Filtering.IntegrationTests
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() : base("TestDbContext")
        {
        }

        public virtual DbSet<TestClass> TestObjects { get; set; }
        public virtual DbSet<CustomTestClass> CustomTestObjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomTestClass>()
                        .ToTable(Contstants.CustomTableName, Contstants.CustomSchemaName);

            modelBuilder.Entity<CustomTestClass>()
                        .Property(ctc => ctc.Name)
                            .HasColumnName(Contstants.CustomColumnName);

            modelBuilder.Entity<CustomTestClass>()
                        .HasKey(ctc => ctc.StartDateTime);
        }
    }
}
