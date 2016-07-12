namespace PeinearyDevelopment.Framework.Filtering.FilterBuilders.Extensions
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

  public static class FilterBuilderAndExtensions
  {
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, BaseCriterion filterCriterion) where TFilterableObject : class, IFilterable
    {
      var compoundFilterBuilder = new CompoundFilterBuilder<TFilterableObject>(simpleFilterBuilder);
      compoundFilterBuilder.FilterCriteria.Last().Criteria.Add(new CriteriaGroup(filterCriterion));
      compoundFilterBuilder.FilterCriteria.Last().CompoundFilterTypes.Add(CompoundFilterType.And);
      return compoundFilterBuilder;
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, IList<CompoundFilterType> compoundFilterTypes, params BaseCriterion[] criteria) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new CriteriaGroup(criteria, compoundFilterTypes));
    }

    #region bool
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, bool>> propertyNameExpression, BooleanFilterType filterType, bool filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new BooleanCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, BooleanFilterType filterType, bool filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new BooleanCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, bool?>> propertyNameExpression, BooleanFilterType filterType, bool? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableBooleanCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, BooleanFilterType filterType, bool? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableBooleanCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTime
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, DateTime>> propertyNameExpression, DateTimeFilterType filterType, DateTime filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTime filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, DateTime>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTime> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, DateTime?>> propertyNameExpression, DateTimeFilterType filterType, DateTime? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTime? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, DateTime?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTime?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region DateTimeOffset
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, DateTimeOffset>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeOffsetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTimeOffset filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeOffsetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, DateTimeOffset>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeOffsetSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DateTimeOffsetSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, DateTimeOffset?>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeOffsetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, DateTimeFilterType filterType, DateTimeOffset? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeOffsetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, DateTimeOffset?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeOffsetSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDateTimeOffsetSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region decimal
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, decimal>> propertyNameExpression, NumericFilterType filterType, decimal filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DecimalCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, decimal filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DecimalCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, decimal>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DecimalSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<decimal> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DecimalSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, decimal?>> propertyNameExpression, NumericFilterType filterType, decimal? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDecimalCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, decimal? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDecimalCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, decimal?>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDecimalSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<decimal?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDecimalSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region double
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, double>> propertyNameExpression, NumericFilterType filterType, double filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DoubleCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, double filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DoubleCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, double>> propertyNameExpression, SetFilterType filterType, IEnumerable<double> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DoubleSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<double> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new DoubleSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, double?>> propertyNameExpression, NumericFilterType filterType, double? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDoubleCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, double? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDoubleCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, double?>> propertyNameExpression, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDoubleSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<double?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableDoubleSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region float
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, float>> propertyNameExpression, NumericFilterType filterType, float filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new FloatCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, float filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new FloatCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, float>> propertyNameExpression, SetFilterType filterType, IEnumerable<float> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new FloatSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<float> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new FloatSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, float?>> propertyNameExpression, NumericFilterType filterType, float? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableFloatCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, float? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableFloatCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, float?>> propertyNameExpression, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableFloatSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<float?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableFloatSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region int
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, int>> propertyNameExpression, NumericFilterType filterType, int filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new IntegerCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, int filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new IntegerCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, int>> propertyNameExpression, SetFilterType filterType, IEnumerable<int> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new IntegerSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<int> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new IntegerSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, int?>> propertyNameExpression, NumericFilterType filterType, int? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableIntegerCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, int? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableIntegerCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, int?>> propertyNameExpression, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableIntegerSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<int?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableIntegerSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region long
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, long>> propertyNameExpression, NumericFilterType filterType, long filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new LongCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, long filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new LongCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, long>> propertyNameExpression, SetFilterType filterType, IEnumerable<long> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new LongSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<long> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new LongSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, long?>> propertyNameExpression, NumericFilterType filterType, long? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableLongCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, long? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableLongCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, long?>> propertyNameExpression, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableLongSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<long?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableLongSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region short
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, short>> propertyNameExpression, NumericFilterType filterType, short filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new ShortCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, short filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new ShortCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, short>> propertyNameExpression, SetFilterType filterType, IEnumerable<short> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new ShortSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<short> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new ShortSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, short?>> propertyNameExpression, NumericFilterType filterType, short? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableShortCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, NumericFilterType filterType, short? filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableShortCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, short?>> propertyNameExpression, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableShortSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<short?> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new NullableShortSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion

    #region string
    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, string>> propertyNameExpression, StringFilterType filterType, string filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new StringCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, StringFilterType filterType, string filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new StringCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, Expression<Func<TFilterableObject, string>> propertyNameExpression, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new StringSetCriterion<TFilterableObject>(propertyNameExpression, filterType, filterValue));
    }

    public static CompoundFilterBuilder<TFilterableObject> And<TFilterableObject>(this SimpleFilterBuilder<TFilterableObject> simpleFilterBuilder, string propertyName, SetFilterType filterType, IEnumerable<string> filterValue) where TFilterableObject : class, IFilterable
    {
      return simpleFilterBuilder.And(new StringSetCriterion<TFilterableObject>(propertyName, filterType, filterValue));
    }
    #endregion
  }
}
