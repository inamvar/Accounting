using DataLayer.Repository;
using DataLayer.UnitOfWorks;

using Models.Domain;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Tool.hbm2ddl;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Accounting.Console
{
    class Program
    {
        private static string DbFile = "core.db";
        private static IRepository<Bank> _repository;
        static void Main(string[] args)
        {


            using (UnitOfWork.Start())
            {
                //  BuildSchema(UnitOfWork.Configuration);
                //_repository = new Repository<Bank>();
                //var bank = new Bank
                //{
                //    PartyCode = "1234",
                //    Branch = "Tonekabon",
                //    Description="Central bank of Saman in Tonekabon city",
                //    PartyName ="Bank Saman",
                //    BranchCode="9441"


                //};



                //  _repository.SaveOrUpdate(bank);
                //var banks = _repository.FindAll(Order.Asc("PartyName"));
                //foreach (var b in banks)
                //{
                //    System.Console.WriteLine("{0} {1} {2}\n", b.PartyName, b.Branch , b.BranchCode);
                //}


                var _AccountRepository = new Repository<Account>();
                EntityService<Account> service = new EntityService<Account>(_AccountRepository);
                service.Saved += Service_Saved;
                //var parent = new Account()
                //{
                //    AccountCode = 1,
                //    AccountName ="Assets",
                //    Description = "",
                //    IsActive = true,
                //    TrialBalance = 0
                //};

                //var ch = new Account()
                //{
                //    AccountCode = 11,
                //    IsActive = true,
                //    AccountName = "Computers",
                //    TrialBalance = 0,
                //    Description = "Availabel laptops and Pc's"


                //};

                //  var parent = _AccountRepository.Get(11);



                var tableAcc = new Account
                {
                    AccountCode = 2,
                    IsActive = true,
                    AccountName = "Sales",
                    TrialBalance = 0,
                    Description = "Sales account",
                    //  Parent = parent
                };


                service.Save(tableAcc);
                //  ch.Parent = parent;
                //  parent.Childeren.Add(ch);
                //   _AccountRepository.Save(ch);

                //var accounts = _AccountRepository.FindAll(
                //    DetachedCriteria.For<Account>()
                //    .Add(Expression.IsNull("Parent")),
                //     Order.Asc("AccountCode"));
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
