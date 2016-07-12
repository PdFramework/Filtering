namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableIntegerSetCriterion<TFilterableObject> : NullableNumericSetCriterionBase<TFilterableObject, int?> where TFilterableObject : class, IFilterable
  {
    public NullableIntegerSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<int?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableIntegerSetCriterion(Expression<Func<TFilterableObject, int?>> propertyNameExpression, SetFilterType filterType, IEnumerable<int?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
