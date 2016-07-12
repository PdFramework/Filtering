namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableIntegerCriterion<TFilterableObject> : NullableNumericCriterionBase<TFilterableObject, int?> where TFilterableObject : class, IFilterable
  {
    public NullableIntegerCriterion(string propertyName, NumericFilterType filterType, int? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableIntegerCriterion(Expression<Func<TFilterableObject, int?>> propertyNameExpression, NumericFilterType filterType, int? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
