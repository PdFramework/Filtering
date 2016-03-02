namespace Framework.QueryBuilder.Data.Entity
{
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Mapping;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Linq;

    internal static class ObjectContextAdapterExtensions
    {
        //http://stackoverflow.com/questions/23297670/map-entity-framework-code-properties-to-database-columns-cspace-to-sspace
        internal static DbObjectMapper MapDbProperties<TSearchable>(this IObjectContextAdapter dbContext) where TSearchable : class, IFilterable
        {
            var metadataWorkspace = dbContext.ObjectContext.MetadataWorkspace;
            var oSpaceItemCollection = metadataWorkspace.GetItemCollection(DataSpace.OSpace);
            var entityTypes = oSpaceItemCollection.GetItems<EntityType>();
            var entityContainer = metadataWorkspace.GetItems<EntityContainer>(DataSpace.CSpace).Single();
            var entityMapping = metadataWorkspace.GetItems<EntityContainerMapping>(DataSpace.CSSpace).Single().EntitySetMappings;
            var searchableEntityType = entityTypes.First(entityType => entityType.FullName == typeof (TSearchable).FullName);
            var cSpaceEntitySet = entityContainer.EntitySets.SingleOrDefault(t => t.ElementType.Name == searchableEntityType.Name);
            var sSpaceEntitySet = entityMapping.Single(t => t.EntitySet == cSpaceEntitySet);
            var tableInfo = sSpaceEntitySet.EntityTypeMappings.Single().Fragments.Single();

            return new DbObjectMapper
            {
                DbSchema = tableInfo.StoreEntitySet.Schema,
                DbTableName = string.IsNullOrWhiteSpace(tableInfo.StoreEntitySet.Table) ? tableInfo.StoreEntitySet.Name : tableInfo.StoreEntitySet.Table,
                ObjectPropertyColumnNameMapper = tableInfo.PropertyMappings.OfType<ScalarPropertyMapping>().ToDictionary(pm => pm.Property.Name, pm => pm.Column.Name),
                PrimaryKeyPropertyName = cSpaceEntitySet.ElementType.KeyMembers.Select(k => k.Name).First()
            };
        }
    }
}
