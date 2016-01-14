namespace Models.Domain
{
    public class CashBox : Party
    {
        public virtual int BoxNumber { get; set; }
     
        public virtual string Address { get; set; }

        
    }
}
