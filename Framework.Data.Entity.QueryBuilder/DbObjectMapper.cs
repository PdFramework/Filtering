namespace Framework.Data.Entity.QueryBuilder
{
    using System.Collections.Generic;

    internal class DbObjectMapper
    {
        public string DbSchema { get; set; }
        public string DbTableName { get; set; }
        public IDictionary<string, string> ObjectPropertyColumnNameMapper { get; set; }
        public string PrimaryKeyPropertyName { get; set; }
    }
}
