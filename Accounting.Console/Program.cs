using DataLayer.Repository;
using DataLayer.UnitOfWorks;

using Models.Domain;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Services;
using System.IO;

namespace Accounting.Console
{
    class Program
    {
        private static string DbFile = "core.db";
      
        static void Main(string[] args)
        {


            using (UnitOfWork.Start())
            {
                //  BuildSchema(UnitOfWork.Configuration);



                var _AccountRepository = new Repository<Account>();
                EntityService<Account> service = new EntityService<Account>(_AccountRepository);
                service.Saved += Service_Saved;

                var tableAcc = new Account
                {
                    AccountCode = 2,
                    IsActive = true,
                    AccountName = "Sales",
                    TrialBalance = 0,
                    Description = "Sales account",
                    //  Parent = parent
                };


             //   service.Save(tableAcc);
               
                var accounts = service.FindAll("Id");
                foreach (var account in accounts)
                {
                    if (account.Parent == null)
                        System.Console.WriteLine(account.ToString());
                }
                System.Console.ReadKey();
            }
        }

        private static void Service_Saved(object sender, EntityEventArgs<Account> e)
        {
            System.Console.WriteLine("{0}- {1} Saved successfully.", e.Entity.AccountCode, e.Entity.AccountName);
        }

        private static void BuildSchema(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
                File.Delete(DbFile);

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
              .Create(true, true);
        }
    }
}
