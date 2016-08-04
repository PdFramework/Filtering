namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using Newtonsoft.Json;
  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public abstract class BaseCriterion
  {
    [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public object FilterType { get; set; }
    [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public object FilterValue { get; set; }

    internal abstract string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex);
    //TODO: investigate using IEnumerable<DbParameter> as type
    internal abstract IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex);
    [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public string PropertyName { get; internal set; }

  }

  public class BaseCriterion<TFilterable, TFilterType, TFilterValue> : BaseCriterion where TFilterable : class, IFilterable
  {
    [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public new TFilterType FilterType { get; set; }
    [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public new TFilterValue FilterValue { get; set; }

    public BaseCriterion()
    {
    }

    public BaseCriterion(string propertyName, TFilterType filterType, TFilterValue filterValue)
    {
      PropertyName = propertyName;
      FilterType = filterType;
      FilterValue = filterValue;
    }

    public BaseCriterion(Expression<Func<TFilterable, TFilterValue>> propertyNameExpression, TFilterType filterType, TFilterValue filterValue) : this(Utilities.GetPropertyName(typeof(TFilterable), propertyNameExpression), filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex) { throw new NotImplementedException($"The library is unaware of how to turn {PropertyName} of type {typeof(TFilterValue)} into a where clause."); }
    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex) { throw new NotImplementedException(); }
  }

  public class BaseCriterion<TFilterable, TFilterableProperty, TFilterType, TFilterValue> : BaseCriterion where TFilterable : class, IFilterable
                                                                                                          where TFilterValue : IEnumerable<TFilterableProperty>
  {
    [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public new TFilterType FilterType { get; set; }
    [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public new TFilterValue FilterValue { get; set; }

    public BaseCriterion()
    {
    }

    public BaseCriterion(string propertyName, TFilterType filterType, TFilterValue filterValue)
    {
      PropertyName = propertyName;
      FilterType = filterType;
      FilterValue = filterValue;
    }

    public BaseCriterion(Expression<Func<TFilterable, TFilterableProperty>> propertyNameExpression, TFilterType filterType, TFilterValue filterValue) : this(Utilities.GetPropertyName(typeof(TFilterable), propertyNameExpression), filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex) { throw new NotImplementedException($"The library is unaware of how to turn {PropertyName} of type {typeof(TFilterValue)} into a where clause."); }
    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex) { throw new NotImplementedException(); }
  }
}
