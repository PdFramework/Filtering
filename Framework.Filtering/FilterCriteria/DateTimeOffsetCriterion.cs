namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class DateTimeOffsetCriterion<TFilterableObject> : DateTimeCriterionBase<TFilterableObject, DateTimeOffset> where TFilterableObject : class, IFilterable
  {
    public DateTimeOffsetCriterion(string propertyName, DateTimeFilterType filterType, DateTimeOffset filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DateTimeOffsetCriterion(Expression<Func<TFilterableObject, DateTimeOffset>> propertyNameExpression, DateTimeFilterType filterType, DateTimeOffset filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
