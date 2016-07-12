namespace PeinearyDevelopment.Framework.Filtering.FilterBuilders
{
  public class CompoundFilterBuilder<TFilterableObject> : SimpleFilterBuilder<TFilterableObject> where TFilterableObject : class, IFilterable
  {
    public CompoundFilterBuilder(BaseFilterBuilder<TFilterableObject> baseFilterBuilder) : base(baseFilterBuilder) { }
  }
}
