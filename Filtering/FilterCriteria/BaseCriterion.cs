namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public abstract class BaseCriterion
  {
    public object FilterType { get; set; }
    public object FilterValue { get; set; }

    internal abstract string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex);
    //TODO: investigate using IEnumerable<DbParameter> as type
    internal abstract IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex);
    internal string PropertyName { get; set; }
  }

  public class BaseCriterion<TFilterable, TFilterType, TFilterValue> : BaseCriterion where TFilterable : class, IFilterable
  {
    public new TFilterType FilterType { get; set; }
    public new TFilterValue FilterValue { get; set; }

    public BaseCriterion(string propertyName, TFilterType filterType, TFilterValue filterValue)
    {
      PropertyName = propertyName;
      FilterType = filterType;
      FilterValue = filterValue;
    }
    public BaseCriterion(Expression<Func<TFilterable, TFilterValue>> propertyNameExpression, TFilterType filterType, TFilterValue filterValue) : this(Utilities.GetPropertyName(typeof(TFilterable), propertyNameExpression), filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex) { throw new NotImplementedException(); }
    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex) { throw new NotImplementedException(); }
  }

  public class BaseCriterion<TFilterable, TFilterableProperty, TFilterType, TFilterValue> : BaseCriterion where TFilterable : class, IFilterable
                                                                                                          where TFilterValue : IEnumerable<TFilterableProperty>
  {
    public new TFilterType FilterType { get; set; }
    public new TFilterValue FilterValue { get; set; }

    public BaseCriterion(string propertyName, TFilterType filterType, TFilterValue filterValue)
    {
      PropertyName = propertyName;
      FilterType = filterType;
      FilterValue = filterValue;
    }

    public BaseCriterion(Expression<Func<TFilterable, TFilterableProperty>> propertyNameExpression, TFilterType filterType, TFilterValue filterValue) : this(Utilities.GetPropertyName(typeof(TFilterable), propertyNameExpression), filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex) { throw new NotImplementedException(); }
    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex) { throw new NotImplementedException(); }
  }
}
