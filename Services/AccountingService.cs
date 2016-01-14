using DataLayer.Repository;
using Models.Domain;
using DataLayer.UnitOfWorks;
using System;

namespace Services
{
    public class AccountingService
    {
        private EntityService<Account> accountService;

        public Account AddAccount(Account account, bool isRoot=false)
        {
            using (UnitOfWork.Start())
            {
                using (accountService = new EntityService<Account>(new Repository<Account>()))
                {
                    if (isRoot)
                    {
                        account.Parent = null;
                    }
                    var olds = accountService.FindByProperty("AccountName", account.AccountName.Trim());
                    if (olds != null && olds.Count > 0)
                    {
                        throw new Exception("Account {0}- {1} already exists.");
                    }
                    else {
                        return accountService.Save(account);
                    }

                }
            }

        }
    }
}
