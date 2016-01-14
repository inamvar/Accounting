using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using DataLayer.UnitOfWorks;

namespace DataLayer.Repository
{
    public class Repository<T> : IRepository<T>
    {
        protected virtual ISession Session
        {
            get { return UnitOfWork.CurrentSession; }
        }

        protected virtual ISessionFactory SessionFactory
        {
            get { return UnitOfWork.CurrentSession.GetSessionImplementation().Factory; }
        }

        public T Get(object id)
        {
            return (T)Session.Get(typeof(T), id);
        }

        public T Load(object id)
        {
            return (T)Session.Load(typeof(T), id);
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public void DeleteAll()
        {
            Session.Delete(string.Format("from {0}", typeof(T).Name));
        }

        public void DeleteAll(DetachedCriteria where)
        {
            foreach (object entity in where.GetExecutableCriteria(Session).List())
            {
                Session.Delete(entity);
            }
        }

        public T Save(T entity)
        {
            Session.Save(entity);
            return entity;
        }

        public T SaveOrUpdate(T entity)
        {
            Session.SaveOrUpdate(entity);
            return entity;
        }

        public T SaveOrUpdateCopy(T entity)
        {
            //Implementation changed.
             Session.SaveOrUpdate(entity);
            return entity;
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public long Count(DetachedCriteria criteria)
        {
            ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, null);
            crit.SetProjection(Projections.RowCount());
            object countMayBe_Int32_Or_Int64_DependingOnDatabase = crit.UniqueResult();
            return Convert.ToInt64(countMayBe_Int32_Or_Int64_DependingOnDatabase);
        }

        public long Count()
        {
            return Count(null);
        }

        public bool Exists(DetachedCriteria criteria)
        {
            return 0 != Count(criteria);
        }

        public bool Exists()
        {
            return Exists(null);
        }

        public ICollection<T> FindAll(DetachedCriteria criteria, params Order[] orders)
        {
            ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, orders);
            return crit.List<T>();
        }

        public ICollection<T> FindAll(Order order, params ICriterion[] criteria)
        {
            return FindAll(new[] { order }, criteria);
        }

        public ICollection<T> FindAll(Order[] orders, params ICriterion[] criteria)
        {
            ICriteria crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria, orders);
            return crit.List<T>();
        }

        public T FindFirst(params Order[] orders)
        {
            return FindFirst(null, orders);
        }

        public T FindFirst(DetachedCriteria criteria, params Order[] orders)
        {
            ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, orders);
            crit.SetFirstResult(0);
            crit.SetMaxResults(1);
            return crit.UniqueResult<T>();
        }

        public T FindOne(params ICriterion[] criteria)
        {
            ICriteria crit = RepositoryHelper<T>.CreateCriteriaFromArray(Session, criteria, null);
            return crit.UniqueResult<T>();
        }

        public T FindOne(DetachedCriteria criteria)
        {
            ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, null);
            return crit.UniqueResult<T>();
        }

        public ProjT ReportOne<ProjT>(ProjectionList projectionList)
        {
            ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, null, null);
            return DoReportOne<ProjT>(crit, projectionList);
        }

        public ProjT ReportOne<ProjT>(DetachedCriteria criteria, ProjectionList projectionList)
        {
            ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, null);
            return DoReportOne<ProjT>(crit, projectionList);
        }

        public ICollection<ProjT> ReportAll<ProjT>(ProjectionList projectionList)
        {
            return ReportAll<ProjT>(false, projectionList);
        }

        public ICollection<ProjT> ReportAll<ProjT>(bool distinctResults, ProjectionList projectionList)
        {
            ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, null, null);
            return DoReportAll<ProjT>(crit, projectionList, distinctResults);
        }

        public ICollection<ProjT> ReportAll<ProjT>(ProjectionList projectionList, params Order[] orders)
        {
            return ReportAll<ProjT>(false, projectionList, orders);
        }

        public ICollection<ProjT> ReportAll<ProjT>(bool distinctResults, ProjectionList projectionList, params Order[] orders)
        {
            ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, null, orders);
            return DoReportAll<ProjT>(crit, projectionList, distinctResults);
        }

        public ICollection<ProjT> ReportAll<ProjT>(DetachedCriteria criteria, ProjectionList projectionList, params Order[] orders)
        {
            return ReportAll<ProjT>(false, criteria, projectionList, orders);
        }

        public ICollection<ProjT> ReportAll<ProjT>(bool distinctResults, DetachedCriteria criteria, ProjectionList projectionList, params Order[] orders)
        {
            ICriteria crit = RepositoryHelper<T>.GetExecutableCriteria(Session, criteria, orders);
            return DoReportAll<ProjT>(crit, projectionList, distinctResults);
        }

        private static ProjT DoReportOne<ProjT>(ICriteria criteria, ProjectionList projectionList)
        {
            BuildProjectionCriteria<ProjT>(criteria, projectionList, false);
            return criteria.UniqueResult<ProjT>();
        }

        private static ICollection<ProjT> DoReportAll<ProjT>(ICriteria criteria, ProjectionList projectionList, bool distinctResults)
        {
            BuildProjectionCriteria<ProjT>(criteria, projectionList, distinctResults);
            return criteria.List<ProjT>();
        }

        private static void BuildProjectionCriteria<ProjT>(ICriteria criteria, IProjection projectionList, bool distinctResults)
        {
            if (distinctResults)
                criteria.SetProjection(Projections.Distinct(projectionList));
            else
                criteria.SetProjection(projectionList);

            // if we are not returning a tuple, then we need the result transformer
            if (typeof(ProjT) != typeof(object[]))
                criteria.SetResultTransformer(new TypedResultTransformer<ProjT>());
        }

        public ICollection<T> FindAll(string orderField )
        {
            return this.FindAll(null, Order.Asc(orderField));
        }

        public ICollection<T> FindByProperty(string propertyName, object value)
        {
            return this.FindAll(DetachedCriteria.For<T>().Add(Expression.Eq(propertyName, value)));
        }

        /// <summary>This is used to convert the resulting tuples into strongly typed objects.</summary>
        private class TypedResultTransformer<T1> : IResultTransformer
        {
            public object TransformTuple(object[] tuple, string[] aliases)
            {
                if (tuple.Length == 1)
                    return tuple[0];
                else
                    return Activator.CreateInstance(typeof(T1), tuple);
            }

            IList IResultTransformer.TransformList(IList collection)
            {
                return collection;
            }
        }
    }
}
