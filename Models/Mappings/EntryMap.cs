using FluentNHibernate.Mapping;
using Models.Common;
using Models.Domain;

namespace Models.Mappings
{
    public class EntryMap : ClassMap<Entry>
    {
        public EntryMap()
        {
            Table("Entries");
            Id(x => x.Id)
                .Column("Id")
                .Not.Nullable()
                .GeneratedBy.Identity();
            Map(x => x.Debit);
            Map(x => x.Credit);
            Map(x => x.CreateDate);
            Map(x => x.CreatedBy);
            Map(x => x.Description);
            Map(x => x.LastModifyDate);
            Map(x => x.ModifiedBy);

            References<Account>(x => x.Account).Column("AccountFk");
            References<Transaction>(x => x.Transaction).Column("TransactionFk");
            References<Party>(x => x.Party).Column("PartyFk");
            References<Currency>(x => x.Currency).Column("CurrencyFk");

        }
    }
}
