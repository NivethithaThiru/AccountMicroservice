using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountMicroservice.DBHelper;
using AccountMicroservice.Models;

namespace AccountMicroservice.Repository
{
    public class AccountRepository : IAccountRepository
    {
        List<Account> account = AccountDBHelper.getList();
        List<AccountCreationStatus> accountCreationStatuses = AccountDBHelper.getStatusList();
        //POST:
        public List<AccountCreationStatus> CreateAccount(int customerId)
        {

            int maxId = account.Max(i => i.AccountId);

            account.Add(
                new Account { AccountId = maxId + 1, CustomerId = customerId, AccountCreationDate = DateTime.Now, AccountType = "Savings", CurrentBalance = 5000 }
            );
            string accType = account.Last().AccountType;
            accountCreationStatuses.Add(new AccountCreationStatus { AccountId = maxId + 1, Message = $"{accType} Account created successfully.." });


            account.Add(
                new Account { AccountId = maxId + 2, CustomerId = customerId, AccountCreationDate = DateTime.Now, AccountType = "Current", CurrentBalance = 3000 }
            );
            string accType1 = account.Last().AccountType;
            accountCreationStatuses.Add(new AccountCreationStatus { AccountId = maxId + 2, Message = $"{accType1} Account created successfully.." });

            return accountCreationStatuses;
        }
        public Account GetAccountDetails(int accountId)
        {
            foreach (var a in account)
            {
                if (a.AccountId == accountId)
                {
                    return a;
                }
            }
            return null;
        }

        public List<Account> GetAllAccountDetails()
        {
            return account;
        }

        public List<CustomerAccountDetails> GetCustomerAccountsDetails(int customerId)
        {
            List<CustomerAccountDetails> customerAccount = new List<CustomerAccountDetails>();
            foreach (var acc in account)
            {
                if (acc.CustomerId == customerId)
                {
                    customerAccount.Add(new CustomerAccountDetails { AccountId = acc.AccountId, CurrentBalance = acc.CurrentBalance });
                }
            }
            return customerAccount;
        }

        public List<Statement> GetAccountStatement(int accountId, DateTime from_date, DateTime to_date)
        {
            double currentBalance = 0;
            double updatedBalance = 0;
            List<Statement> transaction_Statement = new List<Statement>();

            foreach (var stmt in AccountDBHelper.statements)
            {
                if (stmt.TransactionDate >= from_date && stmt.TransactionDate <= to_date && stmt.AccountId == accountId)
                {
                    currentBalance = 0;
                    foreach (var acc in account)
                    {
                        if (acc.AccountId == accountId)
                        {
                            currentBalance = acc.CurrentBalance;
                            updatedBalance = (currentBalance + stmt.Credit) - stmt.Debit;
                            acc.CurrentBalance = updatedBalance;
                            stmt.BalanceAmount = updatedBalance;
                        }
                        transaction_Statement.Add(stmt);
                    }
                }
            }
            return transaction_Statement;
        }

        public List<Statement> GetAccountStatementByAccountId(int accountId)
        {
            double currentBalance = 0;
            double updatedBalance = 0;
            List<Statement> transaction_Statement = new List<Statement>();

            foreach (var stmt in AccountDBHelper.statements)
            {
                if (stmt.TransactionDate >= (DateTime.Today.AddDays(-30)) && stmt.TransactionDate <= (DateTime.Today) && stmt.AccountId == accountId)
                {
                    foreach (var acc in account)
                    {
                        if (acc.AccountId == accountId)
                        {
                            currentBalance = acc.CurrentBalance;
                            updatedBalance = (currentBalance + stmt.Credit) - stmt.Debit;
                            acc.CurrentBalance = updatedBalance;
                            stmt.BalanceAmount = updatedBalance;
                        }
                    }
                    transaction_Statement.Add(stmt);
                }
            }
            return transaction_Statement;
        }

        public TransactionStatus Deposit(int accountId, double amount)
        {
            TransactionStatus t_status = new TransactionStatus();
            foreach (var acc in account)
            {
                if (acc.AccountId == accountId)
                {
                    acc.CurrentBalance = acc.CurrentBalance + amount;
                    t_status.Updated_Balance = acc.CurrentBalance;
                    t_status.Message = "Completed";
                    return t_status;
                }
            }
            return null;
        }

        public TransactionStatus Withdraw(int accountId, double amount)
        {
            List<Statement> stmts = new List<Statement>();
            TransactionStatus t_status1 = new TransactionStatus();
            foreach (var acc in account)
            {
                if (acc.AccountId == accountId)
                {
                    acc.CurrentBalance = acc.CurrentBalance - amount;
                    t_status1.Updated_Balance = acc.CurrentBalance;
                    t_status1.Message = "Completed";
                    return t_status1;
                }
            }
            return null;
        }


        /*public string generateTransactionId()
        {
            string id = "TSC" + (new Random().Next(9999));
            return id;
        }*/

    }
}
