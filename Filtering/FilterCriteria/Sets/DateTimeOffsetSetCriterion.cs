namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class DateTimeOffsetSetCriterion<TFilterable> : SetCriterionBase<TFilterable, DateTimeOffset> where TFilterable : class, IFilterable
  {
    public DateTimeOffsetSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DateTimeOffsetSetCriterion(Expression<Func<TFilterable, DateTimeOffset>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
