namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NumericSetCriterion<TFilterable, TNumeric> : SetCriterionBase<TFilterable, TNumeric> where TFilterable : class, IFilterable
                                                                                                    where TNumeric : struct
  {
    public NumericSetCriterion()
    {
    }

    public NumericSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<TNumeric> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NumericSetCriterion(Expression<Func<TFilterable, TNumeric>> propertyNameExpression, SetFilterType filterType, IEnumerable<TNumeric> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
