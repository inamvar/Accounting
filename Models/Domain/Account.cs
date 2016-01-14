using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Domain
{
    public class Account 
    {

        public Account() {
            this._childeren = new List<Account>();
        }
            
        public virtual int Id { get; set; }
        public virtual int AccountCode  { get; set; }
        public virtual string AccountName { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual long TrialBalance { get; set; }
        public virtual Account Parent { get; set; }

        private IList<Account> _childeren;
        public virtual IList<Account> Childeren {
            get {
                return this._childeren;
            }
            set
            {
                this._childeren = value;
            }
        }

      
        public virtual string ToString(string tab ="")
        {
            string str = "";
            if (this.Parent == null)
            {
                str += string.Format("{0} {1}\n", this.AccountCode, this.AccountName);
            }
            else {
                tab += "\t";
                str += string.Format("{0} {1} {2}\n", tab, this.AccountCode, this.AccountName);
            }
            foreach (var child in this._childeren)
            {
               str += child.ToString(tab);
            }

            return str;
        }

    }
}
