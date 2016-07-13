namespace PeinearyDevelopment.Framework.Filtering.Data.Entity
{
  using System.Collections.Generic;
  using System.Data.Entity.Infrastructure;
  using System.Text;

  internal class Filter<TFilterable> where TFilterable : class, IFilterable
  {
    public Filter()
    {
      Parameters = new List<object>();
      SqlQueryStringBuilder = new StringBuilder();
    }

    public Filter(IObjectContextAdapter dbContext, BaseFilterBuilder<TFilterable> filterCriteria) : this()
    {
      DbObjectMapper = dbContext.MapDbProperties<TFilterable>();

      this.CreateSelect()
          .CreateFrom()
          .CreateWhere(dbContext, filterCriteria)
          .CreateOrderBy(filterCriteria)
          .CreateOffset(filterCriteria);
    }

    public Filter(DbObjectMapper dbObjectMapper) : this()
    {
      DbObjectMapper = dbObjectMapper;
    }

    public DbObjectMapper DbObjectMapper { get; set; }
    public StringBuilder SqlQueryStringBuilder { get; set; }
    public List<object> Parameters { get; set; }
  }
}
