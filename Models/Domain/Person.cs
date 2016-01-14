using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class Person : Party
    {

        public virtual Gender Gender { get; set; }
        public virtual PersonType PersonType { get; set; }
        public virtual string RegisteredId { get; set; }
        public virtual string Address { get; set; }
        public virtual string Phone { get; set; }
        public virtual string Phone2 { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Mobile2 { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
        public virtual string Email2 { get; set; }
        public virtual bool IsBlocked { get; set; }
        public virtual  PersonGroup Group { get; set; }
        public byte[] Image { get; set; }

    }
}
