namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class DecimalCriterion<TFilterable> : NumericCriterionBase<TFilterable, decimal> where TFilterable : class, IFilterable
  {
    public DecimalCriterion()
    {
    }

    public DecimalCriterion(string propertyName, NumericFilterType filterType, decimal filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DecimalCriterion(Expression<Func<TFilterable, decimal>> propertyNameExpression, NumericFilterType filterType, decimal filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
