namespace Framework.QueryBuilder.SetSearchCriteria
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using SearchCriteria;
    using SingleValueSearchCriteria;
    using SetSearchTypes;
    using SetValueSearchCriteria;

    public class DecimalSetSearchCriteria : SearchCriteriaBase<IEnumerable<decimal>, DecimalSetSearchType>
    {
        public DecimalSetSearchCriteria()
        {
        }

        public DecimalSetSearchCriteria(IEnumerable<decimal> value, DecimalSetSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<IEnumerable<decimal>, DecimalSetSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<decimal> value, DecimalSetSearchType type)
        {
            return new DecimalSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<decimal>, DecimalSetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<decimal> value, DecimalSetSearchType type)
        {
            return new DecimalSetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if (SearchType == DecimalSetSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case DecimalSetSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case DecimalSetSearchType.Between:
                    return $"[{columnName}] BETWEEN ({parametersString})";
                case DecimalSetSearchType.NotIn:
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
