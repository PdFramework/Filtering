namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableShortSetCriterion<TFilterableObject> : NullableNumericSetCriterionBase<TFilterableObject, short?> where TFilterableObject : class, IFilterable
  {
    public NullableShortSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<short?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableShortSetCriterion(Expression<Func<TFilterableObject, short?>> propertyNameExpression, SetFilterType filterType, IEnumerable<short?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
