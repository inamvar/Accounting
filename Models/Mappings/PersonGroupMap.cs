using FluentNHibernate.Mapping;
using Models.Domain;

namespace Models.Mappings
{
    public class PersonGroupMap : ClassMap<PersonGroup>
    {
        public PersonGroupMap() {
            Table("PersonGroup");
          
            Id(x => x.Id)
                .Column("Id")
                .Not.Nullable()
                .GeneratedBy.Identity();

            Map(x => x.GroupName);

            HasMany(x => x.People)
                .KeyColumn("GroupFk")
                .Cascade.SaveUpdate();
        }
    }
}
