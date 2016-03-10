namespace Framework.QueryBuilder.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SearchTypes;

    public static class MultipleValuesSearchCriteriaExtensions
    {
        internal static string CreateWhere<TSearchable>(this SetSearchCriteria<TSearchable, IEnumerable<int>, IntegersSearchType> valueSearchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int startingParameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[valueSearchCriteria.SearchCriteria.SearchPropertyName];
            var parametersString = string.Join(", ", valueSearchCriteria.SearchCriteria.SearchValue.Select(value => $"@p{startingParameterIndex++}"));
            switch (valueSearchCriteria.SearchCriteria.SearchType)
            {
                case IntegersSearchType.In:
                    return $"[{columnName}] IN ({parametersString})";
                case IntegersSearchType.NotIn:
                    return $"[{columnName}] NOT IN ({parametersString})";
                case IntegersSearchType.Between:
                    if (valueSearchCriteria.SearchCriteria.SearchValue.Count() != 2) throw new ArgumentOutOfRangeException("When utilizing the Between operator, exactly 2 values must be provided.");
                    return $"[{columnName}] BETWEEN @p{startingParameterIndex} AND @p{startingParameterIndex + 1}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(valueSearchCriteria.SearchCriteria.SearchType), valueSearchCriteria.SearchCriteria.SearchType, null);
            }
        }
    }
}
