namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableDecimalCriterion<TFilterableObject> : NullableNumericCriterionBase<TFilterableObject, decimal?> where TFilterableObject : class, IFilterable
  {
    public NullableDecimalCriterion(string propertyName, NumericFilterType filterType, decimal? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDecimalCriterion(Expression<Func<TFilterableObject, decimal?>> propertyNameExpression, NumericFilterType filterType, decimal? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
