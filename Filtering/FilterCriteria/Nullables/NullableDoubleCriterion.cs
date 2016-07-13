namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableDoubleCriterion<TFilterable> : NullableNumericCriterionBase<TFilterable, double?> where TFilterable : class, IFilterable
  {
    public NullableDoubleCriterion(string propertyName, NumericFilterType filterType, double? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDoubleCriterion(Expression<Func<TFilterable, double?>> propertyNameExpression, NumericFilterType filterType, double? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}
