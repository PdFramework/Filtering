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

  public static class FilterBuilderOrExtensions
  {
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, BaseCriterion filterCriterion) where TFilterable : class, IFilterable
    {
      var compoundFilterBuilder = new CompoundFilterBuilder<TFilterable>(simpleFilterBuilder);
      compoundFilterBuilder.FilterCriteria.Criteria.Add(new CriteriaGroup(filterCriterion));
      compoundFilterBuilder.FilterCriteria.CompoundFilterTypes.Add(CompoundFilterType.Or);
      return compoundFilterBuilder;
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, IList<CompoundFilterType> compoundFilterTypes, params BaseCriterion[] criteria) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new CriteriaGroup(criteria, compoundFilterTypes));
    }

    #region bool
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, bool>> propertyNameExpression, BooleanFilterType filterType, bool filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new BooleanCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, BooleanFilterType filterType, bool filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new BooleanCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, bool?>> propertyNameExpression, BooleanFilterType filterType, bool? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableBooleanCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, BooleanFilterType filterType, bool? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableBooleanCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTime
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTime>> propertyNameExpression, DateTimeFilterType filterType, DateTime filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DateTimeCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTime filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DateTimeCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTime>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DateTimeSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DateTimeSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTime?>> propertyNameExpression, DateTimeFilterType filterType, DateTime? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDateTimeCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTime? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDateTimeCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTime?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDateTimeSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDateTimeSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTimeOffset
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTimeOffset>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DateTimeOffsetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DateTimeOffsetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTimeOffset>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DateTimeOffsetSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DateTimeOffsetSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTimeOffset?>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDateTimeOffsetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDateTimeOffsetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, DateTimeOffset?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDateTimeOffsetSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDateTimeOffsetSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region decimal
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, decimal>> propertyNameExpression, NumericFilterType filterType, decimal filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DecimalCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, decimal filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DecimalCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, decimal>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DecimalSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<decimal> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DecimalSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, decimal?>> propertyNameExpression, NumericFilterType filterType, decimal? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDecimalCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, decimal? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDecimalCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, decimal?>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDecimalSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDecimalSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region double
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, double>> propertyNameExpression, NumericFilterType filterType, double filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DoubleCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, double filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DoubleCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, double>> propertyNameExpression, SetFilterType filterType, IEnumerable<double> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DoubleSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<double> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new DoubleSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, double?>> propertyNameExpression, NumericFilterType filterType, double? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDoubleCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, double? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDoubleCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, double?>> propertyNameExpression, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDoubleSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableDoubleSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region float
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, float>> propertyNameExpression, NumericFilterType filterType, float filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new FloatCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, float filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new FloatCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, float>> propertyNameExpression, SetFilterType filterType, IEnumerable<float> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new FloatSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<float> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new FloatSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, float?>> propertyNameExpression, NumericFilterType filterType, float? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableFloatCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, float? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableFloatCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, float?>> propertyNameExpression, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableFloatSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableFloatSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region int
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, int>> propertyNameExpression, NumericFilterType filterType, int filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new IntegerCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, int filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new IntegerCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, int>> propertyNameExpression, SetFilterType filterType, IEnumerable<int> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new IntegerSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<int> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new IntegerSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, int?>> propertyNameExpression, NumericFilterType filterType, int? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableIntegerCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, int? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableIntegerCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, int?>> propertyNameExpression, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableIntegerSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableIntegerSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region long
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, long>> propertyNameExpression, NumericFilterType filterType, long filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new LongCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, long filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new LongCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, long>> propertyNameExpression, SetFilterType filterType, IEnumerable<long> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new LongSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<long> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new LongSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, long?>> propertyNameExpression, NumericFilterType filterType, long? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableLongCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, long? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableLongCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, long?>> propertyNameExpression, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableLongSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableLongSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region short
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, short>> propertyNameExpression, NumericFilterType filterType, short filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new ShortCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, short filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new ShortCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, short>> propertyNameExpression, SetFilterType filterType, IEnumerable<short> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new ShortSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<short> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new ShortSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, short?>> propertyNameExpression, NumericFilterType filterType, short? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableShortCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, NumericFilterType filterType, short? filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableShortCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, short?>> propertyNameExpression, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableShortSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new NullableShortSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion

    #region string
    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, string>> propertyNameExpression, StringFilterType filterType, string filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new StringCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, StringFilterType filterType, string filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new StringCriterion<TFilterable>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, Expression<Func<TFilterable, string>> propertyNameExpression, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new StringSetCriterion<TFilterable>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterable> Or<TFilterable>(this SimpleFilterBuilder<TFilterable> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterable : class, IFilterable
    {
      return simpleFilterBuilder.Or(new StringSetCriterion<TFilterable>(propertyName, filterType, filterValue));
    }
    #endregion
  }
}
