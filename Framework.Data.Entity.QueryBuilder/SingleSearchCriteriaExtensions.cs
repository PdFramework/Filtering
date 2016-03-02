namespace Framework.QueryBuilder.Data.Entity
{
    using System;
    using System.Collections.Generic;
    using SearchTypes;

    internal static class SingleSearchCriteriaExtensions
    {
        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, int, IntegerSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case IntegerSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case IntegerSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case IntegerSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case IntegerSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case IntegerSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case IntegerSearchType.DoesNotEqual:
                    return $"[{columnName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, short, ShortSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case ShortSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case ShortSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case ShortSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case ShortSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case ShortSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case ShortSearchType.DoesNotEqual:
                    return $"[{columnName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, long, LongSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case LongSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case LongSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case LongSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case LongSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case LongSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case LongSearchType.DoesNotEqual:
                    return $"[{columnName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, double, DoubleSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case DoubleSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case DoubleSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case DoubleSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case DoubleSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case DoubleSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case DoubleSearchType.DoesNotEqual:
                    return $"[{columnName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, decimal, DecimalSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case DecimalSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case DecimalSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case DecimalSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case DecimalSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case DecimalSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case DecimalSearchType.DoesNotEqual:
                    return $"[{columnName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, float, FloatSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case FloatSearchType.LessThan:
                    return $"[{columnName}] < @p{parameterIndex}";
                case FloatSearchType.LessThanOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case FloatSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case FloatSearchType.GreaterThanOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case FloatSearchType.GreaterThan:
                    return $"[{columnName}] > @p{parameterIndex}";
                case FloatSearchType.DoesNotEqual:
                    return $"[{columnName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, string, StringSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case StringSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case StringSearchType.DoesNotEqual:
                    return $"[{columnName}] != @p{parameterIndex}";
                case StringSearchType.StartsWith:
                    return $"[{columnName}] LIKE @p{parameterIndex} + '%'";
                case StringSearchType.EndsWith:
                    return $"[{columnName}] LIKE '%' + @p{parameterIndex}";
                case StringSearchType.Contains:
                    return $"[{columnName}] LIKE '%' + @p{parameterIndex} + '%'";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, bool, BooleanSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case BooleanSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case BooleanSearchType.DoesNotEqual:
                    return $"[{columnName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, DateTime, DateTimeSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case DateTimeSearchType.Before:
                    return $"[{columnName}] < @p{parameterIndex}";
                case DateTimeSearchType.BeforeOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case DateTimeSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case DateTimeSearchType.AfterOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case DateTimeSearchType.After:
                    return $"[{columnName}] > @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, DateTimeOffset, DateTimeOffsetSearchType> searchCriteria, IDictionary<string, string> propertyNameToColumnNameMapper, int parameterIndex) where TSearchable : class, IFilterable
        {
            var columnName = propertyNameToColumnNameMapper[searchCriteria.SearchCriteria.SearchPropertyName];

            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case DateTimeOffsetSearchType.Before:
                    return $"[{columnName}] < @p{parameterIndex}";
                case DateTimeOffsetSearchType.BeforeOrEquals:
                    return $"[{columnName}] <= @p{parameterIndex}";
                case DateTimeOffsetSearchType.Equals:
                    return $"[{columnName}] = @p{parameterIndex}";
                case DateTimeOffsetSearchType.AfterOrEquals:
                    return $"[{columnName}] >= @p{parameterIndex}";
                case DateTimeOffsetSearchType.After:
                    return $"[{columnName}] > @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }
    }
}
