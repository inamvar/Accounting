using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class Bank : Party
    {
        public  virtual string  Branch { get; set; }
      
        public virtual string BranchCode { get; set; }
    }
}
