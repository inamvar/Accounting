namespace Models.Common
{
    public class Currency
    {
        public virtual int Id { get; set; }
        public virtual string Country { get; set; }
        public virtual string CurrencyName { get; set; }
        public virtual string Sign { get; set; }
        public virtual int Rate { get; set; }
    }
}
