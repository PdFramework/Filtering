namespace Framework.QueryBuilder.SetSearchCriteria
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using SearchCriteria;
    using SetSearchTypes;
    using SetValueSearchCriteria;
    using SingleValueSearchCriteria;

    public class ShortSetSearchCriteria : SearchCriteriaBase<IEnumerable<short>, ShortSetSearchType>
    {
        public ShortSetSearchCriteria()
        {
        }

        public ShortSetSearchCriteria(IEnumerable<short> value, ShortSetSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<IEnumerable<short>, ShortSetSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<short> value, ShortSetSearchType type)
        {
            return new ShortSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<short>, ShortSetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<short> value, ShortSetSearchType type)
        {
            return new ShortSetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if (SearchType == ShortSetSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = SearchType == ShortSetSearchType.Between ? $"@p{parameterIndex++} AND @p{parameterIndex++}" : string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case ShortSetSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case ShortSetSearchType.Between:
                    return $"[{columnName}] BETWEEN {parametersString}";
                case ShortSetSearchType.NotIn:
                    return $"[{columnName}] NOT IN @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(SearchType), SearchType, null);
            }
        }

        internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
        {
          return SearchValue.Select(value => new SqlParameter($"p{startingParameterIndex++}", value));
        }
    }
}
