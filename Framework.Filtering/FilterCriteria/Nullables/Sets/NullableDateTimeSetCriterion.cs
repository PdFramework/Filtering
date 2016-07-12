namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableDateTimeSetCriterion<TFilterableObject> : NullableDateTimeSetCriterionBase<TFilterableObject, DateTime?> where TFilterableObject : class, IFilterable
  {
    public NullableDateTimeSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<DateTime?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDateTimeSetCriterion(Expression<Func<TFilterableObject, DateTime?>> propertyNameExpression, SetFilterType filterType, IEnumerable<DateTime?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
