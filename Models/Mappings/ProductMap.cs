using FluentNHibernate.Mapping;
using Models.Domain;

namespace Models.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap() {
            Table("Products");
            Id(x => x.Id);
            Map(x => x.Name).Length(500).Not.Nullable();
            Map(x => x.Price);
            Map(x => x.Category);
        }
    }
}
