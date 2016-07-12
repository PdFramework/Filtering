namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public class StringCriterion<TFilterableObject> : BaseCriterion<TFilterableObject, StringFilterType, string> where TFilterableObject : class, IFilterable
  {
    public StringCriterion(string propertyName, StringFilterType filterType, string filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public StringCriterion(Expression<Func<TFilterableObject, string>> propertyNameExpression, StringFilterType filterType, string filterValue) : base(propertyNameExpression, filterType, filterValue)
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
