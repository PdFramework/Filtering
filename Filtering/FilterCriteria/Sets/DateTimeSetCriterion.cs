namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class DateTimeSetCriterion<TFilterable> : SetCriterionBase<TFilterable, DateTime> where TFilterable : class, IFilterable
  {
    public DateTimeSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<DateTime> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DateTimeSetCriterion(Expression<Func<TFilterable, DateTime>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
