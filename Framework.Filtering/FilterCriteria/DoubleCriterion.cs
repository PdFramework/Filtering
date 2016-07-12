namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class DoubleCriterion<TFilterableObject> : NumericCriterionBase<TFilterableObject, double> where TFilterableObject : class, IFilterable
  {
    public DoubleCriterion(string propertyName, NumericFilterType filterType, double filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DoubleCriterion(Expression<Func<TFilterableObject, double>> propertyNameExpression, NumericFilterType filterType, double filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
