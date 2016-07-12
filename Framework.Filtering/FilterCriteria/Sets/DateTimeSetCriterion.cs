namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class DateTimeSetCriterion<TFilterableObject> : DateTimeSetCriterionBase<TFilterableObject, DateTime> where TFilterableObject : class, IFilterable
  {
    public DateTimeSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<DateTime> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DateTimeSetCriterion(Expression<Func<TFilterableObject, DateTime>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
