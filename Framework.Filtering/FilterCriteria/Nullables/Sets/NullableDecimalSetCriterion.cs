namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableDecimalSetCriterion<TFilterableObject> : NullableNumericSetCriterionBase<TFilterableObject, decimal?> where TFilterableObject : class, IFilterable
  {
    public NullableDecimalSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<decimal?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDecimalSetCriterion(Expression<Func<TFilterableObject, decimal?>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
