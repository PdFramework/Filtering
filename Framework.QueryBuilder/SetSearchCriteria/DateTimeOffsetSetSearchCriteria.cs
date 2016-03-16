namespace Framework.QueryBuilder.SetSearchCriteria
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using SearchCriteria;
    using SingleValueSearchCriteria;
    using SetSearchTypes;
    using SetValueSearchCriteria;

    public class DateTimeOffsetSetSearchCriteria : SearchCriteriaBase<IEnumerable<DateTimeOffset>, DateTimeOffsetSetSearchType>
    {
        public DateTimeOffsetSetSearchCriteria()
        {
        }

        public DateTimeOffsetSetSearchCriteria(IEnumerable<DateTimeOffset> values, DateTimeOffsetSetSearchType type)
        {
            SearchType = type;
            SearchValue = values;
        }

        public override SearchCriteriaBase<IEnumerable<DateTimeOffset>, DateTimeOffsetSetSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<DateTimeOffset> value, DateTimeOffsetSetSearchType type)
        {
            return new DateTimeOffsetSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<DateTimeOffset>, DateTimeOffsetSetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<DateTimeOffset> value, DateTimeOffsetSetSearchType type)
        {
            return new DateTimeOffsetSetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if(SearchType == DateTimeOffsetSetSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case DateTimeOffsetSetSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case DateTimeOffsetSetSearchType.Between:
                    return $"[{columnName}] BETWEEN ({parametersString})";
                case DateTimeOffsetSetSearchType.NotIn:
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
