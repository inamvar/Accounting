using Models.Common;
using System;

namespace Models.Domain
{
    public class Entry
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime LastModifyDate { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal Debit { get; set; }
        public virtual decimal Credit { get; set; }

        public virtual Account Account { get; set; }
        public virtual Party Party { get; set; }
        public virtual Transaction Transaction { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
