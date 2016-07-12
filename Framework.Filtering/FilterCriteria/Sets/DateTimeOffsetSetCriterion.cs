namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class DateTimeOffsetSetCriterion<TFilterableObject> : DateTimeSetCriterionBase<TFilterableObject, DateTimeOffset> where TFilterableObject : class, IFilterable
  {
    public DateTimeOffsetSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DateTimeOffsetSetCriterion(Expression<Func<TFilterableObject, DateTimeOffset>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
