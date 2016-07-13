namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class DoubleSetCriterion<TFilterable> : SetCriterionBase<TFilterable, double> where TFilterable : class, IFilterable
  {
    public DoubleSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<double> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DoubleSetCriterion(Expression<Func<TFilterable, double>> propertyNameExpression, SetFilterType filterType, IEnumerable<double> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
