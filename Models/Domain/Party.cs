using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class Party
    {
        public virtual int Id { get; set; }
        public virtual string PartyName { get; set; }
        public virtual string PartyCode { get; set; }
        public virtual string Description { get; set; }

        
    }
}
