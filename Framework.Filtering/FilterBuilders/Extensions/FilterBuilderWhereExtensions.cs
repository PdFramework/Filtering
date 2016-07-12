namespace PeinearyDevelopment.Framework.Filtering.FilterBuilders.Extensions
{
  using FilterCriteria;
  using FilterCriteria.Nullables;
  using FilterCriteria.Nullables.Sets;
  using FilterCriteria.Sets;
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public static class FilterBuilderWhereExtensions
  {
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, BaseCriterion filterCriterion) where TFilterableObject : class, IFilterable
    {
      var simpleFilterBuilder = new SimpleFilterBuilder<TFilterableObject>(filterBuilderBase);
      simpleFilterBuilder.FilterCriteria.Add(new CriteriaGroup(filterCriterion));
      return simpleFilterBuilder;
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, IList<CompoundFilterType> compoundFilterTypes, params BaseCriterion[] criteria) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new CriteriaGroup(criteria, compoundFilterTypes));
    }

    #region bool
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, bool>> propertyNameExpression, BooleanFilterType filterType, bool filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new BooleanCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, BooleanFilterType filterType, bool filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new BooleanCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, bool?>> propertyNameExpression, BooleanFilterType filterType, bool? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableBooleanCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, BooleanFilterType filterType, bool? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableBooleanCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTime
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, DateTime>> propertyNameExpression, DateTimeFilterType filterType, DateTime filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, DateTimeFilterType filterType, DateTime filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, DateTime>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, DateTime?>> propertyNameExpression, DateTimeFilterType filterType, DateTime? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, DateTimeFilterType filterType, DateTime? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, DateTime?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeSetCriterion<TFilterableObject> (propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTimeOffset
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, DateTimeOffset>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeOffsetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeOffsetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, DateTimeOffset>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeOffsetSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DateTimeOffsetSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, DateTimeOffset?>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeOffsetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeOffsetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, DateTimeOffset?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeOffsetSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDateTimeOffsetSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region decimal
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, decimal>> propertyNameExpression, NumericFilterType filterType, decimal filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DecimalCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, decimal filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DecimalCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, decimal>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DecimalSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<decimal> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DecimalSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, decimal?>> propertyNameExpression, NumericFilterType filterType, decimal? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDecimalCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, decimal? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDecimalCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, decimal?>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDecimalSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDecimalSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region double
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, double>> propertyNameExpression, NumericFilterType filterType, double filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DoubleCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, double filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DoubleCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, double>> propertyNameExpression, SetFilterType filterType, IEnumerable<double> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DoubleSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<double> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new DoubleSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, double?>> propertyNameExpression, NumericFilterType filterType, double? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDoubleCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, double? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDoubleCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, double?>> propertyNameExpression, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDoubleSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableDoubleSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region float
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, float>> propertyNameExpression, NumericFilterType filterType, float filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new FloatCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, float filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new FloatCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, float>> propertyNameExpression, SetFilterType filterType, IEnumerable<float> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new FloatSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<float> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new FloatSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, float?>> propertyNameExpression, NumericFilterType filterType, float? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableFloatCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, float? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableFloatCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, float?>> propertyNameExpression, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableFloatSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableFloatSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region int
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, int>> propertyNameExpression, NumericFilterType filterType, int filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new IntegerCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, int filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new IntegerCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, int>> propertyNameExpression, SetFilterType filterType, IEnumerable<int> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new IntegerSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<int> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new IntegerSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, int?>> propertyNameExpression, NumericFilterType filterType, int? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableIntegerCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, int? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableIntegerCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, int?>> propertyNameExpression, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableIntegerSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableIntegerSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region long
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, long>> propertyNameExpression, NumericFilterType filterType, long filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new LongCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, long filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new LongCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, long>> propertyNameExpression, SetFilterType filterType, IEnumerable<long> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new LongSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<long> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new LongSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, long?>> propertyNameExpression, NumericFilterType filterType, long? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableLongCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, long? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableLongCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, long?>> propertyNameExpression, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableLongSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableLongSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region short
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, short>> propertyNameExpression, NumericFilterType filterType, short filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new ShortCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, short filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new ShortCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, short>> propertyNameExpression, SetFilterType filterType, IEnumerable<short> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new ShortSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<short> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new ShortSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, short?>> propertyNameExpression, NumericFilterType filterType, short? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableShortCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, NumericFilterType filterType, short? filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableShortCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, short?>> propertyNameExpression, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableShortSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new NullableShortSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region string
    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, string>> propertyNameExpression, StringFilterType filterType, string filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new StringCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, StringFilterType filterType, string filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new StringCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, Expression<Func<TFilterableObject, string>> propertyNameExpression, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new StringSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static SimpleFilterBuilder<TFilterableObject> Where<TFilterableObject>(this FilterBuilder<TFilterableObject> filterBuilderBase, string propertyName, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterableObject : class, IFilterable
    {
      return filterBuilderBase.Where(new StringSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion
  }
}
