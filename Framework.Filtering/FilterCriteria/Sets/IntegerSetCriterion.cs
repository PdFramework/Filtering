namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class IntegerSetCriterion<TFilterableObject> : NumericSetCriterionBase<TFilterableObject, int> where TFilterableObject : class, IFilterable
  {
    public IntegerSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<int> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public IntegerSetCriterion(Expression<Func<TFilterableObject, int>> propertyNameExpression, SetFilterType filterType, IEnumerable<int> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
