using System;
using System.Collections.Generic;

namespace Models.Domain
{
    public class Transaction
    {
        public virtual int Id { get; set; }
        public virtual int Serial { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime LastModifyDate { get; set; }
        public virtual DateTime PaperDate { get; set; }
        public virtual string Note { get; set; }
        public virtual IList<Entry> Entries { get; set; }

        public virtual string CreatedBy { get; set; }
        public virtual string ModifiedBy { get; set; }

        public virtual string RefNumber { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
