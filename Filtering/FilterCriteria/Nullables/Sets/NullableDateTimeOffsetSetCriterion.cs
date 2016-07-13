namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableDateTimeOffsetSetCriterion<TFilterable> : NullableSetCriterionBase<TFilterable, DateTimeOffset?> where TFilterable : class, IFilterable
  {
    public NullableDateTimeOffsetSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDateTimeOffsetSetCriterion(Expression<Func<TFilterable, DateTimeOffset?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTimeOffset?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
