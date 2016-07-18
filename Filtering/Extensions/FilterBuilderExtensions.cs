namespace PeinearyDevelopment.Framework.Filtering.Extensions
{
  using System;
  using System.Linq.Expressions;

  public static class FilterBuilderExtensions
  {
    public static BaseFilterBuilder ReturnAllResults(this BaseFilterBuilder filterBuilder)
    {
      if (filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.ReturnAllResults = true;
      return filterBuilder;
    }

    public static BaseFilterBuilder<TFilterable> ReturnAllResults<TFilterable>(this BaseFilterBuilder<TFilterable> filterBuilder) where TFilterable : class, IFilterable
    {
      if(filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.ReturnAllResults = true;
      return filterBuilder;
    }

    public static BaseFilterBuilder Take(this BaseFilterBuilder filterBuilder, int numberToTake)
    {
      if (filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.PageSize = numberToTake;
      return filterBuilder;
    }

    public static BaseFilterBuilder<TFilterable> Take<TFilterable>(this BaseFilterBuilder<TFilterable> filterBuilder, int numberToTake) where TFilterable : class, IFilterable
    {
      if(filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.PageSize = numberToTake;
      return filterBuilder;
    }

    public static BaseFilterBuilder SkipPages(this BaseFilterBuilder filterBuilder, int pagesToSkip)
    {
      if (filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.PageIndex = pagesToSkip;
      return filterBuilder;
    }

    public static BaseFilterBuilder<TFilterable> SkipPages<TFilterable>(this BaseFilterBuilder<TFilterable> filterBuilder, int pagesToSkip) where TFilterable : class, IFilterable
    {
      if (filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.PageIndex = pagesToSkip;
      return filterBuilder;
    }

    public static BaseFilterBuilder IncludeTotalCount(this BaseFilterBuilder filterBuilder)
    {
      if (filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.IncludeTotalCountWithResults = true;
      return filterBuilder;
    }

    public static BaseFilterBuilder<TFilterable> IncludeTotalCount<TFilterable>(this BaseFilterBuilder<TFilterable> filterBuilder) where TFilterable : class, IFilterable
    {
      if (filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.IncludeTotalCountWithResults = true;
      return filterBuilder;
    }

    public static BaseFilterBuilder<TFilterable> OrderBy<TFilterable>(this BaseFilterBuilder<TFilterable> filterBuilder, string propertyName) where TFilterable : class, IFilterable
    {
      return filterBuilder.OrderBy(propertyName, SortType.Ascending);
    }

    public static BaseFilterBuilder<TFilterable> OrderBy<TFilterable>(this BaseFilterBuilder<TFilterable> filterBuilder, string propertyName, SortType sortType) where TFilterable : class, IFilterable
    {
      if (filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.SortCriteria.Add(new SortCriterion(propertyName, sortType));
      return filterBuilder;
    }

    public static BaseFilterBuilder<TFilterable> OrderBy<TFilterable, TSearchableProperty>(this BaseFilterBuilder<TFilterable> filterBuilder, Expression<Func<TFilterable, TSearchableProperty>> propertyNameExpression) where TFilterable : class, IFilterable
    {
      return filterBuilder.OrderBy(propertyNameExpression, SortType.Ascending);
    }

    public static BaseFilterBuilder<TFilterable> OrderBy<TFilterable, TSearchableProperty>(this BaseFilterBuilder<TFilterable> filterBuilder, Expression<Func<TFilterable, TSearchableProperty>> propertyNameExpression, SortType sortType) where TFilterable : class, IFilterable
    {
      if (filterBuilder == null) throw new ArgumentNullException(nameof(filterBuilder));

      filterBuilder.SortCriteria.Add(new SortCriterion(Utilities.GetPropertyName(typeof(TFilterable), propertyNameExpression), sortType));
      return filterBuilder;
    }
  }
}
