namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableDateTimeSetCriterion<TFilterable> : NullableSetCriterionBase<TFilterable, DateTime?> where TFilterable : class, IFilterable
  {
    public NullableDateTimeSetCriterion()
    {
    }

    public NullableDateTimeSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<DateTime?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDateTimeSetCriterion(Expression<Func<TFilterable, DateTime?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
