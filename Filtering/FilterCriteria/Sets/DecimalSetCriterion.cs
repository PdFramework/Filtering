namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class DecimalSetCriterion<TFilterable> : SetCriterionBase<TFilterable, decimal> where TFilterable : class, IFilterable
  {
    public DecimalSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<decimal> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DecimalSetCriterion(Expression<Func<TFilterable, decimal>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
