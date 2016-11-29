namespace PeinearyDevelopment.Framework.Filtering.Data.Entity
{
    using Filtering;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;

    internal class Filter<TFilterable> where TFilterable : class, IFilterable
    {
        public Filter()
        {
          Parameters = new List<object>();
          SqlQueryStringBuilder = new StringBuilder();
        }

        public Filter(DbContext dbContext, BaseFilterBuilder<TFilterable> filterCriteria) : this()
        {
          DbObjectMapper = dbContext.MapDbProperties<TFilterable>();

          var versionSupportsFetch = ServerHasFetchSupport(dbContext);

          if(versionSupportsFetch || filterCriteria.ReturnAllResults)
          {
              this.CreateSelect()
                  .CreateFrom()
                  .CreateWhere(dbContext, filterCriteria)
                  .CreateOrderBy(filterCriteria)
                  .CreateOffset(filterCriteria);
          }
          else
          {
                this.CreateSelect()
                    .CreatePaginationFrom(dbContext, filterCriteria);
          }
        }

        public Filter(DbObjectMapper dbObjectMapper) : this()
        {
          DbObjectMapper = dbObjectMapper;
        }

        public DbObjectMapper DbObjectMapper { get; set; }
        public StringBuilder SqlQueryStringBuilder { get; set; }
        public List<object> Parameters { get; set; }

        private static bool ServerHasFetchSupport(DbContext dbContext)
        {
            dbContext.Database.Connection.Open();
            var version = dbContext.Database.Connection.ServerVersion;
            dbContext.Database.Connection.Close();

            var versionSegments = version.Split('.');
            int versionInteger;
            return int.TryParse(versionSegments.First(), out versionInteger) && versionInteger >= 11;
        }
    }
}
