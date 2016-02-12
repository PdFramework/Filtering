using System.Data.Entity;

namespace Framework.QueryBuilder.UnitTests
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() : base("TestDbContext")
        {
        }

        public virtual DbSet<TestClass> TestObjects { get; set; }
    }
}
