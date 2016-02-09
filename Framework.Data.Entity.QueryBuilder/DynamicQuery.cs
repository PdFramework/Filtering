namespace Framework.Data.Entity.QueryBuilder
{
    using System.Text;

    internal class DynamicQuery
    {
        public StringBuilder ParameterizedQuery { get; set; }
        public object[] Parameters { get; set; }
    }
}
