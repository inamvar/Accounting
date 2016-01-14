using System;

namespace Models.Domain
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public Account Account { get; set; }
        public Party Party { get; set; }

    }
}
