namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public class NullableDateTimeCriterionBase<TFilterableObject, TDateTime> : BaseCriterion<TFilterableObject, DateTimeFilterType, TDateTime> where TFilterableObject : class, IFilterable
  {
    public NullableDateTimeCriterionBase(string propertyName, DateTimeFilterType filterType, TDateTime filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDateTimeCriterionBase(Expression<Func<TFilterableObject, TDateTime>> propertyNameExpression, DateTimeFilterType filterType, TDateTime filterValue) : base(propertyNameExpression, filterType, filterValue)
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
