using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
   public class EntityEventArgs<T> :EventArgs
    {

        public T Entity { get; set; }
    }
}
