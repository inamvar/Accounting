using NHibernate;
using NHibernate.Criterion;

namespace DataLayer.Repository
{
    public class RepositoryHelper<T>
    {
        public static ICriteria GetExecutableCriteria(ISession session, DetachedCriteria criteria, Order[] orders)
        {
            ICriteria executableCriteria;
            if (criteria != null)
                executableCriteria = criteria.GetExecutableCriteria(session);
            else
                executableCriteria = session.CreateCriteria(typeof(T));

            if (orders != null)
            {
                foreach (Order order in orders)
                    executableCriteria.AddOrder(order);
            }
            return executableCriteria;
        }

        public static ICriteria CreateCriteriaFromArray(ISession session, ICriterion[] criteria, Order[] orders)
        {
            ICriteria crit = session.CreateCriteria(typeof(T));
            foreach (ICriterion criterion in criteria)
            {
                //allow some fancy antics like returning possible return 
                // or null to ignore the criteria
                if (criterion == null)
                    continue;
                crit.Add(criterion);
            }
            if (orders != null)
            {
                foreach (Order order in orders)
                    crit.AddOrder(order);
            }
            return crit;
        }
    }
}
