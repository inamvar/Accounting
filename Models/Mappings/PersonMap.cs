using FluentNHibernate.Mapping;
using Models.Domain;

namespace Models.Mappings
{
    public class PersonMap : SubclassMap<Person>
    {
        public PersonMap() {
            Table("People");
            KeyColumn("Id");
            Map(x => x.Address);
            Map(x => x.Email);
            Map(x => x.Email2);
            Map(x => x.Fax);
            Map(x => x.Gender);
            Map(x => x.Image);
            Map(x => x.IsBlocked);
            Map(x => x.Mobile);
            Map(x => x.Mobile2);
            Map(x => x.PersonType);
            Map(x => x.Phone);
            Map(x => x.Phone2);
            Map(x => x.RegisteredId);

            References<PersonGroup>(x => x.Group)
                .Column("GroupFk");

        }
    }
}
