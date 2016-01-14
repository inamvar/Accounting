using DataLayer.Repository;
using System;
using System.Collections.Generic;

namespace Services
{
    public interface IService<T> : IDisposable
    {

       
        IRepository<T> Repository { get; set; }
        T Save(T entity);
        T SaveOrUpdate(T entity);
        void Delete(object id);
        void Delete(T entity);
        T Get(object id);       
        bool Exists(object id);
        ICollection<T> FindAll(string orderField);

        ICollection<T> FindByProperty(string propertyName, object value);
    }
}
