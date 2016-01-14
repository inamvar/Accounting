using FluentNHibernate.Mapping;
using Models.Domain;

namespace Models.Mappings
{
    public  class BankMap : SubclassMap<Bank>
    {

        public BankMap() {

            Table("Banks");
            KeyColumn("Id");
            Map(x => x.Branch);
            Map(x => x.BranchCode);
            
        }
    }
}
