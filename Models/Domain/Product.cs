namespace Models.Domain
{
    public class Product
    {

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Category { get; set; }
        public virtual int Price { get; set; }

    }
}
