namespace PeinearyDevelopment.Framework.Filtering.Extensions
{
  using FilterCriteria;
  using FilterCriteria.Nullables;
  using FilterCriteria.Nullables.Sets;
  using FilterCriteria.Sets;
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public static class FilterBuilderAndExtensions
  {
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, BaseCriterion filterCriterion) where TFilterable : class, IFilterable
    {
      var compoundFilterBuilder = new CompoundFilterBuilder<TFilterable>(simpleFilterBuilder);
      compoundFilterBuilder.FilterCriteria.Criteria.Add(new CriteriaGroup(filterCriterion));
      compoundFilterBuilder.FilterCriteria.CompoundFilterTypes.Add(CompoundFilterType.And);
      return compoundFilterBuilder;
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, IList<CompoundFilterType> compoundFilterTypes, params BaseCriterion[] criteria) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new CriteriaGroup(criteria, compoundFilterTypes));
    }

    #region bool
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, bool>> propertyNameExpression, BooleanFilterType filterType, bool filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new BooleanCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, BooleanFilterType filterType, bool filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new BooleanCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, bool?>> propertyNameExpression, BooleanFilterType filterType, bool? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableBooleanCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, BooleanFilterType filterType, bool? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableBooleanCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTime
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTime>> propertyNameExpression, DateTimeFilterType filterType, DateTime filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTime filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTime>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTime?>> propertyNameExpression, DateTimeFilterType filterType, DateTime? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTime? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTime?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTimeOffset
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTimeOffset>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeOffsetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeOffsetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTimeOffset>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeOffsetSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeOffsetSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTimeOffset?>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeOffsetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeOffsetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTimeOffset?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeOffsetSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeOffsetSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region numeric
    public static CompoundFilterBuilder<TFilterable> And<TFilterable, TNumeric>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, TNumeric>> propertyNameExpression, NumericFilterType filterType, TNumeric filterValue) where TFilterable : class, IFilterable
                                                                                                                                                                                                                                                                where TNumeric : struct
    {
      return simpleFilterBuilder.And(new NumericCriterion<TFilterable, TNumeric>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable, TNumeric>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, TNumeric filterValue) where TFilterable : class, IFilterable
                                                                                                                                                                                                                    where TNumeric : struct
    {
      return simpleFilterBuilder.And(new NumericCriterion<TFilterable, TNumeric>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable, TNumeric>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, TNumeric>> propertyNameExpression, SetFilterType filterType, IEnumerable<TNumeric> filterValue) where TFilterable : class, IFilterable
                                                                                                                                                                                                                                                                        where TNumeric : struct
    {
      return simpleFilterBuilder.And(new NumericSetCriterion<TFilterable, TNumeric>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable, TNumeric>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<TNumeric> filterValue) where TFilterable : class, IFilterable
                                                                                                                                                                                                                             where TNumeric : struct
    {
      return simpleFilterBuilder.And(new NumericSetCriterion<TFilterable, TNumeric>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, decimal?>> propertyNameExpression, NumericFilterType filterType, decimal? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDecimalCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, decimal? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDecimalCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, decimal?>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDecimalSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDecimalSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region double
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, double?>> propertyNameExpression, NumericFilterType filterType, double? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDoubleCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, double? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDoubleCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, double?>> propertyNameExpression, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDoubleSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDoubleSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region float
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, float?>> propertyNameExpression, NumericFilterType filterType, float? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableFloatCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, float? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableFloatCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, float?>> propertyNameExpression, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableFloatSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableFloatSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region int
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, int?>> propertyNameExpression, NumericFilterType filterType, int? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableIntegerCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, int? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableIntegerCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, int?>> propertyNameExpression, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableIntegerSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableIntegerSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region long
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, long?>> propertyNameExpression, NumericFilterType filterType, long? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableLongCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, long? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableLongCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, long?>> propertyNameExpression, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableLongSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableLongSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region short
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, short?>> propertyNameExpression, NumericFilterType filterType, short? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableShortCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, short? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableShortCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, short?>> propertyNameExpression, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableShortSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableShortSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region string
    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, string>> propertyNameExpression, StringFilterType filterType, string filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new StringCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, StringFilterType filterType, string filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new StringCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, string>> propertyNameExpression, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new StringSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> And<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.And(new StringSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion
  }
}
