namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableDateTimeOffsetCriterion<TFilterable> : NullableDateTimeCriterionBase<TFilterable, DateTimeOffset?> where TFilterable : class, IFilterable
  {
    public NullableDateTimeOffsetCriterion()
    {
    }

    public NullableDateTimeOffsetCriterion(string propertyName, DateTimeFilterType filterType, DateTimeOffset? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDateTimeOffsetCriterion(Expression<Func<TFilterable, DateTimeOffset?>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
