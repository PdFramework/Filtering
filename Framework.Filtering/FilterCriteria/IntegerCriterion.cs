namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class IntegerCriterion<TFilterableObject> : NumericCriterionBase<TFilterableObject, int> where TFilterableObject : class, IFilterable
  {
    public IntegerCriterion(string propertyName, NumericFilterType filterType, int filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public IntegerCriterion(Expression<Func<TFilterableObject, int>> propertyNameExpression, NumericFilterType filterType, int filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
