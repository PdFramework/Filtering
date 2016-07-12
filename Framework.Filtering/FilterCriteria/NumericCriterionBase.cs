namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public abstract class NumericCriterionBase<TFilterableObject, TNumeric> : BaseCriterion<TFilterableObject, NumericFilterType, TNumeric> where TFilterableObject : class, IFilterable
  {
    protected NumericCriterionBase(string propertyName, NumericFilterType filterType, TNumeric filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    protected NumericCriterionBase(Expression<Func<TFilterableObject, TNumeric>> propertyNameExpression, NumericFilterType filterType, TNumeric filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      throw new System.NotImplementedException();
    }

    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
    {
      throw new System.NotImplementedException();
    }
  }
}
