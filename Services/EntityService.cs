using System;
using System.Collections.Generic;
using DataLayer.Repository;

namespace Services
{
    public class EntityService<T> : IService<T>
    {

        private IRepository<T> _repository;

        public delegate void SavedEventHandler(object sender, EntityEventArgs<T> e);
        public event SavedEventHandler Saved;

        public delegate void DeleteEventHandler(object sender, EntityEventArgs<T> e);
        public event DeleteEventHandler Deleted;


        protected virtual void OnSaved(EntityEventArgs<T> e)
        {
            if (Saved != null)
                Saved(this, e);
        }

        protected virtual void OnDeleted(EntityEventArgs<T> e)
        {
            if (Deleted != null)
                Deleted(this, e);
        }


        public EntityService(IRepository<T> repository) {
            this._repository = repository;
        }


        

        public IRepository<T> Repository
        {
            get
            {
                return this._repository;
            }

            set
            {
                this._repository = value;
            }
        }

        public virtual void Delete(T entity)
        {
            this._repository.Delete(entity);
            var arg = new EntityEventArgs<T>();
            arg.Entity = entity;
            OnDeleted(arg);
        }

        public virtual void Delete(object id)
        {
            var entity = this.Get(id);
            this._repository.Delete(entity);
        }

        public virtual bool Exists(object id)
        {
            return false;
        }

        public virtual ICollection<T> FindAll(string orderField)
        {
            return this._repository.FindAll(orderField);
        }

        public virtual T Get(object id)
        {
            return this.Repository.Get(id);
        }

        public virtual T Save(T entity)
        {
            var result = this._repository.Save(entity);
            var arg = new EntityEventArgs<T>();
            arg.Entity = result;
            OnSaved(arg);
            return result;
        }

        public  virtual T SaveOrUpdate(T entity)
        {
            return this._repository.SaveOrUpdate(entity);
        }

        public  virtual ICollection<T> FindByProperty(string propertyName, object value)
        {
            return this._repository.FindByProperty(propertyName, value);
        }

        public void Dispose()
        {
            this._repository = null;
        }
    }
}
