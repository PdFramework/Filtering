namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class DecimalCriterion<TFilterableObject> : NumericCriterionBase<TFilterableObject, decimal> where TFilterableObject : class, IFilterable
  {
    public DecimalCriterion(string propertyName, NumericFilterType filterType, decimal filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DecimalCriterion(Expression<Func<TFilterableObject, decimal>> propertyNameExpression, NumericFilterType filterType, decimal filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
