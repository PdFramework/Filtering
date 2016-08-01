namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableDecimalCriterion<TFilterable> : NullableNumericCriterionBase<TFilterable, decimal?> where TFilterable : class, IFilterable
  {
    public NullableDecimalCriterion()
    {
    }

    public NullableDecimalCriterion(string propertyName, NumericFilterType filterType, decimal? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDecimalCriterion(Expression<Func<TFilterable, decimal?>> propertyNameExpression, NumericFilterType filterType, decimal? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
