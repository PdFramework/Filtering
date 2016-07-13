namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableFloatCriterion<TFilterable> : NullableNumericCriterionBase<TFilterable, float?> where TFilterable : class, IFilterable
  {
    public NullableFloatCriterion(string propertyName, NumericFilterType filterType, float? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableFloatCriterion(Expression<Func<TFilterable, float?>> propertyNameExpression, NumericFilterType filterType, float? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
