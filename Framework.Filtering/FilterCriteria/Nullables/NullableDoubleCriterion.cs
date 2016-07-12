namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableDoubleCriterion<TFilterableObject> : NullableNumericCriterionBase<TFilterableObject, double?> where TFilterableObject : class, IFilterable
  {
    public NullableDoubleCriterion(string propertyName, NumericFilterType filterType, double? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDoubleCriterion(Expression<Func<TFilterableObject, double?>> propertyNameExpression, NumericFilterType filterType, double? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
