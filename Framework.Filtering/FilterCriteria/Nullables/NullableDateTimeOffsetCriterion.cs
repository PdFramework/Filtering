namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableDateTimeOffsetCriterion<TFilterableObject> : NullableDateTimeCriterionBase<TFilterableObject, DateTimeOffset?> where TFilterableObject : class, IFilterable
  {
    public NullableDateTimeOffsetCriterion(string propertyName, DateTimeFilterType filterType, DateTimeOffset? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDateTimeOffsetCriterion(Expression<Func<TFilterableObject, DateTimeOffset?>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
