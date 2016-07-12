namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class StringSetCriterion<TFilterableObject> : SetCriterionBase<TFilterableObject, string> where TFilterableObject : class, IFilterable
  {
    public StringSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<string> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public StringSetCriterion(Expression<Func<TFilterableObject, string>> propertyNameExpression, SetFilterType filterType, IEnumerable<string> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
