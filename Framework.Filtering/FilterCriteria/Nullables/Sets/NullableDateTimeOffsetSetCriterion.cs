namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableDateTimeOffsetSetCriterion<TFilterableObject> : NullableDateTimeSetCriterionBase<TFilterableObject, DateTimeOffset?> where TFilterableObject : class, IFilterable
  {
    public NullableDateTimeOffsetSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDateTimeOffsetSetCriterion(Expression<Func<TFilterableObject, DateTimeOffset?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
