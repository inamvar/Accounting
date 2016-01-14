using System;
using System.Collections.Generic;

namespace Models.Domain
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Serial { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifyDate { get; set; }
        public DateTime PaperDate { get; set; }
        public string Note { get; set; }
        public IList<Entry> Entries { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
