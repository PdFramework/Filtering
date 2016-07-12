namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableLongSetCriterion<TFilterableObject> : NullableNumericSetCriterionBase<TFilterableObject, long?> where TFilterableObject : class, IFilterable
  {
    public NullableLongSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<long?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableLongSetCriterion(Expression<Func<TFilterableObject, long?>> propertyNameExpression, SetFilterType filterType, IEnumerable<long?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
