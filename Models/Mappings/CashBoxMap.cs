using FluentNHibernate.Mapping;
using Models.Domain;

namespace Models.Mappings
{
    public class CashBoxMap: SubclassMap<CashBox>
    {
        public CashBoxMap() {

            Table("CashBoxes");
            KeyColumn("Id");

            Map(x => x.Address);
            Map(x => x.BoxNumber);
           

        }
    }
}
