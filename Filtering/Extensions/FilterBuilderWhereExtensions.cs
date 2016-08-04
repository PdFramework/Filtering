namespace PeinearyDevelopment.Framework.Filtering.Extensions
{
  using FilterCriteria;
  using FilterCriteria.Nullables;
  using FilterCriteria.Nullables.Sets;
  using FilterCriteria.Sets;
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Linq.Expressions;

  public static class FilterBuilderWhereExtensions
  {
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, BaseCriterion filterCriterion) where TFilterable : class, IFilterable
    {
      if(filterBuilderBase == null) throw new ArgumentNullException(nameof(filterBuilderBase));

      if (filterBuilderBase.FilterCriteria.Criteria.Any())
      {
        filterBuilderBase.FilterCriteria.Criteria.Add(new CriteriaGroup(filterCriterion));
      }
      else
      {
        filterBuilderBase.FilterCriteria = new CriteriaGroup(filterCriterion);
      }

      return new SimpleFilterBuilder<TFilterable>(filterBuilderBase);
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, IList<CompoundFilterType> compoundFilterTypes, params BaseCriterion[] criteria) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new CriteriaGroup(criteria, compoundFilterTypes));
    }

    #region bool
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, bool>> propertyNameExpression, BooleanFilterType filterType, bool filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new BooleanCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, BooleanFilterType filterType, bool filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new BooleanCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, bool?>> propertyNameExpression, BooleanFilterType filterType, bool? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableBooleanCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, BooleanFilterType filterType, bool? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableBooleanCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTime
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, DateTime>> propertyNameExpression, DateTimeFilterType filterType, DateTime filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, DateTimeFilterType filterType, DateTime filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, DateTime>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, DateTime?>> propertyNameExpression, DateTimeFilterType filterType, DateTime? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, DateTimeFilterType filterType, DateTime? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, DateTime?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeSetCriterion<TFilterable> (propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTimeOffset
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, DateTimeOffset>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeOffsetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeOffsetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, DateTimeOffset>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeOffsetSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeOffsetSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, DateTimeOffset?>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeOffsetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeOffsetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, DateTimeOffset?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeOffsetSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeOffsetSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
        #endregion

    #region numeric
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable, TNumeric>(this FilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, TNumeric>> propertyNameExpression, NumericFilterType filterType, TNumeric filterValue) where TFilterable : class, IFilterable
                                                                                                                                                                                                                                                          where TNumeric : struct
    {
        return simpleFilterBuilder.Where(new NumericCriterion<TFilterable, TNumeric>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable, TNumeric>(this FilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, TNumeric filterValue) where TFilterable : class, IFilterable
                                                                                                                                                                                                              where TNumeric : struct
    {
        return simpleFilterBuilder.Where(new NumericCriterion<TFilterable, TNumeric>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable, TNumeric>(this FilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, TNumeric>> propertyNameExpression, SetFilterType filterType, IEnumerable<TNumeric> filterValue) where TFilterable : class, IFilterable
                                                                                                                                                                                                                                                                  where TNumeric : struct
    {
      return simpleFilterBuilder.Where(new NumericSetCriterion<TFilterable, TNumeric>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable, TNumeric>(this FilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<TNumeric> filterValue) where TFilterable : class, IFilterable
                                                                                                                                                                                                                       where TNumeric : struct
    {
      return simpleFilterBuilder.Where(new NumericSetCriterion<TFilterable, TNumeric>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, decimal?>> propertyNameExpression, NumericFilterType filterType, decimal? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDecimalCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, NumericFilterType filterType, decimal? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDecimalCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, decimal?>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDecimalSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDecimalSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region double
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, double?>> propertyNameExpression, NumericFilterType filterType, double? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDoubleCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, NumericFilterType filterType, double? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDoubleCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, double?>> propertyNameExpression, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDoubleSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDoubleSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region float
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, float?>> propertyNameExpression, NumericFilterType filterType, float? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableFloatCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, NumericFilterType filterType, float? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableFloatCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, float?>> propertyNameExpression, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableFloatSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableFloatSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region int
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, int?>> propertyNameExpression, NumericFilterType filterType, int? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableIntegerCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, NumericFilterType filterType, int? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableIntegerCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, int?>> propertyNameExpression, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableIntegerSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableIntegerSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region long
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, long?>> propertyNameExpression, NumericFilterType filterType, long? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableLongCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, NumericFilterType filterType, long? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableLongCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, long?>> propertyNameExpression, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableLongSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableLongSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region short
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, short?>> propertyNameExpression, NumericFilterType filterType, short? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableShortCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, NumericFilterType filterType, short? filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableShortCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, short?>> propertyNameExpression, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableShortSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableShortSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region string
    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, string>> propertyNameExpression, StringFilterType filterType, string filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new StringCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, StringFilterType filterType, string filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new StringCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, Expression<Func<TFilterable, string>> propertyNameExpression, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new StringSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterable> Where<TFilterable>(this FilterBuilder<TFilterable> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterable : class, IFilterable
    {
      return filterBuilderBase.Where(new StringSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion
  }
}
