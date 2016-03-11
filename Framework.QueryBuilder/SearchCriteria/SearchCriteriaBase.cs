namespace Framework.QueryBuilder.SearchCriteria
{
    using SingleValueSearchCriteria;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public abstract class SearchCriteriaBase
    {
        internal abstract string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex);
        internal abstract IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex);
        internal string SearchPropertyName { get; set; }
        public object SearchType { get; set; }
        public object SearchValue { get; set; }
    }

    public abstract class SearchCriteriaBase<TSearchValue, TSearchType> : SearchCriteriaBase
    {
        public new TSearchType SearchType { get; set; }
        public new TSearchValue SearchValue { get; set; }
        public abstract SearchCriteriaBase<TSearchValue, TSearchType> CreateSearchCriteriaBase(string searchPropertyName, TSearchValue value, TSearchType type);
        public abstract SingleValueSearchCriteriaBase<TSearchable, TSearchValue, TSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, TSearchValue value, TSearchType type) where TSearchable : class, IFilterable;
    }
}
