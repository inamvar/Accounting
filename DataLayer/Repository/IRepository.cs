using System.Collections.Generic;
using NHibernate.Criterion;

namespace DataLayer.Repository
{
    public interface IRepository<T>
    {
        T Get(object id);
        T Load(object id);
        void Delete(T entity);
        void DeleteAll();
        void DeleteAll(DetachedCriteria where);
        T Save(T entity);
        T SaveOrUpdate(T entity);
        T SaveOrUpdateCopy(T entity);
        void Update(T entity);
        long Count(DetachedCriteria criteria);
        long Count();
        bool Exists(DetachedCriteria criteria);
        bool Exists();
        ICollection<T> FindByProperty(string propertyName, object value);
        ICollection<T> FindAll(string orderField);
        ICollection<T> FindAll(DetachedCriteria criteria, params Order[] orders);
        ICollection<T> FindAll(Order order, params ICriterion[] criteria);
        ICollection<T> FindAll(Order[] orders, params ICriterion[] criteria);
        T FindFirst(params Order[] orders);
        T FindFirst(DetachedCriteria criteria, params Order[] orders);
        T FindOne(params ICriterion[] criteria);
        T FindOne(DetachedCriteria criteria);

        ProjT ReportOne<ProjT>(ProjectionList projectionList);
        ProjT ReportOne<ProjT>(DetachedCriteria criteria, ProjectionList projectionList);
        ICollection<ProjT> ReportAll<ProjT>(ProjectionList projectionList);
        ICollection<ProjT> ReportAll<ProjT>(bool distinctResults, ProjectionList projectionList);
        ICollection<ProjT> ReportAll<ProjT>(ProjectionList projectionList, params Order[] orders);
        ICollection<ProjT> ReportAll<ProjT>(bool distinctResults, ProjectionList projectionList, params Order[] orders);
        ICollection<ProjT> ReportAll<ProjT>(DetachedCriteria criteria, ProjectionList projectionList, params Order[] orders);
        ICollection<ProjT> ReportAll<ProjT>(bool distinctResults, DetachedCriteria criteria, ProjectionList projectionList, params Order[] orders);
    }
}
