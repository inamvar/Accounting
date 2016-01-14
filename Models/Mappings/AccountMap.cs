using FluentNHibernate.Mapping;
using Models.Domain;

namespace Models.Mappings
{
    public class AccountMap : ClassMap<Account>
    {
        public AccountMap() {


            // indicates that this class is the base
            // one for the TPC inheritance strategy and that 
            // the values of its properties should
            // be united with the values of derived classes
            //  UseUnionSubclassForInheritanceMapping();
            Table("Accounts");

            Id(x => x.Id)
            .Column("Id")
            .Not.Nullable()
            .GeneratedBy.Identity();

            Map(q => q.AccountCode);
            Map(q => q.AccountName);
            Map(q => q.Description);
            Map(q => q.IsActive);
            HasMany(q => q.Childeren)
                .KeyColumn("ParentFk")
                .Cascade.All();

            References<Account>(x => x.Parent).Column("ParentFk");



        }
    }
}
