namespace Framework.Data.Entity.QueryBuilder
{
    using System.Text;

    internal class QueryBuilder
    {
        public DbObjectMapper DbObjectMapper { get; set; }
        public StringBuilder StringBuilder { get; set; }
    }
}
