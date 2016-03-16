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

    public class DateTimeSetSearchCriteria : SearchCriteriaBase<IEnumerable<DateTime>, DateTimeSetSearchType>
    {
        public DateTimeSetSearchCriteria()
        {
        }

        public DateTimeSetSearchCriteria(IEnumerable<DateTime> value, DateTimeSetSearchType type)
        {
            SearchType = type;
            SearchValue = value;
        }

        public override SearchCriteriaBase<IEnumerable<DateTime>, DateTimeSetSearchType> CreateSearchCriteriaBase(string searchPropertyName, IEnumerable<DateTime> value, DateTimeSetSearchType type)
        {
            return new DateTimeSetSearchCriteria(value, type)
            {
                SearchPropertyName = searchPropertyName
            };
        }

        public override SingleValueSearchCriteriaBase<TSearchable, IEnumerable<DateTime>, DateTimeSetSearchType> CreateSingleValueSearchCriteria<TSearchable>(string searchPropertyName, IEnumerable<DateTime> value, DateTimeSetSearchType type)
        {
            return new DateTimeSetSearchCriteria<TSearchable>(searchPropertyName, value, type);
        }

        internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
        {
            if (SearchType == DateTimeSetSearchType.Between && SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("The 'Between' search type may only be used with exactly 2 values.");

            var columnName = objectPropertyToColumnNameMapper[SearchPropertyName];
            var parametersString = string.Join(", ", SearchValue.Select(value => $"@p{parameterIndex++}"));

            switch (SearchType)
            {
                case DateTimeSetSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case DateTimeSetSearchType.Between:
                    return $"[{columnName}] BETWEEN ({parametersString})";
                case DateTimeSetSearchType.NotIn:
                    return $"[{columnName}] NOT IN @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(SearchType), SearchType, null);
            }
        }

        internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
        {
            return new[] { new SqlParameter($"p{startingParameterIndex}", SearchValue) };
        }
    }
}
