using System;

namespace Services
{
    public class EntityEventArgs<T> :EventArgs
    {

        public T Entity { get; set; }
    }
}
