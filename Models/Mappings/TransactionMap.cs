using FluentNHibernate.Mapping;
using Models.Domain;

namespace Models.Mappings
{
    public class TransactionMap : ClassMap<Transaction>
    {
        public TransactionMap() {

            Table("Transactions");
           
            Id(x => x.Id)
                .Column("Id")
                .Not.Nullable()
                .GeneratedBy.Identity();
            Map(x => x.CreateDate);
            Map(x => x.CreatedBy);
            Map(x => x.LastModifyDate);
            Map(x => x.ModifiedBy);
            Map(x => x.Note);
            Map(x => x.PaperDate);
            Map(x => x.Serial);
            Map(x => x.TransactionType);
            Map(x => x.RefNumber);

            HasMany<Entry>(x => x.Entries)
                .KeyColumn("TransactionFk")
                .Cascade.All();
                
        }
    }
}
