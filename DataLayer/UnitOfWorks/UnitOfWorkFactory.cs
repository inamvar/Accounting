using System;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace DataLayer.UnitOfWorks
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private const string Default_HibernateConfig = "hibernate.cfg.xml";

        private static ISession _currentSession;
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        internal UnitOfWorkFactory()
        { }

        public IUnitOfWork Create()
        {
            ISession session = CreateSession();
            session.FlushMode = FlushMode.Commit;
            _currentSession = session;
            return new UnitOfWorkImplementor(this, session);
        }

        public Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {

                    _configuration = Fluently.Configure()
                            .Database(
                                SQLiteConfiguration.Standard
                                              .UsingFile("core.db")
                                              
                                             // .ShowSql()
                                              
                        )
                                      
                                     
                            .Mappings(m =>
                                      m.FluentMappings.AddFromAssemblyOf<Models.Domain.Account>()
                                                     
                                      )
                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                            .BuildConfiguration();
                    //_configuration = new Configuration();
                    //string hibernateConfig = Default_HibernateConfig;
                    ////if not rooted, assume path from base directory
                    //if (Path.IsPathRooted(hibernateConfig) == false)
                    //    hibernateConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, hibernateConfig);
                    //if (File.Exists(hibernateConfig))
                    //    _configuration.Configure(new XmlTextReader(hibernateConfig));
                }
                return _configuration;
            }
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    _sessionFactory = Configuration.BuildSessionFactory();
                return _sessionFactory;
            }
        }

        public ISession CurrentSession
        {
            get
            {
                if (_currentSession == null)
                    throw new InvalidOperationException("You are not in a unit of work.");
                return _currentSession;
            }
            set { _currentSession = value; }
        }

        public void DisposeUnitOfWork(UnitOfWorkImplementor adapter)
        {
            CurrentSession = null;
            UnitOfWork.DisposeUnitOfWork(adapter);
        }

        private ISession CreateSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
