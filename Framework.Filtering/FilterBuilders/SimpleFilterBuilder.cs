namespace PeinearyDevelopment.Framework.Filtering.FilterBuilders
{
  public class SimpleFilterBuilder<TFilterableObject> : BaseFilterBuilder<TFilterableObject> where TFilterableObject : class, IFilterable
  {
    public SimpleFilterBuilder(BaseFilterBuilder<TFilterableObject> baseFilterBuilder) : base(baseFilterBuilder) { }
  }
}
