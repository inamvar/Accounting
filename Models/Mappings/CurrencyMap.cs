using FluentNHibernate.Mapping;
using Models.Common;

namespace Models.Mappings
{
   public  class CurrencyMap : ClassMap<Currency>
    {
        public CurrencyMap() {
            Table("Currencies");
            Id(x => x.Id)
             .Column("Id")
             .Not.Nullable()
             .GeneratedBy.Identity();

            Map(x => x.Country);
            Map(x => x.CurrencyName);
            Map(x => x.Rate);
            Map(x => x.Sign);
        }
    }
}
