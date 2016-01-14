using System.Collections.Generic;

namespace Models.Domain
{
    public class Party
    {
        public virtual int Id { get; set; }
        public virtual string PartyName { get; set; }
        public virtual string PartyCode { get; set; }
        public virtual string Description { get; set; }
        public virtual decimal TrialBalance { get; set; }

        public virtual IList<Entry> Entries { get; set; }
    }
}
