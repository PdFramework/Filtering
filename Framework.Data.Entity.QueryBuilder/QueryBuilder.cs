namespace Framework.QueryBuilder.Data.Entity
{
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Text;

    internal class QueryBuilder
    {
        public QueryBuilder()
        {
            QueryParameters = new List<SqlParameter>();
            StringBuilder = new StringBuilder();
        }

        public DbObjectMapper DbObjectMapper { get; set; }
        public StringBuilder StringBuilder { get; set; }
        public List<SqlParameter> QueryParameters { get; set; }
    }
}
