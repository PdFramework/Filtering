namespace Framework.QueryBuilder.Data.Entity
{
    using System.Collections.Generic;
    using System.Text;

    internal class QueryBuilder
    {
        public QueryBuilder()
        {
            QueryParameters = new List<object>();
            StringBuilder = new StringBuilder();
        }

        public DbObjectMapper DbObjectMapper { get; set; }
        public StringBuilder StringBuilder { get; set; }
        public List<object> QueryParameters { get; set; }
    }
}
