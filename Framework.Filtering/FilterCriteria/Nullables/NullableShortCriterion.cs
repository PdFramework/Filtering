namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableShortCriterion<TFilterableObject> : NullableNumericCriterionBase<TFilterableObject, short?> where TFilterableObject : class, IFilterable
  {
    public NullableShortCriterion(string propertyName, NumericFilterType filterType, short? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableShortCriterion(Expression<Func<TFilterableObject, short?>> propertyNameExpression, NumericFilterType filterType, short? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
