namespace Models.Domain
{
    public class Bank : Party
    {
        public  virtual string  Branch { get; set; }
      
        public virtual string BranchCode { get; set; }
    }
}
