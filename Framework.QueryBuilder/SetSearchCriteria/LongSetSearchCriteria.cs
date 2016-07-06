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

    public class LongSetSearchCriteria : SearchCriteriaBase<IEnumerable<long>, LongSetSearchType>
    {
        public LongSetSearchCriteria()
        {
        }

        public LongSetSearchCriteria(IEnumerable<long> value, LongSetSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<IEnumerable<long>, LongSetSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<long> value, LongSetSearchType type)
        {
            return new LongSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<long>, LongSetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<long> value, LongSetSearchType type)
        {
            return new LongSetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if (SearchType == LongSetSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = SearchType == LongSetSearchType.Between ? $"@p{parameterIndex++} AND @p{parameterIndex++}" : string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case LongSetSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case LongSetSearchType.Between:
                    return $"[{columnName}] BETWEEN {parametersString}";
                case LongSetSearchType.NotIn:
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
