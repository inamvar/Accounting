using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UnitOfWorks
{
    public interface IUnitOfWorkImplementor : IUnitOfWork
    {
        void IncrementUsages();
    }
}
