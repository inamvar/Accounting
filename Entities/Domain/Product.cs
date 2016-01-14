using System;

namespace Entities.Domain
{
    public class Product
    {

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual int Price { get; set; }

    }
}
