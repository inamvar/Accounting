using FluentNHibernate.Mapping;
using Models.Domain;

namespace Models.Mappings
{
    public class PartyMap: ClassMap<Party>
    {
        public PartyMap() {


            Table("Parties");

            // the Id function is used for identity
            // key mapping, it is possible to specify the type 
            // of the property, its access, the name
            // of the field in the table and its server type, 
            // facets and other mapping settings,
            // as well as to specify the class name to be used to 
            // generate the primary key for a new
            // record while saving a new record
            Id(x => x.Id)
                .Column("Id")           
                .Not.Nullable()           
                .GeneratedBy.Identity();

            Map(q => q.Description);
            Map(q => q.PartyCode);
            Map(q => q.PartyName);
            Map(q => q.TrialBalance);

            HasMany<Entry>(x => x.Entries)
                .KeyColumn("PartyFk")
                .LazyLoad()
                .Cascade.SaveUpdate();
        }
    }
}
