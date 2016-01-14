using System;

namespace DataLayer.UnitOfWorks
{
    public interface IGenericTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
