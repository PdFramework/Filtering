namespace Framework.QueryBuilder.Data.Entity
{
    using System.Text;

    internal class DynamicQuery
    {
        public StringBuilder ParameterizedQuery { get; set; }
        public object[] Parameters { get; set; }
    }
}
