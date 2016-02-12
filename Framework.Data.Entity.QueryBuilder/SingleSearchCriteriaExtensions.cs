namespace Framework.QueryBuilder.Data.Entity
{
    using System;
    using SearchTypes;

    internal static class SingleSearchCriteriaExtensions
    {
        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, int, IntegerSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case IntegerSearchType.LessThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] < @p{parameterIndex}";
                case IntegerSearchType.LessThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <= @p{parameterIndex}";
                case IntegerSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case IntegerSearchType.GreaterThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] >= @p{parameterIndex}";
                case IntegerSearchType.GreaterThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] > @p{parameterIndex}";
                case IntegerSearchType.DoesNotEqual:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, short, ShortSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case ShortSearchType.LessThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] < @p{parameterIndex}";
                case ShortSearchType.LessThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <= @p{parameterIndex}";
                case ShortSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case ShortSearchType.GreaterThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] >= @p{parameterIndex}";
                case ShortSearchType.GreaterThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] > @p{parameterIndex}";
                case ShortSearchType.DoesNotEqual:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, long, LongSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case LongSearchType.LessThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] < @p{parameterIndex}";
                case LongSearchType.LessThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <= @p{parameterIndex}";
                case LongSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case LongSearchType.GreaterThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] >= @p{parameterIndex}";
                case LongSearchType.GreaterThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] > @p{parameterIndex}";
                case LongSearchType.DoesNotEqual:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, double, DoubleSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case DoubleSearchType.LessThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] < @p{parameterIndex}";
                case DoubleSearchType.LessThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <= @p{parameterIndex}";
                case DoubleSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case DoubleSearchType.GreaterThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] >= @p{parameterIndex}";
                case DoubleSearchType.GreaterThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] > @p{parameterIndex}";
                case DoubleSearchType.DoesNotEqual:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, decimal, DecimalSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case DecimalSearchType.LessThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] < @p{parameterIndex}";
                case DecimalSearchType.LessThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <= @p{parameterIndex}";
                case DecimalSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case DecimalSearchType.GreaterThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] >= @p{parameterIndex}";
                case DecimalSearchType.GreaterThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] > @p{parameterIndex}";
                case DecimalSearchType.DoesNotEqual:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, float, FloatSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case FloatSearchType.LessThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] < @p{parameterIndex}";
                case FloatSearchType.LessThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <= @p{parameterIndex}";
                case FloatSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case FloatSearchType.GreaterThanOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] >= @p{parameterIndex}";
                case FloatSearchType.GreaterThan:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] > @p{parameterIndex}";
                case FloatSearchType.DoesNotEqual:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, string, StringSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case StringSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case StringSearchType.DoesNotEqual:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] != @p{parameterIndex}";
                case StringSearchType.StartsWith:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] LIKE @p{parameterIndex} + '%'";
                case StringSearchType.EndsWith:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] LIKE '%' + @p{parameterIndex}";
                case StringSearchType.Contains:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] LIKE '%' + @p{parameterIndex} + '%'";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, bool, BooleanSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case BooleanSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case BooleanSearchType.DoesNotEqual:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <> @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, DateTime, DateTimeSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case DateTimeSearchType.Before:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] < @p{parameterIndex}";
                case DateTimeSearchType.BeforeOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <= @p{parameterIndex}";
                case DateTimeSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case DateTimeSearchType.AfterOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] >= @p{parameterIndex}";
                case DateTimeSearchType.After:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] > @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }

        internal static string CreateWhere<TSearchable>(this SingleSearchCriteria<TSearchable, DateTimeOffset, DateTimeOffsetSearchType> searchCriteria, int parameterIndex) where TSearchable : class
        {
            switch (searchCriteria.SearchCriteria.SearchType)
            {
                case DateTimeOffsetSearchType.Before:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] < @p{parameterIndex}";
                case DateTimeOffsetSearchType.BeforeOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] <= @p{parameterIndex}";
                case DateTimeOffsetSearchType.Equals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] = @p{parameterIndex}";
                case DateTimeOffsetSearchType.AfterOrEquals:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] >= @p{parameterIndex}";
                case DateTimeOffsetSearchType.After:
                    return $"[{searchCriteria.SearchCriteria.SearchPropertyName}] > @p{parameterIndex}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(searchCriteria.SearchCriteria.SearchType), searchCriteria.SearchCriteria.SearchType, null);
            }
        }
    }
}
