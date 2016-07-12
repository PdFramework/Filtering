namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class DoubleSetCriterion<TFilterableObject> : NumericSetCriterionBase<TFilterableObject, double> where TFilterableObject : class, IFilterable
  {
    public DoubleSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<double> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DoubleSetCriterion(Expression<Func<TFilterableObject, double>> propertyNameExpression, SetFilterType filterType, IEnumerable<double> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
