using System.Collections.Generic;

namespace Models.Domain
{
    public class PersonGroup
    {
        public virtual int Id { get; set; }
        public virtual string GroupName { get; set; }
        public virtual IList<Person> People { get; set; }
    }
}
