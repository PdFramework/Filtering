namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class DoubleCriterion<TFilterable> : NumericCriterionBase<TFilterable, double> where TFilterable : class, IFilterable
  {
    public DoubleCriterion(string propertyName, NumericFilterType filterType, double filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DoubleCriterion(Expression<Func<TFilterable, double>> propertyNameExpression, NumericFilterType filterType, double filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
