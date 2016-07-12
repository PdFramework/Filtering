namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableFloatCriterion<TFilterableObject> : NullableNumericCriterionBase<TFilterableObject, float?> where TFilterableObject : class, IFilterable
  {
    public NullableFloatCriterion(string propertyName, NumericFilterType filterType, float? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableFloatCriterion(Expression<Func<TFilterableObject, float?>> propertyNameExpression, NumericFilterType filterType, float? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
