using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class PersonGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public IList<Person> People { get; set; }
    }
}
