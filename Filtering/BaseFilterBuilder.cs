namespace PeinearyDevelopment.Framework.Filtering
{
  using FilterCriteria;

  using System;
  using System.Collections.Generic;
  using Newtonsoft.Json;

  public abstract class BaseFilterBuilder
  {
    public IList<SortCriterion> SortCriteria { get; }
    [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public CriteriaGroup FilterCriteria { get; set; }
    //public int PageIndex { get; set; }
    //public int PageSize { get; set; }
    public int Take { get; set; }
        public int Skip { get; set; }
    public bool ReturnAllResults { get; set; }
    public bool IncludeTotalCountWithResults { get; set; }

    protected BaseFilterBuilder()
    {
      SortCriteria = new List<SortCriterion>();
      FilterCriteria = new CriteriaGroup();
      //PageIndex = 0;
      //PageSize = 10;
        Skip = 0;
        Take = 10;
    }

    protected BaseFilterBuilder(BaseFilterBuilder baseFilterBuilder)
    {
      if (baseFilterBuilder == null) throw new ArgumentNullException(nameof(baseFilterBuilder));

      FilterCriteria = baseFilterBuilder.FilterCriteria;
      IncludeTotalCountWithResults = baseFilterBuilder.IncludeTotalCountWithResults;
      //PageIndex = baseFilterBuilder.PageIndex;
      //PageSize = baseFilterBuilder.PageSize;
        Take = baseFilterBuilder.Take;
        Skip = baseFilterBuilder.Skip;
      ReturnAllResults = baseFilterBuilder.ReturnAllResults;
      SortCriteria = baseFilterBuilder.SortCriteria;
    }
  }

  public abstract class BaseFilterBuilder<TFilterable> : BaseFilterBuilder where TFilterable : class, IFilterable
  {
    internal Type FilterableObjectType { get; set; }

    protected BaseFilterBuilder()
    {
      FilterableObjectType = typeof(TFilterable);
    }

    protected BaseFilterBuilder(BaseFilterBuilder baseFilterBuilder) : base(baseFilterBuilder)
    {
      FilterableObjectType = typeof(TFilterable);
    }

    protected BaseFilterBuilder(BaseFilterBuilder<TFilterable> baseFilterBuilder) : base(baseFilterBuilder)
    {
      FilterableObjectType = baseFilterBuilder.FilterableObjectType;
    }
  }
}
