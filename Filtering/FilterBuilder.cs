namespace PeinearyDevelopment.Framework.Filtering
{
  public class FilterBuilder<TFilterable> : BaseFilterBuilder<TFilterable> where TFilterable : class, IFilterable
  {
    public FilterBuilder()
    {
    }

    public FilterBuilder(BaseFilterBuilder baseFilterBuilder) : base(baseFilterBuilder)
    {
    }
  }
}
