namespace PeinearyDevelopment.Framework.Filtering.FilterBuilders
{
  using FilterCriteria;
  using FilterTypes;

  using System;
  using System.Collections.Generic;

  public abstract class BaseFilterBuilder<TFilterableObject> where TFilterableObject : class, IFilterable
  {
    internal Type FilterableObjectType { get; set; }
    internal IList<string> SortCriteria { get; set; }
    internal IList<CriteriaGroup> FilterCriteria { get; set; }
    internal IList<CompoundFilterType> FilterCombiners { get; set; }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public bool ReturnAllResults { get; set; }
    public bool IncludeTotalCountWithResults { get; set; }

    protected BaseFilterBuilder()
    {
      FilterableObjectType = typeof(TFilterableObject);
      SortCriteria = new List<string>();
      FilterCriteria = new List<CriteriaGroup>();
      //FilterGroupers?Linkers?Joiners?Combiners?Compounders?
      FilterCombiners = new List<CompoundFilterType>();
    }

    protected BaseFilterBuilder(BaseFilterBuilder<TFilterableObject> baseFilterBuilder)
    {
      if(baseFilterBuilder == null) throw new ArgumentNullException(nameof(baseFilterBuilder));

      FilterCombiners = baseFilterBuilder.FilterCombiners;
      FilterCriteria = baseFilterBuilder.FilterCriteria;
      FilterableObjectType = baseFilterBuilder.FilterableObjectType;
      IncludeTotalCountWithResults = baseFilterBuilder.IncludeTotalCountWithResults;
      PageIndex = baseFilterBuilder.PageIndex;
      PageSize = baseFilterBuilder.PageSize;
      ReturnAllResults = baseFilterBuilder.ReturnAllResults;
      SortCriteria = baseFilterBuilder.SortCriteria;
    }
  }
}
