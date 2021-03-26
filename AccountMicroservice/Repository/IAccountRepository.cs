using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountMicroservice.Models;

namespace AccountMicroservice.Repository
{
    public interface IAccountRepository
    {
        List<Account> GetAllAccountDetails();
        List<AccountCreationStatus> CreateAccount(int customerId);
        Account GetAccountDetails(int accountId);
        List<CustomerAccountDetails> GetCustomerAccountsDetails(int CustomerId);
        List<Statement> GetAccountStatement(int AccountId, DateTime from_date, DateTime to_date);
        List<Statement> GetAccountStatementByAccountId(int AccountId);
        TransactionStatus Deposit(int AccountId, double amount);
        TransactionStatus Withdraw(int AccountId, double amount);
    }
}
