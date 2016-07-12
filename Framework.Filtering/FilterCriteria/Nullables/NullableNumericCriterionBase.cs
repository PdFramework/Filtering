using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using PeinearyDevelopment.Framework.Filtering.FilterTypes;

namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  public abstract class NullableNumericCriterionBase<TFilterableObject, TNumeric> : BaseCriterion<TFilterableObject, NumericFilterType, TNumeric> where TFilterableObject : class, IFilterable
  {
    protected NullableNumericCriterionBase(string propertyName, NumericFilterType filterType, TNumeric filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    protected NullableNumericCriterionBase(Expression<Func<TFilterableObject, TNumeric>> propertyNameExpression, NumericFilterType filterType, TNumeric filterValue) : base(propertyNameExpression, filterType, filterValue)
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
